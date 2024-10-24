import React, { useState } from "react";
import { AlbumModel } from "../types";
import { useNavigate } from "react-router-dom";
import AlbumDeleteModal from "./album-delete-moda";

export type AlbumListProps = {
  albums: AlbumModel[];
  edit: (album: AlbumModel) => void;
};
export const AlbumList = ({ albums, edit }: AlbumListProps) => {
  const navigate = useNavigate();
  const [show, setShow] = useState(false);
  const [albumToDelete, setAlbumToDelete] = useState<AlbumModel>(null);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  function deleteAlbum(album: AlbumModel) {
    setAlbumToDelete(album);
    handleShow();
  }
  return (
    <>
      <div className="row  row-cols-sm-4">
        {albums.map((album: AlbumModel) => {
          return (
            <div key={album.id} className="col-12 col-sm-3">
              <div className="card rounded-3 border-0 mt-5 ">
                <img
                  onClick={() => navigate(`details/${album.id}`)}
                  src={album.albumUrlImage}
                  className="card-img-top"
                  alt="..."
                  width={200}
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
                  {/* <div className="row">
                    <div className="col ">
                      <button className="btn btn-outline-dark w-100">
                        Delete
                      </button>
                    </div>
                    <div className="col">
                      <button
                        // to={`details/${album.id}`}
                        className="btn btn-dark w-100"
                      >
                        Edit
                      </button>
                    </div>
                  </div> */}
                </div>
              </div>
            </div>
          );
        })}
      </div>
      {show && (
        <AlbumDeleteModal
          album={albumToDelete}
          show={show}
          handleClose={handleClose}
        />
      )}
    </>
  );
};
