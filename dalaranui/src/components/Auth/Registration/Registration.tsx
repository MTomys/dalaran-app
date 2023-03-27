import React, { useState } from 'react';

const Registration: React.FC = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [repassword, setRePassword] = useState('');

  const usernameChangedHandler = (event: React.FormEvent<HTMLInputElement>) => {
    setUsername(event.currentTarget.value);
  };

  const passwordChangedHandler = (event: React.FormEvent<HTMLInputElement>) => {
    setPassword(event.currentTarget.value);
  };

  const rePasswordChangedHandler = (
    event: React.FormEvent<HTMLInputElement>
  ) => {
    setRePassword(event.currentTarget.value);
  };

  const clearInputs = () => {
    setUsername('');
    setPassword('');
    setRePassword('');
  };

  const handleFormSubmit = (event: React.SyntheticEvent<HTMLFormElement>) => {
    event.preventDefault();
    console.log('username => ', username);
    console.log('password => ', password);
    console.log('repassword => ', repassword);
    clearInputs();
  };

  return (
    <form onSubmit={handleFormSubmit}>
      <p>Welcome</p>
      <p>Register</p>
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
        <label htmlFor="repassword" />
        <input
          type="password"
          placeholder="re-enter password"
          value={password}
          onChange={rePasswordChangedHandler}
        />
      </div>
      <div>
        <button type="submit">Register</button>
      </div>
    </form>
  );
};

export default Registration;
