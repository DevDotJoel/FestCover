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
  albumImage: z.instanceof(File),
  albumPreview: z.string(),
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
          isPublic: album.isPublic,
          allowPublicUpload: album.allowPublicUpload,
          reviewUploadedContent: album.reviewUploadedContent,
        }
      : undefined,
    resolver: zodResolver(currentSchema),
  });

  function getImage(files) {
    setValue("albumPreview", files[0].filePreviewLink);
    setValue("albumImage", files[0].file);
  }
  return (
    <>
      <div className="row">
        <div className="col ">
          <form id="album-form" onSubmit={handleSubmit(submit)}>
            <div className="card rounded-3 border-0 ">
              <div className="card-body scrollable-div">
                <div className="row mt-2 ">
                  <div className="col d-flex justify-content-center">
                    <img
                      src={
                        watch("albumPreview") === ""
                          ? "/blankprofile.png"
                          : watch("albumPreview")
                      }
                      className="img-responsive"
                      width={200}
                    ></img>
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
