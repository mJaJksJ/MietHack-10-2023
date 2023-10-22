import HeaderBar from "./HeaderBar";
import { NavBar } from "./NavBar";

export const Layout = (props: any) => {
  return (
    <div>
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
