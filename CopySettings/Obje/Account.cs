using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopySettings.Obje
{ 
    public class Account
    {
        public string DisplayName { get; set; }
        public string As { get; set; }
        public string AccessToken { get; set; }
        public string EntitlementToken { get; set; }
        public Guid Ppuuid { get; set; }
        public static string Port { get; set; }
        public static string LPassword { get; set; }
        public bool IsLocal { get; set; }
        public string Region { get; set; }

    }
}
