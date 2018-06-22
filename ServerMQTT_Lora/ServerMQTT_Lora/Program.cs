using ServerMQTT_Lora.DBWorking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMQTT_Lora
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkDb db = new WorkDb();
            db.AddInfo("19", "0", "0", "0", "0", "0", "0");
            Console.ReadLine();
        }
    }
}
