import React, { useEffect, useRef, useState } from "react";
import PaginationBar from "../../components/forms/PaginationBar/PaginationBar";
import { useFetching } from "../../hooks/useFetching";
import LanguagesApi from "../../api/languagesApi";

/**Количество книг на странице */
const pageSize = 10;

/**Страница по умолчанию */
const basePage = 1;

/**Базовые настройки для получения книг */
const baseSearchSettings = {
  start: 0,
  length: pageSize,
  name: null,
};

const GetLanguage = ({ selectedLanguage, setSelectedLanguage, setReset }) => {
  // Вспомогательные переменные
  const fetchedRef = useRef(true);
  let [page, setPage] = useState(basePage);

  // Данные
  let [languages, setLanguages] = useState([]);
  let [languagesCount, setLanguagesCount] = useState([]);
  let [searchSettings, setSearchSettings] = useState(baseSearchSettings);
  let [newSearchSettings, setNewSearchSettings] = useState(baseSearchSettings);

  // Получение данных
  const [fetchLanguages, isLoadingLanguages, errorLanguages] = useFetching(
    async (settings) => {
      const response = await LanguagesApi.getLanguages(settings);
      setLanguages(response.data);
    }
  );
  const [fetchLanguagesCount, isLoadingLanguagesCount, errorLanguagesCount] =
    useFetching(async (settings) => {
      const response = await LanguagesApi.getLanguagesCount(settings);
      setLanguagesCount(response.data);
    });

  useEffect(() => {
    if (fetchedRef.current) {
      fetchedRef.current = false;
      return;
    }
    setReset(reset);
    updateFetch(searchSettings);
  }, []);

  // Функции
  const updateFetch = (settings) => {
    fetchLanguages(settings);
    fetchLanguagesCount(settings);
  };

  const setNewPage = (page) => {
    let settings = {
      ...searchSettings,
      start: (page - 1) * pageSize,
      length: pageSize,
    };
    setPage(page);
    setSearchSettings(settings);
    updateFetch(settings);
  };

  const update = () => {
    let settings = {
      ...newSearchSettings,
      start: (basePage - 1) * pageSize,
      length: pageSize,
    };
    setPage(basePage);
    setSearchSettings(settings);
    updateFetch(settings);
  };

  const reset = () => {
    setPage(basePage);
    setSearchSettings(baseSearchSettings);
    setNewSearchSettings(baseSearchSettings);
    setSelectedLanguage({});
    updateFetch(baseSearchSettings);
  };

  return (
    <div>
      <div>
        Название:{" "}
        <input
          value={newSearchSettings.name ?? ""}
          onChange={(e) =>
            setNewSearchSettings({ ...newSearchSettings, name: e.target.value })
          }
        />
      </div>
      <div>
        <button onClick={() => update()}>Обновить</button>
        <button onClick={() => reset()}>Сбросить</button>
      </div>
      <div>{`Количество языков: ${languagesCount}`}</div>
      <div>{`Язык: ${
        Object.keys(selectedLanguage).length !== 0 &&
        selectedLanguage !== null &&
        selectedLanguage !== undefined
          ? `${selectedLanguage.name} (${selectedLanguage.englishName})`
          : ""
      }`}</div>
      <table>
        <thead>
          <tr>
            <th>Название</th>
            <th>На английском</th>
            <th>Сокращение</th>
            <th>Выбрать</th>
          </tr>
        </thead>
        <tbody>
          {languages.map((language) => (
            <tr key={language.id}>
              <td>{language.name}</td>
              <td>{language.englishName}</td>
              <td>{language.abbreviation}</td>
              <td>
                <input
                  type={"radio"}
                  name="radio"
                  checked={
                    selectedLanguage.id !== null &&
                    language.id === selectedLanguage.id
                  }
                  onChange={() => setSelectedLanguage(language)}
                />
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <PaginationBar
        min={1}
        max={Math.ceil(languagesCount / pageSize)}
        page={page}
        setPage={setNewPage}
        centerCount={1}
      />
    </div>
  );
};

export default GetLanguage;
