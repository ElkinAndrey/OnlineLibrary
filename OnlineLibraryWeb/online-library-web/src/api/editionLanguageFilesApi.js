import axios from "axios";
import { defaultURL } from "./apiSettings";

const URL = `${defaultURL}/books/editions/languages/files`;

export default class EditionLanguageFilesApi {
  static getBookFilePathByEditionLanguageFileId(id) {
    return `${URL}/${id}/download`;
  }
}
