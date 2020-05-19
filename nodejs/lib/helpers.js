import got from "got/dist/source/index.js";
import { baseURL, allowedCategories } from "./constants.js";

/**
 * @description This function fetches data from the JSONPlaceholder API
 * @param {string} category
 * @returns {Promise<string>}
 */
export async function getJSON(category) {
  return got(`${baseURL}${category}`);
}

/**
 * @description This function verifies that the passed in argument is valid.
 * @param {string} category
 * @returns {boolean}
 */
export function isValidCategory(category) {
  return allowedCategories.includes(category);
}
