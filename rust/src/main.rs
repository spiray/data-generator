extern crate reqwest;

use std::env;
use std::fs;
use std::process;

mod constants;
mod helpers;

fn main() {
    let args: Vec<String> = env::args().collect();
    if args.len() != 2 {
        print!("This app requires one argument to start.");
        process::exit(1);
    }
    let category = &args[1];

    if !helpers::is_valid_category(&category) {
        println!(
            "This app requires one valid argument to start. The category options are - {}",
            constants::ALLOWED_CATEGORIES.join(" | ")
        );
    }

    fs::create_dir("data");

    match reqwest::get(&(constants::BASE_URL.to_string() + category)) {
        Ok(mut response) => {
            if response.status() == reqwest::StatusCode::Ok {
                match response.text() {
                    Ok(text) => println!("Response text {}", text),
                    Err(_) => println!("Can not get response text"),
                }
            }
        }
        Err(_) => println!("Request Failed!"),
    }
    // Write to file
}
