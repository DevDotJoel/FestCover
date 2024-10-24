import { useQuery, queryOptions } from "@tanstack/react-query";
import { AlbumContentModel } from "../types";
import { api } from "../../../libs/api-client";
import { QueryConfig } from "../../../libs/react-query";

export const getAlbumContents = ({
  albumId,
}: {
  albumId: string;
}): Promise<AlbumContentModel[]> => {
  return api.get(`/api/AlbumContents/${albumId}`);
};

export const getAlbumContentsQueryOptions = (albumId: string) => {
  return queryOptions({
    queryKey: ["album-contents", albumId],
    queryFn: () => getAlbumContents({ albumId }),
  });
};

type UseAlbumContentsOptions = {
  albumId: string;
  queryConfig?: QueryConfig<typeof getAlbumContentsQueryOptions>;
};

export const useAlbumContents = ({
  albumId,
  queryConfig,
}: UseAlbumContentsOptions) => {
  return useQuery({
    ...getAlbumContentsQueryOptions(albumId),
    ...queryConfig,
  });
};
