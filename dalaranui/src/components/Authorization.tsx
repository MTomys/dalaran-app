import React from 'react';

import { UnauthorizedPage, UserRole, useAuth } from '@/features/auth/index';

type RequiredRoleProps = {
  rolesRequired: UserRole[];
  children: React.ReactNode;
};

export const Authorization: React.FC<RequiredRoleProps> = (props) => {
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
