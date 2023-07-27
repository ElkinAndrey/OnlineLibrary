import axios from "axios";
import { defaultURL } from "./apiSettings";

const URL = `${defaultURL}/books`;

export default class BookApi {
  static async getBooks(settings) {
    const response = await axios.post(`${URL}`, settings);
    return response;
  }

  static async getBooksCount(settings) {
    const response = await axios.post(`${URL}/count`, settings);
    return response;
  }
}
