using System.Linq;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using DataGenerator.Lib;

namespace DataGenerator.Lib
{
    public static class Helpers
    {
        private static readonly HttpClient _client = new HttpClient();
        public static bool IsValidCategory(string category)
        {
            return Constants.ALLOWED_CATEGORIES.Contains(category);
        }
        public static async Task<string> GetJSONData(string category)
        {
            var response = await _client.GetAsync($"{Constants.BASE_URL}{category}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}