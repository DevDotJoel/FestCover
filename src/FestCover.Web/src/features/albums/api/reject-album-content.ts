import { useMutation } from "@tanstack/react-query";

import { MutationConfig, queryClient } from "../../../libs/react-query";
import { AlbumContentPendingModel, RejectAlbumContentModel } from "../types";
import { toast } from "react-toastify";
import { api } from "../../../libs/api-client";

export const rejectAlbumContent = ({
  rejectAlbumContent,
}: {
  rejectAlbumContent: RejectAlbumContentModel;
}): Promise<void> => {
  return toast.promise(
    api.post(`/api/AlbumContents/Reject`, rejectAlbumContent),
    {
      pending: "Rejecting Album Content",
      success: "Album content rejected with success",
    }
  );
};

type UseRejectAlbumContentOptions = {
  config?: MutationConfig<typeof rejectAlbumContent>;
};

export const useRejectAlbumContent = ({
  config,
}: UseRejectAlbumContentOptions = {}) => {
  return useMutation({
    onMutate: async (data) => {
      await queryClient.cancelQueries({ queryKey: ["album-pending-contents"] });

      const previousAlbums = queryClient.getQueryData<
        AlbumContentPendingModel[]
      >(["album-pending-contents"]);

      queryClient.setQueryData(
        ["album-pending-contents"],
        previousAlbums?.filter(
          (albumContent) =>
            albumContent.id !== data.rejectAlbumContent.albumContentId
        )
      );

      return { previousAlbums };
    },
    onError: (_, __, context: any) => {
      if (context?.previousAlbums) {
        queryClient.setQueryData(
          ["album-pending-contents"],
          context.previousAlbums
        );
      }
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["album-pending-contents"] });
    },
    ...config,
    mutationFn: rejectAlbumContent,
  });
};
