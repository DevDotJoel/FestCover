import {
  LoginUserModel,
  loginWithEmailAndPassword,
  AuthResultModel,
} from "../features/auth";
import { logOutUser } from "../features/auth/api/logOutUser";
import { getUser, AuthUserModel } from "../features/users";
import { configureAuth } from "react-query-auth";
async function logoutFn() {
  await logOutUser();
  localStorage.removeItem("accessToken");
}
async function loginFn(data: LoginUserModel) {
  const response = await loginWithEmailAndPassword(data);
  await handleUserResponse(response);
  const user = await getUser();
  return user;
}
async function handleUserResponse(data: AuthResultModel) {
  const { accessToken } = data;
  localStorage.setItem("accessToken", accessToken);
}
async function registerFn() {
  return Promise.resolve({} as AuthUserModel);
}

async function userFn() {
  const accessToken = localStorage.getItem("accessToken");
  if (accessToken) {
    const user = await getUser();
    return user;
  } else {
    return null;
  }
}

export const { useUser, useLogin, useLogout } = configureAuth({
  userFn,
  loginFn,
  registerFn,
  logoutFn: () => logoutFn(),
});
