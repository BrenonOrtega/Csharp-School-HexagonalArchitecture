using System.Text.Json;
using SchoolApp.Infra.Repositories.JsonFiles;

namespace SchoolApp.Infra.Extensions
{
    public static class SetupPlainFileOptions
    {
        public static JsonSerializerOptions SetupValueObjects(this JsonSerializerOptions options)
        {
            options.AllowTrailingCommas = true;
            options.Converters.Add(new NameJsonConverter());
            options.Converters.Add(new EmailJsonConverter());
            return options;
        }
    }
}