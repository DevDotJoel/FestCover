import React from "react";
import { z } from "zod";
import { useFieldArray, useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { FileImporter } from "../../../components/shared/file.importer";
import { toast } from "react-toastify";
import { InputPhoneNumberForm } from "../../../components/ui/forms/input-phone-number-form";
import { InputForm } from "../../../components/ui/forms/input-form";

export type AlbumContentFormType = {
  submit: (data) => void;
  disableFields: boolean;
  emailRequired: boolean;
};
export const AlbumContentForm = ({
  submit,
  disableFields,
  emailRequired,
}: AlbumContentFormType) => {
  const albumFileSchema = z.object({
    filePreviewLink: z.string(),
    file: z.instanceof(File),
  });
  const albumContentSchema = z.object({
    AlbumContentImages: z
      .array(albumFileSchema)

      .min(1, { message: "At least one image is required" }),
    email: emailRequired
      ? z
          .string()
          .min(1, { message: "Email is required" })
          .email("This is not a valid email.")
      : z.string().optional(),
    name: emailRequired
      ? z.string().min(3, { message: "Name is required" })
      : z.string().optional(),
  });
  type AlbumContentFormFields = z.infer<typeof albumContentSchema>;
  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm<AlbumContentFormFields>({
    defaultValues: {
      email: "",
      AlbumContentImages: [],
    },
    resolver: zodResolver(albumContentSchema),
  });
  const { fields, append, remove } = useFieldArray({
    name: "AlbumContentImages",
    control,
  });

  function getImages(files) {
    if (fields.length >= 20) {
      toast.error("Cannot add more than 20 images");
    } else {
      files.forEach((content) => {
        append({
          file: content.file,
          filePreviewLink: content.filePreviewLink,
        });
      });
    }
  }
  function removeImage(index: number) {
    remove(index);
  }

  return (
    <>
      <div className="row ">
        <div className="col ">
          <form id="album-content-form" onSubmit={handleSubmit(submit)}>
            <div className="row ">
              <div className="col d-flex justify-content-center">
                <div>
                  <FileImporter
                    allowedExtensions={"image/*"}
                    output={getImages}
                    message={" Select Images"}
                    icon="bi bi-card-image"
                    allowMultiple={true}
                    disableButton={disableFields}
                    maxLength={10}
                  />
                </div>
              </div>
            </div>
            <div className="row mt-4 row-cols-2 scrollable-album-content-form">
              {fields.map((field: any, index: number) => {
                return (
                  <div key={field.id} className="card rounded-3 border-0 ">
                    <div className="card-body  ">
                      <h5 className="card-title text-end">
                        <button
                          onClick={() => removeImage(index)}
                          className="btn btn-sm btn-danger rounded-5"
                        >
                          <i className="bi bi-x-lg"></i>
                        </button>
                      </h5>
                      <div className="col  ">
                        <img
                          src={field.filePreviewLink}
                          className="card-img-top"
                        ></img>
                      </div>
                    </div>
                  </div>
                );
              })}
            </div>
            {fields.length === 0 && (
              <div className="row">
                <div className="col d-flex justify-content-center">
                  <img
                    src={"/blankprofile.png"}
                    className="img-responsive"
                    width={200}
                  ></img>
                </div>
              </div>
            )}
            {emailRequired && (
              <>
                <div className="row mt-1 d-flex justify-content-center">
                  <div className="col-8 ">
                    <InputForm
                      name={"name"}
                      label={"Name"}
                      control={control}
                      errors={errors}
                      type="text"
                      disableFields={disableFields}
                    />
                  </div>
                </div>
                <div className="row mt-1 d-flex justify-content-center">
                  <div className="col-8 ">
                    <InputForm
                      name={"email"}
                      label={"Email"}
                      control={control}
                      errors={errors}
                      type="text"
                      disableFields={disableFields}
                    />
                  </div>
                </div>
              </>
            )}
          </form>
        </div>
      </div>
    </>
  );
};
