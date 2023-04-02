import React, { useState } from 'react';
import AuthActionButton from './Common/AuthActionButton';
import UsernameInput, { UsernameInputProps } from './Common/UsernameInput';
import PasswordInput, { PasswordInputProps } from './Common/PasswordInput';
import useLogin from '../../hooks/auth/useLogin';

const handleValidateInput = (inputValue: string) => inputValue.trim() !== '';

const Login: React.FC = () => {
  const [usernameValue, setUsernameValue] = useState('');
  const [passwordValue, setPasswordValue] = useState('');
  const [isUsernameValid, setIsUsernameValid] = useState(false);
  const [isPasswordValid, setIsPasswordValid] = useState(false);

  const loginOpts = {
    url: 'auth/login',
    payload: {
      username: usernameValue,
      password: passwordValue,
    },
  };
  const { responseCode, isLoading, login } = useLogin(loginOpts);

  const handleUsernameChange = (username: string) => {
    setUsernameValue(username);
  };
  const handlePasswordChange = (password: string) => {
    setPasswordValue(password);
  };

  const handleUsernameValidityChange = (isUsernameValid: boolean) => {
    setIsUsernameValid(isUsernameValid);
  };
  const handlePasswordValidityChange = (isPasswordValid: boolean) => {
    setIsPasswordValid(isPasswordValid);
  };

  const usernameProps: UsernameInputProps = {
    onUsernameValueChange: handleUsernameChange,
    onInputValidityChange: handleUsernameValidityChange,
    onValidateUsername: handleValidateInput,
  };
  const passwordProps: PasswordInputProps = {
    onPasswordValueChange: handlePasswordChange,
    onPasswordValidityChange: handlePasswordValidityChange,
    onValidatePassword: handleValidateInput,
  };
  const handleFormSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    await login();
  };

  const isSubmitDisabled = !(isUsernameValid && isPasswordValid);

  let infoMessage = '';
  if (isLoading) {
    infoMessage = 'Loading...';
  }
  if (responseCode === 403) {
    infoMessage = 'Invalid credentials';
  } else if (responseCode === 200) {
    infoMessage = 'Successfully logged in';
  } else if (responseCode !== undefined && responseCode >= 500) {
    infoMessage = 'An error occured';
  }

  return (
    <form onSubmit={handleFormSubmit}>
      <div>
        <UsernameInput {...usernameProps} />
      </div>
      <div>
        <PasswordInput {...passwordProps} />
      </div>
      <p>{infoMessage}</p>
      <div>
        <AuthActionButton buttonName="login" disabled={isSubmitDisabled} />
      </div>
    </form>
  );
};

export default Login;
