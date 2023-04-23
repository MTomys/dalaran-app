import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useLogin, useAuth } from '@/features/auth/index';

export const LoginForm: React.FC = () => {
  const [usernameValue, setUsernameValue] = useState('');
  const [passwordValue, setPasswordValue] = useState('');

  const auth = useAuth();
  const navigate = useNavigate();

  const { isSuccess, isLoading, login } = useLogin();

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
    if (isSuccess) {
      redirectBasedOnRole();
    }
  }, [isSuccess]);

  return <form onSubmit={handleFormSubmit}></form>;
};
