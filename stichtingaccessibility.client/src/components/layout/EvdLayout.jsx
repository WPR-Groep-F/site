import {Outlet} from "react-router-dom";
import Navbar from "./Navbar.jsx";

function EvdLayout() {
    const navItems = [
        { iconClass: "bx bxs-home", name: "Home", naar: "", End: "end" },
        { iconClass: "bx bxs-user", name: "Profiel", naar: "profiel" },
        { iconClass: "bx bxs-book-open", name: "Onderzoeken", naar: "onderzoeken" },
        
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

export default EvdLayout;