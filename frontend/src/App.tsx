import { Routes, Route } from 'react-router-dom';
import './App.scss'

// Components
import RegisterUserPage from "./pages/RegisterPage/RegisterUserPage"
import LoginPage from './pages/LoginPage/LoginPage';
import HomePage from './pages/HomePage/HomePage';

function App() {

  return (
    <>
     <Routes>
      <Route path="/account/register" Component={RegisterUserPage}/>
      <Route path="/account/login" Component={LoginPage} />
      <Route path="/home" Component={HomePage}/>
     </Routes> 
    </>
  )
}

export default App
