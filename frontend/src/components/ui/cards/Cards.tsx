import Switch from "@mui/material/Switch";
import type { ITaskCard } from "../../../interfaces/Responses/ITaskCard";
import "./Cards.scss";
import { useState } from "react";

export default function Cards({ name } : ITaskCard){
    
    const [checked, setChecked] = useState(false)

    return(
        <div className="card-container"> 
            <section className="name">
                { name }
            </section>
            <section>

                Image

                <Switch
                    checked={checked} 
                    onClick={() => setChecked(prev => !prev)} />
            </section>
        </div>
    )
}
