import axios from "axios";
import { defaultURL } from "./apiSettings";

const URL = `${defaultURL}/books`;

export default class BooksApi {
  static async getBooks(settings) {
    const response = await axios.post(`${URL}`, settings);
    return response;
  }

  static async getBooksCount(settings) {
    const response = await axios.post(`${URL}/count`, settings);
    return response;
  }

  static async getBookById(id) {
    const response = await axios.get(`${URL}/${id}`);
    return response;
  }

  static async getBookEditionLanguages(settings) {
    const response = await axios.post(`${URL}/language`, settings);
    return response;
  }

  static async getBookEditionLanguagesCount(settings) {
    const response = await axios.post(`${URL}/language/count`, settings);
    return response;
  }
}
