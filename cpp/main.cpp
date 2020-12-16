#include <stdio.h>
#include <vector>
#include <string>

bool is_valid_category(std::string category)
{
    std::vector<std::string> allowed_categories{"posts", "comments", "albums", "photos", "todos", "users"};
    return std::find(std::begin(allowed_categories), std::end(allowed_categories), category) !=
           std::end(allowed_categories);
}

int main(int argc, char *argv[])
{
    std::string category = argv[1];
    printf("%d %s \n", argc, argv[1]);
    if (!is_valid_category(category))
    {
        printf("This app requires one valid argument to start. The category options are - \n");
    }
    return 0;
}

// import { promises as fsPromises } from 'fs';
// import path from 'path';
// import { getJSON, isValidCategory } from './lib/helpers';
// import { allowedCategories } from './lib/constants';

// const category = process.argv[2];
// if (!isValidCategory(category)) {
//   process.stdout.write(
//     `This app requires one valid argument to start. The category options are - \n${allowedCategories.join(
//       '\n'
//     )}\n`
//   );
//   process.exit(1);
// }
// (async () => {
//   try {
//     await fsPromises.stat('data');
//   } catch (err) {
//     await fsPromises.mkdir('data');
//   } finally {
//     const { body } = await getJSON(category);
//     const filePath = path.join(path.resolve(), 'data', `${category}.json`);
//     await fsPromises.writeFile(filePath, body, 'utf-8');
//     process.stdout.write(
//       `Check out your ${category.slice(0, -1)} data @ /data/${category}.json\n`
//     );
//   }
// })();