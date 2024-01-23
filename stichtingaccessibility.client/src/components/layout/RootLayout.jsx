import {Outlet} from "react-router-dom";
import Navbar from "./Navbar.jsx";

function RootLayout(props) {
    return (
        <>
            <Navbar/>
            <main>
                <Outlet/>
            </main>
        </>
    );
}

export default RootLayout;
