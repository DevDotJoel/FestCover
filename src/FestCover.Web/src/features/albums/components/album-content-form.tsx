import React from "react";
import { z } from "zod";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { FileImporter } from "../../../components/shared/file.importer";

const albumContentSchema = z.object({
  AlbumContentImage: z.instanceof(File),
  albumContentPreview: z.string(),
  phoneNumber: z.string().optional(),
});
export type AlbumContentFormFields = z.infer<typeof albumContentSchema>;

export type AlbumContentFormType = {
  submit: (data: AlbumContentFormFields) => void;
  disableFields: boolean;
};
export const AlbumContentForm = ({
  submit,
  disableFields,
}: AlbumContentFormType) => {
  const {
    control,
    handleSubmit,
    formState: { errors },
    setValue,
    watch,
  } = useForm<any>({
    defaultValues: undefined,
    resolver: zodResolver(albumContentSchema),
  });

  function getImage(file) {
    setValue("albumContentPreview", file.filePreviewLink);
    setValue("AlbumContentImage", file.file);
  }
  return (
    <>
      <div className="row">
        <div className="col ">
          <form id="album-content-form" onSubmit={handleSubmit(submit)}>
            <div className="card rounded-3 border-0 ">
              <div className="card-body scrollable-div">
                <div className="row mt-2 ">
                  <div className="col d-flex justify-content-center">
                    <img
                      src={
                        watch("albumContentPreview") === ""
                          ? "/blankprofile.png"
                          : watch("albumContentPreview")
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
                      />
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
