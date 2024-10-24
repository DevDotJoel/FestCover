import { useQuery, queryOptions } from "@tanstack/react-query";
import { AlbumModel } from "../types";
import { api } from "../../../libs/api-client";
import { QueryConfig } from "../../../libs/react-query";

export const getAlbum = ({
  albumId,
}: {
  albumId: string;
}): Promise<AlbumModel> => {
  return api.get(`/api/albums/${albumId}`);
};

export const getAlbumQueryOptions = (albumId: string) => {
  return queryOptions({
    queryKey: ["album", albumId],
    queryFn: () => getAlbum({ albumId }),
  });
};

type UseAlbumOptions = {
  albumId: string;
  queryConfig?: QueryConfig<typeof getAlbumQueryOptions>;
};

export const useAlbum = ({ albumId, queryConfig }: UseAlbumOptions) => {
  return useQuery({
    ...getAlbumQueryOptions(albumId),
    ...queryConfig,
  });
};
