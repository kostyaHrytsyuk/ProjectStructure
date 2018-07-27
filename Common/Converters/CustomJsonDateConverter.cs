using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Common.DTO
{
    class CustomJsonDateConverter : DateTimeConverterBase
    {
        private const string Format = "yyyy-MM-dd";

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            var data = reader.Value.ToString();
            DateTime result;
            if (DateTime.TryParseExact(data, Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                return result;
            }

            return DateTime.Now;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue( ( (DateTime)value ).ToString(Format));
        }
    }
}
