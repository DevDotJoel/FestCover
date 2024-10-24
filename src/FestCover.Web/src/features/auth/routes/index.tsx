import { Route, Routes } from "react-router-dom";
import { lazyImport } from "../../../utils/lazyImport";



const { LoginPage } = lazyImport(
  () => import("../pages/login.page"),
  "LoginPage"
);
export const AuthRoutes = () => {
  return (
    <Routes>
      <Route path="login" element={<LoginPage />} />
    </Routes>
  );
};
