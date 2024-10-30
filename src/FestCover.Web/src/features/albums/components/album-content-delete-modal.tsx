import { AlbumContentModel } from "../types";
import { Modal } from "react-bootstrap";
import { useDeleteAlbumContent } from "../api/delete-album-content";

export type AlbumContentDeleteModalProps = {
  albumContent: AlbumContentModel;
  albumId: string;
  show: boolean;
  handleClose: () => void;
};
export const AlbumContentDeleteModal = ({
  show,
  albumContent,
  albumId,
  handleClose,
}: AlbumContentDeleteModalProps) => {
  const deleteAlbumContentMutation = useDeleteAlbumContent();

  async function deleteAlbumContent() {
    await deleteAlbumContentMutation.mutateAsync({
      albumId: albumId,
      albumContentId: albumContent.id,
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
            <b> Delete Album Content</b>
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <div className="card rounded-3 border-0 mt-3">
            <img
              src={albumContent.mediumAlbumContentUrlImage}
              className="card-img-top"
              srcSet={`
                    ${albumContent.smallAlbumContentUrlImage} 150w, 
                    ${albumContent.mediumAlbumContentUrlImage} 500w, 
                    ${albumContent.largeAlbumContentUrlImage} 1000w, 
                    ${albumContent.originalAlbumContentUrlImage} 2000w
                  `}
              sizes="(max-width: 600px) 150px, 
                  (max-width: 1200px) 500px, 
                  (max-width: 1800px) 1000px, 
                  2000px"
            />
            <div className="row">
              <div className="col mt-3">
                <p>
                  {" "}
                  <b>Are you sure you want to delete this content?</b>{" "}
                </p>
              </div>
            </div>
          </div>
        </Modal.Body>
        <Modal.Footer className="justify-content-between">
          <button
            disabled={deleteAlbumContentMutation.isPending}
            onClick={handleClose}
            className="btn btn rounded-5"
          >
            No
          </button>

          <button
            disabled={deleteAlbumContentMutation.isPending}
            onClick={async () => {
              await deleteAlbumContent();
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
export default AlbumContentDeleteModal;
