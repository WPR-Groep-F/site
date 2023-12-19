import { useEffect, useState } from 'react';
import {createBrowserRouter, RouterProvider} from 'react-router-dom'
import './App.css';
import Home from "./components/Home.jsx";
import Dashboard from "./components/EvdDashboard.jsx"
import Login from './components/login/login.jsx';


const  router = createBrowserRouter(
    [
        {path: '/',element: <Login/>},
        {path: '/dashboard', element:<Dashboard/> }
    ])
function App() {
    
    
    return <RouterProvider router={router}/>
}

export default App;