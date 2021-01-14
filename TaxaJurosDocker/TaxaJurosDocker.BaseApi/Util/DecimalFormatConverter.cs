using System;
using Newtonsoft.Json;
using System.Globalization;
using System.Diagnostics.CodeAnalysis;

namespace TaxaJurosDocker.BaseApi.Util
{
    public class DecimalFormatConverter : JsonConverter<decimal>
    {
        public override decimal ReadJson(JsonReader reader, Type objectType, [AllowNull] decimal existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                if ((string)reader.Value == string.Empty)
                    return decimal.MinValue;
            }
            else if (reader.TokenType == JsonToken.Float ||
                     reader.TokenType == JsonToken.Integer)            
                return Convert.ToDecimal(reader.Value);

            return 0;
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] decimal value, JsonSerializer serializer)
        {
            writer.WriteRawValue(value.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
