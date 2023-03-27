import React from 'react';

export type AuthActionButtonProps = {
  buttonName: string;
  disabled: boolean;
};

const AuthActionButton: React.FC<AuthActionButtonProps> = (props) => {
  const { buttonName, disabled } = props;

  return (
    <button type="submit" disabled={disabled}>
      {buttonName}
    </button>
  );
};

export default AuthActionButton;
