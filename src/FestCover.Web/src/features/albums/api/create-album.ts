import { useMutation } from "@tanstack/react-query";
import { MutationConfig, queryClient } from "../../../libs/react-query";

import { toast } from "react-toastify";
import { CreateAlbumModel, AlbumModel } from "../types";
import { api } from "../../../libs/api-client";

export const createAlbum = (
  createAlbum: CreateAlbumModel
): Promise<AlbumModel> => {
  const formData = new FormData();

  formData.append("name", createAlbum.name);
  formData.append("description", createAlbum.description);
  formData.append("albumImage", createAlbum.albumImage);
  formData.append("albumBackgroundImage", createAlbum.albumBackgroundImage);
  formData.append(
    "isPublic",
    createAlbum.isPublic ? "1" : "0"
  );
  formData.append(
    "allowPublicUpload",
    createAlbum.allowPublicUpload ? "1" : "0"
  );
  formData.append(
    "reviewUploadedContent",
    createAlbum.reviewUploadedContent ? "1" : "0"
  );
  return toast.promise(api.post(`/api/albums`, formData), {
    pending: "Creating Album ",
    success: "Album created with success",
  });
};

type UseCreateAlbumOptions = {
  config?: MutationConfig<typeof createAlbum>;
};

export const useCreateAlbum = ({ config }: UseCreateAlbumOptions = {}) => {
  return useMutation({
    onMutate: async (person: any) => {
      await queryClient.cancelQueries({ queryKey: ["albums"] });

      const previousAlbums = queryClient.getQueryData<AlbumModel[]>(["albums"]);

      const currentAlbum = person as AlbumModel;
      queryClient.setQueryData(
        ["albums"],
        [...(previousAlbums || []), currentAlbum]
      );

      return { previousAlbums };
    },
    onError: (_, __, context: any) => {
      if (context?.previousAlbums) {
        queryClient.setQueryData(["albums"], context.previousAlbums);
      }
    },
    onSuccess: (data) => {
      queryClient.refetchQueries({ queryKey: ["albums"] });
      return data;
    },
    ...config,
    mutationFn: createAlbum,
  });
};
