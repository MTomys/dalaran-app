import React, { useState } from 'react';
import AuthActionButton from './Common/AuthActionButton';
import AuthInput, { AuthInputProps } from './Common/AuthInput';

const handleValidateInput = (inputValue: string) => inputValue.trim() !== '';

const Login: React.FC = () => {
  const [usernameValue, setUsernameValue] = useState('');
  const [passwordValue, setPasswordValue] = useState('');
  const [isUsernameValid, setIsUsernameValid] = useState(false);
  const [isPasswordValid, setIsPasswordValid] = useState(false);

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

  const usernameProps: AuthInputProps = {
    name: 'username',
    inputProps: {
      id: 'username',
      type: 'text',
    },
    onValidateInput: handleValidateInput,
    invalidInputInfo: 'username invalid',
    onInputValueChange: handleUsernameChange,
    onInputValidityChange: handleUsernameValidityChange,
  };

  const passwordProps: AuthInputProps = {
    name: 'password',
    inputProps: {
      id: 'password',
      type: 'password',
    },
    onValidateInput: handleValidateInput,
    invalidInputInfo: 'password invalid',
    onInputValueChange: handlePasswordChange,
    onInputValidityChange: handlePasswordValidityChange,
  };

  const handleFormSubmit = (event: React.FormEvent) => {
    event.preventDefault();
    console.log(usernameValue);
    console.log(passwordValue);
  };

  const isSubmitDisabled = !(isUsernameValid && isPasswordValid);

  return (
    <form onSubmit={handleFormSubmit}>
      <div>
        <AuthInput {...usernameProps}></AuthInput>
      </div>
      <div>
        <AuthInput {...passwordProps}></AuthInput>
      </div>
      <div>
        <AuthActionButton buttonName="login" disabled={isSubmitDisabled} />
      </div>
    </form>
  );
};

export default Login;
