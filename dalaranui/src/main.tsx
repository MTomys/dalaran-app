import React from 'react';
import ReactDOM from 'react-dom/client';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import Root from './routes/Root';
import ErrorPage from './pages/ErrorPage';
import Login from './components/Auth/Login';
import Registration from './components/Auth/Registration';
import AdminPanel from './pages/AdminPanel';
import BajPanel from './pages/BajPanel';

const router = createBrowserRouter([
  {
    path: '/',
    element: <Root />,
    errorElement: <ErrorPage />,
    children: [
      {
        path: 'login',
        element: <Login />,
      },
      {
        path: 'register',
        element: <Registration />,
      },
      {
        path: 'baj',
        element: <BajPanel />,
      },
      {
        path: 'admin',
        element: <AdminPanel />,
      },
    ],
  },
]);

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
