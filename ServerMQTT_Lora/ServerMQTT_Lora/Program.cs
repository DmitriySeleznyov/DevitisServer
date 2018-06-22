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
            db.GetsubjId("01a3f037");
            Console.ReadLine();
        }
    }
}
