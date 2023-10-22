import { Menubar } from "primereact/menubar";
import { MenuItem } from "primereact/menuitem";
import { LOCAL_STORAGE_NAME } from "../../utils/localStorage.consts";

export default function HeaderBar() {
  const items: MenuItem[] | undefined = [];

  return (
    <div className="card">
      <Menubar
        model={items}
        start={
          <div>
            <span className="pi pi-fw pi-slack"></span>Культурно-массовый отдел
          </div>
        }
        end={
          <div>
            <span className="pi pi-fw pi-user"></span>{localStorage.getItem(LOCAL_STORAGE_NAME) || ""}
          </div>
        }
      />
    </div>
  );
}
