import { useState } from "react";
import { ButtonNT } from "../../components/Buttons/Buttons";
import Container from "../../components/Container/Container";
import { InputSearch } from "../../components/Inputs/Inputs";
import MainContent from "../../components/MainContent/MainContent";
import { TitleDate } from "../../components/Titles/Titles";
import ModalCheck from "../../components/Modal/Modal";
import { CheckList } from "../../components/CheckList/CheckList";
import ModalUpdate from "../../components/Modal/ModalUpdate";


function HomePage() {

  const [showModal, setShowModal] = useState(false);

  const [showModalUpdate, setshowModalUpdate] = useState(false);

  const [filterSearch, setFilterSearch] = useState('')

  const [tasks, setTasks] = useState([]);

  const handleAddTask = (description) => {
    setTasks([...tasks, { description, toDo: false }]);
  };

  const handleCheck = (index) => {
    const newCheckTask = [...tasks]; 
    newCheckTask[index].toDo = !newCheckTask[index].toDo; 
    setTasks(newCheckTask);
  };

  const handleUpdate = (index, description) => {
    setTasks(tasks.map((task, i) =>
      i === index ? { ...task, description } : task
    ));
  };

  const handleDelete = (index) => {
    setTasks(tasks.filter((_, i) => i !== index)); 
  };

  const filteredTasks = tasks.filter(task =>
    task.description.toLowerCase().includes(filterSearch.toLowerCase())
  );

  return (
    <MainContent>

      <Container>

        <TitleDate />

        {/* input da pesquisa/filtro */}
        <InputSearch onChangeSearch={setFilterSearch} value={filterSearch} />


        {/* checklist com opcao p update e delete */}
        <CheckList
          tasks={filteredTasks}
          onUpdate={handleUpdate}
          onDelete={handleDelete}
          onChange={handleCheck}
        />

      </Container>

      {/* botao nova tarefa */}
      <ButtonNT onClick={() => setShowModal(true)} />

      {showModal ? <ModalCheck onAddTask={handleAddTask} closeModal={() => setShowModal(false)} /> : <></>}

    </MainContent>


  );
}

export default HomePage;
