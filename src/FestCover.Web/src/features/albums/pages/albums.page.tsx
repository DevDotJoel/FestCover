import React, { useState } from "react";
import { useAlbums } from "../api/get-Albums";
import { Link } from "react-router-dom";
import { AlbumModal } from "../components/album-modal";
import { AlbumList } from "../components/album-list";
import { AlbumModel } from "../types";

export const AlbumsPage = () => {
  const albumsQuery = useAlbums({});
  const [album, setAlbum] = useState<AlbumModel>(null);
  const [show, setShow] = useState(false);
  const handleClose = () => {
    setShow(false);
    setAlbum(null);
  };
  const handleShow = () => setShow(true);
  function editAlbum(albumToEdit: AlbumModel) {
    setAlbum(albumToEdit);
    handleShow();
  }
  if (albumsQuery.isLoading) {
    return (
      <>
        <div className="container">
          <div className="row mt-3">
            <div className="col ">
              <div className="card rounded-3 border-0  " aria-hidden="true">
                <div className="card-body">
                  <div className="row">
                    <div className="col">
                      <span className="placeholder col-12"></span>
                      <span className="placeholder col-12"></span>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>

          <div className="row mt-3 d-flex justify-content-center">
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <h5 className="card-title placeholder-glow">
                    <span className="placeholder col-6"></span>
                  </h5>
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-7"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-6"></span>
                    <span className="placeholder col-8"></span>
                  </p>
                  <a className="btn btn-primary disabled placeholder col-6"></a>
                </div>
              </div>
            </div>
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <h5 className="card-title placeholder-glow">
                    <span className="placeholder col-6"></span>
                  </h5>
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-7"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-6"></span>
                    <span className="placeholder col-8"></span>
                  </p>
                  <a className="btn btn-primary disabled placeholder col-6"></a>
                </div>
              </div>
            </div>
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <h5 className="card-title placeholder-glow">
                    <span className="placeholder col-6"></span>
                  </h5>
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-7"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-6"></span>
                    <span className="placeholder col-8"></span>
                  </p>
                  <a className="btn btn-primary disabled placeholder col-6"></a>
                </div>
              </div>
            </div>
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <h5 className="card-title placeholder-glow">
                    <span className="placeholder col-6"></span>
                  </h5>
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-7"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-6"></span>
                    <span className="placeholder col-8"></span>
                  </p>
                  <a className="btn btn-primary disabled placeholder col-6"></a>
                </div>
              </div>
            </div>
          </div>
          <div className="row mt-3 d-flex justify-content-center">
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <h5 className="card-title placeholder-glow">
                    <span className="placeholder col-6"></span>
                  </h5>
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-7"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-6"></span>
                    <span className="placeholder col-8"></span>
                  </p>
                  <a className="btn btn-primary disabled placeholder col-6"></a>
                </div>
              </div>
            </div>
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <h5 className="card-title placeholder-glow">
                    <span className="placeholder col-6"></span>
                  </h5>
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-7"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-6"></span>
                    <span className="placeholder col-8"></span>
                  </p>
                  <a className="btn btn-primary disabled placeholder col-6"></a>
                </div>
              </div>
            </div>
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <h5 className="card-title placeholder-glow">
                    <span className="placeholder col-6"></span>
                  </h5>
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-7"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-6"></span>
                    <span className="placeholder col-8"></span>
                  </p>
                  <a className="btn btn-primary disabled placeholder col-6"></a>
                </div>
              </div>
            </div>
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <h5 className="card-title placeholder-glow">
                    <span className="placeholder col-6"></span>
                  </h5>
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-7"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-6"></span>
                    <span className="placeholder col-8"></span>
                  </p>
                  <a className="btn btn-primary disabled placeholder col-6"></a>
                </div>
              </div>
            </div>
          </div>
          <div className="row mt-3 d-flex justify-content-center">
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <h5 className="card-title placeholder-glow">
                    <span className="placeholder col-6"></span>
                  </h5>
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-7"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-6"></span>
                    <span className="placeholder col-8"></span>
                  </p>
                  <a className="btn btn-primary disabled placeholder col-6"></a>
                </div>
              </div>
            </div>
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <h5 className="card-title placeholder-glow">
                    <span className="placeholder col-6"></span>
                  </h5>
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-7"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-6"></span>
                    <span className="placeholder col-8"></span>
                  </p>
                  <a className="btn btn-primary disabled placeholder col-6"></a>
                </div>
              </div>
            </div>
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <h5 className="card-title placeholder-glow">
                    <span className="placeholder col-6"></span>
                  </h5>
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-7"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-6"></span>
                    <span className="placeholder col-8"></span>
                  </p>
                  <a className="btn btn-primary disabled placeholder col-6"></a>
                </div>
              </div>
            </div>
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <h5 className="card-title placeholder-glow">
                    <span className="placeholder col-6"></span>
                  </h5>
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-7"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-4"></span>
                    <span className="placeholder col-6"></span>
                    <span className="placeholder col-8"></span>
                  </p>
                  <a className="btn btn-primary disabled placeholder col-6"></a>
                </div>
              </div>
            </div>
          </div>
        </div>
      </>
    );
  }
  if (albumsQuery.error || !albumsQuery.data) {
    return null;
  }
  return (
    <>
      <div className="container">
        <div className="row mt-3">
          <div className="col ">
            <div className="card rounded-3 border-0  " aria-hidden="true">
              <div className="card-body">
                <div className="row">
                  <div className="col">
                    <h2>
                      <b>Albums</b>
                    </h2>
                    <div className="text-muted">
                      Manage and list your albums
                    </div>
                  </div>
                  <div className="col d-flex justify-content-end mt-2">
                    <div>
                      <button
                        onClick={handleShow}
                        className="btn btn-dark rounded-5"
                      >
                        <i className="bi bi-plus-lg"></i> Album
                      </button>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="row mt-3">
          <div className="col ">
            <AlbumList edit={editAlbum} albums={albumsQuery.data} />
          </div>
        </div>
      </div>
      {show && (
        <AlbumModal show={show} album={album} handleClose={handleClose} />
      )}
    </>
  );
};
