import { Suspense } from "react";
import { Navigate, Outlet } from "react-router";
import { lazyImport } from "../utils/lazyImport";
import { PublicLayout } from "../components/ui/layout/public.layout";

const { AuthRoutes } = lazyImport(
  () => import("../features/auth"),
  "AuthRoutes"
);
const { HomeRoutes } = lazyImport(
  () => import("../features/home"),
  "HomeRoutes"
);
export const PublicApp = () => {
  return (
    <>
      <Suspense fallback={<></>}>
        <PublicLayout>
          <Outlet />
        </PublicLayout>
      </Suspense>
    </>
  );
};
export const publicRoutes = [
  {
    path: "/",
    element: <PublicApp />,
    children: [
      {
        path: "/home",
        element: <HomeRoutes />,
      },
      {
        path: "/auth/*",
        element: <AuthRoutes />,
      },
      { path: "*", element: <Navigate to="." /> },
    ],
  },
];
