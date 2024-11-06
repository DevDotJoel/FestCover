import { Modal } from "react-bootstrap";
import { AlbumModel } from "../types";
import QRCode from "react-qr-code";
import {
  EmailIcon,
  EmailShareButton,
  WhatsappIcon,
  WhatsappShareButton,
} from "react-share";
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
  const albumUrl = window.location.origin + "/p/" + album.key;
  const message = `Use the album "${album.name}" in the Fest Cover app to share photos. 
To share photos in my album, please click on the following link: 
${albumUrl} 
You will be taken to my album via the code "${album.key}".`;
  return (
    <>
      <Modal
        backdrop="static"
        keyboard={false}
        show={show}
        onHide={handleClose}
      >
        <Modal.Header closeButton></Modal.Header>
        <Modal.Body>
          <h2 className="card-title text-center">Share your Album </h2>

          <h6 className="card-subtitle mt-2 text-muted text-center">
            Scan this QR code with your phone
          </h6>
          {!album.isPublic && (
            <h6 className="card-subtitle mt-2 text-danger text-center">
              This Album is not public
            </h6>
          )}
          <div className="row mt-5">
            <div className="col d-flex justify-content-center ">
              <QRCode value={albumUrl} />
            </div>
          </div>
          <div className="row mt-5 ">
            <div className="col  d-flex justify-content-center">
              <h4>
                <b>Album Code:</b> {album.key}
              </h4>
            </div>
          </div>
          <div className="row mt-3 d-flex justify-content-center">
            <div className="col-10  ">
              <div className="input-group mb-3">
                <input
                  value={albumUrl}
                  type="text"
                  disabled={true}
                  className={`form-control rounded-3`}
                />
                <button
                  onClick={() => {
                    navigator.clipboard.writeText(albumUrl);
                  }}
                  className="btn btn-blue"
                >
                  <i className="bi bi-paperclip"></i>
                </button>
              </div>
            </div>
          </div>
          <div className="row mt-3 d-flex justify-content-center">
            <div className="col-2">
              <WhatsappShareButton url={" "} title={message}>
                <WhatsappIcon size={32} round />
              </WhatsappShareButton>
            </div>
            <div className="col-2">
              <EmailShareButton
                body={message}
                url={""}
                subject={`Join the album ${album.name} in the Fest Cover app to share photos.`}
              >
                <EmailIcon size={32} round />
              </EmailShareButton>
            </div>
          </div>
        </Modal.Body>
      </Modal>
    </>
  );
};
