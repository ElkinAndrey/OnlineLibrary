import axios from "axios";
import { defaultURL } from "./apiSettings";

const URL = `${defaultURL}/auth`;

export default class AuthorsApi {
  static async register(params) {
    const response = await axios.post(`${URL}/register`, params);
    return response;
  }
}
