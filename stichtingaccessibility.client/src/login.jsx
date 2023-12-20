import { useEffect, useState } from 'react';
import './App.css';
import {useNavigate} from 'react-router-dom';

const Login = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();
  const handleSubmit = (e) => {
    e.preventDefault();
    

    // Add your authentication logic here
    console.log('Username:', username);
    console.log('Password:', password);

    // Reset the form fields after submission
    setUsername('');
    setPassword('');
    
    navigate('/deskundig');
    
    
  };

  return (
    <div>
      <h2>Login</h2>
      <form onSubmit={handleSubmit}>
        <label>
          Username:
          <input type="text" value={username} onChange={(e) => setUsername(e.target.value)} />
        </label>
        <br />
        <label>
          Password:
          <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
        </label>
        <br />
        <button type="submit">Submit</button>
      </form>
    </div>
  );
};


export default Login;