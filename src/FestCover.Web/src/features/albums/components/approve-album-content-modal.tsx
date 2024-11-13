import { AlbumContentPendingModel, AlbumModel } from "../types";
import { Modal } from "react-bootstrap";
import { useApproveAlbumContent } from "../api/approve-album-content";

export type ApproveAlbumContentModalProps = {
  albumContent: AlbumContentPendingModel;
  show: boolean;
  handleClose: () => void;
};
export const ApproveAlbumContentModal = ({
  show,
  albumContent,
  handleClose,
}: ApproveAlbumContentModalProps) => {
  const approveAlbumContentMutation = useApproveAlbumContent();

  async function approveAlbumContent() {
    await approveAlbumContentMutation.mutateAsync({
      approveAlbumContent: { albumContentId: albumContent.id },
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
              Are you sure you want to approve this content from{" "}
              <b>{albumContent.name} </b> with the phone number{" "}
              <b>{albumContent.phoneNumber} </b>?
            </div>
          </div>
        </Modal.Body>
        <Modal.Footer className="justify-content-between">
          <button
            disabled={approveAlbumContentMutation.isPending}
            onClick={handleClose}
            className="btn btn rounded-5"
          >
            No
          </button>

          <button
            disabled={approveAlbumContentMutation.isPending}
            onClick={async () => {
              await approveAlbumContent();
            }}
            className="btn btn-blue rounded-5"
          >
            Yes
          </button>
        </Modal.Footer>
      </Modal>
    </>
  );
};
export default ApproveAlbumContentModal;
