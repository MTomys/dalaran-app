import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useLogin, useAuth } from '@/features/auth';
import { ValidatableFormInput, FormSubmitButton } from '@/index';

const isStringNotEmpty = (s: string) => s.trim().length > 0;

export const LoginForm: React.FC = () => {
  const [usernameValue, setUsernameValue] = useState('');
  const [usernameValid, setUsernameValid] = useState(false);
  const [passwordValue, setPasswordValue] = useState('');
  const [passwordValid, setPasswordValid] = useState(false);

  const auth = useAuth();
  const navigate = useNavigate();

  const { isLoading, loginStatus, login } = useLogin();

  const handleFormSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    const loginRequest = {
      username: usernameValue,
      password: passwordValue,
    };
    await login(loginRequest);
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
    if (loginStatus === 'Login successful') {
      redirectBasedOnRole();
    }
  }, [loginStatus]);

  return (
    <form onSubmit={handleFormSubmit}>
      <ValidatableFormInput
        name="username"
        inputProps={{ id: 'username', type: 'text' }}
        onValidateInput={isStringNotEmpty}
        invalidInputInfo="Username cannot be empty"
        onInputValueChange={(value) => setUsernameValue(value)}
        onInputValidityChange={(value) => setUsernameValid(value)}
      />
      <ValidatableFormInput
        name="password"
        inputProps={{ id: 'password', type: 'password' }}
        onValidateInput={isStringNotEmpty}
        invalidInputInfo="Password cannot be empty"
        onInputValueChange={(value) => setPasswordValue(value)}
        onInputValidityChange={(value) => setPasswordValid(value)}
      />
      <FormSubmitButton buttonName="login" disabled={false} />
      <p>{loginStatus}</p>
    </form>
  );
};
