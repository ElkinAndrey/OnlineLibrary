import React, { useEffect, useRef, useState } from "react";
import "./App.css";
import { useFetching } from "./hooks/useFetching";
import HomeApi from "./api/homeApi";

function App() {
  const fetchedRef = useRef(true);
  let [helloWorld, setHelloWorld] = useState("");

  const [fetchBooks, isLoadingBooks, errorBooks] = useFetching(async () => {
    const response = await HomeApi.helloWorld();
    setHelloWorld(response.data);
  });

  useEffect(() => {
    if (fetchedRef.current) {
      fetchedRef.current = false;
      return;
    }
    fetchBooks();
  }, []);

  return <div>{helloWorld}</div>;
}

export default App;
