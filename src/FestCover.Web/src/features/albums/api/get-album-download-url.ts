import { useQuery, queryOptions } from "@tanstack/react-query";
import { api } from "../../../libs/api-client";
import { QueryConfig } from "../../../libs/react-query";

export const getAlbumContentDownloadUrl = ({
  albumId,
}: {
  albumId: string;
}): Promise<string> => {
  return api.get(`/api/AlbumContents/Download/${albumId}`);
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
