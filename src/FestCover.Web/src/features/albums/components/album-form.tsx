import React from "react";
import { z } from "zod";
import { AlbumModel } from "../types";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { FileImporter } from "../../../components/shared/file.importer";
import { InputForm } from "../../../components/ui/forms/input-form";
import { InputCheckBoxForm } from "../../../components/ui/forms/input-checkbox-form";
const albumSchema = z.object({
  id: z.string().optional(),
  name: z.string().min(5, { message: "The album name is required" }),
  description: z
    .string()
    .min(5, { message: "The album description is required" }),
  albumImage: z.instanceof(File, { message: " Album cover is required" }),
  albumBackgroundImage: z.instanceof(File).optional(),
  albumPreview: z.string(),
  albumBackgroundPreview: z.string().optional(),
  allowPublicUpload: z.boolean({
    required_error: "Allow Public Upload is required",
  }),
  isPublic: z.boolean({
    required_error: "Public  is required",
  }),
  reviewUploadedContent: z.boolean({
    required_error: "Review Uploaded Content is required",
  }),
});
export type AlbumFormFields = z.infer<typeof albumSchema>;

export type AlbumFormsType = {
  album?: AlbumModel;
  submit: (data: AlbumFormFields) => void;
  disableFields: boolean;
};
export const AlbumForm = ({ submit, album, disableFields }: AlbumFormsType) => {
  const currentSchema = albumSchema.extend({
    albumImage:
      album != null ? z.instanceof(File).optional() : z.instanceof(File),
  });

  const {
    control,
    handleSubmit,
    formState: { errors },
    setValue,
    watch,
  } = useForm<AlbumFormFields>({
    defaultValues: album
      ? {
          id: album.id,
          name: album.name,
          description: album.description,
          albumPreview: album.url,
          albumBackgroundPreview: album.backgroundUrl,
          isPublic: album.isPublic,
          allowPublicUpload: album.allowPublicUpload,
          reviewUploadedContent: album.reviewUploadedContent,
        }
      : {
          albumImage: null,
          albumBackgroundImage: null,
        },
    resolver: zodResolver(currentSchema),
  });

  function getImage(files) {
    setValue("albumPreview", files[0].filePreviewLink);
    setValue("albumImage", files[0].file);
  }
  function getAlbumBackgroundImage(files) {
    setValue("albumBackgroundPreview", files[0].filePreviewLink);
    setValue("albumBackgroundImage", files[0].file);
  }
  function removeImage() {
    setValue("albumPreview", "");
    setValue("albumImage", undefined);
  }
  function removeBackgroundImage() {
    setValue("albumBackgroundPreview", "");
    setValue("albumBackgroundImage", undefined);
  }
  return (
    <>
      <div className="row">
        <div className="col ">
          <form id="album-form" onSubmit={handleSubmit(submit)}>
            <div className="card rounded-3 border-0 ">
              <div className="card-body scrollable-div">
                <div className="row mt-2 d-flex justify-content-center ">
                  <div className="col-5 ">
                    <img
                      src={watch("albumPreview")}
                      className="img-fluid"
                      width={200}
                    ></img>
                  </div>
                  {watch("albumPreview") != "" &&
                    watch("albumPreview") != null && (
                      <div className="col-1 ps-0">
                        <button
                          type="button"
                          onClick={removeImage}
                          className="btn btn-sm btn-danger rounded-5"
                        >
                          <i className="bi bi-x-lg"></i>
                        </button>
                      </div>
                    )}
                </div>
                {errors?.albumImage && (
                  <div className="row d-flex justify-content-center ">
                    <div className="col-8 ms-5">
                      <span className="invalid-feedback d-block">
                        {errors?.albumImage.message}
                      </span>
                    </div>
                  </div>
                )}
                <div className="row mt-3">
                  <div className="col d-flex justify-content-center">
                    <div>
                      <FileImporter
                        allowedExtensions={"image/png, image/jpeg"}
                        output={getImage}
                        message={" Select Album Cover"}
                        icon="bi bi-card-image"
                        allowMultiple={false}
                        disableButton={disableFields}
                        maxLength={1}
                      />
                    </div>
                  </div>
                </div>
                <hr />
                <div className="row mt-2 d-flex justify-content-center ">
                  <div className="col-5">
                    <img
                      src={watch("albumBackgroundPreview")}
                      className="img-fluid"
                      width={200}
                    ></img>
                  </div>
                  {watch("albumBackgroundPreview") != "" &&
                    watch("albumBackgroundPreview") != null && (
                      <div className="col-1 ps-0 ">
                        <button
                          onClick={removeBackgroundImage}
                          type="button"
                          className="btn btn-sm btn-danger rounded-5"
                        >
                          <i className="bi bi-x-lg"></i>
                        </button>
                      </div>
                    )}
                </div>
                <div className="row mt-3">
                  <div className="col d-flex justify-content-center">
                    <div>
                      <FileImporter
                        allowedExtensions={"image/png, image/jpeg"}
                        output={getAlbumBackgroundImage}
                        message={" Select Album Background "}
                        icon="bi bi-card-image"
                        allowMultiple={false}
                        disableButton={disableFields}
                        maxLength={1}
                      />
                    </div>
                  </div>
                </div>
                <div className="row mt-2">
                  <div className="col">
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
                <div className="row mt-2">
                  <div className="col">
                    <InputForm
                      name={"description"}
                      label={"Description "}
                      control={control}
                      errors={errors}
                      type="text"
                      disableFields={disableFields}
                    />
                  </div>
                </div>
                <div className="row mt-2">
                  <div className="col">
                    <InputCheckBoxForm
                      name={"isPublic"}
                      label={"Public  "}
                      control={control}
                      errors={errors}
                      disableFields={disableFields}
                    />
                  </div>
                </div>
                <div className="row mt-2">
                  <div className="col">
                    <InputCheckBoxForm
                      name={"allowPublicUpload"}
                      label={"Allow Public Upload "}
                      control={control}
                      errors={errors}
                      disableFields={disableFields}
                    />
                  </div>
                </div>
                <div className="row mt-2">
                  <div className="col">
                    <InputCheckBoxForm
                      name={"reviewUploadedContent"}
                      label={"Review Uploaded Content "}
                      control={control}
                      errors={errors}
                      disableFields={disableFields}
                    />
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
