import React from 'react';
import { Outlet } from 'react-router-dom';
import PlebRequests from '../components/Admin/PlebRequests';
import RequiredRole from '../components/Auth/RequiredRole';

export const AdminPanel: React.FC = () => {
  return (
    <RequiredRole rolesRequired={['admin']}>
      <h1>Admin Panel</h1>
      <Outlet />
      <PlebRequests />
    </RequiredRole>
  );
};
