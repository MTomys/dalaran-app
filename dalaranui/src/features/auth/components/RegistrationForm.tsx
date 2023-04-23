import React, { useState } from 'react';

export const RegistrationForm: React.FC = () => {
  const [usernameValue, setUsernameValue] = useState('');
  const [passwordValue, setPasswordValue] = useState('');
  const [reEnterPasswordValue, setreEnterPasswordValue] = useState('');

  const [isUsernameValid, setIsUsernameValid] = useState(false);
  const [isPasswordValid, setIsPasswordValid] = useState(false);
  const [isReEnterPasswordValid, setIsReEnterPasswordValid] = useState(false);

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

  return <form onSubmit={handleFormSubmit}></form>;
};

export default RegistrationForm;
