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
        {albumContents?.map((albumContent: AlbumContentModel) => {
          return (
            <div key={albumContent.id} className="col-12 col-sm-3">
              <div className="card rounded-3 border-0 mt-1">
                <img
                  onClick={() => {
                    setContentSelected(
                      albumContent.originalAlbumContentUrlImage
                    );
                    handleShowContent();
                  }}
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
      {albumContents.length === 0 && (
        <div className="card rounded-3 border-0 mt-1">
          <div className="card-body">
            <div className="row">
              <div className="col d-flex justify-content-center">
                <h5>No content yet... start by adding 😊</h5>
              </div>
            </div>
          </div>
        </div>
      )}
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
          contents={[
            ...albumContents.map(
              (content) => content.originalAlbumContentUrlImage
            ),
          ]}
          show={showContent}
          contentSelected={contentSelected}
          handleClose={handleContentClose}
        />
      )}
    </>
  );
};
