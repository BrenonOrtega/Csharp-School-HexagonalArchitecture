using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SchoolApp.Domain.ValueObjects;

namespace SchoolApp.Infra.Repositories.JsonFiles
{
    public class EmailJsonConverter  : JsonConverter<Email>
    {
        public override Email Read(
            ref Utf8JsonReader reader,
            Type typeToConvert, 
            JsonSerializerOptions options) =>  new Email(reader.GetString());

        public override void Write(
            Utf8JsonWriter writer,
            Email value, 
            JsonSerializerOptions options) => writer.WriteStringValue(value);
    }   
}