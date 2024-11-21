import React, { useEffect } from "react";
import Cookies from "js-cookie";
import { useNavigate } from "react-router";
export const ExternalLoginPage = () => {
  const navigate = useNavigate();
  const accessToken = Cookies.get("token");

  useEffect(() => {
    console.log(accessToken);
    if (accessToken) {
      localStorage.setItem("accessToken", accessToken);
      navigate("/albums");
    } else {
      navigate("/auth/login");
    }
  }, []);

  return <></>;
};
