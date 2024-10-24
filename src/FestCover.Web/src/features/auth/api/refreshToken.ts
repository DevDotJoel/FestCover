import { api } from "../../../libs/api-client";
import { AuthResultModel, RefreshTokenModel } from "../types";


export const refreshToken = (request:RefreshTokenModel): Promise<AuthResultModel> => {
    return api.post('api/auth/refresh',request);
  };