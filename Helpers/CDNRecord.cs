using System;
using System.Text.Json.Serialization;

namespace AppFoxScreenShotTerm.Helpers
{
    public class CDNRecord
    {
        [JsonPropertyName("date")]
        public string Date { get; set; } = String.Empty;
        
        [JsonPropertyName("screenshot")]
        public string ScreenShot { get; set; } = String.Empty;

    }
}