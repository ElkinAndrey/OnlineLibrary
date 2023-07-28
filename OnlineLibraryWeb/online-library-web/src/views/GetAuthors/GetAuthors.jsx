import React from "react";
import { useFetching } from "../../hooks/useFetching";
import { useState } from "react";
import { useEffect } from "react";
import { useRef } from "react";
import AuthorsApi from "../../api/authorsApi";
import PaginationBar from "../../components/forms/PaginationBar/PaginationBar";

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

const GetAuthors = ({ selectedAuthors, setSelectedAuthors, setReset }) => {
  // Вспомогательные переменные
  const fetchedRef = useRef(true);
  let [page, setPage] = useState(basePage);

  // Данные
  let [authors, setAuthors] = useState([]);
  let [authorsCount, setAuthorsCount] = useState([]);
  let [searchSettings, setSearchSettings] = useState(baseSearchSettings);
  let [newSearchSettings, setNewSearchSettings] = useState(baseSearchSettings);

  // Получение данных
  const [fetchAuthors, isLoadingAuthors, errorAuthors] = useFetching(
    async (settings) => {
      const response = await AuthorsApi.getAuthors(settings);
      setAuthors(response.data);
    }
  );
  const [fetchAuthorsCount, isLoadingAuthorsCount, errorAuthorsCount] =
    useFetching(async (settings) => {
      const response = await AuthorsApi.getAuthorsCount(settings);
      setAuthorsCount(response.data);
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
    fetchAuthors(settings);
    fetchAuthorsCount(settings);
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
    setSelectedAuthors([]);
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
      <div>{`Количество авторов: ${authorsCount}`}</div>
      <table>
        <thead>
          <tr>
            <th>Название</th>
            <th>Добавить</th>
          </tr>
        </thead>
        <tbody>
          {authors.map((author) => (
            <tr key={author.id}>
              <td>{author.name}</td>
              <td>
                <input
                  type={"checkbox"}
                  checked={(selectedAuthors ?? []).some(
                    (t) => t.id === author.id
                  )}
                  onChange={() => {
                    if (
                      (selectedAuthors ?? []).some((t) => t.id === author.id)
                    ) {
                      let newAuthors = selectedAuthors.filter(
                        (t) => t.id !== author.id
                      );
                      setSelectedAuthors(newAuthors);
                    } else {
                      setSelectedAuthors([...selectedAuthors, author]);
                    }
                  }}
                />
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <PaginationBar
        min={1}
        max={Math.ceil(authorsCount / pageSize)}
        page={page}
        setPage={setNewPage}
        centerCount={1}
      />
    </div>
  );
};

export default GetAuthors;
