using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ServerMQTT_Lora
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectMqtt stconnect = new ConnectMqtt();

            stconnect.MainConnect();
            //stconnect.PublishMessage();
           // stconnect.PublishRetaindMessage();
            stconnect.SubscribeMessage();
            // stconnect.DisconnectMqtt();

            Console.ReadKey();
        }
    }
}
