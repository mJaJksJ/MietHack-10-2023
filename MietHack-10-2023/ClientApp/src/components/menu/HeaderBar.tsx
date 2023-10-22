import { Menubar } from "primereact/menubar";
import { MenuItem } from "primereact/menuitem";

export default function BasicDemo() {
  const items: MenuItem[] | undefined = [];

  return (
    <div className="card">
      <Menubar model={items} />
    </div>
  );
}
