import PlebRequests from './components/Admin/PlebRequests';
import Login from './components/Auth/Login';
import { AuthProvider } from './context/Auth/AuthProvider';
const App: React.FC = () => {
  return (
    <AuthProvider>
      <Login />
      <PlebRequests />
    </AuthProvider>
  );
};

export default App;
