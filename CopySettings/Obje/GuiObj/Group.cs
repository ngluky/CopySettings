using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CopySettings.Obje.GuiObj
{
    public class Group
    {
        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("items")] public Item[] Items { get; set; }

    }
}
