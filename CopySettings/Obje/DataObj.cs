using System.Collections.Generic;

namespace CopySettings.Obje
{
    public class DataObj
    {
        public Dictionary<string, Dictionary<string, KeyBind>> actionMappings { get; set; }
        public List<AxisMapping> axisMappings { get; set; }
        public Dictionary<string, bool> boolSettings { get; set; } = new();
        public Dictionary<string, float> floatSettings { get; set; } = new();
        public Dictionary<string, int> intSettings { get; set; } = new();
        public int roamingSetttingsVersion { get; set; }
        public Dictionary<string, string> stringSettings { get; set; } = new();
        public List<string> settingsProfiles { get; set; }
    }

    public class KeyBind
    {
        public string KeyIndex1 { get; set; }
        public string KeyIndex2 { get; set; }
        public string Name { get; set; }
        public List<Actionmapping> keyList { get; set; } = new();

    }
}
