import { Route, Routes } from "react-router-dom";
import { lazyImport } from "../../../utils/lazyImport";
import { RoutesPermissions } from "../../../routes/permissions";

const { AlbumsPage } = lazyImport(
  () => import("../pages/albums.page"),
  "AlbumsPage"
);
const { AlbumDetailPage } = lazyImport(
  () => import("../pages/album-detail.page"),
  "AlbumDetailPage"
);
export const AlbumRoutes = () => {
  return (
    <Routes>
      <Route path="" element={<AlbumsPage />} />
      <Route path="details/:id" element={<AlbumDetailPage />} />
    </Routes>
  );
};
