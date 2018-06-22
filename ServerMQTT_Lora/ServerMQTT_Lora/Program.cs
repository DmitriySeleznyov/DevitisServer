using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;

namespace ServerMQTT_Lora
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectMqtt stconnect = new ConnectMqtt();
            ListenerMQTT socket = new ListenerMQTT();

            MqttClient client;

            //client = new MqttClient("broker.hivemq.com");
            //byte code = client.Connect(Guid.NewGuid().ToString());

            //client.ProtocolVersion = MqttProtocolVersion.Version_3_1;
            //socket.Listen();
            //stconnect.MainConnect();
            //stconnect.PublishMessage();
            // stconnect.PublishRetaindMessage();
            stconnect.SubscribeMessage();

            Console.ReadKey();
        }
    }
}
