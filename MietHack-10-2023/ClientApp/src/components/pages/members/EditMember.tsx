import { useEffect, useState } from "react";
import { Button } from "primereact/button";
import { InputText } from "primereact/inputtext";

export const EditMember = (member: any, onEdit: () => void) => {  
  const [comment, setComment] = useState("");
  useEffect(() => {
    setComment(member && member.comment || "")
  }, [member])

  return (
    <>
      <div style={{ paddingBottom: "10px" }}>
        <InputText
          placeholder="Комментарий"
          onChange={(e) => setComment(e.target.value)}
          style={{ width: "100%" }}
          value={comment}
        />
      </div>
      <div style={{ 'justifyContent': 'flex-end', 'display': 'flex'}}>
        <Button style={{ 'borderRadius': '10px' }} onClick={() => onEdit()}>
          Обновить
        </Button>
      </div>
    </>
  );
};
