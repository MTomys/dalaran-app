export type UserRole = 'baj' | 'admin' | 'newcomerBaj';

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

export type LoginOptions = {
  url: string;
  payload: {
    username: string;
    password: string;
    requestPhrase?: string;
  };
};