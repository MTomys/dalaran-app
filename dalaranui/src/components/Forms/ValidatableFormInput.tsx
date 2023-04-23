import React, { useEffect, useState } from 'react';

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

export const ValidatableFormInput: React.FC<ValidatableInputProps> = (
  props
) => {
  const {
    name,
    inputProps,
    onValidateInput,
    invalidInputInfo,
    onInputValueChange,
    onInputValidityChange,
  } = props;

  const [wasTouched, setWasTouched] = useState(false);
  const [inputValue, setInputValue] = useState('');

  const isInputValueValid = onValidateInput(inputValue);
  const isInputInvalid = !isInputValueValid && wasTouched;

  const errorMessage = isInputInvalid ? invalidInputInfo : '';

  const handleBlur = () => {
    setWasTouched(true);
  };

  const handleInputChange = (event: React.FormEvent<HTMLInputElement>) => {
    const value = event.currentTarget.value;
    setInputValue(value);
  };

  useEffect(() => {
    onInputValueChange(inputValue);
  }, [inputValue]);

  useEffect(() => {
    onInputValidityChange(!isInputInvalid);
  }, [isInputInvalid]);

  return (
    <>
      <label htmlFor={inputProps.id}>{name}</label>
      <input
        {...inputProps}
        value={inputValue}
        onChange={handleInputChange}
        onBlur={handleBlur}
      />
      <span>{errorMessage}</span>
    </>
  );
};
