import { promises as fsPromises } from "fs";
import path from "path";
import { getJSON, isValidCategory } from "./lib/helpers.js";
import { allowedCategories } from "./lib/constants.js";

const category = process.argv[2];
if (!isValidCategory(category)) {
  process.stdout.write(
    `This app requires one valid argument to start. The category options are - \n${allowedCategories.join(
      "\n"
    )}\n`
  );
  process.exit(1);
}
(async () => {
  try {
    await fsPromises.stat("data");
  } catch (err) {
    await fsPromises.mkdir("data");
  } finally {
    const { body } = await getJSON(category);
    const filePath = path.join(path.resolve(), "data", `${category}.json`);
    await fsPromises.writeFile(filePath, body, "utf-8");
    process.stdout.write(
      `Check out your ${category.slice(0, -1)} data @ /data/${category}.json\n`
    );
  }
})();
