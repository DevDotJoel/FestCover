import { useState } from "react";
import { Modal } from "react-bootstrap";
import ReactCodeInput from "react-code-input";
import { useNavigate } from "react-router";

export type AccessCodeModalProps = {
  show: boolean;
  handleClose: () => void;
};
export const AccessCodeModal = ({
  show,

  handleClose,
}: AccessCodeModalProps) => {
  const navigate = useNavigate();
  const [value, setValue] = useState<string>("");
  const [isValid, setIsValid] = useState<boolean>(false);
  // const deleteSurveyMutation = useDeleteSurvey();

  // async function deleteSurvey() {
  //   await deleteSurveyMutation.mutateAsync({ surveyId: survey.id });
  //   handleClose();
  // }

  return (
    <>
      <Modal
        backdrop="static"
        keyboard={false}
        show={show}
        onHide={handleClose}
      >
        <Modal.Header closeButton>
          <Modal.Title className="ms-auto">
            <b> Access Code</b>
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <div className="row mt-3">
            <div className="col d-flex justify-content-center">
              <ReactCodeInput
                inputMode="katakana"
                name="Access Code"
                type="password"
                fields={8}
                value={value}
                onChange={(data) => {
                  setValue(data);
                }}
              />
            </div>
          </div>
        </Modal.Body>
        <Modal.Footer className="justify-content-between">
          <button onClick={handleClose} className="btn btn-blue rounded-5">
            Cancel
          </button>

          <button
            disabled={value.length === 8 ? false : true}
            className="btn btn-blue rounded-5"
            onClick={() => {
              navigate(`/p/${value}`);
            }}
          >
            Submit
          </button>
        </Modal.Footer>
      </Modal>
    </>
  );
};
