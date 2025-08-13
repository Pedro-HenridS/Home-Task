import LoginForm from '../../components/forms/Login/LoginForm';
import { useRef } from "react";
import './LoginPage.scss';
import type { IFormHandle } from '../../interfaces/IFormHandle';
import brandingImg from '../../assets/branding.jpg';

export default function LoginPage(){

    const formRef = useRef<IFormHandle>(null);
    
    return(
        <div className='body'>
            <main className="main">
                <div className='box'>
                <h1>Login</h1>
                <LoginForm ref={formRef}></LoginForm>
                <button onClick={() =>  formRef.current?.submitForm() }>Entrar</button>
                </div>
            </main>
            <aside className="aside">
                <div className='container'>
                    <img className="image" src={brandingImg} alt="Branding"/>
                    <text className="text" id="">A new idea of <br/> organization.</text>
                </div>
            </aside>
        </div> 
    )
}