using System;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("An application which outputs the horse names in price ascending order.\n\nLet's start...\n");
            var results = new HorseStats(
                SimpleInjectorIOC.Logger,
                SimpleInjectorIOC.Provider).
                GetHorsesStats(string.Concat(AppDomain.CurrentDomain.BaseDirectory, "FeedData"));
            Console.WriteLine(" Results: \n");

            if (results != null)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    var horse = results[i];
                    Console.WriteLine($" {horse.Name,-50} {horse.Price:C} (AUD)");
                }
            }
            Console.WriteLine(results == null ? "\nSorry! Something went wrong. Please refer log file." : "\nOperation completed successfully. Thanks!");
            Console.ReadKey();
        }
    }
}
