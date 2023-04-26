import React, { useState } from 'react';
import { axios } from '@/lib/axios';
import { ValidatableFormInput, FormSubmitButton } from '@/index';

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

  return (
    <form onSubmit={handleFormSubmit}>
      <ValidatableFormInput
        name="username"
        inputProps={{ id: 'username', type: 'text' }}
        onValidateInput={() => true}
        onInputValueChange={(value) => setUsernameValue(value)}
        onInputValidityChange={(value) => setIsUsernameValid(value)}
        invalidInputInfo="invalid username"
      />
      <ValidatableFormInput
        name="password"
        inputProps={{ id: 'password', type: 'password' }}
        onValidateInput={() => true}
        onInputValueChange={(value) => setPasswordValue(value)}
        onInputValidityChange={(value) => setIsPasswordValid(value)}
        invalidInputInfo="invalid password"
      />
      <ValidatableFormInput
        name="re-enter password"
        inputProps={{ id: 'reEnterPassword', type: 'password' }}
        onValidateInput={() => true}
        onInputValueChange={(value) => setreEnterPasswordValue(value)}
        onInputValidityChange={(value) => setIsReEnterPasswordValid(value)}
        invalidInputInfo="passwords do not match"
      />
      <FormSubmitButton buttonName="register" disabled={false} />
    </form>
  );
};

export default RegistrationForm;
