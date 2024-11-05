import { AlbumModel } from "../types";
import { Modal } from "react-bootstrap";
import { useDeleteAlbum } from "../api/delete-album";

export type AlbumDeleteModalProps = {
  album: AlbumModel;
  show: boolean;
  handleClose: () => void;
};
export const AlbumDeleteModal = ({
  show,
  album,
  handleClose,
}: AlbumDeleteModalProps) => {
  const deleteAlbumMutation = useDeleteAlbum();

  async function deleteAlbum() {
    await deleteAlbumMutation.mutateAsync({ albumId: album.id });
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
          <Modal.Title>
            <b> Delete Album</b>
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <div className="row">
            <div className="col">
              <img src={album.url} className="card-img-top" />
            </div>
          </div>
          <div className="row mt-2">
            <div className="col">
              Are you sure you want to delete the album <b>{album.name}</b> ?
            </div>
          </div>
        </Modal.Body>
        <Modal.Footer className="justify-content-between">
          <button
            disabled={deleteAlbumMutation.isPending}
            onClick={handleClose}
            className="btn btn rounded-5"
          >
            No
          </button>

          <button
            disabled={deleteAlbumMutation.isPending}
            onClick={async () => {
              await deleteAlbum();
            }}
            className="btn btn-danger rounded-5"
          >
            Yes
          </button>
        </Modal.Footer>
      </Modal>
    </>
  );
};
export default AlbumDeleteModal;
