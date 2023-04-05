import useAuth from '../../hooks/auth/useAuth';
import React from 'react';

type RequiredRoleProps = {
  children: React.ReactNode;
};

const RequiredRole: React.FC<RequiredRoleProps> = (props) => {
  const { children } = props;

  return <div></div>;
};

export default RequiredRole;
