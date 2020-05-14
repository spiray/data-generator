using System.Linq;
using System.IO;
using System.Net;
using static DataGenerator.Constants.Constants;

namespace DataGenerator.Helpers
{
    static class Helpers
    {
        public static bool IsValidCategory(string category)
        {
            return ALLOWED_CATEGORIES.Contains(category);
        }
        public static string GetJSONData(string category)
        {
            WebRequest request = WebRequest.Create(BASE_URL + category);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
    }
}