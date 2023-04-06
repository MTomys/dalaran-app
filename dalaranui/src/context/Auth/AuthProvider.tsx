import { createContext, ReactNode, useState } from 'react';

export type UserRole = 'baj' | 'admin';

export type AuthStateType = {
  token: string;
  username: string;
  role: UserRole;
} | null;

export type AuthContextType = {
  authState: AuthStateType;
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
  const [authState, setAuthState] = useState<AuthStateType>(null);

  const updateAuth = (auth: AuthStateType) => {
    setAuthState(auth);
    console.log('auth set to: ', auth);
  };

  const clearAuth = () => {
    setAuthState(null);
  };

  return (
    <AuthContext.Provider value={{ authState, updateAuth, clearAuth }}>
      {children}
    </AuthContext.Provider>
  );
};

export default AuthContext;
