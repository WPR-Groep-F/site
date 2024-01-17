import { createBrowserRouter, RouterProvider } from "react-router-dom";
import {QueryClientProvider} from "react-query";
import "./App.css";
import Login from "./pages/login/login.jsx";
import Dashboard from "./pages/EVD/EvdDashboard.jsx";
import RootLayout from "./components/layout/RootLayout.jsx";
import EvdProfiel from "./pages/EVD/EvdProfiel.jsx";
import EvdOnderzoeken from "./pages/EVD/EvdOnderzoeken.jsx";
import QueryTesting from "./pages/QueryTesting/QueryTesting.jsx";

const queryClient = new QueryClientProvider();

const router = createBrowserRouter([
  { path: "/", element: <Login /> },

  { path: "/querytesting", element: <QueryTesting /> },
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
