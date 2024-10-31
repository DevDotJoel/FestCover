import React from "react";
import { useParams } from "react-router";
import { usePublicAlbum } from "../api/get-public-albums";
import { AlbumPublicContentList } from "../../albums/components/album-public-content-list";

export const AlbumPublicPage = () => {
  const { id } = useParams();
  const publicAlbumQuery = usePublicAlbum({
    key: id ?? "",
  });

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
    return null;
  }

  return (
    <>
      <div className="container-fluid">
        <div className="row mt-3 ">
          <div className="col">
            <div className="card rounded-4 border-0">
              <div className="card-body">
                <div className="row">
                  <div className="col-4 ">
                    <img
                      src={publicAlbumQuery.data.originalAlbumUrlImage}
                      className="img-fluid rounded-circle"
                    />
                    {/* <div className="col d-flex justify-content-end mt-2">
                    <div>
                      <button className="btn btn-blue rounded-5">
                        <i className="bi bi-plus-lg"></i> Content
                      </button>
                    </div>
                  </div> */}
                  </div>
                  <div className="col">
                    <h4 className=" mt-3">{publicAlbumQuery.data.name}</h4>
                  </div>
                </div>
                <div className="row mt-2">
                  <div className="col">
                    <button className="btn btn-blue rounded-5 w-100">
                      Back
                    </button>
                  </div>
                  <div className="col">
                    <button className="btn btn-blue rounded-5 w-100">
                      Add Content
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
      </div>
    </>
  );
};
