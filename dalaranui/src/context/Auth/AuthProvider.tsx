import { createContext, ReactNode, useState } from 'react';

type UserRole = 'baj' | 'admin';

export type AuthStateType = {
  authToken: string;
  refreshToken: string;
  role: UserRole;
} | null;

export type AuthContextType = {
  auth: AuthStateType;
  updateAuth: (auth: AuthStateType) => void;
  clearAuth: () => void;
};

type AuthContextProviderType = {
  children: ReactNode;
};

const AuthContext = createContext<AuthContextType | null>(null);

export const AuthProvider: React.FC<AuthContextProviderType> = ({
  children,
}) => {
  const [auth, setAuth] = useState<AuthStateType>(null);

  const updateAuth = (auth: AuthStateType) => {
    setAuth(auth);
  };

  const clearAuth = () => {
    setAuth(null);
  };

  return (
    <AuthContext.Provider value={{ auth, updateAuth, clearAuth }}>
      {children}
    </AuthContext.Provider>
  );
};

export default AuthContext;
