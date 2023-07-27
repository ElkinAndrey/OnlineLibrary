import React, { useEffect, useRef, useState } from "react";
import { useFetching } from "../../../hooks/useFetching";
import BookApi from "../../../api/bookApi";
import { SearchSettings } from "../../../views/SearchSettings/SearchSettings";
import PaginationBar from "../../forms/PaginationBar/PaginationBar";

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

/**Получить новые настройки */
const getNewSettings = (newSettings, start = 0, length = pageSize) => {
  return { ...newSettings, start: start, length: length };
};

/**Страница с книгами */
const Books = () => {
  // Вспомогательные переменные
  const fetchedRef = useRef(true);
  let [useEffectCall, setUseEffectCall] = useState(true);
  let [page, setPage] = useState(basePage);

  // Данные
  let [books, setBooks] = useState([]);
  let [booksCount, setBooksCount] = useState([]);
  let [searchSettings, setSearchSettings] = useState(baseSearchSettings);
  let [newSearchSettings, setNewSearchSettings] = useState(baseSearchSettings);

  // Получение данных
  const [fetchBooks, isLoadingBooks, errorBooks] = useFetching(
    async (settings) => {
      console.log(1);
      const response = await BookApi.getBooks(settings);
      setBooks(response.data);
    }
  );
  const [fetchBooksCount, isLoadingBooksCount, errorBooksCount] = useFetching(
    async (settings) => {
      console.log(2);
      const response = await BookApi.getBooksCount(settings);
      setBooksCount(response.data);
    }
  );

  useEffect(() => {
    if (fetchedRef.current) {
      fetchedRef.current = false;
      return;
    }
    let settings = getNewSettings(
      searchSettings,
      (page - 1) * pageSize,
      pageSize
    );
    setSearchSettings(settings);
    fetchBooks(settings);
    fetchBooksCount(settings);
  }, [page, useEffectCall]);

  // Функции
  const update = () => {
    let newSettings = getNewSettings(newSearchSettings);
    setSearchSettings(newSettings);
    changePage();
  };

  const changePage = () => {
    if (page === 1) {
      setUseEffectCall(!useEffectCall);
    } else {
      setPage(basePage);
    }
  };

  return (
    <>
      <SearchSettings
        settings={newSearchSettings}
        setSettings={setNewSearchSettings}
      />
      <button onClick={update}>Обновить</button>
      <div>{`Количество найденных книг: ${booksCount}`}</div>
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
          </tr>
        </thead>
        <tbody>
          {books.map((book) => (
            <tr key={book.id}>
              <td>{book.name}</td>
              <td>{book.editionNumber}</td>
              <td>{book.authors.join(", ")}</td>
              <td>{book.year}</td>
              <td>{book.language.abbreviation}</td>
              <td>{book.topics.join(", ")}</td>
              <td>{book.numberPages}</td>
              <td>{book.numberAdditionsNotes}</td>
            </tr>
          ))}
        </tbody>
      </table>
      <PaginationBar
        min={1}
        max={100}
        page={page}
        setPage={setPage}
        centerCount={3}
      />
    </>
  );
};

export default Books;
