import React, { useState } from "react";
import { AlbumModel } from "../types";
import { useNavigate } from "react-router-dom";
import AlbumDeleteModal from "./album-delete-moda";
import { AlbumShareModal } from "./album-share-modal";

export type AlbumListProps = {
  albums: AlbumModel[];
  edit: (album: AlbumModel) => void;
};
export const AlbumList = ({ albums, edit }: AlbumListProps) => {
  const navigate = useNavigate();
  const [show, setShow] = useState(false);
  const [albumToDelete, setAlbumToDelete] = useState<AlbumModel>(null);

  const [showAlbumToShare, setShowAlbumToShare] = useState(false);
  const [albumToShare, setAlbumToShare] = useState<AlbumModel>(null);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const handleAlbumToShareClose = () => setShowAlbumToShare(false);
  const handleAlbumToShareShow = () => setShowAlbumToShare(true);

  function deleteAlbum(album: AlbumModel) {
    setAlbumToDelete(album);
    handleShow();
  }
  return (
    <>
      <div className="row  row-cols-sm-4">
        {albums?.map((album: AlbumModel) => {
          return (
            <div key={album.id} className="col-12 col-sm-3">
              <div className="card rounded-3 border-0 mt-5 ">
                <img
                  onClick={() => navigate(`details/${album.id}`)}
                  src={album.mediumAlbumUrlImage}
                  className="card-img-top"
                  srcSet={`
                    ${album.smallAlbumUrlImage} 150w, 
                    ${album.mediumAlbumUrlImage} 500w, 
                    ${album.largeAlbumUrlImage} 1000w, 
                    ${album.originalAlbumUrlImage} 2000w
                  `}
                  sizes="(max-width: 600px) 150px, 
                  (max-width: 1200px) 500px, 
                  (max-width: 1800px) 1000px, 
                  2000px"
                />
                <div className="card-body">
                  <h5 className="card-title">{album.name}</h5>
                  <h6 className="card-subtitle mb-2 text-muted">
                    {album.description}
                  </h6>
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
                            onClick={() => edit(album)}
                            className="dropdown-item"
                            type="button"
                          >
                            Edit
                          </button>
                          <button
                            onClick={() => {
                              setAlbumToShare(album);
                              handleAlbumToShareShow();
                            }}
                            className="dropdown-item"
                            type="button"
                          >
                            Share
                          </button>
                        </li>
                        <li>
                          <button
                            onClick={() => {
                              deleteAlbum(album);
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
      {albums.length === 0 && (
        <div className="card rounded-3 border-0 mt-1">
          <div className="card-body">
            <div className="row">
              <div className="col d-flex justify-content-center">
                <h5>No albums created... start by adding 😊</h5>
              </div>
            </div>
          </div>
        </div>
      )}
      {show && (
        <AlbumDeleteModal
          album={albumToDelete}
          show={show}
          handleClose={handleClose}
        />
      )}
      {showAlbumToShare && (
        <AlbumShareModal
          album={albumToShare}
          show={showAlbumToShare}
          handleClose={handleAlbumToShareClose}
        />
      )}
    </>
  );
};
