import React from 'react';

export type AuthActionButtonProps = {
  buttonName: string;
  disabled: boolean;
};

export const FormSubmitButton: React.FC<AuthActionButtonProps> = (props) => {
  const { buttonName, disabled } = props;

  return (
    <button type="submit" disabled={disabled}>
      {buttonName}
    </button>
  );
};
