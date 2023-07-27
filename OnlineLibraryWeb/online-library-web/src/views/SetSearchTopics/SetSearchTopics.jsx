import React, { useState } from "react";
import Modal from "../../components/forms/Modal/Modal";
import GetTopics from "../GetTopics/GetTopics";

const SetSearchTopics = ({ settings, setSettings, addResetFuncs }) => {
  // Вспомогательные переменные
  let [modalActive, setModalActive] = useState(false);

  // Данные
  let [topics, setTopics] = useState([]);

  return (
    <div style={{ border: "3px solid black" }}>
      <div>{`Темы: ${topics.map((t) => t.name).join(", ")}`}</div>
      <div>
        Книга должна иметь все выбранные темы
        <input
          type={"checkbox"}
          checked={settings.mustHaveAllTopics}
          onChange={() => {
            setSettings({
              ...settings,
              mustHaveAllTopics: !settings.mustHaveAllTopics,
            });
          }}
        />
      </div>
      <div>
        <button onClick={() => setModalActive(true)}>Добавить</button>
      </div>
      <Modal active={modalActive} setActive={setModalActive}>
        <GetTopics
          selectedTopics={topics}
          setSelectedTopics={(t) => {
            setTopics(t);
            setSettings({ ...settings, topics: t.map((tt) => tt.id) });
          }}
          addResetFuncs={addResetFuncs}
        />
      </Modal>
    </div>
  );
};

export default SetSearchTopics;
