import { Menubar } from "primereact/menubar";
import { MenuItem } from "primereact/menuitem";
import {
  LOCAL_STORAGE_NAME,
  LOCAL_STORAGE_TOKEN,
} from "../../utils/localStorage.consts";
import { ApiService } from "../../utils/api";

export default function HeaderBar(updateState: () => void) {
  const api = new ApiService();

  const items: MenuItem[] | undefined = [
    {
      label: localStorage.getItem(LOCAL_STORAGE_NAME) || "",
      icon: "pi pi-fw pi-user",
      items: [
        {
          label: "Выход",
          icon: "pi pi-fw pi-trash",
          command: (event) => {
            api.deAuth();
            updateState();
          },
        },
      ],
    },
  ];
  const menubar = () => {
    if (localStorage.getItem(LOCAL_STORAGE_TOKEN)) {
      return <Menubar model={items} style={{ width: "80%" }} />;
    }
    return <></>;
  };

  return (
    <div className="card" style={{ display: "flex", flexDirection: "row" }}>
      <div
        style={{
          width: "20%",
          display: "flex",
          alignItems: "center",
          paddingLeft: "10px",
        }}
      >
        <div>
          <span className="pi pi-fw pi-slack"></span>Культурно-массовый отдел
        </div>
      </div>
      {menubar()}
    </div>
  );
}
