using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SchoolApp.Domain.ValueObjects;

namespace SchoolApp.Infra.Repositories.JsonFiles
{
    public class NameJsonConverter : JsonConverter<Name>
    {
        public override Name Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) 
        {
            if (reader.TokenType.Equals(JsonTokenType.String))
            {
                var text = reader.GetString();
                return new Name ( text ) ;
            }
            return null;
        }

        public override void Write(Utf8JsonWriter writer, Name value, JsonSerializerOptions options) => writer.WriteStringValue(value);
    }
}