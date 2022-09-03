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
        [JsonPropertyName("Name")] public string Name { get; set; }

        [JsonPropertyName("Items")] public Item[] Items { get; set; }

    }
}
