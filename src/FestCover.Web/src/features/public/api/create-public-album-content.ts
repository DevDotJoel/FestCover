import { useMutation } from "@tanstack/react-query";
import { MutationConfig, queryClient } from "../../../libs/react-query";

import { toast } from "react-toastify";
import {
  AlbumDetailModel,
  CreateAlbumContentPublicModel,
} from "../../albums/types";
import { api } from "../../../libs/api-client";

export const createPublicAlbumContent = (
  createPublicAlbumContent: CreateAlbumContentPublicModel
): Promise<void> => {
  const formData = new FormData();
  formData.append("phoneNumber", createPublicAlbumContent.phoneNumber);
  formData.append("name", createPublicAlbumContent.name);
  formData.append("AlbumId", createPublicAlbumContent.albumId);
  for (let i = 0; i < createPublicAlbumContent.albumContentImages.length; i++) {
    formData.append(
      "AlbumContentImages",
      createPublicAlbumContent.albumContentImages[i]
    );
  }

  return toast.promise(api.post(`/api/AlbumContents/Public/Upload`, formData), {
    pending: "Adding Album Content ",
    success: "Album Content uploaded with success",
  });
};

type UseCreatePublicAlbumContentOptions = {
  config?: MutationConfig<typeof createPublicAlbumContent>;
};

export const useCreatePublicAlbumContent = ({
  config,
}: UseCreatePublicAlbumContentOptions = {}) => {
  return useMutation({
    onMutate: async (albumPublicContent: any) => {
      await queryClient.cancelQueries({
        queryKey: ["public-album", albumPublicContent.albumId],
      });

      const previousAlbumContents = queryClient.getQueryData<
        AlbumDetailModel[]
      >(["public-album", albumPublicContent.albumId]);
      return {
        previousAlbumContents: previousAlbumContents,
        albumId: albumPublicContent.albumId,
      };
    },
    onSuccess: (_, __, context: any) => {
      queryClient.refetchQueries({
        queryKey: ["public-album", context.albumId],
      });
    },
    ...config,
    mutationFn: createPublicAlbumContent,
  });
};
