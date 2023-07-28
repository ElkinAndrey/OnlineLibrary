import React, { useEffect, useRef, useState } from "react";
import InputNumder from "../InputNumder/InputNumder";
import { getNullIfZero } from "../../utils/getNullIfZero";
import SetSearch from "../SetSearch/SetSearch";
import GetTopics from "../GetTopics/GetTopics";
import GetAuthors from "../GetAuthors/GetAuthors";
import GetPublishers from "../GetPublishers/GetPublishers";
import SetSearchLanguage from "../SetSearchLanguage/SetSearchLanguage";

const emptyFunc = () => {};

export function SearchSettings({ settings, setSettings, setResetFunc }) {
  // Вспомогательные переменные
  const fetchedRef = useRef(true);

  // Данные
  let [topics, setTopics] = useState([]);
  let [authors, setAuthors] = useState([]);
  let [publishers, setPublishers] = useState([]);

  let [resetLanguage, setResetLanguage] = useState({ run: emptyFunc });
  let [resetTopics, setResetTopics] = useState({ run: emptyFunc });
  let [resetAuthors, setResetAuthors] = useState({ run: emptyFunc });
  let [resetPublishers, setResetPublishers] = useState({ run: emptyFunc });

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
      },
    });
  }, [resetLanguage, resetTopics, resetAuthors, resetPublishers]);

  return (
    <>
      <div>
        {"Название: "}
        <input
          value={settings.name ?? ""}
          onChange={(e) => setSettings({ ...settings, name: e.target.value })}
        />
      </div>
      <InputNumder
        text={"Минимальный год публикации: "}
        value={settings.yearMin}
        setValue={(v) =>
          setSettings({ ...settings, yearMin: getNullIfZero(v) })
        }
      />
      <InputNumder
        text={"Максимальный год публикации: "}
        value={settings.yearMax}
        setValue={(v) =>
          setSettings({ ...settings, yearMax: getNullIfZero(v) })
        }
      />
      <InputNumder
        text={"Минимальное количество страниц: "}
        value={settings.numberPagesMin}
        setValue={(v) =>
          setSettings({ ...settings, numberPagesMin: getNullIfZero(v) })
        }
      />
      <InputNumder
        text={"Максимальное количество страниц: "}
        value={settings.numberPagesMax}
        setValue={(v) =>
          setSettings({ ...settings, numberPagesMax: getNullIfZero(v) })
        }
      />
      <InputNumder
        text={"Минимальное количество добавлений в заметки: "}
        value={settings.numberAdditionsNotesMin}
        setValue={(v) =>
          setSettings({
            ...settings,
            numberAdditionsNotesMin: getNullIfZero(v),
          })
        }
      />
      <InputNumder
        text={"Максимальное количество добавлений в заметки: "}
        value={settings.numberAdditionsNotesMax}
        setValue={(v) =>
          setSettings({
            ...settings,
            numberAdditionsNotesMax: getNullIfZero(v),
          })
        }
      />

      <SetSearchLanguage
        settings={settings}
        setSettings={setSettings}
        setReset={(p) => setResetLanguage({ run: p })}
      />

      <SetSearch
        name={`Темы: ${topics.map((t) => t.name).join(", ")}`}
        mustHaveAllName={"Книга должна иметь все выбранные темы"}
        mustHaveAll={settings.mustHaveAllTopics}
        setMustHaveAll={() =>
          setSettings({
            ...settings,
            mustHaveAllTopics: !settings.mustHaveAllTopics,
          })
        }
      >
        <h1 style={{ textAlign: "center" }}>Темы</h1>
        <GetTopics
          selectedTopics={topics}
          setSelectedTopics={(t) => {
            setTopics(t);
            setSettings({ ...settings, topics: t.map((tt) => tt.id) });
          }}
          setReset={(p) => setResetTopics({ run: p })}
        />
      </SetSearch>

      <SetSearch
        name={`Авторы: ${authors.map((t) => t.name).join(", ")}`}
        mustHaveAllName={"Книга должна иметь всех выбранных авторов"}
        mustHaveAll={settings.mustHaveAllAuthors}
        setMustHaveAll={() =>
          setSettings({
            ...settings,
            mustHaveAllAuthors: !settings.mustHaveAllAuthors,
          })
        }
      >
        <h1 style={{ textAlign: "center" }}>Авторы</h1>
        <GetAuthors
          selectedAuthors={authors}
          setSelectedAuthors={(a) => {
            setAuthors(a);
            setSettings({ ...settings, authors: a.map((aa) => aa.id) });
          }}
          setReset={(p) => setResetAuthors({ run: p })}
        />
      </SetSearch>

      <SetSearch
        name={`Издательства: ${publishers.map((t) => t.name).join(", ")}`}
        mustHaveAllName={"Книга должна иметь все выбранные издательства"}
        mustHaveAll={settings.mustHaveAllPublishers}
        setMustHaveAll={() =>
          setSettings({
            ...settings,
            mustHaveAllPublishers: !settings.mustHaveAllPublishers,
          })
        }
      >
        <h1 style={{ textAlign: "center" }}>Издательства</h1>
        <GetPublishers
          selectedPublishers={publishers}
          setSelectedPublishers={(p) => {
            setPublishers(p);
            setSettings({ ...settings, publishers: p.map((pp) => pp.id) });
          }}
          setReset={(p) => setResetPublishers({ run: p })}
        />
      </SetSearch>
    </>
  );
}
