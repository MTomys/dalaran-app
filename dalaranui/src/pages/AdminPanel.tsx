import React from 'react';
import { Outlet, Link, useNavigation } from 'react-router-dom';

const AdminPanel: React.FC = () => {
  return (
    <>
      <h1>Admin Panel</h1>
      <Outlet />
    </>
  );
};

export default AdminPanel;
