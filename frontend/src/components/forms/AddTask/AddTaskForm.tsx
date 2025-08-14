import { forwardRef, useImperativeHandle, useState } from 'react';
import './/AddTaskForm.scss';
import axios from 'axios';
import type { IFormHandle } from '../../../interfaces/IFormHandle';
import type { IAddTaskForm } from '../../../interfaces/Requests/IAddTaskForn';



const AddTaskForm = forwardRef<IFormHandle>((_props, ref) => {

    // Criação do useState e da função que altera ele
    const [formData, setFormData] = useState<IAddTaskForm>({
        Name: '',
        Description: undefined,
        Due: new Date(),
        Group_Id: '',
        Status: [0, 1, 2, 3]
    });

    // Define o que vai acontecer quando receber a ref externa
    useImperativeHandle(ref, () => ({
        submitForm: () => {
            hadleSubmit();
        }
    }));

    // Função que o submitForm chama para enviar os dados
    const hadleSubmit = async () => {
        console.log('Dados a serem enviados:', formData);

        try {
            const res = await axios.post("http://localhost:5044/create-task", formData, {
                headers: { "Content-Type": "application/json" }
            });
            console.log("Sucesso:", res.data);
            alert("Formulário enviado com sucesso!");
        }
        catch (err) {
            console.error("Erro ao enviar:", err);
            alert("Erro ao enviar o formulário");
        }
    };

    // Função chamada quando algum campo é alterado
    const handleChange = (e: React.ChangeEvent<HTMLInputElement>, name: string) => {

        setFormData(prevData => ({
            ...prevData,
            [name]: e.target.value
        }));
    };

    return (
        <form onSubmit={(e) => e.preventDefault()}>
            <section id="name">
                <label>Username</label>
                <input
                    type="text"
                    className="input"
                    name="Username"
                    placeholder="Insira seu username"
                    value={formData.Name}
                    onChange={(e) => { handleChange(e, 'Username') }}
                />
            </section>
            <section id="email">
                <label>Email</label>
                <input
                    type="email"
                    className="input"
                    name="Email"
                    placeholder="Insira seu email"
                    value={formData.Description}
                    onChange={(e) => { handleChange(e, 'Email') }}
                />
            </section>
            <section id="password">
                <label>Senha</label>
                <input
                    type="password"
                    className="input"
                    name="Password"
                    placeholder="Insira sua senha"
                    value={formData.Due}
                    onChange={(e) => { handleChange(e, 'Password') }}
                />
                <input
                    type="password"
                    id="pass-two"
                    className="input"
                    name="ConfirmedPassword"
                    placeholder="Confirme sua senha"
                    value={formData.Group_Id}
                    onChange={(e) => { handleChange(e, 'ConfirmedPassword') }}
                />
            </section>
        </form>
    );
});

export default AddTaskForm;
