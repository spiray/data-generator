using System;
using System.Linq;

static class Constants
{
    public const string BASE_URL = "https://jsonplaceholder.typicode.com/";
    public static readonly string[] ALLOWED_CATEGORIES = { "posts", "comments", "albums", "photos", "todos", "users" };
}

namespace csharp
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("This app requires one argument to start.");
                return 1;
            }

            string category = args[0];
            if (!Constants.ALLOWED_CATEGORIES.Contains(category))
            {
                Console.WriteLine("This app requires one valid argument to start. The category options are - {0}", string.Join(" | ", Constants.ALLOWED_CATEGORIES));
                return 1;
            }

            return 0;
        }
    }
}