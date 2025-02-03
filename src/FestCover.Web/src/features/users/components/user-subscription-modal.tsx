import { Modal } from "react-bootstrap";

import { AuthUserModel, UpdateUserSubscriptionModel } from "../types";
import { useUpdateUserSubscription } from "../api/user-update-subscription";
export type AlbumShareModalProps = {
  user: AuthUserModel;
  show: boolean;
  handleClose: () => void;
};
export const UserSubscriptionModal = ({
  show,
  user,
  handleClose,
}: AlbumShareModalProps) => {
  const updateUserSubscriptionMutation = useUpdateUserSubscription();
  async function updateUserSubscription(subscriptionType: string) {
    const userSubscription = {} as UpdateUserSubscriptionModel;
    userSubscription.subscriptionType = subscriptionType;
    const result = await updateUserSubscriptionMutation.mutateAsync(
      userSubscription
    );
    window.location.href = result;
  }
  return (
    <>
      <Modal
        backdrop="static"
        keyboard={false}
        show={show}
        onHide={handleClose}
        size="xl"
      >
        <Modal.Header closeButton>
          <Modal.Title className="ms-auto">
            <b> Subscription Plan</b>
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <div className="row">
            <div className="col">
              <div className="card rounded-3 border-0 shadow-lg mt-5">
                <div className="card-body">
                  <h5 className="card-title">Free Plan</h5>

                  <div className="row mt-3">
                    <div className="col ">
                      <div className="row">
                        <div className="col ms-4">
                          <h1>0€</h1>
                        </div>
                      </div>
                      <div className="row">
                        <div className="col">
                          <div></div>
                          <button
                            onClick={async () => {
                              await updateUserSubscription("None");
                            }}
                            disabled={
                              user.subscriptionType === "None" ||
                              updateUserSubscriptionMutation.isPending
                            }
                            className="btn btn-blue  rounded-5"
                          >
                            Choose plan
                          </button>
                        </div>
                      </div>
                    </div>
                    <div className="col ">
                      <div className="row">
                        <div className="col  d-flex justify-content-end">
                          3 Albums
                        </div>
                      </div>
                      <div className="row">
                        <div className="col  d-flex justify-content-end">
                          3G Storage
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div className="col">
              <div className="card rounded-3 border-0 shadow-lg mt-5">
                <div className="card-body">
                  <h5 className="card-title">Basic Plan</h5>

                  <div className="row mt-3">
                    <div className="col ">
                      <div className="row">
                        <div className="col ms-4">
                          <h1>8€</h1>
                        </div>
                      </div>
                      <div className="row">
                        <div className="col">
                          <button
                            onClick={async () => {
                              await updateUserSubscription("Basic");
                            }}
                            disabled={
                              user.subscriptionType === "Basic" ||
                              updateUserSubscriptionMutation.isPending
                            }
                            className="btn btn-blue  rounded-5"
                          >
                            Choose plan
                          </button>
                        </div>
                      </div>
                    </div>
                    <div className="col ">
                      <div className="row">
                        <div className="col  d-flex justify-content-end">
                          Unlimited Albums
                        </div>
                      </div>
                      <div className="row">
                        <div className="col  d-flex justify-content-end">
                          100G Storage
                        </div>
                      </div>
                      <div className="row">
                        <div className="col  d-flex justify-content-end">
                          Analytics
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div className="col">
              <div className="card rounded-3 border-0 shadow-lg mt-5">
                <div className="card-body">
                  <h5 className="card-title">Premium Plan</h5>

                  <div className="row mt-3">
                    <div className="col ">
                      <div className="row">
                        <div className="col ms-4">
                          <h1>15€</h1>
                        </div>
                      </div>
                      <div className="row">
                        <div className="col">
                          <button
                            onClick={async () => {
                              await updateUserSubscription("Premium");
                            }}
                            disabled={
                              user.subscriptionType === "Premium" ||
                              updateUserSubscriptionMutation.isPending
                            }
                            className="btn btn-blue  rounded-5"
                          >
                            Choose plan
                          </button>
                        </div>
                      </div>
                    </div>
                    <div className="col ">
                      <div className="row">
                        <div className="col  d-flex justify-content-end">
                          Unlimited Albums
                        </div>
                      </div>
                      <div className="row">
                        <div className="col  d-flex justify-content-end">
                          Unlimited Storage
                        </div>
                      </div>
                      <div className="row">
                        <div className="col  d-flex justify-content-end">
                          Analytics
                        </div>
                      </div>
                      <div className="row">
                        <div className="col  d-flex justify-content-end">
                          QR Themes
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </Modal.Body>
      </Modal>
    </>
  );
};
