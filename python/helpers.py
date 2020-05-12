"""This module provides helpers for the main script"""

from constants import allowed_categories


def is_valid_category(category):
    """
    This function checks if the provided category
    is in the list of allowed categories and returns a boolean.
    """
    return category in allowed_categories
