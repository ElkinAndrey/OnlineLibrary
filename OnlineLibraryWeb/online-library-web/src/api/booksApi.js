import axios from "axios";
import { defaultURL } from "./apiSettings";
import { getEmptyArray } from "../utils/getEmptyArray";

const URL = `${defaultURL}/books`;

export default class BooksApi {
  static async getBooks(settings) {
    const response = await axios.post(`${URL}/get`, settings);
    return response;
  }

  static async addBook(params) {
    let formData = new FormData();

    const a = (name, value) => formData.append(name, value);
    const g = (name, value) => formData.get(name, value);

    a("name", params.name);
    a("generalDescription", params.generalDescription);
    a("year", params.year);
    a("description", params.description);
    a("editionNumber", params.editionNumber);
    a("numberPages", params.numberPages);
    (params.topics && params.topics.length !== 0 ? a : g)(
      "topics",
      getEmptyArray(params.topics)
    );
    (params.authors && params.authors.length !== 0 ? a : g)(
      "authors",
      getEmptyArray(params.authors)
    );
    (params.publishers && params.publishers.length !== 0 ? a : g)(
      "publishers",
      getEmptyArray(params.publishers)
    );
    (params.language ? a : g)("language", params.language);
    (params.fileExtensions ? a : g)("fileExtensions", params.fileExtensions);
    (params.cover ? a : g)("cover", params.cover);
    (params.file ? a : g)("file", params.file);

    await axios.post(`${URL}`, formData);
  }
}
