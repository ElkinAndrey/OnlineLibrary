import axios from "axios";
import { defaultURL } from "./apiSettings";

const URL = `${defaultURL}/authors`;

export default class AuthorsApi {
  static async getAuthors(settings) {
    const response = await axios.post(`${URL}/get`, settings);
    return response;
  }

  static async getAuthorsCount(settings) {
    const response = await axios.post(`${URL}/count`, settings);
    return response;
  }
}
