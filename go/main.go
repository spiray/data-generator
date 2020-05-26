package main

import (
	"fmt"
	lib "github.com/spiray/data-generator/go/lib"
	"os"
	"strings"
)

func main() {
	if len(os.Args) != 2 {
		println("This app requires one argument to start.")
		os.Exit(1)
	}

	category := os.Args[1]
	if !lib.IsValidCategory(category) {
		fmt.Printf("This app requires one valid argument to start. The category options are - %v\n", strings.Join(lib.AllowedCategories[:], " | "))
		os.Exit(1)
	}

	err := os.Mkdir("data", os.ModeDir)
	if err != nil {
		println("Data directory already exists")
	}

	data := lib.GetJSONData(category)

	file, _ := os.Create("data/" + category + ".json")
	_, writeError := file.WriteString(data)
	if writeError != nil {
		println("Could not write to file")
		os.Exit(1)
	}
	file.Close()

	fmt.Printf("Check out your %s data @ /data/%s.json\n", category[:len(category)-1], category)
	os.Exit(0)
}
