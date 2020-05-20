package lib

func isValidCategory(category string) bool {
	for _, a := range allowedCategories {
		if a == category {
			return true
		}
	}
	return false
}
