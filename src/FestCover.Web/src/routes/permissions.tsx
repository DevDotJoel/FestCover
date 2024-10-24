import { Navigate } from "react-router-dom";

import { useUser } from "../libs/auth";

export const RoutesPermissions = ({ children, requiresAuth }) => {
  const user = useUser({ staleTime: Infinity, gcTime: Infinity });
  if (user.isLoading) {
    return <></>;
  }
  if (!user.data && requiresAuth) {
    return <Navigate replace to="/auth/login" />;
  }

  return children;
};
