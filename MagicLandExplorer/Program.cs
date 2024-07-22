using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MagicLandExplorer.Tasks;

namespace MagicLandExplorer
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFilePath = Path.Combine(baseDirectory, "data", "MagicLandData.json");

            if (!File.Exists(jsonFilePath))
            {
                Console.WriteLine($"The file {jsonFilePath} does not exist.");
                return;
            }

            try
            {
                string jsonData = File.ReadAllText(jsonFilePath);
                List<Category> categoryList = JsonConvert.DeserializeObject<List<Category>>(jsonData);

                var filteredDestinations = FilterDestinations.GetFilteredDestinations(categoryList).Select(destination => destination.Name).ToList();
                Console.WriteLine("1- Destinations with duration less than 100 minutes:");
                filteredDestinations.ForEach(Console.WriteLine);

                var longestDurationDestination = LongestDuration.GetLongestDuration(categoryList);
                Console.WriteLine("\n2- Destination with the longest duration:");
                Console.WriteLine(longestDurationDestination?.Name);

                var sortedDestinations = SortByName.GetSortedDestinations(categoryList).Select(destination => destination.Name).ToList();
                Console.WriteLine("\n3- Sorted destinations by name:");
                sortedDestinations.ForEach(Console.WriteLine);

                var top3Durations = Top3Duration.GetTop3Durations(categoryList);
                Console.WriteLine("\n4- Top 3 longest-duration destinations:");
                top3Durations.ForEach(destination => Console.WriteLine($"{destination.Name} - {destination.Duration} minutes"));
            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
