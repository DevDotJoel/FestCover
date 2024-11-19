import React, { useEffect } from "react";
import { z } from "zod";
import { useForm, useWatch } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { FileImporter } from "../../../components/shared/file.importer";
import { InputForm } from "../../../components/ui/forms/input-form";
import { AuthUserModel } from "../types";
const userProfileSchema = z
  .object({
    username: z.string().refine((s) => !s.includes(" "), {
      message: "Username cannot contain spaces!",
    }),
    email: z.string().min(5, { message: "Email is required" }),
    currentPassword: z.string().optional(),
    file: z.instanceof(File).optional(),
    password: z.string().optional(),
    password2: z.string().optional(),
    filePreview: z.string().optional(),
  })
  .superRefine(({ currentPassword, password, password2 }, ctx) => {
    if (currentPassword !== "")
      if (password === "" && password2 === "") {
        ctx.addIssue({
          code: "custom",
          message: "The new password must be filled",
          path: ["password"],
        });
      }
    if (password2 !== password) {
      ctx.addIssue({
        code: "custom",
        message: "The passwords did not match",
        path: ["password2"],
      });
    }
  });
export type UserProfileFormFields = z.infer<typeof userProfileSchema>;

export type UserFormProps = {
  user: AuthUserModel;
  submit: (data: UserProfileFormFields) => void;
  disableFields: boolean;
};
export const UserProfileForm = ({
  submit,
  user,
  disableFields,
}: UserFormProps) => {
  const {
    control,
    handleSubmit,
    formState: { errors },
    setValue,
    watch,
  } = useForm<UserProfileFormFields>({
    defaultValues: user
      ? {
          username: user.username,
          email: user.email,
          filePreview: user.pictureUrl !== null ? user.pictureUrl : "",
        }
      : undefined,
    resolver: zodResolver(userProfileSchema),
  });
  const currentPassword = useWatch({
    control,
    name: "currentPassword",
  });
  useEffect(() => {
    if (currentPassword === "") {
      setValue("password", null);
      setValue("password2", null);
    }
  }, [currentPassword, setValue]);
  function getImage(files) {
    setValue("filePreview", files[0].filePreviewLink);
    setValue("file", files[0].file);
  }
  return (
    <>
      <div className="row">
        <div className="col ">
          <form id="user-profile-form" onSubmit={handleSubmit(submit)}>
            <div className="row">
              <div className="col d-flex justify-content-center">
                <div className="row ">
                  <div className="col ">
                    <img
                      src={
                        watch("filePreview") === ""
                          ? "/blankprofile.png"
                          : watch("filePreview")
                      }
                      className="rounded-circle"
                      width={200}
                      height={200}
                    ></img>
                  </div>
                </div>
              </div>
            </div>
            <div className="row mt-3">
              <div className="col d-flex justify-content-center">
                <div>
                  <FileImporter
                    allowedExtensions={"image/png, image/jpeg"}
                    output={getImage}
                    message={" Select Image"}
                    icon="bi bi-card-image"
                    allowMultiple={false}
                    disableButton={disableFields}
                    maxLength={1}
                  />
                </div>
              </div>
            </div>
            <div className="row mt-3 d-flex justify-content-center">
              <div className="col col-sm-6">
                <div className="card rounded-3 border-0 ">
                  <div className="card-body ">
                    <div className="row mt-2">
                      <div className="col">
                        <InputForm
                          name={"username"}
                          label={"Username"}
                          control={control}
                          errors={errors}
                          type="text"
                          disableFields={disableFields}
                        />
                      </div>
                    </div>
                    <div className="row mt-2">
                      <div className="col">
                        <InputForm
                          name={"email"}
                          label={"Email "}
                          control={control}
                          errors={errors}
                          type="text"
                          disableFields={disableFields}
                        />
                      </div>
                    </div>
                    <div className="row mt-3">
                      <div className="col">
                        <h3>
                          <b>Password</b>
                        </h3>
                      </div>
                    </div>
                    <div className="row mt-2">
                      <div className="col">
                        <InputForm
                          name={"currentPassword"}
                          label={"Current Password"}
                          control={control}
                          errors={errors}
                          type="password"
                          disableFields={false}
                        />
                      </div>
                    </div>
                    <div className="row mt-2">
                      <div className="col">
                        <InputForm
                          name={"password"}
                          label={"New Password"}
                          control={control}
                          errors={errors}
                          type="password"
                          disableFields={currentPassword === ""}
                        />
                      </div>
                    </div>
                    <div className="row mt-2">
                      <div className="col">
                        <InputForm
                          name={"password2"}
                          label={"Repeat Password"}
                          control={control}
                          errors={errors}
                          type="password"
                          disableFields={currentPassword === ""}
                        />
                      </div>
                    </div>
                    <div className="row mt-2">
                      <div className="col d-flex justify-content-center">
                        <button
                          disabled={disableFields}
                          type="submit"
                          form="user-profile-form"
                          className="btn btn-blue rounded-5"
                        >
                          Save
                        </button>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </form>
        </div>
      </div>
    </>
  );
};
