import { api } from "../../../libs/api-client";

export const logOutUser = (): Promise<void> => {
  return api.get("api/auth/logout");
};
