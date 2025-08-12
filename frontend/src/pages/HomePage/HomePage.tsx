import axios from "axios";
import "./HomePage.scss";
import { useEffect, useState } from "react";

export default function HomePage(){

    const [message, setMessage] = useState("");

    useEffect(() => {

        const fetchMessage = async() => {
            await axios.get("http://localhost:5044/home/tasks", {withCredentials: true})
            .then(res => {
                setMessage(res.data.message)
            })
            .catch(err => {
                console.log("Erro ao buscar a mensagem", err)
        })
    }

    fetchMessage();
}, []);

    return(<h1>
        {message}
    </h1>)
}