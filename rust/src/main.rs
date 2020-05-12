use std::fs;
use std::env;
use std::process;

mod helpers;
mod constants;

fn main() {

    let args: Vec<String> = env::args().collect();
    if args.len() != 2 {
        print!("This app requires one argument to start.");
        process::exit(1);
    }
    let  category = &args[1];

    if !helpers::is_valid_category(&category) {
        println!("This app requires one valid argument to start. The category options are - {}", constants::allowed_categories.join(" | "));
    }

    fs::create_dir("data");

    // TODO: Send HTTP request
    // Write to file
}
