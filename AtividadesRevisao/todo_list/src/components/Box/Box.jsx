import { SearchInput } from "../Input/Input"
import { Title } from "../Text/Text";
import moment from "moment";
import "./style.css"

export const ToDoListBox = () => {

    const agora = moment();

    return (
        <div className="todolist-box__box">
            <Title>{moment().format('dddd, MMMM do')}</Title>
            <SearchInput/>
        </div>
    )
}