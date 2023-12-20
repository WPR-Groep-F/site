import React, { useState } from "react";
import { Link } from 'react-router-dom';
import logo from "../../assets/Logo/logo_darkblue.png";
import classes from './Navbar.module.css'

function Navbar() {
    const [menuOpen, setMenuOpen] = useState(false);

    return (
        <div>
            <nav>
                <div className={classes.logo}>
                    <img src={logo} alt='logo' />
                    <h1>Accesibility</h1>
                </div>

                <div className={classes=["menu"]} onClick={() => setMenuOpen(!menuOpen)}>
                    <i class='bx bx-menu' ></i>
                </div>
                <ul>

                    <li>
                        <Link to=""><i class='bx bxs-home' ></i> Home</Link>
                    </li>
                    <li>
                        <Link to=""><i class='bx bxs-user'></i>  Profile</Link>
                    </li>
                    <li>
                        <Link to=""><i class='bx bxs-dashboard' ></i>    Dashboard</Link>
                    </li>
                </ul>
            </nav>
            <div className={classes=["bg-cirkel"]}></div>
            <div className={classes=["bg-vector"]}>
                <svg width="821" height="722" viewBox="0 0 821 722" fill="none" xmlns="http://www.w3.org/2000/svg">
                    <path d="M257.5 140C121.9 152.8 29.6667 52 0.5 0L864.5 3.5V721.5H768C469.2 683.5 519.5 532 582 461C618.5 411.167 684.5 291.1 656.5 209.5C621.5 107.5 427 124 257.5 140Z" fill="#3877FF" />
                </svg>
            </div>
        </div>
    )

}

export default Navbar;

