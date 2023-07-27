import React, { useEffect, useRef, useState } from "react";
import { useFetching } from "../../../hooks/useFetching";
import BookApi from "../../../api/bookApi";

const pageSize = 20;

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

const Books = () => {
  // Вспомогательные переменные
  const fetchedRef = useRef(false);

  // Данные
  let [books, setBooks] = useState([]);
  let [booksCount, setBooksCount] = useState([]);
  let [searchSettings, setSearchSettings] = useState(baseSearchSettings);

  // Получение данных
  const [fetchBooks, isLoadingBooks, errorBooks] = useFetching(
    async (settings) => {
      const response = await BookApi.getBooks(settings);
      setBooks(response.data);
    }
  );
  const [fetchBooksCount, isLoadingBooksCount, errorBooksCount] = useFetching(
    async (settings) => {
      const response = await BookApi.getBooksCount(settings);
      setBooksCount(response.data);
    }
  );

  useEffect(() => {
    if (!fetchedRef.current) fetchedRef.current = true;
    fetchBooks(searchSettings);
    fetchBooksCount(searchSettings);
  }, []);

  return (
    <>
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
    </>
  );
};

export default Books;
