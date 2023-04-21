import React from 'react';
import { RequiredRoleWrapper } from '../../auth/index';

export const BajPanel: React.FC = () => {
  return (
    <RequiredRoleWrapper rolesRequired={['baj']}>
      <h1>Baj Panel</h1>
    </RequiredRoleWrapper>
  );
};
