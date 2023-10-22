import { useState } from "react";
import { Dropdown } from "primereact/dropdown";
import { Button } from "primereact/button";

export const ChoiseStudent = (onAdd: () => void) => {
  const [group, setGroup] = useState(null);

  const groups = ["ПИН-44", "ПИН-43", "ПИН-42"];
  const studentsList = [
    "Иванов Иван Иванович",
    "Петров Петр Иванович",
    "Васильев Василий Василиевич",
  ];

  return (
    <>
      <div style={{ paddingBottom: "10px" }}>
        <Dropdown
          value={group}
          onChange={(e) => setGroup(e.value)}
          options={groups}
          placeholder="Выбрать группу"
          style={{ width: "100%" }}
        />
      </div>
      <div style={{ paddingBottom: "10px" }}>
        <Dropdown
          value={group}
          onChange={(e) => setGroup(e.value)}
          options={studentsList}
          placeholder="Выбрать студента"
          style={{ width: "100%" }}
        />
      </div>
      <div style={{ 'justifyContent': 'flex-end', 'display': 'flex'}}>
        <Button style={{ 'borderRadius': '10px' }} onClick={() => onAdd()}>
          Добавить
        </Button>
      </div>
    </>
  );
};
