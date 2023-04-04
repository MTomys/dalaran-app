import { Outlet, Link, useNavigation } from 'react-router-dom';
import { AuthProvider } from '../context/Auth/AuthProvider';

const Root: React.FC = () => {
  const navigation = useNavigation();
  const isLoading = navigation.state === 'loading';
  return (
    <AuthProvider>
      <Link to="/login">Login</Link>
      &nbsp;
      <Link to="/register">Register</Link>
      <Link to="/admin/plebs">Plebs</Link>
      <p>{isLoading ? 'Currently loading...' : 'not loading'}</p>
      <Outlet />
    </AuthProvider>
  );
};

export default Root;
