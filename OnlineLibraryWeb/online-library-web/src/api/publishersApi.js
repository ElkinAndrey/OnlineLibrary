import axios from "axios";
import { defaultURL } from "./apiSettings";

const URL = `${defaultURL}/publishers`;

export default class PublishersApi {
  static async getPublishers(settings) {
    const response = await axios.post(`${URL}/get`, settings);
    return response;
  }

  static async getPublishersCount(settings) {
    const response = await axios.post(`${URL}/count`, settings);
    return response;
  }
}
