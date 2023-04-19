import React from 'react';
import RequiredRole from '../components/Auth/RequiredRole';

const BajPanel: React.FC = () => {
  return (
    <RequiredRole rolesRequired={['baj']}>
      <h1>Baj Panel</h1>
    </RequiredRole>
  );
};

export default BajPanel;
