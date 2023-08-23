import axios from "axios";
import { defaultURL } from "./apiSettings";

const URL = `${defaultURL}/books/editions/languages`;

export default class EditionLanguagesApi {
  static async getBooks(settings) {
    const response = await axios.post(`${URL}/get`, settings);
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
    const response = await axios.post(
      `${URL}/${settings.editionLanguageId}/other/get`,
      settings
    );
    return response;
  }

  static async getBookEditionLanguagesCount(settings) {
    const response = await axios.post(
      `${URL}/${settings.editionLanguageId}/other/count`,
      settings
    );
    return response;
  }

  static getBookCoverPathByEditionLanguageId(id) {
    return `${URL}/${id}/cover`;
  }
}
