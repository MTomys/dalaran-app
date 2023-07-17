export type UserRole = 'baj' | 'admin' | 'newcomerBaj' | 'anonymous';

export type AuthResponseType = {
  token: string;
  username: string;
  role: UserRole;
};

export type AuthContextType = {
  authState: AuthResponseType;
  updateAuth: (auth: AuthResponseType) => void;
  clearAuth: () => void;
};
