import { useQuery, queryOptions } from "@tanstack/react-query";
import { AlbumDetailModel } from "../../albums/types";
import { api } from "../../../libs/api-client";
import { QueryConfig } from "../../../libs/react-query";

export const getPublicAlbum = ({
  key,
}: {
    key: string;
}): Promise<AlbumDetailModel> => {
  return api.get(`/api/albums/public/${key}`);
};

export const getPublicAlbumQueryOptions = (key: string) => {
  return queryOptions({
    queryKey: ["public-album", key],
    queryFn: () => getPublicAlbum({ key }),
  });
};

type UsePublicAlbumOptions = {
  key: string;
  queryConfig?: QueryConfig<typeof getPublicAlbumQueryOptions>;
};

export const usePublicAlbum = ({ key, queryConfig }: UsePublicAlbumOptions) => {
  return useQuery({
    ...getPublicAlbumQueryOptions(key),
    ...queryConfig,
  });
};
