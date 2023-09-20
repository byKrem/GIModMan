using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GIModMan.Converters
{
    public class UnixTimeToDateTimeConverter : DateTimeConverterBase
    {
        private static readonly DateTime _epoch =
            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            return _epoch.AddSeconds(Convert.ToDouble(reader.Value)).ToLocalTime();
        }

        public static DateTime FromUnixTime(long unixTime)
        {
            return _epoch.AddSeconds(unixTime).ToLocalTime();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
