import { useEffect, useState } from 'react';
import {createBrowserRouter, RouterProvider} from 'react-router-dom'
import './App.css';
import Login from './pages/login/login.jsx';
import Dashboard from './pages/EVD/EvdDashboard.jsx'
import RootLayout from './components/layout/RootLayout.jsx';

const router = createBrowserRouter([
    {path: '/', element: <Login/>},
    
    {
        path: '/deskundig',
        element: <RootLayout />,
        children: [
            {index: true, element:<Dashboard/> },
        ]
    },
        
    ])
function App() {
    
    
    return <RouterProvider router={router}/>
}

export default App;