import { Authorization } from '@/components/Authorization';
import React from 'react';

export const NewcomerBajPage: React.FC = () => {
  return (
    <Authorization rolesRequired={['newcomerBaj']}>
      <main>
        <h1>Newcomer baj page</h1>
      </main>
    </Authorization>
  );
};
