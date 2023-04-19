import React from 'react';
import AuthInput, { AuthInputProps } from './AuthInput';

export type PasswordInputProps = {
  onValidatePassword: (password: string) => boolean;
  onPasswordValueChange: (password: string) => void;
  onPasswordValidityChange: (passwordValidity: boolean) => void;
};

const PasswordInput: React.FC<PasswordInputProps> = (props) => {
  const {
    onValidatePassword,
    onPasswordValueChange,
    onPasswordValidityChange,
  } = props;

  const passwordProps: AuthInputProps = {
    name: 'password',
    inputProps: {
      id: 'password',
      type: 'password',
    },
    onValidateInput: onValidatePassword,
    invalidInputInfo: 'password invalid',
    onInputValueChange: onPasswordValueChange,
    onInputValidityChange: onPasswordValidityChange,
  };

  return <AuthInput {...passwordProps} />;
};

export default PasswordInput;
