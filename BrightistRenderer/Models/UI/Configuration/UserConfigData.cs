using System.Text.Json;
using System.Text.Json.Serialization;

namespace BrightistRenderer.Models.UI.Configuration
{
    class UserConfigData
    {
        public string? SheetId { get; set; }
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? PlayerName { get; set; }
    }

    [JsonSerializable(typeof(UserConfigData))]
    partial class UserConfigDataContext : JsonSerializerContext
    {
        public static readonly UserConfigDataContext Instance = new(new JsonSerializerOptions { AllowTrailingCommas = true });
    }
}
