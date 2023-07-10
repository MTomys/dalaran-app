import { Outlet } from 'react-router-dom';
import { AuthProvider } from '@/features/auth/index';

const Root: React.FC = () => {
  return (
    <AuthProvider>
      <Outlet />
    </AuthProvider>
  );
};

export default Root;
