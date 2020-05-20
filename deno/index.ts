import { getJSON, isValidCategory } from './lib/helpers.ts';
import { allowedCategories } from './lib/constants.ts';

const [category] = Deno.args;
if (!isValidCategory(category)) {
  console.log(
    `This app requires one valid argument to start. The category options are - \n${allowedCategories.join(
      '\n'
    )}\n`
  );
  Deno.exit(1);
}
try {
  await Deno.stat('data');
} catch (err) {
  await Deno.mkdir('data', { recursive: true });
} finally {
  const body = await getJSON(category);
  const filePath = `data/${category}.json`;
  await Deno.writeFile(
    filePath,
    new TextEncoder().encode(JSON.stringify(body, null, 2))
  );
  console.log(
    `Check out your ${category.slice(0, -1)} data @ /data/${category}.json\n`
  );
}
