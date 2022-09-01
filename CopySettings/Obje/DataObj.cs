using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopySettings.Obje
{
    public class DataObj
    {
        public List<Actionmapping> actionMappings { get; set; }
        public List<object> axisMappings { get; set; }
        public Dictionary<string, bool> boolSettings { get; set; } = new();
        public Dictionary<string , float> floatSettings { get; set; } = new();
        public Dictionary<string, int> intSettings { get; set; } = new();
        public int roamingSetttingsVersion { get; set; }
        public Dictionary<string , string> stringSettings { get; set; } = new();
        public List<string> settingsProfiles { get; set; }
    }
}
