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
            ConnectMqtt connect = new ConnectMqtt();
            PublishInfo pubInfo = new PublishInfo();
            
            connect.MqttConnect();
            //pubInfo.PublishMessage(); class for sending message on Mqtt broker server for choosen topic


            Console.ReadKey();
        }
    }
}
