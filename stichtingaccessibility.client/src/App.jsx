import { useEffect, useState } from 'react';
import {createBrowserRouter, RouterProvider, } from 'react-router-dom'
import './App.css';
import DeskundigDashboard from "./pages/Deskundig/DeskundigDashboard.jsx";
import DeskundigOnderzoeken from "./pages/Deskundig/DeskundigOnderzoeken.jsx";
import DeskundigProfiel from "./pages/Deskundig/DeskundigProfiel.jsx";
import DeskundigRootLayout from "./components/Layout/Deskundig/DeskundigRootLayout.jsx";
import Login from "./login.jsx";

const  router = createBrowserRouter([
    {path: '/', element: <Login/>},
    
    {
        path: '/deskundig',
        element: <DeskundigRootLayout />,
        children: [
            {index: true, element:<DeskundigDashboard/> },
            {path: "onderzoeken", element: <DeskundigOnderzoeken/>},
            {path: "profiel", element: <DeskundigProfiel/>},
        ]
    },
        
    ])

function MyButton() {
    return (
      <button>I'm a button</button>
    );
  }

  function MyForm() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
  
    const handleSubmit = (e) => {
      e.preventDefault();
      console.log('Email:', email);
      console.log('Password:', password);
    };

    return (
        <form onSubmit={handleSubmit}>
          <label>
            Email:
            <input type="email" value={email} onChange={(e) => setEmail(e.target.value)} />
          </label>
          <br />
          <label>
            Password:
            <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
          </label>
          <br />
          <button type="submit">Submit</button>
        </form>
      );
    }
    
function App() {
    return (
        <RouterProvider router={router}>
      </RouterProvider>
    );
  }
  
  export default  App;
