import { Suspense } from "react";
import { Navigate, Outlet } from "react-router-dom";

import { MainLayout } from "../components/ui/layout/main.layout";
import { lazyImport } from "../utils/lazyImport";
import { useUser } from "../libs/auth";

// import { RoutesPermissions } from "./permissions";
const { UserRoutes } = lazyImport(
  () => import("../features/users"),
  "UserRoutes"
);
const { AlbumRoutes } = lazyImport(
  () => import("../features/albums"),
  "AlbumRoutes"
);
export const App = () => {
  const user = useUser();
  if (user.isLoading) {
    return <></>;
  }

  if (!user.data) {
    return <Navigate replace to="/auth/login" />;
  }
  return (
    <>
      <MainLayout>
        <Suspense fallback={<></>}>
          <Outlet />
        </Suspense>
      </MainLayout>
    </>
  );
};
export const protectedRoutes = [
  {
    path: "/",
    element: <App />,
    children: [
      {
        path: "/albums/*",
        element: <AlbumRoutes />,
      },
      {
        path: "/user/*",
        element: <UserRoutes />,
      },
      { path: "*", element: <Navigate to="." /> },
    ],
  },
];
