import React, { useEffect } from "react";
import { useNavigate } from "react-router";
import { useSearchParams } from "react-router-dom";
export const ExternalLoginPage = () => {
  const navigate = useNavigate();
  const [searchParams] = useSearchParams();

  useEffect(() => {
    const accessToken = searchParams.get("token");
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
