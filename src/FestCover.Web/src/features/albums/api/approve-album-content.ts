import { useMutation } from "@tanstack/react-query";

import { MutationConfig, queryClient } from "../../../libs/react-query";
import { AlbumContentPendingModel, ApproveAlbumContentModel } from "../types";
import { toast } from "react-toastify";
import { api } from "../../../libs/api-client";

export const approveAlbumContent = ({
  approveAlbumContent,
}: {
  approveAlbumContent: ApproveAlbumContentModel;
}): Promise<void> => {
  return toast.promise(
    api.post(`/api/AlbumContents/Approve`, approveAlbumContent),
    {
      pending: "Approving Album Content",
      success: "Album content approved with success",
    }
  );
};

type UseApproveAlbumContentOptions = {
  config?: MutationConfig<typeof approveAlbumContent>;
};

export const useApproveAlbumContent = ({
  config,
}: UseApproveAlbumContentOptions = {}) => {
  return useMutation({
    onMutate: async (data) => {
      await queryClient.cancelQueries({ queryKey: ["album-pending-contents"] });

      const previousAlbumContents = queryClient.getQueryData<
        AlbumContentPendingModel[]
      >(["album-pending-contents"]);
      const album =previousAlbumContents.find(a=>a.id==data.approveAlbumContent.albumContentId);
      queryClient.setQueryData(
        ["album-pending-contents"],
        previousAlbumContents?.filter(
          (albumContent) =>
            albumContent.id !== data.approveAlbumContent.albumContentId
        )
      );
      return  { previousAlbumContents:previousAlbumContents,albumId:album.albumId };
    },
    onError: (_, __, context: any) => {
      if (context?.previousAlbumContents) {
        queryClient.setQueryData(
          ["album-pending-contents"],
          context.previousAlbumContents
        );
      }
    },
    onSuccess: (_, __, context: any) => {
      queryClient.invalidateQueries({ queryKey: ["album-pending-contents"] });
      queryClient.refetchQueries({queryKey:["album-contents",context.albumId]});
    },
    ...config,
    mutationFn: approveAlbumContent,
  });
};
