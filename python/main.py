"""This script will accept one argument and generate a json file based on the inputted category"""

import os
import os.path
import sys
import json
from pathlib import Path
import requests
from constants import BASE_URL, allowed_categories
from helpers import is_valid_category

if len(sys.argv) != 2:
    print("This app requires one argument to start.")
    sys.exit(1)

category = sys.argv[1]
if not is_valid_category(category=category):
    print(
        "This app requires one valid argument to start. The category options are - {}".format(
            " | ".join(allowed_categories)
        )
    )
    sys.exit(1)

try:
    if not os.path.isdir("data"):
        os.mkdir("data")

    data = requests.get(BASE_URL + category).json()
    json_object = json.dumps(data, indent=2)
    data_folder = Path("data/")
    data_file = data_folder / (category + ".json")
    f = open(data_file, "w")
    f.write(json_object)
    f.close()
    print("Check out your {} data @ /data/{}.json\n".format(category[:-1], category))
except requests.exceptions.RequestException:
    print("Something went wrong")
    sys.exit(1)
