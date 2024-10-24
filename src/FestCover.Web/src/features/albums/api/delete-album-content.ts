
import { useMutation } from '@tanstack/react-query';

import {  MutationConfig, queryClient } from '../../../libs/react-query';
import {  AlbumContentModel } from '../types';
import { toast } from 'react-toastify';
import { api } from '../../../libs/api-client';



export const deleteAlbumContent = ( { albumContentId }: { albumContentId: string, albumId: string }): Promise<void> => {
   return toast.promise(api.delete(`/api/AlbumContents/${albumContentId}`), {
        pending: "Deleting album content",
        success: "Album content deleted with success",      
      }); 
};


type UseDeleteAlbumContentOptions = {
    config?: MutationConfig<typeof deleteAlbumContent>;
  };
  
  export const useDeleteAlbumContent = ({ config }: UseDeleteAlbumContentOptions= {}) => {

    return useMutation({
      onMutate: async (deletedAlbum:any) => {
        await queryClient.cancelQueries({queryKey:["album-contents"]}, deletedAlbum.albumId);
  
        const previousAlbumContents = queryClient.getQueryData<AlbumContentModel[]>([
            'album-contents',
            deletedAlbum?.albumId,
          ]);
  
        queryClient.setQueryData(
          ['album-contents',deletedAlbum.albumId],
          previousAlbumContents?.filter((albumContent) => albumContent.id !== deletedAlbum.albumContentId)
        );

        return  { previousAlbumContents:previousAlbumContents,albumId:deletedAlbum.albumId };
      },
      onError: (_, __, context: any) => {
        if (context?.previousAlbumContents) {
          queryClient.setQueryData(['album-contents',context.albumId, ], context.previousAlbumContents);
        }
      },
      onSuccess: (_, __, context: any) => {
        console.log(context)
        queryClient.invalidateQueries({queryKey:["album-contents",context.albumId]});
      },
      ...config,
      mutationFn: deleteAlbumContent,
    });
  };
  
