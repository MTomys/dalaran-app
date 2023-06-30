import React, { createContext, ReactNode, useState } from 'react';
import { AuthContextType, AuthResponseType } from '@/features/auth';
import { storage } from '@/index';

export const AuthContext = createContext<AuthContextType | null>(null);

type AuthProviderProps = {
  children: ReactNode;
};

export const AuthProvider: React.FC<AuthProviderProps> = ({ children }) => {
  const [authState, setAuthState] = useState<AuthResponseType>(null);

  const updateAuth = (auth: AuthResponseType) => {
    setAuthState(auth);
    storage.setToken(auth?.token as string);
    console.log('auth set to: ', auth);
  };

  const clearAuth = () => {
    setAuthState(null);
    storage.clearToken();
  };

  return (
    <AuthContext.Provider value={{ authState, updateAuth, clearAuth }}>
      {children}
    </AuthContext.Provider>
  );
};
