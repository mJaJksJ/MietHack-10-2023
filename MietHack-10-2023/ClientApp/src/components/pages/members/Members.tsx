import { Card } from "primereact/card";
import { Layout } from "../../menu/Layout";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { Button } from "primereact/button";
import "./Members.css";
import "primereact/resources/themes/lara-light-indigo/theme.css";
import { useRef, useState } from "react";
import { Toast } from "primereact/toast";
import { ConfirmDialog, confirmDialog } from "primereact/confirmdialog";
import { Dialog } from "primereact/dialog";
import { ChoiseStudent } from "../choise-student/ChoiseStudent";
import { EditMember } from "./EditMember";

const members = [
  {
    id: 1,
    name: "Ланселот Банович де Бенуа",
    group: "ПИН-44",
    comment: "Крутой",
    birthday: "02.03.921",
    telephone: "+7-(999)-999-99-99",
    mail: "8188888@miet.ru",
    addingDate: "01.05.931",
    lastUpdateDate: "01.05.931",
  },
  {
    id: 4,
    name: "Галахад Ланселотович Озерный",
    group: "В-11",
    comment: "Пронес чашу с вином в стс-ку",
    birthday: "02.03.921",
    telephone: "+7-(999)-999-99-99",
    mail: "8188888@miet.ru",
    addingDate: "07.04.945",
    lastUpdateDate: "01.05.931",
  },
  {
    id: 5,
    name: "Артур Утерович Пендрагон",
    group: "К-10",
    comment: "На вступительных достал меч из камня",
    birthday: "02.03.921",
    telephone: "+7-(999)-999-99-99",
    mail: "8188888@miet.ru",
    addingDate: "12.09.928",
    lastUpdateDate: "01.05.931",
  },
];

export const Members = () => {
  const toast = [
    { id: 1, value: useRef<Toast>(null) },
    { id: 4, value: useRef<Toast>(null) },
    { id: 5, value: useRef<Toast>(null) },
  ];
  const accept = (name: string, id: number) => {
    toast
      .find((x) => x.id === id)
      ?.value.current?.show({
        severity: "success",
        summary: "Confirmed",
        detail: `Участник ${name} удален`,
        life: 2000,
      });
  };
  const confirmDelete = (name: string, id: number) => {
    confirmDialog({
      message: `Вы уверены что хотите удалить участника ${name}?`,
      header: "Подтверждение действия",
      icon: "pi pi-exclamation-triangle",
      accept: () => accept(name, id),
    });
  };

  const actions = (row: any) => {
    return (
      <>
        <Toast ref={toast.find((x) => x.id === row.id)?.value} />
        <ConfirmDialog />
        <div style={{ minWidth: "80px" }}>
          <Button
            id="row.id"
            className="button pi pi-fw pi-pencil"
            tooltip="Редактировать"
            onClick={() => {
              setEditRow(row);
              setVisibleEdit(true);
            }}
          ></Button>
          <Button
            id="row.id"
            onClick={() => confirmDelete(row.name, row.id)}
            className="button pi pi-fw pi-times"
            tooltip="Удалить"
          ></Button>
        </div>
      </>
    );
  };

  const [visibleAdd, setVisibleAdd] = useState(false);
  const [visibleEdit, setVisibleEdit] = useState(false);
  const [editRow, setEditRow] = useState(null);
  return (
    <Layout>
      <Dialog
        header="Добавить участника"
        visible={visibleAdd}
        style={{ width: "50vw" }}
        onHide={() => setVisibleAdd(false)}
      >
        {ChoiseStudent(() => {
          setVisibleAdd(false);
        })}
      </Dialog>
      <Dialog
        header="Редактировать участника"
        visible={!!editRow && visibleEdit}
        style={{ width: "50vw" }}
        onHide={() => {
          setVisibleEdit(false);
          setEditRow(null);
        }}
      >
        {EditMember(editRow, () => {
          setVisibleEdit(false);
          setEditRow(null);
        })}
      </Dialog>
      <Card title="Состав СО">
        <Button
          style={{ borderRadius: "10px", marginBottom: "10px" }}
          onClick={() => setVisibleAdd(true)}
        >
          Добавить участника
        </Button>
        <DataTable value={members} showGridlines tableStyle={{}}>
          <Column header="Действие" body={actions}></Column>
          <Column field="name" header="Имя"></Column>
          <Column field="group" header="Группа"></Column>
          <Column field="birthday" header="Дата рождения"></Column>
          <Column field="telephone" header="Телефон"></Column>
          <Column field="mail" header="Почта"></Column>
          <Column field="comment" header="Комментарий"></Column>
          <Column field="addingDate" header="Дата добавления"></Column>
        </DataTable>
      </Card>
    </Layout>
  );
};
