import { Navigate } from "react-router-dom";
import Books from "../components/pages/Books/Books";
import BookEditionLanguage from "../components/pages/BookEditionLanguage/BookEditionLanguage";
import AddBook from "../components/pages/AddBook/AddBook";
import Register from "../components/pages/Register/Register";

export const routes = [
  { path: "/", element: <Books />, exact: true },
  { path: "*", element: <Navigate to="/" />, exact: true },
  { path: "/:bookId", element: <BookEditionLanguage />, exact: true },
  { path: "/add", element: <AddBook />, exact: true },
  { path: "/register", element: <Register />, exact: true },
];
