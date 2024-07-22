using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicLandExplorer.Tasks
{
    public static class LongestDuration
    {
        public static Destination GetLongestDuration(List<Category> categoryList)
        {
            return categoryList
                .SelectMany(category => category.Destinations)
                .OrderByDescending(destination => destination.Duration)
                .FirstOrDefault();
        }
    }
}
