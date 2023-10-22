import { useState } from "react";
import HeaderBar from "./HeaderBar";
import { NavBar } from "./NavBar";
import { Dialog } from "primereact/dialog";
import { Auth } from "../pages/auth/Auth";
import { LOCAL_STORAGE_TOKEN } from "../../utils/localStorage.consts";
import './HeaderBar.css'

export const Layout = (props: any) => {
  
  const [visibleAuth, setVisibleAuth] = useState(!localStorage.getItem(LOCAL_STORAGE_TOKEN));
  
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
        <div style={{ minWidth: "300px", height: "100vh" }}>
          <NavBar />
        </div>
        {
          props.children
        }
      </div>
    </div>
  );
};
