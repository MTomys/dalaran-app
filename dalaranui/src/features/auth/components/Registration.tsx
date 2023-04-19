import React, { useState } from 'react';
import UsernameInput, { UsernameInputProps } from './Common/UsernameInput';
import PasswordInput, { PasswordInputProps } from './Common/PasswordInput';
import ReEnterPasswordInput, {
  ReEnterPasswordInputProps,
} from './Common/ReEnterPasswordInput';
import AuthActionButton from './Common/AuthActionButton';
import axios from '../../api/axios';

const handleValidateUsername = (username: string) => {
  return true;
};

const handleValidatePassword = (password: string) => {
  return true;
};

const handleValidateReEnterPassword = (reEnterPassword: string) => {
  return true;
};

const Registration: React.FC = () => {
  const [usernameValue, setUsernameValue] = useState('');
  const [passwordValue, setPasswordValue] = useState('');
  const [reEnterPasswordValue, setreEnterPasswordValue] = useState('');

  const [isUsernameValid, setIsUsernameValid] = useState(false);
  const [isPasswordValid, setIsPasswordValid] = useState(false);
  const [isReEnterPasswordValid, setIsReEnterPasswordValid] = useState(false);

  const handleUsernameChange = (username: string) => setUsernameValue(username);
  const handlePasswordChange = (password: string) => setPasswordValue(password);
  const handleReEnterPasswordChange = (reEnterPassword: string) =>
    setreEnterPasswordValue(reEnterPassword);

  const handleUsernameValidityChange = (isUsernameValid: boolean) => {
    setIsUsernameValid(isUsernameValid);
  };
  const handlePasswordValidityChange = (isPasswordValid: boolean) => {
    setIsPasswordValid(isPasswordValid);
  };
  const handleReEnterPasswordValidityChange = (
    isReEnterPasswordValid: boolean
  ) => {
    setIsReEnterPasswordValid(isReEnterPasswordValid);
  };

  const usernameProps: UsernameInputProps = {
    onUsernameValueChange: handleUsernameChange,
    onInputValidityChange: handleUsernameValidityChange,
    onValidateUsername: handleValidateUsername,
  };
  const passwordProps: PasswordInputProps = {
    onPasswordValueChange: handlePasswordChange,
    onPasswordValidityChange: handlePasswordValidityChange,
    onValidatePassword: handleValidatePassword,
  };
  const reEnterPasswordProps: ReEnterPasswordInputProps = {
    onReEnterPasswordValueChange: handleReEnterPasswordChange,
    onReEnterPasswordValidityChange: handleReEnterPasswordValidityChange,
    onValidateReenterPassword: handleValidateReEnterPassword,
  };

  const handleFormSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    await register();
  };

  const isSubmitDisabled = !(
    isUsernameValid &&
    isPasswordValid &&
    isReEnterPasswordValid
  );

  const register = async () => {
    try {
      const body = JSON.stringify({
        username: usernameValue,
        password: passwordValue,
        requestMessage: 'test',
      });
      const response = await axios.post('/auth/register', body);
      console.log(response);
    } catch (err) {
      console.error(err);
    }
  };

  return (
    <form onSubmit={handleFormSubmit}>
      <div>
        <UsernameInput {...usernameProps} />
      </div>
      <div>
        <PasswordInput {...passwordProps} />
      </div>
      <div>
        <ReEnterPasswordInput {...reEnterPasswordProps} />
      </div>
      <div>
        <AuthActionButton buttonName="register" disabled={isSubmitDisabled} />
      </div>
    </form>
  );
};

export default Registration;
