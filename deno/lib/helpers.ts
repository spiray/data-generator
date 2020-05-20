import { baseURL, allowedCategories } from './constants.ts';

export async function getJSON(
  category: string
): Promise<Array<Record<string, any>>> {
  const response = await fetch(`${baseURL}${category}`);
  return response.json();
}

export function isValidCategory(category: string): boolean {
  return allowedCategories.includes(category);
}
