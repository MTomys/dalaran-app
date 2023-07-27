import { useContext } from 'react';
import { AuthContext } from '@/features/auth';

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error('auth context should not be null when calling this method');
  }
  return context;
};
