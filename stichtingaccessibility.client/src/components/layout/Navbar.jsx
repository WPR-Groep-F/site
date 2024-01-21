import React, {useState} from "react";
import {NavLink, Form} from "react-router-dom";
import logo from "../../assets/Logo/logo_darkblue.png";
import classes from "./Navbar.module.css";
import './Navbar.module.css'

function Navbar() {
    const [menuOpen, setMenuOpen] = useState(false);
    const toggleMenu = () => {
        setMenuOpen(!menuOpen);
    }

    return (
        <header>
            <nav>
                <div className={classes.logo}>
                    <img src={logo} alt="logo"/>
                    <h1>Accesibility</h1>
                </div>

                <div className={classes["menu"]} onClick={toggleMenu}>
                    <i className="bx bx-menu"></i>
                </div>
                <ul className={`${classes.navList} ${menuOpen ? 'menu-open' : 'menu-closed'}`}>
                    <li>
                        <NavLink
                            to=""
                            className={({isActive}) =>
                                isActive ? classes.active : undefined
                            }
                            end
                        >
                            <i className="bx bxs-home"></i> Home
                        </NavLink>
                    </li>
                    <li>
                        <NavLink
                            to="profiel"
                            className={({isActive}) =>
                                isActive ? classes.active : undefined
                            }
                        >
                            <i className="bx bxs-user"></i> Profile
                        </NavLink>
                    </li>
                    <li>
                        <NavLink
                            to="Onderzoeken"
                            className={({isActive}) =>
                                isActive ? classes.active : undefined
                            }
                        >
                            <i className="bx bxs-book-open"></i> Onderzoeken
                        </NavLink>
                    </li>
                    <li>
                        <Form action="/logout" method="post">
                            <button>Logout</button>
                        </Form>

                    </li>
                </ul>
            </nav>
            <div className={classes["bg-cirkel"]}></div>
            <div className={classes["bg-vector"]}>
                <svg
                    width="821"
                    height="722"
                    viewBox="0 0 821 722"
                    fill="none"
                    xmlns="http://www.w3.org/2000/svg"
                >
                    <path
                        d="M257.5 140C121.9 152.8 29.6667 52 0.5 0L864.5 3.5V721.5H768C469.2 683.5 519.5 532 582 461C618.5 411.167 684.5 291.1 656.5 209.5C621.5 107.5 427 124 257.5 140Z"
                        fill="#3877FF"
                    />
                </svg>
            </div>
        </header>
    );
}

export default Navbar;