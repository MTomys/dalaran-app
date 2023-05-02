import { useContext } from 'react';
import { AuthContext } from '@/features/auth';

export const useAuth = () => {
  return useContext(AuthContext);
};
