import React, { useEffect, useRef, useState } from "react";
import { Link, useParams } from "react-router-dom";
import BooksApi from "../../../api/booksApi";
import { useFetching } from "../../../hooks/useFetching";
import PaginationBar from "../../forms/PaginationBar/PaginationBar";

/**Количество языков на странице */
const pageSize = 10;

/**Страница по умолчанию */
const basePage = 1;

const BookEditionLanguage = () => {
  // Вспомогательные переменные
  const dataFetchedRef = useRef(false);
  const params = useParams();
  const [page, setPage] = useState(basePage);
  const [baseSearchSettings, setBaseSearchSettings] = useState({
    start: 0,
    length: pageSize,
    name: null,
    bookEditionLanguageId: params.bookId,
  });

  // Данные
  const [book, setBook] = useState({});
  let [bookEditionLanguages, setBookEditionLanguages] = useState([]);
  let [bookEditionLanguagesCount, setBookEditionLanguagesCount] = useState([]);
  let [searchSettings, setSearchSettings] = useState(baseSearchSettings);
  let [newSearchSettings, setNewSearchSettings] = useState(baseSearchSettings);

  // Получение данных
  const [fetchBook, isLoadingBook, errorBook] = useFetching(
    async (bookEditionLanguageId) => {
      const response = await BooksApi.getBookById(bookEditionLanguageId);
      setBook(response.data);
    }
  );
  const [fetchLanguages, isLoadingLanguages, errorLanguages] = useFetching(
    async (settings) => {
      const response = await BooksApi.getBookEditionLanguages(settings);
      setBookEditionLanguages(response.data);
    }
  );
  const [fetchLanguagesCount, isLoadingLanguagesCount, errorLanguagesCount] =
    useFetching(async (settings) => {
      const response = await BooksApi.getBookEditionLanguagesCount(settings);
      setBookEditionLanguagesCount(response.data);
    });

  useEffect(() => {
    if (dataFetchedRef.current) return;
    dataFetchedRef.current = true;
    fetchBook(params.bookId);
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
    updateFetch(baseSearchSettings);
  };

  return (
    <div>
      <div>
        <b>Название: </b>
        {`${book?.name}`}
      </div>
      <div>
        <b>Общее описание: </b>
        {`${book?.generalDescription}`}
      </div>
      <div>
        <b>Год издания: </b>
        {`${book?.year}`}
      </div>
      <div>
        <b>Описание конкретного издания: </b>
        {`${book?.description}`}
      </div>
      <div>
        <b>Количество страниц</b>
        {`${book?.numberPages}`}
      </div>
      <div>
        <b>Номер издания: </b>
        {`${book?.editionNumber}`}
      </div>
      <div>
        <b>Количество добавлений в заметки: </b>
        {`${book?.numberAdditionsNotes}`}
      </div>
      <div>
        <b>Количество скачиваний: </b>
        {`${book?.numberDownloads}`}
      </div>
      <div>
        <b>Категории: </b>
        {`${book?.topics?.join(", ")}`}
      </div>
      <div>
        <b>Авторы: </b>
        {`${book?.authors?.join(", ")}`}
      </div>
      <div>
        <b>Издательства: </b>
        {`${book?.publishers?.join(", ")}`}
      </div>
      <div>
        <b>Язык: </b>
        {`${book?.language?.name} ${book?.language?.englishName} ${book?.language?.abbreviation}`}
      </div>
      <div>
        <b>Другие издания этой же книги: </b>
        {(book.booksSameEdition ?? []).map((b) => (
          <label key={b.bookEditionLanguageId}>
            <Link to={`/${b.bookEditionLanguageId}`}>{b.editionNumber}</Link>
            {", "}
          </label>
        ))}
      </div>
      <div>
        <b>Скачать: </b>
        {(book.fileExtensions ?? []).map((f) => (
          <label key={f.id}>
            <Link>{f.name}</Link>
            {", "}
          </label>
        ))}
      </div>

      <div>
        <div>
          Название:{" "}
          <input
            value={newSearchSettings.name ?? ""}
            onChange={(e) =>
              setNewSearchSettings({
                ...newSearchSettings,
                name: e.target.value,
              })
            }
          />
        </div>
        <div>
          <button onClick={() => update()}>Обновить</button>
          <button onClick={() => reset()}>Сбросить</button>
        </div>
        <div>{`Количество языков: ${bookEditionLanguagesCount}`}</div>
        <table>
          <thead>
            <tr>
              <th>Название</th>
              <th>На английском</th>
              <th>Сокращение</th>
              <th>Страниц</th>
              <th>В заметках</th>
              <th>Скачиваний</th>
              <th>Открыть</th>
            </tr>
          </thead>
          <tbody>
            {(bookEditionLanguages ?? []).map((bookEditionLanguage) => (
              <tr key={bookEditionLanguage.language.id}>
                <td>{bookEditionLanguage.language.name}</td>
                <td>{bookEditionLanguage.language.englishName}</td>
                <td>{bookEditionLanguage.language.abbreviation}</td>
                <td>{bookEditionLanguage.numberPages}</td>
                <td>{bookEditionLanguage.numberAdditionsNotes}</td>
                <td>{bookEditionLanguage.numberDownloads}</td>
                <td>
                  <Link to={`/${bookEditionLanguage.bookEditionLanguageId}`}>
                    Открыть
                  </Link>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
        <PaginationBar
          min={1}
          max={Math.ceil(bookEditionLanguagesCount / pageSize)}
          page={page}
          setPage={setNewPage}
          centerCount={1}
        />
      </div>
    </div>
  );
};

export default BookEditionLanguage;
