import useAuth from '../../hooks/auth/useAuth';
import { UserRole } from '../../context/Auth/AuthProvider';
import React from 'react';

import UnauthorizedPage from '../../pages/UnauthorizedPage';

type RequiredRoleProps = {
  rolesRequired: UserRole[];
  children: React.ReactNode;
};

const RequiredRole: React.FC<RequiredRoleProps> = (props) => {
  const { children, rolesRequired } = props;
  const auth = useAuth();

  const userRole = auth?.authState?.role;

  const isPermittedToView = () => {
    if (typeof userRole === 'undefined') {
      return false;
    }

    return rolesRequired.includes(userRole);
  };

  return isPermittedToView() ? <>{children}</> : <UnauthorizedPage />;
};

export default RequiredRole;