import { useNavigate } from 'react-router-dom';
const UnauthorizedPage: React.FC = () => {
  const navigate = useNavigate();

  return (
    <main>
      <h1> You are unauthorized to view this page</h1>
      <button type="button" onClick={() => navigate(-1)}>
        Take me back
      </button>
    </main>
  );
};

export default UnauthorizedPage;
