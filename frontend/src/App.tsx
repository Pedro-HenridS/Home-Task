import { Routes, Route } from 'react-router-dom';
import './App.css'

// Components
import RegisterUserPage from "./pages/RegisterPage/RegisterUserPage"
import LoginPage from './pages/LoginPage/LoginPage';

function App() {

  return (
    <>
     <Routes>
      <Route path="/account/register" Component={RegisterUserPage}/>
      <Route path="/account/login" Component={LoginPage} />
     </Routes> 
    </>
  )
}

export default App
