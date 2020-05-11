import got from "got/dist/source/index.js";
import { baseURL, allowedCategories } from "./constants/index.js";

export async function getJSON(category) {
  return got(`${baseURL}${category}`);
}

export function isValidCategory(category) {
  return allowedCategories.includes(category);
}
