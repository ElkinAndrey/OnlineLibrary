import React from "react";

const InputNumder = ({ text, value, setValue }) => {
  return (
    <div>
      {text}
      <input
        type={"number"}
        value={value ?? ""}
        onChange={(e) => setValue(e.target.value)}
      />
    </div>
  );
};

export default InputNumder;
