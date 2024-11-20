import { LoginForm } from "../components/login-form";
import { useLogin } from "../../../libs/auth";
import { useNavigate } from "react-router-dom";
import { useState } from "react";
import { AccessCodeModal } from "../components/access-code-modal";
import { toast } from "react-toastify";
import { API_URL } from "../../../config/env";

export const LoginPage = () => {
  const login = useLogin();
  const navigate = useNavigate();
  const [show, setShow] = useState(false);
  const handleClose = () => {
    setShow(false);
  };
  const handleShow = () => setShow(true);
  async function onSubmit(data: any) {
    await login.mutateAsync(data);
    navigate("/albums");
  }
  return (
    <>
      <div className="d-flex justify-content-center align-items-center mt-5">
        <div className="row ">
          <div className="col ">
            <div className="card rounded-3 border-0">
              <div className="card-body  ">
                <div className="row ">
                  <div className="col d-flex justify-content-center">
                    <h3>
                      <b>Fest Cover </b>
                    </h3>
                  </div>
                </div>
                <div className="row mt-2">
                  <div className="col">
                    <LoginForm
                      onSubmit={onSubmit}
                      disableFields={login.isPending}
                    />
                  </div>
                </div>
                <hr />
                <div className="row mt-1">
                  <div className="col ">
                    <form
                      method="POST"
                      action={`${API_URL}api/auth/external-login?provider=Google&returnUrl=/home`}
                    >
                      <button className="btn btn-danger rounded-5 w-100">
                        <i className="bi bi-google"></i> Google
                      </button>
                    </form>
                  </div>
                </div>
                <hr />
                <div className="row mt-1">
                  <div className="col ">
                    <div>
                      <button
                        disabled={login.isPending}
                        onClick={handleShow}
                        className="btn btn-blue rounded-5 w-100"
                      >
                        Enter Code
                      </button>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      {show && <AccessCodeModal show={show} handleClose={handleClose} />}
    </>
  );
};
