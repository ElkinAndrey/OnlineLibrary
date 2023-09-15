import axios from "axios";
import { defaultURL } from "./apiSettings";

const URL = `${defaultURL}/file`;

export default class FileExtensionsApi {
  static async getFileExtensions(settings) {
    const response = await axios.post(`${URL}/get`, settings);
    return response;
  }

  static async getFileExtensionsCount(settings) {
    const response = await axios.post(`${URL}/count`, settings);
    return response;
  }
}
