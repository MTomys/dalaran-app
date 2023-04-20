import { useContext } from 'react';
import AuthContext from '../../context/Auth/AuthProvider';

export const useAuth = () => {
  return useContext(AuthContext);
};
