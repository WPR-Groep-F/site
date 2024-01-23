import {Outlet} from "react-router-dom";
import Navbar from "./Navbar.jsx";

function BedrijfPortaalLayout() {
    const navItems = [
        { iconClass: "bx bxs-home", name: "Home", naar: "", End: "end" },
        { iconClass: "bx bxs-user-plus", name: "Invite", naar: "invite" },

    ];
    return (
        <>
            <Navbar navItems={navItems}/>
            <main>
                <Outlet/>
            </main>
        </>
    );
}

export default BedrijfPortaalLayout;