import { forwardRef, useImperativeHandle, useState } from 'react';
import type { ILoginFormData } from '../../../interfaces/Requests/ILoginFormData';
import './LoginForm.scss';
import axios from 'axios';
import type { IFormHandle } from '../../../interfaces/IFormHandle';
import { useNavigate } from 'react-router-dom';



const LoginForm = forwardRef<IFormHandle>((_props, ref) =>{

    const navigate = useNavigate()

    // Use state dos inputs
    const [formData, changeForm] = useState<ILoginFormData>({
        Email: '',
        Password: ''
    });

    const handleInput = (e:React.ChangeEvent<HTMLInputElement>, name: string )=>{
        changeForm(prevData => ({
            ...prevData,
            [name]: e.target.value
        }))
    }

    useImperativeHandle(ref, () => ({
        submitForm: () => {
            handleSubmit();
        }
    }))

    const handleSubmit = async ()=> {

        console.log('Dados a serem enviados:', formData)

        
        try{

            axios.defaults.withCredentials = true;

            await axios.post("http://localhost:5044/account/login", formData, { withCredentials: true })

            navigate("/home")

        }catch(err){
            console.log("Erro ao enviar a requisição: " + err)
        }
    }

    return (
        <form onSubmit={(e) => e.preventDefault()}>
            <section id="email">
                <label>Email</label>
                <input
                    type="email"
                    className="input"
                    name="Email"
                    placeholder="Insira seu email"

                    onChange={(e) => {
                        handleInput(e, "Email")
                    }}

                />
            </section>
            <section id="password">
                <label>Senha</label>
                <input
                    type="password"
                    className="input"
                    name="Password"
                    placeholder="Insira sua senha"
                    onChange={(e) => {
                        handleInput(e, "Password")
                    }}
                />
            </section>
        </form>
    )
});

export default LoginForm;
