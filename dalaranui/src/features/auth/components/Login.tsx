import React, { useEffect, useState } from 'react';
import AuthActionButton from './Common/AuthActionButton';
import UsernameInput, { UsernameInputProps } from './Common/UsernameInput';
import PasswordInput, { PasswordInputProps } from './Common/PasswordInput';
import useAuth from '../../hooks/auth/useAuth';
import useLogin from '../../hooks/auth/useLogin';
import { useNavigate } from 'react-router-dom';

const handleValidateInput = (inputValue: string) => inputValue.trim() !== '';

const Login: React.FC = () => {
  const [usernameValue, setUsernameValue] = useState('');
  const [passwordValue, setPasswordValue] = useState('');
  const [isUsernameValid, setIsUsernameValid] = useState(false);
  const [isPasswordValid, setIsPasswordValid] = useState(false);
  const auth = useAuth();
  const navigate = useNavigate();

  const loginOpts = {
    url: 'auth/login',
    payload: {
      username: usernameValue,
      password: passwordValue,
    },
  };
  const { responseCode, isLoading, login, infoMessage } = useLogin(loginOpts);

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

  const redirectBasedOnRole = () => {
    if (auth !== null) {
      const role = auth?.authState?.role;
      console.log(role);
      if (role === 'baj') {
        navigate('/baj');
      } else if (role === 'admin') {
        navigate('/admin');
      } else if (role === 'newcomerBaj') {
        navigate('/newcomerBaj');
      }
    }
  };

  useEffect(() => {
    if (responseCode === 200) {
      redirectBasedOnRole();
    }
  }, [responseCode]);

  const isSubmitDisabled = !(isUsernameValid && isPasswordValid) || isLoading;

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
