import { isRouteErrorResponse, useRouteError } from 'react-router-dom';

export const ErrorPage: React.FC = () => {
  const error = useRouteError();
  const errorInfo = isRouteErrorResponse(error)
    ? `status: ${error.statusText}  data: ${error.data}`
    : ``;

  console.error(error);

  return (
    <main>
      <h1>Error!</h1>
      <p>an unexpected error occured</p>
      <p>
        <i>{errorInfo}</i>
      </p>
    </main>
  );
};
