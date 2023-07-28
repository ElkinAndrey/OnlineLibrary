import React from "react";
import { useFetching } from "../../hooks/useFetching";
import { useState } from "react";
import { useEffect } from "react";
import { useRef } from "react";
import PublishersApi from "../../api/publishersApi";
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

const GetPublishers = ({
  selectedPublishers,
  setSelectedPublishers,
  setReset,
}) => {
  // Вспомогательные переменные
  const fetchedRef = useRef(true);
  let [page, setPage] = useState(basePage);

  // Данные
  let [publishers, setPublishers] = useState([]);
  let [publishersCount, setPublishersCount] = useState([]);
  let [searchSettings, setSearchSettings] = useState(baseSearchSettings);
  let [newSearchSettings, setNewSearchSettings] = useState(baseSearchSettings);

  // Получение данных
  const [fetchPublishers, isLoadingPublishers, errorPublishers] = useFetching(
    async (settings) => {
      const response = await PublishersApi.getPublishers(settings);
      setPublishers(response.data);
    }
  );
  const [fetchPublishersCount, isLoadingPublishersCount, errorPublishersCount] =
    useFetching(async (settings) => {
      const response = await PublishersApi.getPublishersCount(settings);
      setPublishersCount(response.data);
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
    fetchPublishers(settings);
    fetchPublishersCount(settings);
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
    setSelectedPublishers([]);
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
      <div>{`Количество тем: ${publishersCount}`}</div>
      <table>
        <thead>
          <tr>
            <th>Название</th>
            <th>Добавить</th>
          </tr>
        </thead>
        <tbody>
          {publishers.map((publisher) => (
            <tr key={publisher.id}>
              <td>{publisher.name}</td>
              <td>
                <input
                  type={"checkbox"}
                  checked={(selectedPublishers ?? []).some(
                    (t) => t.id === publisher.id
                  )}
                  onChange={() => {
                    if (
                      (selectedPublishers ?? []).some(
                        (t) => t.id === publisher.id
                      )
                    ) {
                      let newPublishers = selectedPublishers.filter(
                        (t) => t.id !== publisher.id
                      );
                      setSelectedPublishers(newPublishers);
                    } else {
                      setSelectedPublishers([...selectedPublishers, publisher]);
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
        max={Math.ceil(publishersCount / pageSize)}
        page={page}
        setPage={setNewPage}
        centerCount={1}
      />
    </div>
  );
};

export default GetPublishers;
