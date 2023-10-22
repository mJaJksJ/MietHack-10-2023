import { Button } from "primereact/button";
import { InputText } from "primereact/inputtext";
import { useState } from "react";
import { Password } from "primereact/password";
import { ApiService } from "../../../utils/api";
import {
  LOCAL_STORAGE_NAME,
  LOCAL_STORAGE_ROLE,
  LOCAL_STORAGE_TOKEN,
} from "../../../utils/localStorage.consts";

export const Auth = (onAuth: () => void) => {
  const api = new ApiService();
  const [login, setLogin] = useState("");
  const [password, setPassword] = useState("");

  const auth = () => {
    api.authorize(login, password).then((response) => {
      localStorage.setItem(LOCAL_STORAGE_TOKEN, response.token || "");
      localStorage.setItem(LOCAL_STORAGE_NAME, response.name || "");
      localStorage.setItem(LOCAL_STORAGE_ROLE, response.role || "");
      onAuth();
    });
  };

  return (
    <>
      <div style={{ paddingBottom: "10px", width: '250px' }}>
        <InputText
          placeholder="логин"
          onChange={(e) => setLogin(e.target.value)}
          style={{ width: "100%" }}
        />
      </div>
      <div style={{ paddingBottom: "10px", width: '250px' }}>
        <Password
          placeholder="пароль"
          onChange={(e) => setPassword(e.target.value)}
          style={{ width: "100%" }}
        />
      </div>
      <div style={{ justifyContent: "flex-end", display: "flex" }}>
        <Button style={{ borderRadius: "10px" }} onClick={() => auth()}>
          Вход
        </Button>
      </div>
    </>
  );
};
