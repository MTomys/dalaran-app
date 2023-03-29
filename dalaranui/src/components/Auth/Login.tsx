import React, { useState } from 'react';
import AuthActionButton from './Common/AuthActionButton';
import UsernameInput, { UsernameInputProps } from './Common/UsernameInput';
import PasswordInput, { PasswordInputProps } from './Common/PasswordInput';

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

  const handleFormSubmit = (event: React.FormEvent) => {
    event.preventDefault();
    console.log(usernameValue);
    console.log(passwordValue);
  };

  const isSubmitDisabled = !(isUsernameValid && isPasswordValid);

  return (
    <form onSubmit={handleFormSubmit}>
      <div>
        <UsernameInput {...usernameProps} />
      </div>
      <div>
        <PasswordInput {...passwordProps} />
      </div>
      <div>
        <AuthActionButton buttonName="login" disabled={isSubmitDisabled} />
      </div>
    </form>
  );
};

export default Login;
