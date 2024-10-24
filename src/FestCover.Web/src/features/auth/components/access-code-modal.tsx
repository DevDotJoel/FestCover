import { Modal } from "react-bootstrap";
import ReactCodeInput from "react-code-input";

export type AccessCodeModalProps = {
  show: boolean;
  handleClose: () => void;
};
export const AccessCodeModal = ({
  show,

  handleClose,
}: AccessCodeModalProps) => {
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
              />
            </div>
          </div>
        </Modal.Body>
        <Modal.Footer className="justify-content-between">
          <button onClick={handleClose} className="btn btn-dark rounded-5">
            Cancel
          </button>

          <button className="btn btn-dark rounded-5">Submit</button>
        </Modal.Footer>
      </Modal>
    </>
  );
};
