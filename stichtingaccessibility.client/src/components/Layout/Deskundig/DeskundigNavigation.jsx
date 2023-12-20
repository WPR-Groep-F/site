import {Link} from 'react-router-dom';

import classes from './DeskundigNavigation.module.css';
function DeskundigNavigation(){
    return<header className={classes.navigation}>
        <div>LOGO</div>
        <nav>
            <ul>
                <li><Link to="">Dashboard</Link></li>
                <li><Link to="onderzoeken">Onderzoeken</Link></li>
                <li><Link to="profiel">Profiel</Link></li>
                <li><Link to="/">Logout</Link></li>
                
            </ul>
        </nav>
    </header>
}

export default DeskundigNavigation;