import "./HomePage.scss";
import NavBar from "../../components/common/nav/NavBar";
import { useEffect,  useState } from "react";
import axios from "axios";
import type { ITask } from "../../interfaces/Responses/Tasks";

export default function HomePage() {
    const [tasks, setTasks] = useState<ITask[]>([]);

    useEffect(() => {
        
        const fetchTasks = async () => {
            try {
                const response = await axios.get("http://localhost:5044/all", { withCredentials: true });
                setTasks(response.data.data)

            } catch (error) {
                console.error("Erro ao buscar tasks:", error);
            }
        };

        fetchTasks();

    }, []);



    return (
        <div>
            <NavBar />
            <ul>
                {tasks.map(task => (
                    <li key={task.id}>{task.name}</li>
                ))}
            </ul>
        </div>
    );
}
