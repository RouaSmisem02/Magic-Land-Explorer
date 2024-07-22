using Newtonsoft.Json;
using System;

namespace MagicLandExplorer
{
    public class Destination
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }

        [JsonConverter(typeof(DurationConverter))]
        public int Duration { get; set; }

        public string Description { get; set; }
    }
}
