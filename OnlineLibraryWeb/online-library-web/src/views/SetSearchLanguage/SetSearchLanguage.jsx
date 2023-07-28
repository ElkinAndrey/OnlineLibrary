import React, { useState } from "react";
import Modal from "../../components/forms/Modal/Modal";
import GetLanguage from "../GetLanguage/GetLanguage";

const SetSearchLanguage = ({ settings, setSettings, setReset }) => {
  // Вспомогательные переменные
  let [modalActive, setModalActive] = useState(false);

  // Данные
  const [language, setLanguage] = useState({});

  return (
    <div>
      {`Язык: ${language.abbreviation ?? "Все языки"} `}
      <button onClick={() => setModalActive(true)}>Изменить</button>
      <Modal active={modalActive} setActive={setModalActive}>
        <h1 style={{ textAlign: "center" }}>Языки</h1>
        <GetLanguage
          selectedLanguage={language}
          setSelectedLanguage={(l) => {
            setLanguage(l);
            setSettings({ ...settings, languageId: l.id });
          }}
          setReset={setReset}
        />
      </Modal>
    </div>
  );
};

export default SetSearchLanguage;
