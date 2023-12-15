import { useEffect, useState } from 'react';
import './App.css';

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

  export default function App() {
    return (
        <div>
        <h1>Welcome to my app</h1>
        <MyForm />
      </div>
    );
  }
