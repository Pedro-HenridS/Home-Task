import LoginForm from '../../components/forms/Login/LoginForm';
import { useRef } from "react";
import './LoginPage.scss';
import type { IFormHandle } from '../../interfaces/IFormHandle';

export default function LoginPage(){

    const formRef = useRef<IFormHandle>(null);
    
    return(
        <section>
            <h1>Login</h1>
            <LoginForm ref={formRef}></LoginForm>
            <button onClick={() =>  formRef.current?.submitForm() }>Entrar</button>
        </section> 
    )
}