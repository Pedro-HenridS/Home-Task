import './RegisterUserPage.scss';
import RegisterUserForm from "../../components/forms/RegisterForm";
import { useRef } from "react";
import type { formHandle } from '../../interfaces/formHandle';

export default function RegisterUserPage(){

    const formRef = useRef<formHandle>(null);

    return (
        <section className='container-section'>
            <h1>Cadastrar</h1>
            <RegisterUserForm ref = {formRef}></RegisterUserForm>
            <button onClick={() => formRef.current?.submitForm()} >Criar conta</button>
        </section>
    )
}