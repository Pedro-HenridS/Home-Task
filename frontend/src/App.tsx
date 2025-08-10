import { Routes, Route } from 'react-router-dom';
import './App.css'
import RegisterForm from './components/forms/RegisterForm';

function App() {

  return (
    <>
     <Routes>
      <Route path="/account/register" Component={RegisterForm}/>
     </Routes> 
    </>
  )
}

export default App
