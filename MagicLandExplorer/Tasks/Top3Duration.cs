using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicLandExplorer.Tasks
{
    public static class Top3Duration
    {
        public static List<Destination> GetTop3Durations(List<Category> categoryList)
        {
            return categoryList
                .SelectMany(category => category.Destinations)
                .OrderByDescending(destination => destination.Duration)
                .Take(3)
                .ToList();
        }
    }

}
