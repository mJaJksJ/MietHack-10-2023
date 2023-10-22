import { useState } from "react";
import HeaderBar from "./HeaderBar";
import { NavBar } from "./NavBar";
import { Dialog } from "primereact/dialog";
import { Auth } from "../pages/auth/Auth";

export const Layout = (props: any) => {
  
  const [visibleAuth, setVisibleAuth] = useState(true);
  
  return (
    <div>
      <Dialog
        header="Авторизация"
        visible={visibleAuth}
        style={{ width: "50vw" }}
        onHide={() => setVisibleAuth(false)}
      >
        {Auth(() =>{ setVisibleAuth(false)})}
      </Dialog>

      <HeaderBar />
      <div style={{ display: "flex" }}>
        <div style={{ width: "300px", height: "100vh" }}>
          <NavBar />
        </div>
        {
          props.children
        }
      </div>
    </div>
  );
};
