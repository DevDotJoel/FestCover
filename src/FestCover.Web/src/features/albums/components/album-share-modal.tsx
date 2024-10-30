import { Modal } from "react-bootstrap";
import { AlbumModel } from "../types";
import QRCode from "react-qr-code";
export type AlbumShareModalProps = {
  album: AlbumModel;
  show: boolean;
  handleClose: () => void;
};
export const AlbumShareModal = ({
  show,
  album,
  handleClose,
}: AlbumShareModalProps) => {
  const albumUrl = window.location.origin + "/public/" + album.key;
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
            <b> Share Album </b>
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <div className="row mt-3">
            <div className="col d-flex justify-content-center ">
              <QRCode value={albumUrl} />,
            </div>
          </div>
        </Modal.Body>
        <Modal.Footer className="justify-content-between">
          <button onClick={handleClose} className="btn btn-dark rounded-5">
            Close
          </button>
        </Modal.Footer>
      </Modal>
    </>
  );
};
