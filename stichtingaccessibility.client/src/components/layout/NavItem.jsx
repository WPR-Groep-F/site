import classes from "./NavItem.module.css";
import {NavLink} from "react-router-dom";

function NavItem(props) {
    return (
        <li>
            <NavLink
                to={props.Naar}
                className={({isActive}) =>
                    isActive ? classes.active : undefined
                }
                end={props.End}
            >
                <i className={props.IconClass}></i> {props.Name}
            </NavLink>
        </li>
    )
}

export default NavItem;