import './RegisterUserPage.scss';
import RegisterForm from "../../components/forms/Register/RegisterForm";
import { useRef } from "react";
import type { IFormHandle } from '../../interfaces/IFormHandle';
import brandingImg from '../../assets/branding.jpg';

export default function RegisterUserPage(){

    const formRef = useRef<IFormHandle>(null);

    return (
                <div className='body'>
            <main className="main">
                <div className='box'>
                <h1>Cadastro</h1>
                <RegisterForm ref={formRef}></RegisterForm>
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