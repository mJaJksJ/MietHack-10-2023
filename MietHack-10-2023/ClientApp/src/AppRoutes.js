import { Documentation } from "./components/pages/documentation/Documentation";
import { Home } from "./components/pages/home/Home";
import { Members } from "./components/pages/members/Members";
import { createBrowserRouter } from "react-router-dom";
import { Projects } from "./components/pages/projects/Projects";
import { SendDocumentation } from "./components/pages/send-documentation/SendDocumentation";
import { Contracts } from "./components/pages/contacts/Contracts";

const AppRoutes = createBrowserRouter([
  {
    path: "/",
    element: <Home />,
  },
  {
    path: "/home",
    element: <Home />,
  },
  {
    path: "/members",
    element: <Members />,
  },
  {
    path: "/documentation",
    element: <Documentation />,
  },
  {
    path: "/projects",
    element: <Projects />,
  },
  {
    path: "/send-documents",
    element: <SendDocumentation />,
  },
  {
    path: "/contacts",
    element: <Contracts />,
  },
]);

export default AppRoutes;
