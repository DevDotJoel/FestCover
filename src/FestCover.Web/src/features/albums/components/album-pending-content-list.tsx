import React, { useState } from "react";
import { AlbumContentPendingModel } from "../types";
import { ContentSlider } from "../../../components/shared/content-slider";
import ApproveAlbumContentModal from "./approve-album-content-modal";
import RejectAlbumContentModal from "./reject-album-content-modal";

export type AlbumPendingContentListProps = {
  albumContents: AlbumContentPendingModel[];
};
export const AlbumPendingContentList = ({
  albumContents,
}: AlbumPendingContentListProps) => {
  const [showContent, setShowContent] = useState(false);
  const [contentSelected, setContentSelected] = useState(null);
  const [showApproveModal, setShowApproveModal] = useState(false);
  const [showRejectModal, setShowRejectModal] = useState(false);
  const [albumContent, setAlbumContent] =
    useState<AlbumContentPendingModel>(null);
  const handleContentClose = () => {
    setContentSelected(null);
    setShowContent(false);
  };

  const handleShowContent = () => setShowContent(true);
  const handleCloseShowApproveModal = () => {
    setAlbumContent(null);
    setShowApproveModal(false);
  };
  const handleShowApproveModal = () => setShowApproveModal(true);

  const handleCloseShowRejectModal = () => {
    setAlbumContent(null);
    setShowRejectModal(false);
  };
  const handleShowRejectModal = () => setShowRejectModal(true);
  return (
    <>
      <div className="row  row-cols-3 ">
        {albumContents?.map((albumContent: AlbumContentPendingModel) => {
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
                />
                <div className="card-body">
                  <h6 className="card-subtitle mb-2 text-muted">
                    <b>Album:</b>
                    {albumContent.albumName}
                  </h6>
                  <h6 className="card-subtitle mb-2 text-muted">
                    <b>By:</b>
                    {albumContent.name}
                  </h6>
                  <h6 className="card-subtitle mb-2 text-muted">
                    <b> Number:</b>
                    {albumContent.phoneNumber}
                  </h6>
                  <h6 className="card-subtitle mb-2 text-muted">
                    <b> Date:</b>
                    {albumContent.date}
                  </h6>
                  <div className="row">
                    <div className="col"></div>
                  </div>
                  <div className="row ">
                    <div className="col  ">
                      <button
                        onClick={() => {
                          setAlbumContent(albumContent);
                          handleShowApproveModal();
                        }}
                        type="button"
                        className="btn btn-blue  "
                        data-bs-toggle="dropdown"
                        aria-expanded="false"
                      >
                        <i className="bi bi-check-circle-fill "></i>
                      </button>
                    </div>
                    <div className="col d-flex justify-content-end ">
                      <button
                        onClick={() => {
                          setAlbumContent(albumContent);
                          handleShowRejectModal();
                        }}
                        type="button"
                        className="btn btn-danger  "
                        data-bs-toggle="dropdown"
                        aria-expanded="false"
                      >
                        <i className="bi bi-trash3-fill "></i>
                      </button>
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
                <h5>No pending content yet...</h5>
              </div>
            </div>
          </div>
        </div>
      )}
      {showContent && (
        <ContentSlider
          contents={[...albumContents.map((content) => content.url)]}
          show={showContent}
          contentSelected={contentSelected}
          handleClose={handleContentClose}
        />
      )}
      {showApproveModal && (
        <ApproveAlbumContentModal
          albumContent={albumContent}
          show={showApproveModal}
          handleClose={handleCloseShowApproveModal}
        />
      )}
      {showRejectModal && (
        <RejectAlbumContentModal
          albumContent={albumContent}
          show={showRejectModal}
          handleClose={handleCloseShowRejectModal}
        />
      )}
    </>
  );
};
