import { SearchIcon } from "../Icon/Icon"
import "./style.css"

export const SearchInput = () => {
    return (
        <div className="search-input__box">
            <SearchIcon />


            <input className="search-input__field" placeholder="Procurar tarefa" type="search" />
        </div>
    )
};

export const TodoListInputs = () => {
    return (
        <div className="">

        </div>

    )
}