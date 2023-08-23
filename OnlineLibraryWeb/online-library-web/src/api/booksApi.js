import axios from "axios";
import { defaultURL } from "./apiSettings";

const URL = `${defaultURL}/books`;

export default class BooksApi {
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
      `${URL}/${settings.editionLanguageId}/language/get`,
      settings
    );
    return response;
  }

  static async getBookEditionLanguagesCount(settings) {
    const response = await axios.post(
      `${URL}/${settings.editionLanguageId}/language/count`,
      settings
    );
    return response;
  }

  static getBookCoverPathByEditionLanguageId(id) {
    return `${URL}/${id}/cover`;
  }

  static getBookFilePathByEditionLanguageFileId(id) {
    return `${URL}/file/${id}`;
  }
}
