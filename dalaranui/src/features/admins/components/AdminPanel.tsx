import React from 'react';
import { Outlet } from 'react-router-dom';
import { PlebRequests } from '@/features/admins/index';
import { Authorization } from '@/index';

export const AdminPanel: React.FC = () => {
  return (
    <Authorization rolesRequired={['admin']}>
      <h1>Admin Panel</h1>
      <Outlet />
      <PlebRequests />
    </Authorization>
  );
};
