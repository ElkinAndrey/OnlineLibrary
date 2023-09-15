import React, { useEffect, useRef, useState } from "react";
import { isNullOrEmpty } from "../../utils/isNullOrEmpty";
import Modal from "../../components/forms/Modal/Modal";
import PaginationBar from "../../components/forms/PaginationBar/PaginationBar";
import { useFetching } from "../../hooks/useFetching";
import FileExtensionsApi from "../../api/fileExtensionsApi";

const SetSearchOne = ({
  groupName,
  name,
  empty,
  header,
  getElements,
  getCount,
  setReset,
  setElementId,
  getId,
  getName,
}) => {
  // Константы
  const basePage = 1;
  const pageSize = 10;
  const baseSearchSettings = {
    start: (basePage - 1) * pageSize,
    length: pageSize,
    name: null,
  };

  // Переменные
  const fetchedRef = useRef(true);
  const [page, setPage] = useState(basePage);
  const [modalActive, setModalActive] = useState("");
  const [selectedElement, setSelectedElement] = useState({});
  const [searchSettings, setSearchSettings] = useState(baseSearchSettings);
  const [newSearchSettings, setNewSearchSettings] =
    useState(baseSearchSettings);
  const [elements, setElements] = useState([]);
  const [count, setCount] = useState(0);

  // Получение данных
  const [fetchElements, isLoadingElements, errorElements] = useFetching(
    async (settings) => {
      const response = await getElements(settings);
      setElements(response.data);
    }
  );

  const [fetchElementsCount, isLoadingElementsCount, errorElementsCount] =
    useFetching(async (settings) => {
      const response = await getCount(settings);
      setCount(response.data);
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
    fetchElements(settings);
    fetchElementsCount(settings);
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
    setSelectedElement({});
    setElementId(null);
    updateFetch(baseSearchSettings);
  };

  return (
    <div>
      {`${name}: ${
        isNullOrEmpty(getName(selectedElement))
          ? empty
          : getName(selectedElement)
      } `}
      <button onClick={() => setModalActive(true)}>Изменить</button>
      <Modal active={modalActive} setActive={setModalActive}>
        <h1 style={{ textAlign: "center" }}>{header}</h1>
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
          <div>{`Количество языков: ${count}`}</div>
          <div>{`Элемент: ${
            isNullOrEmpty(selectedElement.name) ? empty : selectedElement.name
          } `}</div>
          <table>
            <thead>
              <tr>
                <th>Название</th>
                <th>Выбрать</th>
              </tr>
            </thead>
            <tbody>
              {elements.map((element) => (
                <tr key={getId(element)}>
                  <td>{getName(element)}</td>
                  <td>
                    <input
                      type={"radio"}
                      name={groupName}
                      checked={
                        getId(selectedElement) !== null &&
                        getId(element) === getId(selectedElement)
                      }
                      onChange={() => {
                        setSelectedElement(element);
                        setElementId(getId(element));
                      }}
                    />
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          <PaginationBar
            min={1}
            max={Math.ceil(count / pageSize)}
            page={page}
            setPage={setNewPage}
            centerCount={1}
          />
        </div>
      </Modal>
    </div>
  );
};

export default SetSearchOne;
