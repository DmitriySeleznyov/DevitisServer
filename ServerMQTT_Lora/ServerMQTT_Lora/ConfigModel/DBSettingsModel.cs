using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMQTT_Lora.ConfigModel
{
    public class DBSettingsModel
    {
        public string server { get; set; }
        public string port { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string database { get; set; }
    }
}
