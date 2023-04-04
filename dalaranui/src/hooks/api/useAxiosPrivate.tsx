import axios from 'axios';
import useAuth from '../auth/useAuth';

const useAxiosPrivate = () => {
  const authState = useAuth();
  const authToken = authState?.auth?.token;
  console.log('auth state => ', authState);

  const axiosPrivate = axios.create({
    baseURL: '/api',
    headers: {
      'Content-Type': 'application/json',
      Authorization: `Bearer ${authToken}`,
    },
  });

  return axiosPrivate;
};

export default useAxiosPrivate;
