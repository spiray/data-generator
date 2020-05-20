package main

import (
	"os"
)

func main() {
	if len(os.Args) != 2 {
		println("This app requires one argument to start.")
		os.Exit(1)
	}
	category := os.Args[1]
	if lib.isValidCategory(category) {
		println("Hi")
	}
}
