from constants import base_URL, allowed_categories
import requests


def get_JSON(category):
    response = requests.get(base_URL + category)
    print(response.status_code)
    print(response.json())
    return response.json()


def is_valid_category(category):
    return category in allowed_categories


async def get_jSON_and_write_data(category):
    response = await get_JSON(category=category)
    print(response)
    return 0
