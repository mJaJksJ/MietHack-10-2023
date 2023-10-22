import React from "react";
import "./custom.css";
import "primereact/resources/themes/lara-light-indigo/theme.css";
import { RouterProvider } from "react-router-dom";
import AppRoutes from "./AppRoutes";

export const App = () => (
  <React.StrictMode>
      <RouterProvider router={AppRoutes}/>
  </React.StrictMode>
);
