import { AxiosError } from 'axios';

export type FormSubmitButtonProps = {
  buttonName: string;
  disabled: boolean;
};

export type AxiosErrorResponse = {
  error: AxiosError;
  message: string;
}