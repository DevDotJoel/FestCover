import React, { useState } from "react";
import { AlbumContentModel } from "../types";
import AlbumContentDeleteModal from "./album-content-delete-modal";
import { ContentSlider } from "../../../components/shared/content-slider";

export type AlbumContentListProps = {
  albumContents: AlbumContentModel[];
  albumId: string;
};
export const AlbumContentList = ({
  albumContents,
  albumId,
}: AlbumContentListProps) => {
  const [show, setShow] = useState(false);
  const [showContent, setShowContent] = useState(false);
  const [contentSelected, setContentSelected] = useState(null);
  const [albumContentToDelete, setAlbumContentToDelete] =
    useState<AlbumContentModel>(null);
  const handleClose = () => {
    setAlbumContentToDelete(null);
    setShow(false);
  };
  const handleShow = () => setShow(true);
  const handleContentClose = () => {
    setContentSelected(null);
    setShowContent(false);
  };

  const handleShowContent = () => setShowContent(true);

  function deleteAlbumContent(albumContent: AlbumContentModel) {
    setAlbumContentToDelete(albumContent);
    handleShow();
  }
  return (
    <>
      <div className="row  row-cols-sm-4 ">
        {albumContents.map((albumContent: AlbumContentModel) => {
          return (
            <div key={albumContent.id} className="col-12 col-sm-3">
              <div className="card rounded-3 border-0 mt-1">
                <img
                  onClick={() => {
                    setContentSelected(albumContent.url);
                    handleShowContent();
                  }}
                  src={albumContent.url}
                  className="card-img-top"
                  alt="..."
                  width={200}
                />
                <div className="card-body">
                  <div className="row">
                    <div className="col d-flex justify-content-end ">
                      <button
                        type="button"
                        className="btn btn  "
                        data-bs-toggle="dropdown"
                        aria-expanded="false"
                      >
                        <i className="bi bi-three-dots "></i>
                      </button>
                      <ul className="dropdown-menu">
                        <li>
                          <button
                            onClick={() => {
                              deleteAlbumContent(albumContent);
                            }}
                            className="dropdown-item text-danger"
                            type="button"
                          >
                            Delete
                          </button>
                        </li>
                      </ul>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          );
        })}
      </div>

      {show && (
        <AlbumContentDeleteModal
          albumContent={albumContentToDelete}
          show={show}
          handleClose={handleClose}
          albumId={albumId}
        />
      )}
      {showContent && (
        <ContentSlider
          contents={[...albumContents.map((content) => content.url)]}
          show={showContent}
          contentSelected={contentSelected}
          handleClose={handleContentClose}
        />
      )}
    </>
  );
};
