import { AlbumContentPendingModel, AlbumModel } from "../types";
import { Modal } from "react-bootstrap";
import { useRejectAlbumContent } from "../api/reject-album-content";

export type RejectAlbumContentModalProps = {
  albumContent: AlbumContentPendingModel;
  show: boolean;
  handleClose: () => void;
};
export const RejectAlbumContentModal = ({
  show,
  albumContent,
  handleClose,
}: RejectAlbumContentModalProps) => {
  const rejectAlbumContentMutation = useRejectAlbumContent();

  async function rejectAlbumContent() {
    await rejectAlbumContentMutation.mutateAsync({
      rejectAlbumContent: { albumContentId: albumContent.id },
    });
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
              <img src={albumContent.url} className="card-img-top" />
            </div>
          </div>
          <div className="row mt-2">
            <div className="col">
              Are you sure you want to reject this content from{" "}
              <b>{albumContent.name} </b> with the phone number{" "}
              <b>{albumContent.phoneNumber} </b>?
            </div>
          </div>
        </Modal.Body>
        <Modal.Footer className="justify-content-between">
          <button
            disabled={rejectAlbumContentMutation.isPending}
            onClick={handleClose}
            className="btn btn rounded-5"
          >
            No
          </button>

          <button
            disabled={rejectAlbumContentMutation.isPending}
            onClick={async () => {
              await rejectAlbumContent();
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
export default RejectAlbumContentModal;
