using System;

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
