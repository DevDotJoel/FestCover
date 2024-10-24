import { Link, useNavigate } from "react-router-dom";
import { useLogout, useUser } from "../../../libs/auth";

export const LayoutNavbar = () => {
  const navigate = useNavigate();
  const logoutQuery = useLogout();
  const userQuery = useUser();

  if (userQuery.isLoading) {
    return <></>;
  }
  const user = userQuery.data;
  function logOut() {
    logoutQuery.mutate({});
    navigate("/auth/login");
  }
  return (
    <>
      <nav className="navbar navbar-expand-lg navbar-white bg-white shadow-sm sticky-top">
        <div className="container-fluid">
          <div className="navbar-brand">
            <b>FestCover</b>
          </div>
          <button
            className="navbar-toggler "
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarNavDropdown"
            aria-controls="navbarNavDropdown"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
        </div>
      </nav>
    </>
  );
};
