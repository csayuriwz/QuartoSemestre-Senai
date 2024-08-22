import React, { useState } from 'react';
import './Modal.css';
import { ModalTitle } from '../Titles/Titles';
import { ConfirmTask } from '../Buttons/Buttons';

const ModalCheck = ({ onAddTask, closeModal, onUpdateTask }) => {
  const [taskDescription, setTaskDescription] = useState('');

  const handleAddTask = () => {
    onAddTask(taskDescription);
    setTaskDescription(''); 
    closeModal();
  };

  const handleUpdate = () => {
    onUpdateTask(taskDescription);
    setTaskDescription('');
    closeModal();
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

        <ConfirmTask text={"Confirmar tarefa"} onClick={handleAddTask}/>

      </div>

    </div>
  );
};

export default ModalCheck;