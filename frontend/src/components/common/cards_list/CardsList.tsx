import type ICardListProps from "../../../interfaces/Responses/ICardListProps";
import Cards from "../../ui/cards/Cards";
import './CardsList.scss';

export default function CardList({ tasks }: ICardListProps) {
    return (
        <section className="task-list">
            <ul className="tasks">

                {tasks.map(t => (
                    <li className="task">
                        <Cards name={t.name} />
                    </li>
                ))}
            </ul>
        </section>
    )
}