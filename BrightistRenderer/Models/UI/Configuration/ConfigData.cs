using System.Text.Json;
using System.Text.Json.Serialization;

namespace BrightistRenderer.Models.UI.Configuration
{
    internal class ConfigData
    {
        public required string SheetId { get; set; }
        public required string ClientId { get; set; }
        public required string ClientSecret { get; set; }
        public required string PlayerName { get; set; }
    }

    [JsonSerializable(typeof(ConfigData))]
    partial class ConfigDataContext : JsonSerializerContext
    {
        public static readonly ConfigDataContext Instance = new(new JsonSerializerOptions { AllowTrailingCommas = true });
    }
}
