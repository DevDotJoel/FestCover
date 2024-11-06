import { Modal } from "react-bootstrap";
import { CreateAlbumContentModel } from "../types";
import { useCreateAlbumContent } from "../api/create-album-content";
import { AlbumContentForm } from "./album-content-form";

export type AlbumContentModalProps = {
  albumId: string;
  show: boolean;
  handleClose: () => void;
};
export const AlbumContentModal = ({
  show,
  albumId,
  handleClose,
}: AlbumContentModalProps) => {
  const createAlbumContentMutation = useCreateAlbumContent();

  async function saveAlbum(data) {
    const createAlbumContent = {} as CreateAlbumContentModel;
    createAlbumContent.albumId = albumId;
    createAlbumContent.albumContentImages = data.AlbumContentImages.map((f) => {
      return f.file;
    });
    console.log(createAlbumContent);
    await createAlbumContentMutation.mutateAsync(createAlbumContent);
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
            <b> Album Content</b>
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <div className="row mt-3">
            <div className="col ">
              <AlbumContentForm
                disableFields={createAlbumContentMutation.isPending}
                submit={saveAlbum}
              />
            </div>
          </div>
        </Modal.Body>
        <Modal.Footer className="justify-content-between">
          <button
            disabled={createAlbumContentMutation.isPending}
            onClick={handleClose}
            className="btn btn-blue rounded-5"
          >
            Close
          </button>

          <button
            disabled={createAlbumContentMutation.isPending}
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
