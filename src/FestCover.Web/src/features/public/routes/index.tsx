import { Route, Routes } from "react-router-dom";
import { lazyImport } from "../../../utils/lazyImport";

const { AlbumPublicPage } = lazyImport(
  () => import("../pages/album-public.page"),
  "AlbumPublicPage"
);
export const PublicRoutes = () => {
  return (
    <Routes>
      <Route path="/:id" element={<AlbumPublicPage />} />
    </Routes>
  );
};
