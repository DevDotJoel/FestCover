import React, { useState } from "react";
import { AlbumContentModel } from "../types";
import { ContentSlider } from "../../../components/shared/content-slider";

export type AlbumPublicContentListProps = {
  albumContents: AlbumContentModel[];
};
export const AlbumPublicContentList = ({
  albumContents,
}: AlbumPublicContentListProps) => {
  const [showContent, setShowContent] = useState(false);
  const [contentSelected, setContentSelected] = useState(null);

  const handleContentClose = () => {
    setContentSelected(null);
    setShowContent(false);
  };

  const handleShowContent = () => setShowContent(true);

  return (
    <>
      <div className="row  row-cols-3 ">
        {albumContents?.map((albumContent: AlbumContentModel) => {
          return (
            <div key={albumContent.id} className="col mt-2">
              <img
                onClick={() => {
                  setContentSelected(albumContent.url);
                  handleShowContent();
                }}
                src={albumContent.url}
                className="card-img-top"
              />
            </div>
          );
        })}
      </div>
      {showContent && (
        <ContentSlider
          contents={[...albumContents.map((content) => content.url)]}
          show={showContent}
          contentSelected={contentSelected}
          handleClose={handleContentClose}
        />
      )}
    </>
  );
};
