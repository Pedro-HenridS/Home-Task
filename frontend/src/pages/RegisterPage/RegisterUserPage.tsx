import './RegisterUserPage.scss'
import RegisterForm from "../../components/forms/RegisterForm"

export default function RegisterUserPage(){

    return (
        <section className='container-section'>
            <h1>Cadastrar</h1>
            <RegisterForm></RegisterForm>
            <button>Criar conta</button>
        </section>
    )
}