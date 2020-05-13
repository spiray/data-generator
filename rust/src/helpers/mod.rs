#[path = "../constants/mod.rs"]
mod constants;

pub fn is_valid_category(category: &str) -> bool {
    constants::ALLOWED_CATEGORIES.contains(&category)
}
