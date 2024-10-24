import { useUser } from "../../../libs/auth";
import { LayoutNavbar } from "./layout.navbar";
import { SideNav } from "./sidenav";

export const MainLayout = ({ children }: any) => {
  const userQuery = useUser();

  if (userQuery.isLoading) {
    return <></>;
  }
  const user = userQuery.data;
  return (
    <>
      {!user && <LayoutNavbar />}
      <div className="container-fluid  ">
        <div className="row flex-nowrap">
          {user && (
            <div className="col-auto col-md-3 col-xl-2 px-sm-2 px-0 bg-white shadow-sm">
              <SideNav />
            </div>
          )}
          <div className="col py-3">{children}</div>
        </div>
      </div>
    </>
  );
};
