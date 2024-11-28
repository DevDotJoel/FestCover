import { useQuery, queryOptions } from "@tanstack/react-query";
import { api } from "../../../libs/api-client";
import { QueryConfig } from "../../../libs/react-query";
import { toast } from "react-toastify";

export const getAlbumContentDownloadUrl = ({
  albumId,
}: {
  albumId: string;
}): Promise<Blob> => {
  return toast.promise( api.get(`/api/AlbumContents/Download/${albumId}`,{
    responseType:"blob"
  }), {
    pending: "Downloading Album ",
    success: "Album downloaded with success",
  });
};

export const getAlbumContentDownloadUrlOptions = (albumId: string) => {
  return queryOptions({
    queryKey: ["album-download-url", albumId],
    queryFn: () => getAlbumContentDownloadUrl({ albumId }),
  });
};

type UseAlbumContentDownloadUrlOptions = {
  albumId: string;
  queryConfig?: QueryConfig<typeof getAlbumContentDownloadUrlOptions>;
};

export const useAlbumContentDownloadUrl = ({
  albumId,
  queryConfig,
}: UseAlbumContentDownloadUrlOptions) => {
  return useQuery({
    ...getAlbumContentDownloadUrlOptions(albumId),
    ...queryConfig,
  });
};
