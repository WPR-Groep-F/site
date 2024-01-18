import { createBrowserRouter, RouterProvider } from "react-router-dom";
import {QueryClientProvider,QueryClient} from "react-query";
import "./App.css";
import Login , {action as LoginAction} from "./pages/login/login.jsx";
import Dashboard from "./pages/EVD/EvdDashboard.jsx";
import RootLayout from "./components/layout/RootLayout.jsx";
import EvdProfiel from "./pages/EVD/EvdProfiel.jsx";
import EvdOnderzoeken from "./pages/EVD/EvdOnderzoeken.jsx";
import QueryTesting from "./pages/QueryTesting/QueryTesting.jsx";
import Register, {action as RegisterAction} from "./pages/login/register.jsx";


const queryClient = new QueryClient();

const router = createBrowserRouter([
  { path: "/", element: <Login /> , action: LoginAction },

  { path: "/querytesting", element: <QueryTesting /> },
  { path: "/register", element: <Register />, action: RegisterAction },
  {
    path: "/deskundig",
    element: <RootLayout />,
    children: [
      { index: true, element: <Dashboard /> },
      {path: "profiel", element: <EvdProfiel />},
      {path: "onderzoeken", element: <EvdOnderzoeken />},
          
    ],
  },
]);

function App() {
  return (
      <QueryClientProvider client={queryClient}>
        <RouterProvider router={router} />
      </QueryClientProvider>)
}

export default App;
