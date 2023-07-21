import React from 'react';
import ReactDOM from 'react-dom/client';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import Root from './routes/Root';
import { LoginPage, RegistrationPage } from '@/features/auth';
import { NewcomerBajPage } from '@/features/newcomerBajs';
import { BajPage } from '@/features/bajs';
import { AdminPage } from '@/features/admins';
import { ErrorPage } from '@/pages/ErrorPage';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import './index.css';
import { MainPage } from './pages/MainPage';

const queryClient = new QueryClient();

const router = createBrowserRouter([
  {
    path: '',
    element: <Root />,
    errorElement: <ErrorPage />,
    children: [
      {
        path: '/',
        element: <MainPage />,
      },
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
      {
        path: 'newcomerBaj',
        element: <NewcomerBajPage />,
      },
    ],
  },
]);

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
  <QueryClientProvider client={queryClient}>
    <RouterProvider router={router} />
  </QueryClientProvider>
);
