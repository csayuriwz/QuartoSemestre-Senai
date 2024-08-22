import React, { useState } from 'react';
import './Modal.css';
import { ModalTitle } from '../Titles/Titles';
import { ConfirmTask } from '../Buttons/Buttons';

const ModalUpdate = ({closeModal, onUpdateTask, index }) => {

  const [taskDescription, setTaskDescription] = useState('');

  const handleUpdate = () => {
    if (index !== null) {
      onUpdateTask(index, taskDescription);
      setTaskDescription('');
      closeModal();
    }
  }

  return (
    <div className="modal">

      <div className="modal-content">

        <ModalTitle/>

        <input 
          className="modal-input"
          type="text"
          value={taskDescription} 
          onChange={(e) => setTaskDescription(e.target.value)} 
          placeholder="Tarefa..." 
        />

        <ConfirmTask text={"Atualizar tarefa"} onClick={handleUpdate}/>

      </div>

    </div>
  );
};

export default ModalUpdate;