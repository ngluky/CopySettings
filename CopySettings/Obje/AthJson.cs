using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CopySettings.Obje
{
    public class AthJson
    {
        [JsonPropertyName("isSu")] public string isSu { get; set; }
        [JsonPropertyName("err_mess")] public string err_mess { get; set; }
        [JsonPropertyName("data")] public Dictionary<string , string> data { get; set; }
    }

    public class Userinfo
    {
        [JsonPropertyName("sub")] public Guid puuid { get; set; }
    }
}
