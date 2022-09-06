using CopySettings.Obje;
using Newtonsoft.Json;
using Serilog.Core;
using System.Collections.Generic;

namespace CopySettings.Hellp
{
    public static class Constants
    {
        public static string Region { get; set; } = "ap";
        public static readonly string ClinePlatform = "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9";
        public static string Version { get; set; } = "release-05.04-shipping-11-751550";
        public static Dictionary<string, string> NameAgents { get; set; } = new()
        {
            {"BountyHunter","Fade"},
            {"Breach","Breach"},
            {"Clay","Raze"},
            {"Deadeye","Chamber"},
            {"Grenadier","KAY/O"},
            {"Guide","Skye"},
            {"Gumshoe","Cypher"},
            {"Hunter_NPE","Sova"},
            {"Hunter","Sova"},
            {"Killjoy","Killjoy"},
            {"Pandemic","Viper"},
            {"Phoenix","Phoenix"},
            {"Rift","Astra"},
            {"Sarge","Brimstone"},
            {"Sprinter","Neon"},
            {"Stealth","Yoru"},
            {"Thorne","Sage"},
            {"Vampire","Reyna"},
            {"Wraith","Omen"},
            {"Wushu","Jett"}
        };

        public static string SettingDefault_string { get; set; }

        public static Data SettingDefault { get; set; }

        public static Data GetNewData()
        {
            return JsonConvert.DeserializeObject<Data>(SettingDefault_string);
        }

        public static Logger Log { get; set; }
    }
}
