import {createBrowserRouter, RouterProvider} from "react-router-dom";
import {QueryClientProvider, QueryClient} from "react-query";
import "./App.css";
import Login, {action as LoginAction} from "./pages/login/login.jsx";
import Dashboard from "./pages/EVD/EvdDashboard.jsx";
import EvdProfiel from "./pages/EVD/EvdProfiel.jsx";
import EvdOnderzoeken from "./pages/EVD/EvdOnderzoeken.jsx";
import QueryTesting from "./pages/QueryTesting/QueryTesting.jsx";
import Register, {action as RegisterAction} from "./pages/login/register.jsx";
import Forgot from "./pages/login/forgot.jsx";
import ErrorPage from "./pages/ErrorPage.jsx";
import {action as logoutAction} from "./pages/login/logout.jsx"
import EvdLayout from "./components/layout/EvdLayout.jsx";
import BedrijfPortaalLayout from "./components/layout/BedrijfPortaalLayout.jsx";
import BeheerderPortaalLayout from "./components/layout/BeheerderPortaalLayout.jsx";
import Invite from "./pages/BeheederPortaal/Invite.jsx";


const queryClient = new QueryClient();

const router = createBrowserRouter([
    {path: "/", element: <Login/>, action: LoginAction, errorElement: <ErrorPage/>},
    {path: "/logout", action: logoutAction},
    {path: "/querytesting", element: <QueryTesting/>},
    {path: "/register", element: <Register/>, action: RegisterAction},
    {path: "/forgot", element: <Forgot/>,},
    {
        path: "/deskundig",
        element: <EvdLayout/>,
        children: [
            {index: true, element: <Dashboard/>},
            {path: "profiel", element: <EvdProfiel/>},
            {path: "onderzoeken", element: <EvdOnderzoeken/>},
        ],
    },
    {
        path: "/bedrijfportaal",
        element: <BedrijfPortaalLayout/>,
        children: [
            {index: true, element: <Dashboard/>},
            {path: "invite", element: <Invite/>},
        ],
    },
    {
        path: "/beheerderportaal",
        element: <BeheerderPortaalLayout/>,
        children: [
            {index: true, element: <Dashboard/>},
            {path: "invite", element: <Invite/>},
        ],
    },
]);

function App() {
    return (
        <QueryClientProvider client={queryClient}>
            <RouterProvider router={router}/>
        </QueryClientProvider>)
}

export default App;
