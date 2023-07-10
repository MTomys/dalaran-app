import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useLogin, useAuth, UserRole } from '@/features/auth';

export const LoginForm: React.FC = () => {
  const [usernameValue, setUsernameValue] = useState('');
  const [passwordValue, setPasswordValue] = useState('');

  const auth = useAuth();
  const navigate = useNavigate();
  const { mutate } = useLogin();

  const handleFormSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    const loginRequest = {
      username: usernameValue,
      password: passwordValue,
    };
    mutate(loginRequest, {
      onSuccess: (data) => {
        auth?.updateAuth(data);
        redirectBasedOnRole(data.role);
      },
    });
  };

  const redirectBasedOnRole = (role: UserRole) => {
    if (auth !== null) {
      if (role === 'baj') {
        navigate('/baj');
      } else if (role === 'admin') {
        navigate('/admin');
      } else if (role === 'newcomerBaj') {
        navigate('/newcomerBaj');
      }
    }
  };

  return (
    <div className="flex items-center border border-green-500 rounded-sm max-w-lg mx-auto mt-16">
      <form
        className="flex flex-col mx-auto space-y-4 bg-inherit p-4"
        onSubmit={handleFormSubmit}
      >
        <div>
          <p className="text-3xl text-green-500 text-center pb-6">Login</p>
          <p className="text-green-500 text-center pb-2 text-sm">Username</p>
          <input
            className="bg-inherit border border-green-500 rounded-sm caret-green-500 p-0.5 text-green-500"
            type="text"
            onChange={(e) => setUsernameValue(e.target.value)}
          />
        </div>
        <div>
          <p className="text-green-500 text-center pb-2 text-sm">Password</p>
          <input
            className="bg-inherit border border-green-500 rounded-sm caret-green-500 p-0.5 text-green-500"
            type="password"
            onChange={(e) => setPasswordValue(e.target.value)}
          />
        </div>
        <div className="mx-auto pt-2 pb-2">
          <button className="border border-green-500 rounded-sm text-green-500 w-32 p-0.5 hover:border-green-300 hover:text-green-300 transition">
            Login
          </button>
        </div>
      </form>
    </div>
  );
};
