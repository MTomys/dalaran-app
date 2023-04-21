import { Outlet, Link, useNavigation } from 'react-router-dom';
import { AuthProvider } from '@/features/auth/index';

const Root: React.FC = () => {
  const navigation = useNavigation();
  const isLoading = navigation.state === 'loading';
  return (
    <AuthProvider>
      <Link to="/login">Login</Link>
      &nbsp;
      <Link to="/register">Register</Link>
      <Link to="/baj">Baj Panel</Link>
      <Link to="/admin">Admin panel</Link>
      <p>{isLoading ? 'Currently loading...' : 'not loading'}</p>
      <Outlet />
    </AuthProvider>
  );
};

export default Root;
