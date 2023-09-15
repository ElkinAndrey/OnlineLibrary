import React, { useState } from "react";
import { useFetching } from "../../../hooks/useFetching";
import AuthApi from "../../../api/authApi";

const Register = () => {
  // Константы
  const baseParams = {
    email: "",
    password: "",
  };

  // Переменные
  const [params, setParams] = useState(baseParams);

  // Отправка и получение данных
  const [fetchReg, isLoadingReg, errorReg] = useFetching(async (p) => {
    await AuthApi.register(p);
  });

  // Функции
  const reg = () => {
    fetchReg(params);
  };

  const reset = () => {
    setParams(baseParams);
  };

  return (
    <div>
      <div>
        <label>Email</label>
        <input
          value={params.email}
          onChange={(e) => setParams({ ...params, email: e.target.value })}
        />
      </div>
      <div>
        <label>Пароль</label>
        <input
          value={params.password}
          onChange={(e) => setParams({ ...params, password: e.target.value })}
        />
        <div>
          <button onClick={reg}>Зарегистрироваться</button>
          <button onClick={reset}>Сбросить</button>
        </div>
      </div>
    </div>
  );
};

export default Register;
