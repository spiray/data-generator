extern crate reqwest;

use std::env;
use std::fs;
use std::io;
use std::io::prelude::*;
use std::process;

mod constants;
mod helpers;

fn main() -> io::Result<()> {
    let args: Vec<String> = env::args().collect();
    if args.len() != 2 {
        eprint!("This app requires one argument to start.");
        process::exit(1);
    }
    let category = &args[1];

    if !helpers::is_valid_category(&category) {
        eprintln!(
            "This app requires one valid argument to start. The category options are - {}",
            constants::ALLOWED_CATEGORIES.join(" | ")
        );
        process::exit(1);
    }
    fs::create_dir("data");
    Ok(
        match reqwest::get(&(constants::BASE_URL.to_string() + category)) {
            Ok(mut response) => {
                if response.status() == reqwest::StatusCode::OK {
                    match response.text() {
                        Ok(text) => {
                            // Write to file
                            let mut file =
                                fs::File::create(&("./data/".to_string() + category + ".json"))?;
                            file.write_all(text.as_bytes())?;
                            eprintln!(
                                "Check out your {} data @ /data/{}.json",
                                &category[0..String::from(category).len() - 1],
                                &category
                            );
                        }
                        Err(_) => eprintln!("Can not get response text"),
                    }
                }
            }
            Err(_) => eprintln!("Request Failed!"),
        },
    )
}
