export type UserRole = 'baj' | 'admin' | 'newcomerBaj';

export type AuthResponseType = {
  token: string;
  username: string;
  role: UserRole;
};

export type AuthStateType = AuthResponseType | null;

export type AuthContextType = {
  authState: AuthStateType;
  updateAuth: (auth: AuthStateType) => void;
  clearAuth: () => void;
};
