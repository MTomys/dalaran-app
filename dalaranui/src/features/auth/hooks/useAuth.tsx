import { useContext } from 'react';
import { AuthContext } from '@/features/auth/index';

export const useAuth = () => {
  return useContext(AuthContext);
};
