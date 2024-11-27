import React, { useState } from "react";
import { Navigate, useParams } from "react-router";
import { usePublicAlbum } from "../api/get-public-albums";
import { AlbumPublicContentList } from "../../albums/components/album-public-content-list";
import { AlbumContentPublicModal } from "../../albums/components/album-content-public-modal";

export const AlbumPublicPage = () => {
  const { id } = useParams();
  const publicAlbumQuery = usePublicAlbum({
    key: id ?? "",
  });
  const [show, setShow] = useState(false);
  const handleClose = () => {
    setShow(false);
  };
  const handleShow = () => setShow(true);
  if (publicAlbumQuery.isLoading) {
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
  if (publicAlbumQuery.error || !publicAlbumQuery.data) {
    return <Navigate replace to="/auth/login" />;
  }

  return (
    <>
      <div className="container-fluid">
        <div className="row mt-3  ">
          <div className="col ">
            <div
              style={{
                backgroundImage: `url(${
                  publicAlbumQuery.data.backgroundUrl ?? null
                })`,
                backgroundSize: "cover",
                backgroundPosition: "center",
                backgroundRepeat: "no-repeat",
                height: "300px",
                borderRadius: "10px",
                position: "relative",
                color: "white",
              }}
              className="card rounded-4 border-0"
            >
              <div className="card-body">
                <div className="row d-flex justify-content-center">
                  <div className="col-4 col-sm-2  ">
                    <img
                      src={publicAlbumQuery.data.url}
                      className="img-fluid rounded-circle "
                    />
                  </div>
                  {/* <div className="col">
                    <h4 className=" mt-3">{publicAlbumQuery.data.name}</h4>
                  </div> */}
                </div>
                <div className="row mt-2 ">
                  <div className="col d-flex justify-content-center">
                    <h3 className=" mt-3">
                      <b> {publicAlbumQuery.data.name}</b>
                    </h3>
                  </div>
                </div>
                <div className="row mt-2 ">
                  {/* <div className="col  ">
                    <Link
                      to={"/auth/login"}
                      className="btn btn-dark rounded-5 w-100  "
                    >
                      Back
                    </Link>
                  </div> */}
                  <div className="col d-flex justify-content-center ">
                    <button
                      onClick={handleShow}
                      disabled={!publicAlbumQuery.data.allowPublicUpload}
                      className="btn btn-blue rounded-5  "
                    >
                      <i className="bi bi-camera-fill"></i> Upload Photos
                    </button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="row mt-3">
          <div className="col ">
            <AlbumPublicContentList
              albumContents={publicAlbumQuery.data.contents}
            />
          </div>
        </div>
        {show && (
          <AlbumContentPublicModal
            show={show}
            albumId={publicAlbumQuery.data.id}
            handleClose={handleClose}
          />
        )}
      </div>
    </>
  );
};
