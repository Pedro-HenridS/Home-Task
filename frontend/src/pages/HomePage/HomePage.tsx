import "./HomePage.scss";
import NavBar from "../../components/common/nav/NavBar";
import { useEffect, useState } from "react";
import axios from "axios";
import type { Task } from "../../interfaces/Responses/Tasks";

export default function HomePage() {
    const [tasks, setTasks] = useState<Task[]>([]);

    useEffect(() => {
        const fetchTasks = async () => {
            try {
                const response = await axios.get("http://localhost:5044/all", { withCredentials: true });
                setTasks(response.data.Data ?? []);

            } catch (error) {
                console.error("Erro ao buscar tasks:", error);
            }
        };

        fetchTasks();

        console.log(tasks)
    }, []);



    return (
        <div>
            <NavBar />
            <ul>
                {Array.isArray(tasks) && tasks.map(task => (
                    <li key={task.Id}>{task.Name}</li>
                ))}
            </ul>
        </div>
    );
}
