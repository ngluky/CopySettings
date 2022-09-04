using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CopySettings.Obje.GuiObj
{
    public class Item       
    {
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("path")] public string path { get; set; }
        [JsonPropertyName("type")] public string Type { get; set; }
        [JsonPropertyName("minimum")] public double Minimum { get; set; }
        [JsonPropertyName("maximum")] public double Maximum { get; set; }
        [JsonPropertyName("textSwich")] public string TextSwich { get; set; }


    }
}
