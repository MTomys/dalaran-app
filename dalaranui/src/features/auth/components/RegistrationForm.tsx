import React, { useState } from 'react';
import { axios } from '@/lib/axios';
import { ValidatableFormInput, FormSubmitButton } from '@/index';

export const RegistrationForm: React.FC = () => {
  const [usernameValue, setUsernameValue] = useState('');
  const [passwordValue, setPasswordValue] = useState('');
  const [reEnterPasswordValue, setreEnterPasswordValue] = useState('');

  const handleFormSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    await register();
  };

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
    <div className="flex items-center border border-green-500 rounded-sm max-w-lg mx-auto mt-16">
      <form
        className="flex flex-col mx-auto space-y-4 bg-inherit p-4"
        onSubmit={handleFormSubmit}
      >
        <div>
          <p className="text-2xl text-green-500 text-center pb-6 ">
            Request account
          </p>
          <p className="text-green-500 text-center pb-2 text-sm">
            Preffered username
          </p>
          <input
            className="bg-inherit border border-green-500 rounded-sm caret-green-500 p-0.5"
            type="text"
            onChange={(e) => setUsernameValue(e.target.value)}
          />
        </div>
        <div>
          <p className="text-green-500 text-center pb-2 text-sm">Password</p>
          <input
            className="bg-inherit border border-green-500 rounded-sm caret-green-500 p-0.5"
            type="text"
            onChange={(e) => setPasswordValue(e.target.value)}
          />
        </div>
        <div>
          <p className="text-green-500 text-center pb-2 text-sm">
            Re-enter password
          </p>
          <input
            className="bg-inherit border border-green-500 rounded-sm caret-green-500 p-0.5"
            type="text"
            onChange={(e) => setreEnterPasswordValue(e.target.value)}
          />
        </div>
        <div className="mx-auto pt-2 pb-2">
          <button className="border border-green-500 rounded-sm text-green-500 text-sm w-44 p-2 hover:border-green-300 hover:text-green-300 transition">
            Request registration
          </button>
        </div>
      </form>
    </div>
  );
};

export default RegistrationForm;
