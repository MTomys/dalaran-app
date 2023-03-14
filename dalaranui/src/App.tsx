import Login from './components/Login/Login';
import MainBackground from './components/CommonUI/MainBackground';
import Registration from './components/Registration/Registration';
const App: React.FC = () => {
  return (
    <MainBackground>
      <Login />
      <Registration />
    </MainBackground>
  );
};

export default App;
