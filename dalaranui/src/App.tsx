import PlebRequests from './components/Admin/PlebRequests';
import Login from './components/Auth/Login';
import AuthProvider from './context/Auth/AuthContext';
const App: React.FC = () => {
  return (
    <AuthProvider>
      <PlebRequests />
    </AuthProvider>
  );
};

export default App;
