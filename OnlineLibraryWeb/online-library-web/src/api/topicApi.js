import axios from "axios";
import { defaultURL } from "./apiSettings";

const URL = `${defaultURL}/topics`;

export default class TopicsApi {
  static async getTopics(settings) {
    const response = await axios.post(`${URL}`, settings);
    return response;
  }

  static async getTopicsCount(settings) {
    const response = await axios.post(`${URL}/count`, settings);
    return response;
  }
}
