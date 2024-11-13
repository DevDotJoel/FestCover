import { useQuery, queryOptions } from "@tanstack/react-query";
import { AlbumContentModel, AlbumContentPendingModel } from "../types";
import { api } from "../../../libs/api-client";
import { QueryConfig } from "../../../libs/react-query";

export const getAlbumPendingContents = (): Promise<
  AlbumContentPendingModel[]
> => {
  return api.get(`/api/AlbumContents/Pending`);
};

export const getAlbumPendingContentsQueryOptions = () => {
  return queryOptions({
    queryKey: ["album-pending-contents"],
    queryFn: () => getAlbumPendingContents(),
  });
};

type UseAlbumPendingContentsOptions = {
  queryConfig?: QueryConfig<typeof getAlbumPendingContentsQueryOptions>;
};

export const useAlbumPendingContents = ({
  queryConfig,
}: UseAlbumPendingContentsOptions) => {
  return useQuery({
    ...getAlbumPendingContentsQueryOptions(),
    ...queryConfig,
  });
};
