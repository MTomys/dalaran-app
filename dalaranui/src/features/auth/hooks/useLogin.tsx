const INVALID_USAGE_MESSAGE =
  'Error while using useLogin, useAuth context should never be null or undefined when calling this hook';

export const useLogin = (options: LoginOptions) => {
  const authContext = useAuth();
  if (authContext === null || authContext === undefined) {
    throw new Error(INVALID_USAGE_MESSAGE);
  }

  const { authState, updateAuth } = authContext;
  const [isLoading, setIsLoading] = useState(false);

  const login = async () => {
    try {
      setIsLoading(true);
      const response = await axios.post(url, JSON.stringify(payload));
      if (isAuthResponse(response.data)) {
        updateAuth(response.data);
        console.log(authState);
      }
    } catch (err) {
      if (isAxiosError(err)) {
      }
      console.error(err);
    } finally {
      setIsLoading(false);
    }
  };

  let infoMessage = '';
  if (isLoading) {
    infoMessage = 'Loading...';
  }
  if (responseCode === 403) {
    infoMessage = 'Invalid credentials';
  } else if (responseCode === 200) {
    infoMessage = 'Successfully logged in';
  } else if (responseCode !== undefined && responseCode >= 500) {
    infoMessage = 'A server error occured';
  }

  return { isLoading, responseCode, login, infoMessage };
};

const isAuthResponse = (object: unknown): object is AuthStateType => {
  if (object !== null && typeof object === 'object') {
    return 'token' in object;
  }
  return false;
};
