package lib

import "net/http"
import "io/ioutil"

// IsValidCategory determines if a category is valid and returns a boolean
func IsValidCategory(category string) bool {
	for _, a := range AllowedCategories {
		if a == category {
			return true
		}
	}
	return false
}

// GetJSONData requests JSON data from the JSONPlaceholder API and returns it as a string
func GetJSONData(category string) string {
	resp, err := http.Get(baseURL + category)
	if err != nil {
		println(err)
		return "ERROR: HTTP request error"
	}
	defer resp.Body.Close()
	body, _ := ioutil.ReadAll(resp.Body)
	return string(body)
}
