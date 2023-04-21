export type ValidatableInputProps = {
  name: string;
  inputProps: {
    id: string;
    type: string;
  };
  onValidateInput: (inputValue: string) => boolean;
  invalidInputInfo: string;
  onInputValueChange: (inputValue: string) => void;
  onInputValidityChange: (inputValue: boolean) => void;
};

export type FormSubmitButtonProps = {
  buttonName: string;
  disabled: boolean;
};
