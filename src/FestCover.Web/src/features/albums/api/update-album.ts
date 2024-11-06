import { useMutation } from "@tanstack/react-query";
import { MutationConfig, queryClient } from "../../../libs/react-query";

import { toast } from "react-toastify";
import { UpdateAlbumModel, AlbumModel } from "../types";
import { api } from "../../../libs/api-client";

export const updateAlbum = (
  updateAlbum: UpdateAlbumModel
): Promise<AlbumModel> => {
  const formData = new FormData();
  formData.append("albumId", updateAlbum.albumId);
  formData.append("name", updateAlbum.name);
  formData.append("description", updateAlbum.description);
  formData.append("isPublic", updateAlbum.isPublic ? "1" : "0");
  formData.append(
    "allowPublicUpload",
    updateAlbum.allowPublicUpload ? "1" : "0"
  );
  formData.append(
    "reviewUploadedContent",
    updateAlbum.reviewUploadedContent ? "1" : "0"
  );
  formData.append("albumImage", updateAlbum.albumImage);

  return toast.promise(api.put(`/api/albums`, formData), {
    pending: "Updating Album ",
    success: "Album updated with success",
  });
};

type UseUpdateAlbumOptions = {
  config?: MutationConfig<typeof updateAlbum>;
};

export const useUpdateAlbum = ({ config }: UseUpdateAlbumOptions = {}) => {
  return useMutation({
    onMutate: async (album: any) => {
      await queryClient.cancelQueries({ queryKey: ["albums"] });

      const previousAlbums = queryClient.getQueryData<AlbumModel[]>(["albums"]);

      const currentAlbum = album as AlbumModel;
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
    mutationFn: updateAlbum,
  });
};
