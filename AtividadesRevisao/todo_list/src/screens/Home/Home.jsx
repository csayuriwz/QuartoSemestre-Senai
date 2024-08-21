import { ToDoListBox } from "../../components/Box/Box"
import { BtnExterno } from "../../components/Button/Button"
import { ContainerHome, ToDoListContainer } from "../../components/Container/style"
import { TodoListInputs } from "../../components/Input/Input"

export const HomePage = () => {

    return (
        <ContainerHome>

            {/* quadradinho roxo escuro */}
            <ToDoListContainer>

                {/* div que contem o titulo e o search input */}
                <ToDoListBox />

                <TodoListInputs />

            </ToDoListContainer>

            <BtnExterno>Nova Tarefa</BtnExterno>

        </ContainerHome>
    )
}