import React, { useState } from "react";
import { AlbumContentModel } from "../types";
import AlbumContentDeleteModal from "./album-content-delete-modal";

export type AlbumContentListProps = {
  albumContents: AlbumContentModel[];
  albumId: string;
};
export const AlbumContentList = ({
  albumContents,
  albumId,
}: AlbumContentListProps) => {
  const [show, setShow] = useState(false);
  const [albumContentToDelete, setAlbumContentToDelete] =
    useState<AlbumContentModel>(null);
  const handleClose = () => {
    console.log(albumContentToDelete);
    setAlbumContentToDelete(null);
    setShow(false);
  };
  const handleShow = () => setShow(true);

  function deleteAlbumContent(albumContent: AlbumContentModel) {
    setAlbumContentToDelete(albumContent);
    handleShow();
  }
  return (
    <>
      <div className="row  row-cols-sm-4">
        {albumContents.map((albumContent: AlbumContentModel) => {
          return (
            <div key={albumContent.id} className="col-12 col-sm-3">
              <div className="card rounded-3 border-0 mt-3">
                <img
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
    </>
  );
};
