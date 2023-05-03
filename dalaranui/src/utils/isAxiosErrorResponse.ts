import { AxiosErrorResponse } from '@/types';
import { isAxiosError } from 'axios';

export const isAxiosErrorResponse = (
  object: unknown
): object is AxiosErrorResponse => {
  if (object !== null && typeof object === 'object') {
    console.log('object', object);
    if ('error' in object) {
      console.log('is axios error?', isAxiosError(object['error']))
      return isAxiosError(object.error);
    }
  }
  return false;
};
