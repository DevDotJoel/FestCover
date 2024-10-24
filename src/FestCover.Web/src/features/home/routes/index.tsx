import { Route, Routes } from "react-router-dom";
import { lazyImport } from "../../../utils/lazyImport";

const { HomePage } = lazyImport(() => import("../pages/home.page"), "HomePage");
export const HomeRoutes = () => {
  return (
    <Routes>
      <Route path="" element={<HomePage />} />
    </Routes>
  );
};
