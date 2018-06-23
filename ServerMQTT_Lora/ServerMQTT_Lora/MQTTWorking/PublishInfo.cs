using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Threading;

namespace ServerMQTT_Lora
{
    public class PublishInfo: ConnectMqtt
    {
        MqttClient client;

        public void PublishMessage()
        {
            client = new MqttClient("broker.hivemq.com");
            //client = new MqttClient("localhost");
            byte code = client.Connect(Guid.NewGuid().ToString());
            client.ProtocolVersion = MqttProtocolVersion.Version_3_1;

            client.MqttMsgPublished += client_MqttMsgPublished;

            string mes = Console.ReadLine();
            string topic = "exz/lora";//BLEKFIEFF  exz/lora
            ushort send = client.Publish(topic, Encoding.UTF8.GetBytes(mes), 
                                            MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, 
                                            true);
        }
        private void MqttSubscribeTopic(string topic, byte qoslevel)
        {
            string[] topics = { topic };
            byte[] qoss = { qoslevel };
            client.Subscribe(topics, qoss);
        }
        void client_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        {
            Console.WriteLine("MessageId = " + e.MessageId + " Published = " + e.IsPublished);
        }
       
    }
}
