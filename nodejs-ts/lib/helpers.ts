import got from 'got/dist/source/index.js';
import { Response } from 'got/dist/source/core';
import { baseURL, allowedCategories } from './constants';

export async function getJSON(category: string): Promise<Response<string>> {
  return got(`${baseURL}${category}`);
}

export function isValidCategory(category: string): boolean {
  return allowedCategories.includes(category);
}
