import React from "react";
import { useUser } from "../../../libs/auth";
import { UserProfileForm } from "../components/user-profile-form";
import { UpdateAuthUserModel } from "../types";
import { useUpdateUserProfile } from "../api/update-user";

export const UserProfilePage = () => {
  const userQuery = useUser();
  const updateUserMutation = useUpdateUserProfile();
  if (userQuery.isLoading) {
    return <></>;
  }
  const user = userQuery.data;

  async function submitUpdateUser(userInfo) {
    const updateUser = {} as UpdateAuthUserModel;
    updateUser.username = userInfo.username;
    updateUser.email = userInfo.email;
    updateUser.currentPassword =
      userInfo.currentPassword != "" ? userInfo.currentPassword : null;
    updateUser.password = userInfo.password != "" ? userInfo.password : null;
    updateUser.password2 = userInfo.password2 != "" ? userInfo.password2 : null;
    updateUser.file = userInfo.file != undefined ? userInfo.file : null;
    await updateUserMutation.mutateAsync(updateUser);
  }
  return (
    <>
      <UserProfileForm
        disableFields={updateUserMutation.isPending}
        user={user}
        submit={submitUpdateUser}
      />
    </>
  );
};
