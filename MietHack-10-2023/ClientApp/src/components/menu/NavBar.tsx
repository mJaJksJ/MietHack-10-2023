import { PanelMenu } from "primereact/panelmenu";
import { MenuItem, MenuItemOptions } from "primereact/menuitem";
import "primereact/resources/themes/lara-light-indigo/theme.css";
import "primeicons/primeicons.css";
import { NavLink } from "react-router-dom";
import "./NavBar.css";

export const NavBar = () => {
  const directorItems: MenuItem[] = [
    {
      template: (item: MenuItem, options: MenuItemOptions) => {
        return (
            <NavLink className='navbar' style={{'width': '100%'}} to="/home">
                <span className="pi pi-fw pi-home"> </span>Главная страница      
            </NavLink>
        );
      },
    },
    {
      template: (item: MenuItem, options: MenuItemOptions) => {
        return (
            <NavLink className='navbar' style={{'width': '100%'}} to="/members">
                <span className="pi pi-fw pi-users"> </span>Состав СО      
            </NavLink>
        );
      },
    },
    {
      template: (item: MenuItem, options: MenuItemOptions) => {
        return (
            <NavLink className='navbar' style={{'width': '100%'}} to="/documentation">
                <span className="pi pi-fw pi-file"> </span>Документация СО  
            </NavLink>
        );
      },
    },
    {
      template: (item: MenuItem, options: MenuItemOptions) => {
        return (
            <NavLink className='navbar' style={{'width': '100%'}} to="/projects">
                <span className="pi pi-fw pi-images"> </span>Проекты СО     
            </NavLink>
        );
      },
    },
    {
      template: (item: MenuItem, options: MenuItemOptions) => {
        return (
            <NavLink className='navbar' style={{'width': '100%'}} to="/send-documents">
                <span className="pi pi-fw pi-send"> </span>Отправка документов     
            </NavLink>
        );
      },
    },
    {
      template: (item: MenuItem, options: MenuItemOptions) => {
        return (
            <NavLink className='navbar' style={{'width': '100%'}} to="/contacts">
                <span className="pi pi-fw pi-info-circle"></span>Контактная информация     
            </NavLink>
        );
      },
    },
  ];

  return (
    <div className="card flex" style={{ height: "100%" }}>
      <PanelMenu model={directorItems} className="w-full md:w-25rem" />
    </div>
  );
}
