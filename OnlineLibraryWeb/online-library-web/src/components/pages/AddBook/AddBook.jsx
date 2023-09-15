import React, { useEffect, useRef, useState } from "react";
import InputNumder from "../../../views/InputNumder/InputNumder";
import SetSearch from "../../../views/SetSearch/SetSearch";
import GetTopics from "../../../views/GetTopics/GetTopics";
import GetAuthors from "../../../views/GetAuthors/GetAuthors";
import GetPublishers from "../../../views/GetPublishers/GetPublishers";
import SetSearchOne from "../../../views/SetSearchOne/SetSearchOne";
import { emptyFunc } from "../../../utils/emptyFunc";
import FileExtensionsApi from "../../../api/fileExtensionsApi";
import LanguagesApi from "../../../api/languagesApi";
import { isNullOrEmpty } from "../../../utils/isNullOrEmpty";
import { useFetching } from "../../../hooks/useFetching";
import BooksApi from "../../../api/booksApi";

const AddBook = () => {
  // Вспомогательные переменные
  const baseImage =
    "data:image/png;base64,R0lGODlhFAAUAIAAAP///wAAACH5BAEAAAAALAAAAAAUABQAAAIRhI+py+0Po5y02ouz3rz7rxUAOw==";
  const fetchedRef = useRef(true);
  const baseParams = {
    name: "",
    generalDescription: "",
    year: 0,
    description: "",
    editionNumber: "",
    numberPages: 0,
    topics: [],
    authors: [],
    publishers: [],
    language: null,
    fileExtensions: null,
    cover: "",
    file: "",
  };

  // Данные
  const [params, setParams] = useState(baseParams);

  let [selectedTopics, setSelectedTopics] = useState([]);
  let [selectedAuthors, setSelectedAuthors] = useState([]);
  let [selectedPublishers, setSelectedPublishers] = useState([]);

  let [resetFunc, setResetFunc] = useState({ run: emptyFunc });
  let [resetLanguage, setResetLanguage] = useState({ run: emptyFunc });
  let [resetFiles, setResetFiles] = useState({ run: emptyFunc });
  let [resetTopics, setResetTopics] = useState({ run: emptyFunc });
  let [resetAuthors, setResetAuthors] = useState({ run: emptyFunc });
  let [resetPublishers, setResetPublishers] = useState({ run: emptyFunc });

  const [coverName, setCoverName] = useState("");
  const [cover, setCover] = useState(null);
  const [coverSrc, setCoverSrc] = useState(baseImage);
  const [coverNotSelected, setCoverNotSelected] = useState(false);

  const [fileName, setFileName] = useState("");
  const [file, setFile] = useState(null);
  const [fileNotSelected, setFileNotSelected] = useState(false);

  // Отправка и получение данных
  const [fetchBook, isLoadingBook, errorBook] = useFetching(async (p) => {
    await BooksApi.addBook(p);
  });

  // Действия
  useEffect(() => {
    if (fetchedRef.current) {
      fetchedRef.current = false;
      return;
    }
    setResetFunc({
      run: () => {
        resetLanguage.run();
        resetTopics.run();
        resetAuthors.run();
        resetPublishers.run();
        resetFiles.run();
      },
    });
  }, [resetLanguage, resetTopics, resetAuthors, resetPublishers, resetFiles]);

  // Функции
  const reset = () => {
    resetFunc.run();
    setParams(baseParams);

    setCoverName("");
    setCover(null);
    setCoverSrc(baseImage);

    setFileName("");
    setFile(null);
  };

  const addCover = (e) => {
    if (e.target.files && e.target.files[0]) {
      let image = e.target.files[0];
      setCoverName(image.name);
      const reader = new FileReader();
      reader.onload = (x) => {
        setCover(image);
        setCoverSrc(x.target.result);
      };
      reader.readAsDataURL(image);
      setCoverNotSelected(false);
    }
  };

  const addFile = (e) => {
    if (e.target.files && e.target.files[0]) {
      let f = e.target.files[0];
      setFileName(f.name);
      const reader = new FileReader();
      reader.onload = (x) => {
        setFile(f);
      };
      reader.readAsDataURL(f);
      setFileNotSelected(false);
    }
  };

  const add = () => {
    fetchBook({ ...params, cover: cover, file: file });
  };

  return (
    <div>
      <div>
        {"Название: "}
        <input
          value={params.name ?? ""}
          onChange={(e) => setParams({ ...params, name: e.target.value })}
        />
      </div>

      <div>
        <div>Общее описание</div>
        <textarea
          value={params.generalDescription ?? ""}
          onChange={(v) =>
            setParams({ ...params, generalDescription: v.target.value })
          }
        ></textarea>
      </div>

      <InputNumder
        text={"Год публикации: "}
        value={params.year}
        setValue={(v) => setParams({ ...params, year: Number(v) })}
      />

      <div>
        <div>Описание издания</div>
        <textarea
          value={params.description ?? ""}
          onChange={(v) =>
            setParams({ ...params, description: v.target.value })
          }
        ></textarea>
      </div>

      <div>
        {"Издание: "}
        <input
          value={params.editionNumber ?? ""}
          onChange={(e) =>
            setParams({ ...params, editionNumber: e.target.value })
          }
        />
      </div>

      <InputNumder
        text={"Количество страниц: "}
        value={params.numberPages}
        setValue={(v) => setParams({ ...params, numberPages: Number(v) })}
      />

      <SetSearch name={`Темы: ${selectedTopics.map((t) => t.name).join(", ")}`}>
        <h1 style={{ textAlign: "center" }}>Темы</h1>
        <GetTopics
          selectedTopics={selectedTopics}
          setSelectedTopics={(t) => {
            setSelectedTopics(t);
            setParams({ ...params, topics: t.map((tt) => tt.id) });
          }}
          setReset={(p) => setResetTopics({ run: p })}
        />
      </SetSearch>

      <SetSearch
        name={`Авторы: ${selectedAuthors.map((t) => t.name).join(", ")}`}
      >
        <h1 style={{ textAlign: "center" }}>Авторы</h1>
        <GetAuthors
          selectedAuthors={selectedAuthors}
          setSelectedAuthors={(a) => {
            setSelectedAuthors(a);
            setParams({ ...params, authors: a.map((aa) => aa.id) });
          }}
          setReset={(p) => setResetAuthors({ run: p })}
        />
      </SetSearch>

      <SetSearch
        name={`Издательства: ${selectedPublishers
          .map((t) => t.name)
          .join(", ")}`}
      >
        <h1 style={{ textAlign: "center" }}>Издательства</h1>
        <GetPublishers
          selectedPublishers={selectedPublishers}
          setSelectedPublishers={(p) => {
            setSelectedPublishers(p);
            setParams({ ...params, publishers: p.map((pp) => pp.id) });
          }}
          setReset={(p) => setResetPublishers({ run: p })}
        />
      </SetSearch>

      <SetSearchOne
        groupName={"Language"}
        name={"Язык"}
        empty={"не выбран"}
        header={"Язык"}
        setReset={(p) => setResetLanguage({ run: p })}
        setElementId={(l) => setParams({ ...params, language: l })}
        getId={(e) => e.id}
        getName={(e) =>
          isNullOrEmpty(e.name) &&
          isNullOrEmpty(e.englishName) &&
          isNullOrEmpty(e.abbreviation)
            ? null
            : `${e.name}, ${e.englishName}, ${e.abbreviation}`
        }
        getElements={LanguagesApi.getLanguages}
        getCount={LanguagesApi.getLanguagesCount}
      />

      <SetSearchOne
        groupName={"FileType"}
        name={"Тип файла"}
        empty={"не выбран"}
        header={"Тип файла"}
        setReset={(p) => setResetFiles({ run: p })}
        setElementId={(l) => setParams({ ...params, fileExtensions: l })}
        getId={(e) => e.id}
        getName={(e) => e.name}
        getElements={FileExtensionsApi.getFileExtensions}
        getCount={FileExtensionsApi.getFileExtensionsCount}
      />

      <div style={{ border: "3px black solid" }}>
        <div>Картинка</div>
        <div style={{ display: "inline-block" }}>
          <img
            style={{ width: "300px" }}
            hidden={baseImage === coverSrc ? true : false}
            src={coverSrc}
            alt={""}
          />
          <div style={coverNotSelected ? { color: "var(red)" } : {}}>
            {coverName === "" ? "Файл не выбран" : coverName}
          </div>
        </div>

        <div>
          <label
            htmlFor="formIdCover"
            style={{
              background: "#EFEFEF",
              border: "1px #767676 solid",
              borderRadius: "2px",
              padding: "0px 5px",
              cursor: "pointer",
            }}
          >
            <input
              name=""
              type="file"
              accept="image/*"
              onChange={addCover}
              id="formIdCover"
              hidden
            />
            Выбрать картинку
          </label>
        </div>
      </div>

      <div style={{ border: "3px black solid" }}>
        <div>Файл</div>
        <div style={fileNotSelected ? { color: "var(red)" } : {}}>
          {fileName === "" ? "Файл не выбран" : fileName}
        </div>
        <div>
          <label
            htmlFor="formIdFile"
            style={{
              background: "#EFEFEF",
              border: "1px #767676 solid",
              borderRadius: "2px",
              padding: "0px 5px",
              cursor: "pointer",
            }}
          >
            <input
              name=""
              type="file"
              onChange={addFile}
              id="formIdFile"
              hidden
            />
            Выбрать Файл
          </label>
        </div>
      </div>

      <button onClick={() => add()}>Добавить</button>
      <button onClick={() => reset()}>Сбросить</button>
    </div>
  );
};

export default AddBook;
