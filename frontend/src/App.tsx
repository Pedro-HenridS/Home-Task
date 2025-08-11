import { Routes, Route } from 'react-router-dom';
import './App.css'
import RegisterUserPage from "./pages/RegisterPage/RegisterUserPage"

function App() {

  return (
    <>
     <Routes>
      <Route path="/account/register" Component={RegisterUserPage}/>
     </Routes> 
    </>
  )
}

export default App
