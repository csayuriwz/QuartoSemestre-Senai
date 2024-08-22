import "./Titles.css"

const DiaSemana = [
  "Domingo",
  "Segunda",
  "Terça",
  "Quarta",
  "Quinta",
  "Sexta",
  "Sábado",
]

const MesAno = [
  "Janeiro",
  "Fevereiro",
  "Março",
  "Abril",
  "Maio",
  "Junho",
  "Julho",
  "Agosto",
  "Setembro",
  "Outubro",
  "Novembro",
  "Dezembro",
]


export function TitleDate({dayText, day, month}) {

  const date = new Date();

  const dia = date.getDay();
  const diaNumero = date.getDate();
  const mes = date.getMonth();

  return (
    <h1 className="title-date">{`${DiaSemana[dia]}, `} <span className="span-day">{diaNumero}</span> de {MesAno[mes]}</h1>
  );
}


export function ModalTitle() {
  return (
    <h1 className="modal-text">Descreva sua tarefa</h1>
  )
}
