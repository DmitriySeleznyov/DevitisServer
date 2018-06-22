using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ServerMQTT_Lora
{
    public class ConnectMqtt
    {
        MqttClient client;
       

        public void MainConnect(string topic)
        {

           // client = new MqttClient("broker.hivemq.com");
                /*new MqttClient("broker.hivemq.com",
                                    MqttSettings.MQTT_BROKER_DEFAULT_SSL_PORT,
                                     true,
                                     new X509Certificate(ResourceSet.m2mqtt_ca));*/
            byte code = client.Connect(Guid.NewGuid().ToString(), null, null,
                           false, // will retain flag
                           MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, // will QoS
                           true, // will flag
                           topic, // will topic
                           client.WillMessage,
                           true,
                           60);
           // byte code = client.Connect(Guid.NewGuid().ToString());
           
            client.ProtocolVersion = MqttProtocolVersion.Version_3_1;
            //Console.WriteLine("MQTT " + MqttProtocolVersion.Version_3_1 + " Connect");
 
        }

        public void PublishMessage()
        {
           // string message = Console.ReadLine();
            client.MqttMsgPublished += client_MqttMsgPublished;

            ushort msgId = client.Publish("/my_topic", // topic
                                          Encoding.UTF8.GetBytes("MyMessageBody"), // message body
                                          MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, // QoS level
                                          false); // retained
           
        }
        public void PublishRetaindMessage()
        {
            ushort msgId = client.Publish("/my_topic", // topic
                            Encoding.UTF8.GetBytes("MyMessageBody"), // message body
                            MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, // QoS level
                            true); // retained
        }

        public void SubscribeMessage()
        {

            client = new MqttClient("broker.hivemq.com");
            byte code = client.Connect(Guid.NewGuid().ToString());
            client.ProtocolVersion = MqttProtocolVersion.Version_3_1;

            client.MqttMsgSubscribed += client_MqttMsgSubscribed;
            
            string[] arraytopic = new string[] { "exz/lora", "BLEKFIEFF" };
            byte[] messagetopic = new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                    MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE};

            ushort msgId = client.Subscribe(arraytopic,messagetopic);

            for (int i = 0; i < arraytopic.Length; i++)
            {
                Console.WriteLine("Topic name {"+i+"}:" + arraytopic[i]);

            }

            Console.WriteLine("                        ");
            //Console.WriteLine("Chose topic: ");
            int chooseTopic = 1; //int.Parse(Console.ReadLine());
            //DisconnectMqtt();
            if (chooseTopic == 0)
            {
               MainConnect("exz/lora");
            }
            else
            {
                MainConnect("BLEKFIEFF");
            }

            Console.WriteLine("Will Message topic {" + i + "}:" + client.WillMessage);
            
            //string temp = client.WillMessage;
        }
        public void DisconnectMqtt()
        {
            client.Disconnect();
            Console.WriteLine("MQTT Disconnect");

        }

        void client_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        {
            Debug.WriteLine("MessageId = " + e.MessageId + " Published = " + e.IsPublished);
            Console.WriteLine("MessageId = " + e.MessageId + " Published = " + e.IsPublished);
        }

        void client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            Console.WriteLine("Subscribed for id = " + e.MessageId );
        }

    }
}
