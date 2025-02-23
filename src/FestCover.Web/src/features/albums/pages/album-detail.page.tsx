import { useState } from "react";
import { useParams } from "react-router";
import { useAlbumContents } from "../api/get-Album-Contents";
import { AlbumContentList } from "../components/album-content-list";
import { AlbumContentModal } from "../components/album-content-modal";
import { saveAs } from "file-saver";
import { useAlbumContentDownloadUrl } from "../api/get-album-download-url";
export const AlbumDetailPage = () => {
  const { id } = useParams();
  const albumContentsQuery = useAlbumContents({
    albumId: id ?? "",
  });
  const albumDownloadUrlQuery = useAlbumContentDownloadUrl({
    albumId: id,
    queryConfig: {
      enabled: false,
    },
  });
  const [show, setShow] = useState(false);
  const handleClose = () => {
    setShow(false);
  };
  const handleShow = () => setShow(true);
  if (albumContentsQuery.isLoading) {
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
  if (albumContentsQuery.error || !albumContentsQuery.data) {
    return null;
  }

  async function downloadImages() {
    const { data } = await albumDownloadUrlQuery.refetch();
    saveAs(data, crypto.randomUUID() + ".zip");
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
                      <b>Album Contents</b>
                    </h2>
                    <div className="text-muted">List your album content</div>
                  </div>
                  <div className="col d-flex justify-content-end mt-2">
                    <div>
                      <button
                        disabled={albumDownloadUrlQuery.isFetching}
                        onClick={handleShow}
                        className="btn btn-blue rounded-5"
                      >
                        <i className="bi bi-plus-lg"></i> Content
                      </button>
                    </div>
                  </div>
                </div>
                <div className="row">
                  <div className="col d-flex justify-content-end">
                    <div>
                      <button
                        onClick={downloadImages}
                        className="btn btn-blue rounded-5"
                      >
                        <i className="bi bi-download"></i>
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
            <AlbumContentList
              albumId={id}
              albumContents={albumContentsQuery.data}
            />
          </div>
        </div>
        {show && (
          <AlbumContentModal
            albumId={id}
            show={show}
            handleClose={handleClose}
          />
        )}
      </div>
    </>
  );
};
