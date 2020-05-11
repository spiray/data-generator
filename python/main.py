import os
import os.path
import sys
import asyncio
import requests
import json
from pathlib import Path
from constants import base_URL
from helpers import is_valid_category, get_JSON

try:
    category = sys.argv[1]
    # TODO: Validate category
except:
    print("This app requires one valid argument to start.", sys.argv)


try:
    if not os.path.isdir("data"):
        os.mkdir("data")

    data = requests.get(base_URL + category).json()
    json_object = json.dumps(data, indent=2)
    data_folder = Path("data/")
    data_file = data_folder / (category + ".json")
    f = open(data_file, "w")
    f.write(json_object)
    f.close()
except:
    print("Something went wrong")
