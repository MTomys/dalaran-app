import React from 'react';
import { Authorization } from '../../auth/index';

export const BajPanel: React.FC = () => {
  return (
    <Authorization rolesRequired={['baj']}>
      <h1>Baj Panel</h1>
    </Authorization>
  );
};
