using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicLandExplorer.Tasks
{
    public static class FilterDestinations
    {
        public static List<Destination> GetFilteredDestinations(List<Category> categoryList)
        {
            return categoryList
                .SelectMany(category => category.Destinations)
                .Where(destination => destination.Duration < 100)
                .ToList();
        }
    }
}