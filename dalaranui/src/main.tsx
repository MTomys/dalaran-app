import React from 'react';
import ReactDOM from 'react-dom/client';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import Root from './routes/Root';
import { AdminPage } from './features/admins/index';
import { LoginPage, RegistrationPage } from './features/auth/index';
import { ErrorPage } from '../src/index';
import { BajPage } from './features/bajs/index';

const router = createBrowserRouter([
  {
    path: '/',
    element: <Root />,
    errorElement: <ErrorPage />,
    children: [
      {
        path: 'login',
        element: <LoginPage />,
      },
      {
        path: 'register',
        element: <RegistrationPage />,
      },
      {
        path: 'baj',
        element: <BajPage />,
      },
      {
        path: 'admin',
        element: <AdminPage />,
      },
    ],
  },
]);

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
