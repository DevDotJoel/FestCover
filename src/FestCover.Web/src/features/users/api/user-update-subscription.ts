import { useMutation } from "@tanstack/react-query";
import { MutationConfig, queryClient } from "../../../libs/react-query";

import { toast } from "react-toastify";
import {
  AuthUserModel,
  UpdateAuthUserModel,
  UpdateUserSubscriptionModel,
} from "../types";
import { api } from "../../../libs/api-client";

export const updateUserSubscription = (
  updateUserSubscription: UpdateUserSubscriptionModel
): Promise<string> => {
  return toast.promise(
    api.put(`/api/users/Subscription`, updateUserSubscription),
    {
      pending: "Checking User Susbscription",
      success: "User redirected with success",
    }
  );
};

type UseUpdateUserSubscriptionOptions = {
  config?: MutationConfig<typeof updateUserSubscription>;
};

export const useUpdateUserSubscription = ({
  config,
}: UseUpdateUserSubscriptionOptions = {}) => {
  return useMutation({
    onSuccess: (data) => {
      return data;
    },
    ...config,
    mutationFn: updateUserSubscription,
  });
};
