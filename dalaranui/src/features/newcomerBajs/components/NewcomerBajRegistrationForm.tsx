import React, { useState } from 'react';

import { FormSubmitButton, ValidatableFormInput } from '@/index';
import { useCreateBajAccount } from '@/features/newcomerBajs';
import { useNavigate } from 'react-router-dom';

export const NewcomerBajRegistrationForm: React.FC = () => {
  const [profileName, setProfileName] = useState<string>('');
  const [profileNameValid, setProfileNameValid] = useState<boolean>(false);
  const navigate = useNavigate();

  const { mutate, isSuccess, isError, error } = useCreateBajAccount();

  const handleFormSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    const newBajRequest = {
      newcomerBajProfileName: profileName,
    };
    mutate(newBajRequest, {
      onSuccess: () => {
        navigate('/baj');
      },
    });
  };

  return (
    <section>
      <h2>Welcome to the service and congratulations on being accepted!</h2>
      <p>It's time for you to create your new account.</p>
      <p>
        Please choose your profile name, which will be your displayed name to all
        service users. Your username used for logging in is kept to your eyes only
        for security reasons.
      </p>
      <form onSubmit={handleFormSubmit}>
        <ValidatableFormInput
          name="profile name"
          inputProps={{ id: 'profileName', type: 'text' }}
          onValidateInput={() => true}
          invalidInputInfo="Profile name can not be empty"
          onInputValueChange={(value) => setProfileName(value)}
          onInputValidityChange={(value) => setProfileNameValid(value)}
        />
        <FormSubmitButton buttonName="Register" disabled={!profileNameValid} />
        {isSuccess && <p>Success!</p>}
        {isError && <pre>{error as string}</pre>}
      </form>
    </section>
  );
};
