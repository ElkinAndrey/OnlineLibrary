import axios from "axios";
import { defaultURL } from "./apiSettings";

const URL = `${defaultURL}/home`;

export default class HomeApi {
  static async helloWorld() {
    const response = await axios.get(`${URL}`);
    return response;
  }
}
