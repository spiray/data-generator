using System;
using System.IO;
using static DataGenerator.Constants.Constants;
using static DataGenerator.Helpers.Helpers;

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
            if (!IsValidCategory(category))
            {
                Console.WriteLine("This app requires one valid argument to start. The category options are - {0}", string.Join(" | ", ALLOWED_CATEGORIES));
                return 1;
            }

            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "data")))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "data"));
            }

            try
            {
                string data = GetJSONData(category);
                File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "data", category + ".json"), data);
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return 1;
            }


            return 0;
        }
    }
}