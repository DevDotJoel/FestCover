import { Route, Routes } from "react-router-dom";
import { lazyImport } from "../../../utils/lazyImport";

const { UserProfilePage } = lazyImport(
  () => import("../pages/user-profile.page"),
  "UserProfilePage"
);

export const UserRoutes = () => {
  return (
    <Routes>
      <Route path="profile" element={<UserProfilePage />} />
    </Routes>
  );
};
