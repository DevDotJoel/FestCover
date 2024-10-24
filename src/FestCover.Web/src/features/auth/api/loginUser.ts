import { toast } from "react-toastify";

import { AuthResultModel, LoginUserModel } from "../types";
import { api } from "../../../libs/api-client";

export const loginWithEmailAndPassword = (
  data: LoginUserModel
): Promise<AuthResultModel> => {
  return toast.promise(api.post("api/auth/login", data), {
    pending: "Sign in",
    success: "Signed  with success",
  });
};
