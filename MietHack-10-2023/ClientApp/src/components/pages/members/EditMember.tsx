import { useEffect, useState } from "react";
import { Button } from "primereact/button";
import { InputText } from "primereact/inputtext";
import { InputMask } from "primereact/inputmask";
import { Calendar } from "primereact/calendar";

export const EditMember = (member: any, onEdit: () => void) => {
  const [comment, setComment] = useState("");
  const [telephone, setTelephone] = useState("");
  const [mail, setMail] = useState("");
  const [birthday, setBirthday] = useState(new Date());
  useEffect(() => {
    setComment((member && member.comment) || "");
  }, [member]);

  return (
    <>
      <div style={{ paddingBottom: "10px" }}>
        <Calendar
          value={birthday}
          onChange={(e) => setBirthday(e.value || new Date())}
          dateFormat="dd.mm.yy"
          style={{ width: "100%" }}
        />
      </div>
      <div style={{ paddingBottom: "10px" }}>
        <InputMask
          placeholder="Телефон"
          onChange={(e) => setTelephone(e.target.value || "")}
          style={{ width: "100%" }}
          mask="+9-(999)-999-99-99"
          value={telephone}
        />
      </div>
      <div style={{ paddingBottom: "10px" }}>
        <InputText
          placeholder="Почта"
          onChange={(e) => setMail(e.target.value)}
          style={{ width: "100%" }}
          value={mail}
        />
      </div>
      <div style={{ paddingBottom: "10px" }}>
        <InputText
          placeholder="Комментарий"
          onChange={(e) => setComment(e.target.value)}
          style={{ width: "100%" }}
          value={comment}
        />
      </div>
      <div style={{ justifyContent: "flex-end", display: "flex" }}>
        <Button style={{ borderRadius: "10px" }} onClick={() => onEdit()}>
          Обновить
        </Button>
      </div>
    </>
  );
};
