#[path = "../constants/mod.rs"] mod constants;

pub fn is_valid_category(category:&str)-> bool{
    return constants::allowed_categories.contains(&category);
}