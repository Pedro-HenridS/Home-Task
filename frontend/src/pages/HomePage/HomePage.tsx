import "./HomePage.scss";
import NavBar from "../../components/common/nav/NavBar";
import Cards from "../../components/ui/cards/Cards";
import GroupCards from "../../components/ui/group-cards/Group-Cards";
//import { useEffect,  useState } from "react";
//import axios from "axios";
//import type { ITask } from "../../interfaces/Responses/Tasks";

export default function HomePage() {
    //  const [tasks, setTasks] = useState<ITask[]>([]);

    //  useEffect(() => {

    //      const fetchTasks = async () => {
    //          try {
    //              const response = await axios.get("http://localhost:5044/all", { withCredentials: true });
    //              setTasks(response.data.data)

    //          } catch (error) {
    //              console.error("Erro ao buscar tasks:", error);
    //          }
    //      };

    //      fetchTasks();

    //  }, []);

    const tasks = [
        { id: 1, name: "teste 1" },
        { id: 2, name: "teste 2" },
        { id: 3, name: "teste 3" }];

    return (
        <div>
            <NavBar />
            <main className="tasks-body">
                <section>
                    <ul className="groups">
                        
                        <li className="group-card">
                            <GroupCards/>
                        </li>
                        <li className="group-card">
                            <GroupCards/>
                        </li>
                        <li className="group-card">
                            <GroupCards/>
                        </li>

                    </ul>
                </section>
                <ul>
                    {tasks.map(task => (
                        <li>
                            <Cards name={task.name} />
                        </li>
                        
                    ))}
                </ul>
            </main>

        </div>
    );
}
