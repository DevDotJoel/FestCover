import { queryOptions, useQuery } from '@tanstack/react-query';

import { api } from '../../../libs/api-client';
import { QueryConfig } from '../../../libs/react-query';
import { AlbumModel } from '../types';


export const getAlbums = (): Promise<AlbumModel[]> => {
  return api.get(`/api/albums`);
};

export const getAlbumsQueryOptions = () => {
  return queryOptions({
    queryKey: ['albums'],
    queryFn: () => getAlbums(),
  });
};

type UseAlbumsOptions = {
  queryConfig?: QueryConfig<typeof getAlbums>;
};

export const useAlbums = ({
  queryConfig,
}: UseAlbumsOptions) => {
  return useQuery({
    ...getAlbumsQueryOptions(),
    ...queryConfig,
  });
};