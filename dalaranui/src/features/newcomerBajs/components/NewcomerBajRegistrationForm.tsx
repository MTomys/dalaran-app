import React, { useState } from 'react';

import { FormSubmitButton, ValidatableFormInput } from '@/index';

export const NewcomerBajRegistrationForm: React.FC = () => {
  const [profileName, setProfileName] = useState<string>('');
  const [profileNameValid, setProfileNameValid] = useState<boolean>();
  const [isSubmitDisabled, setIsSubmitDisabled] = useState<boolean>(true);

  const handleFormSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
  };

  return (
    <section>
      <h2>Welcome to the service and congratulations on being accepted!</h2>
      <p>It's time for you to create your new account.</p>
      <p>
        Please choose your profile name, which will be visible to all service users.
        Your username used for logging in is kept to your eyes only for security
        reasons.
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
        <FormSubmitButton buttonName='Register' disabled={isSubmitDisabled}/>
      </form>
    </section>
  );
};
