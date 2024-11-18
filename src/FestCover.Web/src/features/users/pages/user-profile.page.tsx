import React from "react";
import { useUser } from "../../../libs/auth";
import { UserProfileForm } from "../components/user-profile-form";

export const UserProfilePage = () => {
  const userQuery = useUser();

  if (userQuery.isLoading) {
    return <></>;
  }
  const user = userQuery.data;
  return (
    <>
      <UserProfileForm
        disableFields={false}
        user={user}
        submit={(data: any) => {
          console.log(data);
        }}
      />
    </>
  );
};
