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
        [JsonPropertyName("Name")] public string Name { get; set; }
        [JsonPropertyName("Path")] public string path { get; set; }

        [JsonPropertyName("Type")] public string Type { get; set; }
        [JsonPropertyName("Minimum")] public int Minimum { get; set; }
        [JsonPropertyName("Maximum")] public int Maximum { get; set; }
        [JsonPropertyName("textSwich")] public string TextSwich { get; set; }


    }
}
