using System;
using System.IO;
using DataGenerator.Lib;

namespace DataGenerator
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
            if (!Helpers.IsValidCategory(category))
            {
                Console.WriteLine("This app requires one valid argument to start. The category options are - {0}", string.Join(" | ", Constants.ALLOWED_CATEGORIES));
                return 1;
            }

            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "data"));

            try
            {
                var data = Helpers.GetJSONData(category).GetAwaiter().GetResult();
                File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "data", $"{category}.json"), data);
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return 1;
            }

            Console.WriteLine("Check out your {0} data @ /data/{1}.json", category.Substring(0, category.Length - 1), category);
            return 0;
        }
    }
}