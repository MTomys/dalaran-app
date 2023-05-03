import { AuthStateType } from '@/features/auth';

export const isAuthResponse = (object: unknown): object is AuthStateType => {
  if (object !== null && typeof object === 'object') {
    return 'token' in object;
  }
  return false;
};
