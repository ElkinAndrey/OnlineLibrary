import React, { useState } from "react";
import Modal from "../../components/forms/Modal/Modal";

const SetSearch = ({
  name,
  mustHaveAllName,
  mustHaveAll,
  setMustHaveAll,
  children,
}) => {
  // Вспомогательные переменные
  let [modalActive, setModalActive] = useState(false);

  return (
    <div style={{ border: "3px solid black" }}>
      <div>{name}</div>
      {((mustHaveAllName !== null && mustHaveAllName !== undefined) ||
        (mustHaveAll !== null && mustHaveAll !== undefined) ||
        (setMustHaveAll !== null && setMustHaveAll !== undefined)) && (
        <div>
          {mustHaveAllName}
          <input
            type={"checkbox"}
            checked={mustHaveAll}
            onChange={setMustHaveAll}
          />
        </div>
      )}
      <div>
        <button onClick={() => setModalActive(true)}>Добавить</button>
      </div>
      <Modal active={modalActive} setActive={setModalActive}>
        {children}
      </Modal>
    </div>
  );
};

export default SetSearch;
