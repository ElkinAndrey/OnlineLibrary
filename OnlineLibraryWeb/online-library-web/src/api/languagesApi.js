import axios from "axios";
import { defaultURL } from "./apiSettings";

const URL = `${defaultURL}/languages`;

export default class LanguagesApi {
  static async getLanguages(settings) {
    const response = await axios.post(`${URL}/get`, settings);
    return response;
  }

  static async getLanguagesCount(settings) {
    const response = await axios.post(`${URL}/count`, settings);
    return response;
  }
}
