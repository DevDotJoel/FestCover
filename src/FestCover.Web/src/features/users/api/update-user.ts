import { useMutation } from "@tanstack/react-query";
import { MutationConfig, queryClient } from "../../../libs/react-query";

import { toast } from "react-toastify";
import { AuthUserModel, UpdateAuthUserModel } from "../types";
import { api } from "../../../libs/api-client";

export const updateUserProfile = (
  updateUser: UpdateAuthUserModel
): Promise<void> => {
  const formData = new FormData();
  formData.append("username", updateUser.username);
  formData.append("email", updateUser.email);
  formData.append("currentPassword", updateUser.currentPassword);
  formData.append("password", updateUser.password);
  formData.append("password2", updateUser.password2);
  formData.append("file", updateUser.file);

  return toast.promise(api.put(`/api/users/profile`, formData), {
    pending: "Updating User ",
    success: "User updated with success",
  });
};

type UseUpdateUserOptions = {
  config?: MutationConfig<typeof updateUserProfile>;
};

export const useUpdateUserProfile = ({ config }: UseUpdateUserOptions = {}) => {
  return useMutation({
    onMutate: async () => {

      const previousUserInfo = queryClient.getQueryData<AuthUserModel>(["authenticated-user"]);

      return { previousUserInfo };
    },
    onError: (_, __, context:any) => {
      if (context?.previousUserInfo) {
        queryClient.setQueryData(["authenticated-user"], context.previousUserInfo);
      }
    },
    onSuccess: (data) => {
      queryClient.refetchQueries({ queryKey: ["authenticated-user"] });
      return data;
    },
    ...config,
    mutationFn: updateUserProfile,
  });
};
