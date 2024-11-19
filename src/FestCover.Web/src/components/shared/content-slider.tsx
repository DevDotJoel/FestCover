import React, { useEffect, useState } from "react";
import { Carousel, Modal } from "react-bootstrap";

export type ContentSliderPropsType = {
  contents: string[];
  contentSelected?: string;
  show: boolean;
  handleClose: () => void;
};
export const ContentSlider = ({
  show,
  contentSelected,
  contents,
  handleClose,
}: ContentSliderPropsType) => {
  const [index, setIndex] = useState(0);

  useEffect(() => {
    if (contentSelected) {
      const selectedIndex = contents.indexOf(contentSelected);
      if (selectedIndex !== -1) {
        setIndex(selectedIndex);
      }
    }
  }, [contentSelected, contents]);

  const handleSelect = (selectedIndex) => {
    setIndex(selectedIndex);
  };
  return (
    <>
      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title className="ms-auto"></Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Carousel
            interval={null}
            activeIndex={index}
            onSelect={handleSelect}
            fade={false}
          >
            {contents.map((content, index) => {
              return (
                <Carousel.Item key={index}>
                  <img
                    src={content}
                    className="img-fluid d-block  "
                    alt="..."
                  />
                </Carousel.Item>
              );
            })}
          </Carousel>
        </Modal.Body>
      </Modal>
    </>
  );
};
