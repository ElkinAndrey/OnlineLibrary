import React from "react";
import InputNumder from "../InputNumder/InputNumder";
import { getNullIfZero } from "../../utils/getNullIfZero";
import SetSearchTopics from "../SetSearchTopics/SetSearchTopics";

export function SearchSettings({ settings, setSettings, addResetFuncs }) {
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
      <SetSearchTopics
        settings={settings}
        setSettings={setSettings}
        addResetFuncs={addResetFuncs}
      />
      {/* <SetSettingsAuthors settings={settings} setSettings={setSettings} /> */}
      {/* <SetSettingsPublishers settings={settings} setSettings={setSettings} /> */}
    </>
  );
}
