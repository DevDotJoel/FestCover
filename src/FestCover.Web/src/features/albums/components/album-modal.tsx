import { Modal } from "react-bootstrap";
import { AlbumModel, CreateAlbumModel, UpdateAlbumModel } from "../types";
import { AlbumForm } from "./album-form";
import { useCreateAlbum } from "../api/create-album";
import { useUpdateAlbum } from "../api/update-album";

export type AlbumModalProps = {
  album?: AlbumModel;
  show: boolean;
  handleClose: () => void;
};
export const AlbumModal = ({ show, album, handleClose }: AlbumModalProps) => {
  const createAlbumMutation = useCreateAlbum();
  const updateAlbumMutation = useUpdateAlbum();
  async function saveAlbum(data) {
    console.log(data);
    if (data.id != null || data.id != undefined) {
      const updateAlbum = {} as UpdateAlbumModel;
      updateAlbum.albumId = data.id;
      updateAlbum.name = data.name;
      updateAlbum.description = data.description;
      updateAlbum.albumImage = data.albumImage;
      await updateAlbumMutation.mutateAsync(updateAlbum);
    } else {
      const createAlbum = {} as CreateAlbumModel;
      createAlbum.name = data.name;
      createAlbum.description = data.description;
      createAlbum.albumImage = data.albumImage;
      await createAlbumMutation.mutateAsync(createAlbum);
    }

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
            <b> Album Information</b>
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <div className="row mt-3">
            <div className="col ">
              <AlbumForm
                disableFields={createAlbumMutation.isPending}
                album={album}
                submit={saveAlbum}
              />
            </div>
          </div>
        </Modal.Body>
        <Modal.Footer className="justify-content-between">
          <button onClick={handleClose} className="btn btn-blue rounded-5">
            Close
          </button>

          <button form="album-form" className="btn btn-blue rounded-5">
            Save
          </button>
        </Modal.Footer>
      </Modal>
    </>
  );
};
