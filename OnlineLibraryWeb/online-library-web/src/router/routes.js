import { Navigate } from "react-router-dom";
import Books from "../components/pages/Books/Books";
import BookEditionLanguage from "../components/pages/BookEditionLanguage/BookEditionLanguage";


export const routes = [
  { path: "/", element: <Books />, exact: true },
  { path: "*", element: <Navigate to="/" />, exact: true },
  { path: "/:bookId", element: <BookEditionLanguage />, exact: true },
  //   { path: "/transport", element: <TransportsPage />, exact: true },
  //   { path: "/transport/:transportId", element: <TransportPage />, exact: true },
];
