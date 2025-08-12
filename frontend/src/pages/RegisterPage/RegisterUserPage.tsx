import './RegisterUserPage.scss';
import RegisterForm from "../../components/forms/Register/RegisterForm";
import { useRef } from "react";
import type { IFormHandle } from '../../interfaces/IFormHandle';

export default function RegisterUserPage(){

    const formRef = useRef<IFormHandle>(null);

    return (
        <section className='container-section'>
            <h1>Cadastrar</h1>
            <RegisterForm ref = {formRef}></RegisterForm>
            <button onClick={() => formRef.current?.submitForm()} >Criar conta</button>
        </section>
    )
}