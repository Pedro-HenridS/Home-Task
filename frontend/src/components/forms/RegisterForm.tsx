import './RegisterForm.scss'

export default function RegisterForm(){

    return(
        <form>
            <section className="username">
                <label >Username</label>
                <input type="username" className="input" placeholder="Insira seu username"/>
            </section>
            <section className="email">
                <label>Email</label>
                <input type="email" className="input" placeholder="Insira seu email"/>
            </section>
            <section className="password">
                <label>Senha</label>
                <input type="password" className="input" placeholder="Insira sua senha"/>
                <input type="confirmPassword" id="pass-two" className="input" placeholder="Confirme sua senha"/>
            </section>
        </form>
)}