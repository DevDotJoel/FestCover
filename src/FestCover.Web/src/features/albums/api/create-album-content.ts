import { useMutation } from "@tanstack/react-query";
import { MutationConfig, queryClient } from "../../../libs/react-query";

import { toast } from "react-toastify";
import { CreateAlbumContentModel, AlbumContentModel } from "../types";
import { api } from "../../../libs/api-client";

export const createAlbumContent = (
  createAlbumContent: CreateAlbumContentModel
): Promise<AlbumContentModel> => {
  const formData = new FormData();

  formData.append("AlbumId", createAlbumContent.albumId);
  formData.append("AlbumContentImage", createAlbumContent.albumContentImage);

  return toast.promise(api.post(`/api/AlbumContents`, formData), {
    pending: "Creating Album Content ",
    success: "Album Content created with success",
  });
};

type UseCreateAlbumContentOptions = {
  config?: MutationConfig<typeof createAlbumContent>;
};

export const useCreateAlbumContent = ({
  config,
}: UseCreateAlbumContentOptions = {}) => {
  return useMutation({
    onMutate: async (albumContent: any) => {
      await queryClient.cancelQueries({ queryKey: ["album-contents"] });

      const previousAlbumContents = queryClient.getQueryData<
        AlbumContentModel[]
      >(["album-contents"]);

      const currentAlbumContent = albumContent as AlbumContentModel;
      queryClient.setQueryData(
        ["album-contents"],
        [...(previousAlbumContents || []), currentAlbumContent]
      );

      return { previousAlbumContents };
    },
    onError: (_, __, context: any) => {
      if (context?.previousAlbumContents) {
        queryClient.setQueryData(
          ["album-contents"],
          context.previousAlbumContents
        );
      }
    },
    onSuccess: (data) => {
      queryClient.refetchQueries({ queryKey: ["album-contents"] });
      return data;
    },
    ...config,
    mutationFn: createAlbumContent,
  });
};
