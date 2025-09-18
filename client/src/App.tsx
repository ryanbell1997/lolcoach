import './App.css'
import Registration from './pages/Registration'
import UserInfo from './components/UserInfo';
import MatchHistory from './pages/MatchHistory';
import MatchReview from './pages/MatchReview';

function App() {

  return (
    <>
      <h1 className="mb-5">LoL Coach</h1>
      <Registration />
      <MatchHistory />
      <MatchReview  />
      <UserInfo />
    </>
  )
}

export default App
