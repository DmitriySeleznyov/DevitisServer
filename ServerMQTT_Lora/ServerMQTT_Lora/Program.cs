using ServerMQTT_Lora.DBWorking;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;

namespace ServerMQTT_Lora
{
    public class Program
    {
        static void Main(string[] args)
        {

            ConnectMqtt con = new ConnectMqtt();
            PublishInfo pub = new PublishInfo();
            PublishedMessage pubM = new PublishedMessage();

            //con.Connect();
            //pub.PublishMessage();
            pubM.PublishMess();
            //client.ProtocolVersion = MqttProtocolVersion.Version_3_1;

            Console.ReadKey();
        }
    }
}
