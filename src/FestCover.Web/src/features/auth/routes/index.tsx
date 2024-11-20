import { Route, Routes } from "react-router-dom";
import { lazyImport } from "../../../utils/lazyImport";

const { LoginPage } = lazyImport(
  () => import("../pages/login.page"),
  "LoginPage"
);

const { ExternalLoginPage } = lazyImport(
  () => import("../pages/external.login.page"),
  "ExternalLoginPage"
);
export const AuthRoutes = () => {
  return (
    <Routes>
      <Route path="login" element={<LoginPage />} />
      <Route path="external-login-callback" element={<ExternalLoginPage />} />
    </Routes>
  );
};
