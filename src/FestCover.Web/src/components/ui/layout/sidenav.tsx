import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { useLogout, useUser } from "../../../libs/auth";
import { queryClient } from "../../../libs/react-query";

export const SideNav = () => {
  const navigate = useNavigate();

  const currentQueryClient = queryClient;
  const logoutQuery = useLogout();

  const userQuery = useUser();

  if (userQuery.isLoading) {
    return <></>;
  }
  const user = userQuery.data;
  function logOut() {
    logoutQuery.mutate({});
    currentQueryClient.clear();
    navigate("/auth/login");
  }
  return (
    <>
      <div className="d-flex flex-column align-items-center align-items-sm-start px-3 pt-2 text-white min-vh-100 sticky-top">
        <ul
          className="nav nav-pills flex-column mb-sm-auto mb-0 align-items-center align-items-sm-start "
          id="menu"
        >
          <li>
            <Link to="albums" className="nav-link px-0 align-middle text-dark">
              <i className="fs-4  bi bi-journal-album"></i>{" "}
              <span className="ms-1 d-none d-sm-inline">Albums</span>
            </Link>
          </li>
          <li>
            <Link
              to="albums/pendent"
              className="nav-link px-0 align-middle text-dark"
            >
              <i className="fs-4  bi bi-hourglass-split"></i>{" "}
              <span className="ms-1 d-none d-sm-inline">Pendent Content</span>
            </Link>
          </li>
        </ul>
        <hr />
        <div className="dropdown pb-4">
          <a
            href="#"
            className="d-flex align-items-center text-white text-decoration-none dropdown-toggle"
            id="dropdownUser1"
            data-bs-toggle="dropdown"
            aria-expanded="false"
          >
            <img
              src={
                user.pictureUrl != null ? user.pictureUrl : "/blankprofile.png"
              }
              alt="hugenerd"
              width="20"
              height="20"
              className="rounded-circle"
            />
            <span className="d-none d-sm-inline text-dark mx-1">
              {user.username}
            </span>
          </a>
          <ul className="dropdown-menu dropdown-menu-dark text-small shadow">
            {/* <li>
              <a className="dropdown-item" href="#">
                New project...
              </a>
            </li>
            <li>
              <hr className="dropdown-divider" />
            </li> */}
            <li>
              <Link to="user/profile" className="dropdown-item">
                Profile
              </Link>
            </li>
            <li>
              <button className="dropdown-item" onClick={logOut}>
                Sign out
              </button>
            </li>
          </ul>
        </div>
      </div>
    </>
  );
};
