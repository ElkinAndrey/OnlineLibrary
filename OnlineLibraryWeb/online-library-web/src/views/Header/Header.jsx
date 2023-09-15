import React from "react";
import { Link } from "react-router-dom";

const Header = () => {
  return (
    <div style={{ backgroundColor: "#e6e6e6" }}>
      <Link style={{ marginRight: "10px" }} to={`/`}>
        На главную
      </Link>
      <Link style={{ marginRight: "10px" }} to={`/register`}>
        Регистрация
      </Link>
    </div>
  );
};

export default Header;
