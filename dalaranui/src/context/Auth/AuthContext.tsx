import { createContext, ReactNode, useState } from 'react';

type UserRole = 'baj' | 'admin';

type AuthStateType = {
  authToken: string;
  refreshToken: string;
  role: UserRole;
} | null;

type AuthContextType = {
  auth: AuthStateType;
  updateAuth: (auth: AuthStateType) => void;
  clearAuth: () => void;
};

type AuthContextProviderType = {
  children: ReactNode;
};

export const AuthContext = createContext<AuthContextType | null>(null);

const AuthProvider: React.FC<AuthContextProviderType> = ({ children }) => {
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

export default AuthProvider;
