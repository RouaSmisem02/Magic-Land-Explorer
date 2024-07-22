using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicLandExplorer.Tasks
{
    public static class SortByName
    {
        public static List<Destination> GetSortedDestinations(List<Category> categoryList)
        {
            return categoryList
                .SelectMany(category => category.Destinations)
                .OrderBy(destination => destination.Name)
                .ToList();
        }
    }
}
