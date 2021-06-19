using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SchoolApp.Domain.ValueObjects;

namespace SchoolApp.Infra.Repositories.PlainFiles
{
    public class NameJsonConverter : JsonConverter<Name>
    {
        public override Name Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) => new Name(reader.GetString());


        public override void Write(Utf8JsonWriter writer, Name value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
    }
}