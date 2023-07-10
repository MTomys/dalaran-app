import React from 'react';
import { PlebRequests, useGetPlebs } from '@/features/admins';
import { Authorization } from '@/index';

export const AdminPanel: React.FC = () => {
  const getPlebsQuery = useGetPlebs();

  return (
    <Authorization rolesRequired={['admin']}>
      <h1>Admin Panel</h1>
      {getPlebsQuery.isError && (
        <pre>{JSON.stringify(getPlebsQuery.error as string)}</pre>
      )}
      {getPlebsQuery.isSuccess && <PlebRequests plebRequests={getPlebsQuery.data} />}
    </Authorization>
  );
};
