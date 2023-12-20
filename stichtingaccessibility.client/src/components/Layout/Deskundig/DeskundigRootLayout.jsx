import {Outlet} from 'react-router-dom';
import DeskundigNavigation from './DeskundigNavigation.jsx';
function DeskundigRootLayout(){
    return <>
        <DeskundigNavigation/>
        <main>
            <Outlet />
        </main>
    </>
}

export default DeskundigRootLayout;