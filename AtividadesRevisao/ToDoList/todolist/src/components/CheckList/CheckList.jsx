import { useState } from "react";
import { DeleteTask, UpdateTask } from "../Buttons/Buttons";
import "./CheckList.css"
import ModalUpdate from "../Modal/ModalUpdate";

export function CheckList({ tasks, onChange, onUpdate, onDelete }) {

    const [showModalUpdate, setshowModalUpdate] = useState(false);

    const [IndexActive, setIndexActive] = useState(null);

    const handleUpdateClick = (index) => {
        setIndexActive(index);
        setshowModalUpdate(true);
    };

    return (
        <ul className="checklist">
            {tasks.map((task, index) => (

                <li key={index} className={task.toDo ? "task-complete" : "task"}>

                    <div className="container-input-desc">

                        <input
                            type="checkbox"
                            checked={task.toDo}
                            onChange={() => onChange(index)}
                        />

                        <span className={task.toDo ? "description-task" : "description-task-complete"}>{task.description}</span>

                    </div>

                    {task.toDo == false

                        ?

                        <div className="container-button">
                            <UpdateTask onClick={() => handleUpdateClick(index)} />
                            <DeleteTask onClick={() => onDelete(index)} />
                        </div>

                        :

                        <></>

                    }

                    {/* verificacao do index*/}
                    {showModalUpdate && IndexActive === index && (
                        <ModalUpdate
                            // passa o index p modal de atualizar, p pegar o index da tarefa que deve mudar a descricao la, passando para o método que vem da home
                            index={IndexActive}
                            // pega o método de update da home
                            onUpdateTask={onUpdate}
                            closeModal={() => setshowModalUpdate(false)}
                        />
                    )}


                </li>
            )

            )}


        </ul>
    );
}

