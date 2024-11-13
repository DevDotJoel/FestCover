import { Modal } from "react-bootstrap";
import {
  CreateAlbumContentModel,
  CreateAlbumContentPublicModel,
} from "../types";
import { useCreateAlbumContent } from "../api/create-album-content";
import { AlbumContentForm } from "./album-content-form";
import { useCreatePublicAlbumContent } from "../../public/api/create-public-album-content";

export type AlbumContentPublicModalProps = {
  albumId: string;
  show: boolean;
  handleClose: () => void;
};
export const AlbumContentPublicModal = ({
  show,
  albumId,
  handleClose,
}: AlbumContentPublicModalProps) => {
  const createCreatePublicAlbumContentMutation = useCreatePublicAlbumContent();

  async function saveAlbumContent(data) {
    console.log(data);
    const createAlbumContent = {} as CreateAlbumContentPublicModel;
    createAlbumContent.phoneNumber = data.phoneNumber;
    createAlbumContent.name = data.name;
    createAlbumContent.albumId = albumId;
    createAlbumContent.albumContentImages = data.AlbumContentImages.map((f) => {
      return f.file;
    });
    await createCreatePublicAlbumContentMutation.mutateAsync(
      createAlbumContent
    );
    handleClose();
  }

  return (
    <>
      <Modal
        backdrop="static"
        keyboard={false}
        show={show}
        onHide={handleClose}
      >
        <Modal.Header closeButton>
          <Modal.Title className="ms-auto">
            <b> Add Content to Album</b>
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <div className="row mt-3">
            <div className="col ">
              <AlbumContentForm
                disableFields={createCreatePublicAlbumContentMutation.isPending}
                submit={saveAlbumContent}
                phoneNumberRequired={true}
              />
            </div>
          </div>
        </Modal.Body>
        <Modal.Footer className="justify-content-between">
          <button
            disabled={createCreatePublicAlbumContentMutation.isPending}
            onClick={handleClose}
            className="btn btn-blue rounded-5"
          >
            Close
          </button>

          <button
            disabled={createCreatePublicAlbumContentMutation.isPending}
            form="album-content-form"
            className="btn btn-blue rounded-5"
          >
            Save
          </button>
        </Modal.Footer>
      </Modal>
    </>
  );
};
