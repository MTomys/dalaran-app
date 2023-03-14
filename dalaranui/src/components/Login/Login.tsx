import React, { useState } from 'react';

const Login: React.FC = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  const usernameChangedHandler = (event: React.FormEvent<HTMLInputElement>) => {
    setUsername(event.currentTarget.value);
  };

  const passwordChangedHandler = (event: React.FormEvent<HTMLInputElement>) => {
    setPassword(event.currentTarget.value);
  };

  const clearInputs = () => {
    setUsername('');
    setPassword('');
  };

  const handleFormSubmit = (event: React.SyntheticEvent<HTMLFormElement>) => {
    event.preventDefault();
    console.log('username => ', username);
    console.log('password => ', password);
    clearInputs();
  };

  return (
    <form onSubmit={handleFormSubmit}>
      <div>
        <label htmlFor="username" />
        <input
          type="text"
          placeholder="username"
          value={username}
          onChange={usernameChangedHandler}
        />
      </div>
      <div>
        <label htmlFor="password" />
        <input
          type="password"
          placeholder="password"
          value={password}
          onChange={passwordChangedHandler}
        />
      </div>
      <div>
        <button type="submit">Log in</button>
      </div>
    </form>
  );
};

export default Login;
