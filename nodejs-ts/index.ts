import { promises as fsPromises } from 'fs';
import path from 'path';
import { getJSON, isValidCategory } from './lib/helpers';
import { allowedCategories } from './lib/constants';

const category = process.argv[2];
if (!isValidCategory(category)) {
  process.stdout.write(
    `This app requires one valid argument to start. The category options are - \n${allowedCategories.join(
      '\n'
    )}\n`
  );
  process.exit(1);
}
(async () => {
  try {
    await fsPromises.stat('data');
  } catch (err) {
    await fsPromises.mkdir('data');
  } finally {
    const { body } = await getJSON(category);
    const filePath = path.join(path.resolve(), 'data', `${category}.json`);
    await fsPromises.writeFile(filePath, body, 'utf-8');
  }
})();
