import React from 'react';
import AuthInput, { AuthInputProps } from './AuthInput';

export type UsernameInputProps = {
  onValidateUsername: (username: string) => boolean;
  onUsernameValueChange: (username: string) => void;
  onInputValidityChange: (usernameValidity: boolean) => void;
};

const UsernameInput: React.FC<UsernameInputProps> = (props) => {
  const { onValidateUsername, onUsernameValueChange, onInputValidityChange } =
    props;

  const usernameProps: AuthInputProps = {
    name: 'username',
    inputProps: {
      id: 'username',
      type: 'text',
    },
    onValidateInput: onValidateUsername,
    invalidInputInfo: 'username invalid',
    onInputValueChange: onUsernameValueChange,
    onInputValidityChange: onInputValidityChange,
  };

  return <AuthInput {...usernameProps} />;
};

export default UsernameInput;
