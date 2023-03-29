import React from 'react';
import AuthInput, { AuthInputProps } from './AuthInput';

export type ReEnterPasswordInputProps = {
  onValidateReenterPassword: (password: string) => boolean;
  onReEnterPasswordValueChange: (password: string) => void;
  onReEnterPasswordValidityChange: (passwordValidity: boolean) => void;
};

const ReEnterPasswordInput: React.FC<ReEnterPasswordInputProps> = (props) => {
  const {
    onValidateReenterPassword,
    onReEnterPasswordValueChange,
    onReEnterPasswordValidityChange,
  } = props;

  const reEnterPasswordProps: AuthInputProps = {
    name: 're-enter password',
    inputProps: {
      id: 'reEnterPassword',
      type: 'password',
    },
    onValidateInput: onValidateReenterPassword,
    invalidInputInfo: 'password invalid',
    onInputValueChange: onReEnterPasswordValueChange,
    onInputValidityChange: onReEnterPasswordValidityChange,
  };

  return <AuthInput {...reEnterPasswordProps} />;
};

export default ReEnterPasswordInput;
