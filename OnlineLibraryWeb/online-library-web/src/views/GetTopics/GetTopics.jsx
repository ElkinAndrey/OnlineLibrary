import React from "react";
import { useFetching } from "../../hooks/useFetching";
import { useState } from "react";
import { useEffect } from "react";
import { useRef } from "react";
import TopicApi from "../../api/topicApi";
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

const GetTopics = ({ selectedTopics, setSelectedTopics, addResetFuncs }) => {
  // Вспомогательные переменные
  const fetchedRef = useRef(true);
  let [page, setPage] = useState(basePage);

  // Данные
  let [topics, setTopics] = useState([]);
  let [topicsCount, setTopicsCount] = useState([]);
  let [searchSettings, setSearchSettings] = useState(baseSearchSettings);
  let [newSearchSettings, setNewSearchSettings] = useState(baseSearchSettings);

  // Получение данных
  const [fetchTopics, isLoadingTopics, errorTopics] = useFetching(
    async (settings) => {
      const response = await TopicApi.getTopics(settings);
      setTopics(response.data);
    }
  );
  const [fetchTopicsCount, isLoadingTopicsCount, errorTopicsCount] =
    useFetching(async (settings) => {
      const response = await TopicApi.getTopicsCount(settings);
      setTopicsCount(response.data);
    });

  useEffect(() => {
    if (fetchedRef.current) {
      fetchedRef.current = false;
      return;
    }
    addResetFuncs(reset);
    updateFetch(searchSettings);
  }, []);

  // Функции
  const updateFetch = (settings) => {
    fetchTopics(settings);
    fetchTopicsCount(settings);
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
    setSelectedTopics([]);
    updateFetch(baseSearchSettings);
  };

  return (
    <div>
      <div>
        Название:{" "}
        <input
          value={searchSettings.name ?? ""}
          onChange={(e) =>
            setSearchSettings({ ...searchSettings, name: e.target.value })
          }
        />
      </div>
      <div>
        <button onClick={() => update()}>Обновить</button>
        <button onClick={() => reset()}>Сбросить</button>
      </div>
      <div>{`Количество тем: ${topicsCount}`}</div>
      <table>
        <thead>
          <tr>
            <th>Название</th>
            <th>Добавить</th>
          </tr>
        </thead>
        <tbody>
          {topics.map((topic) => (
            <tr key={topic.id}>
              <td>{topic.name}</td>
              <td>
                <input
                  type={"checkbox"}
                  checked={(selectedTopics ?? []).some(
                    (t) => t.id === topic.id
                  )}
                  onChange={() => {
                    if ((selectedTopics ?? []).some((t) => t.id === topic.id)) {
                      let newTopics = selectedTopics.filter(
                        (t) => t.id !== topic.id
                      );
                      setSelectedTopics(newTopics);
                    } else {
                      setSelectedTopics([...selectedTopics, topic]);
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
        max={Math.ceil(topicsCount / pageSize)}
        page={page}
        setPage={setNewPage}
        centerCount={1}
      />
    </div>
  );
};

export default GetTopics;
