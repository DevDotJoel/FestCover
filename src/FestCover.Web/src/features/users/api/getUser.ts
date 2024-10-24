import { api } from "../../../libs/api-client";
import { AuthUserModel } from "../types";

export const getUser = (): Promise<AuthUserModel> => {
  return api.get("api/users/me");
};
