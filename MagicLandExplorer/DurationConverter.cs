using Newtonsoft.Json;
using System;

namespace MagicLandExplorer
{
    public class DurationConverter : JsonConverter<int>
    {
        public override int ReadJson(JsonReader reader, Type objectType, int existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string durationString = (string)reader.Value;

            if (durationString.ToLower().EndsWith("minutes"))
            {
                string minutesPart = durationString.ToLower().Replace("minutes", "").Trim();
                if (int.TryParse(minutesPart, out int minutes))
                {
                    return minutes;
                }
            }

            throw new JsonSerializationException("Invalid duration format.");
        }

        public override void WriteJson(JsonWriter writer, int value, JsonSerializer serializer)
        {
            writer.WriteValue($"{value} minutes");
        }
    }
}
