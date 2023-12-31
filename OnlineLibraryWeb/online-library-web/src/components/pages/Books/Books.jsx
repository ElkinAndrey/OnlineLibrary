import React, { useEffect, useRef, useState } from "react";
import { useFetching } from "../../../hooks/useFetching";
import EditionLanguagesApi from "../../../api/editionLanguagesApi";
import { SearchSettings } from "../../../views/SearchSettings/SearchSettings";
import PaginationBar from "../../forms/PaginationBar/PaginationBar";
import { Link } from "react-router-dom";

/**Количество книг на странице */
const pageSize = 20;

/**Страница по умолчанию */
const basePage = 1;

/**Базовые настройки для получения книг */
const baseSearchSettings = {
  start: 0,
  length: pageSize,
  name: null,
  yearMin: null,
  yearMax: null,
  numberPagesMin: null,
  numberPagesMax: null,
  numberAdditionsNotesMin: null,
  numberAdditionsNotesMax: null,
  languageId: null,
  mustHaveAllTopics: false,
  topics: [],
  mustHaveAllAuthors: false,
  authors: [],
  mustHaveAllPublishers: false,
  publishers: [],
};

/**Страница с книгами */
const Books = () => {
  // Вспомогательные переменные
  const fetchedRef = useRef(true);
  let [page, setPage] = useState(basePage);

  // Данные
  let [books, setBooks] = useState([]);
  let [booksCount, setBooksCount] = useState([]);
  let [searchSettings, setSearchSettings] = useState(baseSearchSettings);
  let [newSearchSettings, setNewSearchSettings] = useState(baseSearchSettings);
  let [resetFunc, setResetFunc] = useState({ run: () => {} });

  // Получение данных
  const [fetchBooks, isLoadingBooks, errorBooks] = useFetching(
    async (settings) => {
      const response = await EditionLanguagesApi.getBooks(settings);
      setBooks(response.data);
    }
  );
  const [fetchBooksCount, isLoadingBooksCount, errorBooksCount] = useFetching(
    async (settings) => {
      const response = await EditionLanguagesApi.getBooksCount(settings);
      setBooksCount(response.data);
    }
  );

  useEffect(() => {
    if (fetchedRef.current) {
      fetchedRef.current = false;
      return;
    }
    updateFetch(searchSettings);
  }, []);

  // Функции
  const updateFetch = (settings) => {
    fetchBooks(settings);
    fetchBooksCount(settings);
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
    resetFunc.run();
    setPage(basePage);
    setSearchSettings(baseSearchSettings);
    setNewSearchSettings(baseSearchSettings);
    updateFetch(baseSearchSettings);
  };

  return (
    <>
      <SearchSettings
        settings={newSearchSettings}
        setSettings={setNewSearchSettings}
        setResetFunc={setResetFunc}
      />
      <button onClick={update}>Обновить</button>
      <button onClick={reset}>Сбросить</button>
      <div>{`Количество найденных книг: ${booksCount}`}</div>
      <Link to={"/add"}>Добавить книгу</Link>
      <table>
        <thead>
          <tr>
            <th>Название</th>
            <th>Издание</th>
            <th>Авторы</th>
            <th>Год</th>
            <th>Язык</th>
            <th>Темы</th>
            <th>Количество страниц</th>
            <th>В заметках</th>
            <th>Скачиваний</th>
            <th>Открыть</th>
          </tr>
        </thead>
        <tbody>
          {books.map((book) => (
            <tr key={book.editionLanguageId}>
              <td>{book.name}</td>
              <td>{book.editionNumber}</td>
              <td>{book.authors.join(", ")}</td>
              <td>{book.year}</td>
              <td>{book.language.abbreviation}</td>
              <td>{book.topics.join(", ")}</td>
              <td>{book.numberPages}</td>
              <td>{book.numberAdditionsNotes}</td>
              <td>{book.numberDownloads}</td>
              <td>
                <Link to={book.editionLanguageId}>Открыть</Link>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <PaginationBar
        min={1}
        max={Math.ceil(booksCount / pageSize)}
        page={page}
        setPage={setNewPage}
        centerCount={3}
      />
    </>
  );
};

export default Books;
