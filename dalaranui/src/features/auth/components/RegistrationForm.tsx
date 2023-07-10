import React, { useState } from 'react';
import { axios } from '@/lib/axios';

export const RegistrationForm: React.FC = () => {
  const [usernameValue, setUsernameValue] = useState('');
  const [passwordValue, setPasswordValue] = useState('');
  const [secretPassphrase, setSecretPassphrase] = useState('');
  const [requestMessage, setRequestMessage] = useState('');

  const handleFormSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    await register();
  };

  const register = async () => {
    try {
      const body = JSON.stringify({
        username: usernameValue,
        password: passwordValue,
        secretPassphrase: secretPassphrase,
        requestMessage: requestMessage,
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
          <p className="text-2xl  text-center pb-6 ">Request account</p>
          <p className=" text-center pb-2 text-sm">Preffered username</p>
          <input
            className="bg-inherit border border-green-500 rounded-sm caret-green-500 p-0.5"
            type="text"
            onChange={(e) => setUsernameValue(e.target.value)}
          />
        </div>
        <div>
          <p className=" text-center pb-2 text-sm">Password</p>
          <input
            className="bg-inherit border border-green-500 rounded-sm caret-green-500 p-0.5"
            type="text"
            onChange={(e) => setPasswordValue(e.target.value)}
          />
        </div>
        <div>
          <p className="text-center pb-2 text-sm">Request message</p>
          <input
            className="bg-inherit border border-green-500 rounded-sm caret-green-500 p-0.5"
            type="text"
            onChange={(e) => setRequestMessage(e.target.value)}
          />
        </div>
        <div>
          <p className="text-center pb-2 text-sm text-cyan-500">Secret passphrase</p>
          <input
            className="bg-inherit border border-cyan-500 rounded-sm caret-green-500 p-0.5"
            type="password"
            onChange={(e) => setSecretPassphrase(e.target.value)}
          />
        </div>
        <div className="mx-auto pt-2 pb-2">
          <button className="border border-green-500 rounded-sm  text-sm w-44 p-2 hover:border-green-300 hover:text-green-300 transition">
            Request registration
          </button>
        </div>
      </form>
    </div>
  );
};

export default RegistrationForm;
