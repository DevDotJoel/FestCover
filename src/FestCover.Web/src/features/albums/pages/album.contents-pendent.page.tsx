import React, { useState } from "react";
import { useAlbumPendingContents } from "../api/get-albums-pending-content";
import { AlbumPendingContentList } from "../components/album-pending-content-list";

export const AlbumContentPendentPage = () => {
  const albumsPendingContentsQuery = useAlbumPendingContents({});
  const [show, setShow] = useState(false);
  const handleClose = () => {
    setShow(false);
  };
  const handleShow = () => setShow(true);
  if (albumsPendingContentsQuery.isLoading) {
    return (
      <>
        <div className="container">
          <div className="row mt-3">
            <div className="col ">
              <div className="card rounded-3 border-0  " aria-hidden="true">
                <div className="card-body">
                  <div className="row">
                    <div className="col">
                      <span className="placeholder col-12 placeholder"></span>
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
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                  </p>
                </div>
              </div>
            </div>
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                  </p>
                </div>
              </div>
            </div>
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                  </p>
                </div>
              </div>
            </div>
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                  </p>
                </div>
              </div>
            </div>
          </div>
          <div className="row mt-3 d-flex justify-content-center">
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                  </p>
                </div>
              </div>
            </div>
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                  </p>
                </div>
              </div>
            </div>
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                  </p>
                </div>
              </div>
            </div>
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                  </p>
                </div>
              </div>
            </div>
          </div>
          <div className="row mt-3 d-flex justify-content-center">
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                  </p>
                </div>
              </div>
            </div>
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                  </p>
                </div>
              </div>
            </div>
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                  </p>
                </div>
              </div>
            </div>
            <div className="col ">
              <div className="card rounded-3 border-0 " aria-hidden="true">
                <div className="card-body">
                  <p className="card-text placeholder-glow">
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                    <span className="placeholder col-12"></span>
                  </p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </>
    );
  }
  if (albumsPendingContentsQuery.error || !albumsPendingContentsQuery.data) {
    return null;
  }
  return (
    <>
      <div className="container">
        <div className="row mt-3  ">
          <div className="col ">
            <div className="card rounded-3 border-0    " aria-hidden="true">
              <div className="card-body">
                <div className="row">
                  <div className="col">
                    <h2>
                      <b>Pending Content</b>
                    </h2>
                    <div className="text-muted">
                      List of pending approval content
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="row mt-3">
          <div className="col">
            <AlbumPendingContentList
              albumContents={albumsPendingContentsQuery.data}
            />
          </div>
        </div>
      </div>
    </>
  );
};
