
import { useMutation } from '@tanstack/react-query';

import {  MutationConfig, queryClient } from '../../../libs/react-query';
import {  AlbumModel } from '../types';
import { toast } from 'react-toastify';
import { api } from '../../../libs/api-client';



export const deleteAlbum = ({ albumId }: { albumId: string }): Promise<void> => {
   return toast.promise(api.delete(`/api/albums/${albumId}`), {
        pending: "Deleting Album",
        success: "Album deleted with success",      
      }); 
};


type UseDeleteAlbumOptions = {
    config?: MutationConfig<typeof deleteAlbum>;
  };
  
  export const useDeleteAlbum = ({ config }: UseDeleteAlbumOptions= {}) => {

    return useMutation({
      onMutate: async (deletedPerson) => {
        await queryClient.cancelQueries({queryKey:["albums"]});
  
        const previousAlbums = queryClient.getQueryData<AlbumModel[]>(['albums']);
  
        queryClient.setQueryData(
          ['albums',],
          previousAlbums?.filter((album) => album.id !== deletedPerson.albumId)
        );
  
        return { previousAlbums };
      },
      onError: (_, __, context: any) => {
        if (context?.previousAlbums) {
          queryClient.setQueryData(['albums' ], context.previousAlbums);
        }
      },
      onSuccess: () => {
        queryClient.invalidateQueries({ queryKey: ["albums"] });
      },
      ...config,
      mutationFn: deleteAlbum,
    });
  };
  
