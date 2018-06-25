using ServerMQTT_Lora.MQTTWorking;
using System;

using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ServerMQTT_Lora
{
    public class ConnectMqtt
    {
        
        MqttClient client;
        PublishedMessage pubMessage = new PublishedMessage();
       

        /// <summary>
        /// Conncet to server Mqtt for this param.
        /// (host = broker.hivemq.com, port = 1883, topic = exz/lora, qosLevel = 2).
        /// </summary>
        public void MqttConnect(MqttSettingsModel settings)
        {
            client = new MqttClient(settings.HostName);
            byte code = client.Connect(Guid.NewGuid().ToString());
            client.ProtocolVersion = MqttProtocolVersion.Version_3_1;

            if (client.IsConnected)
            {
                Console.WriteLine("Connected to Mqtt: \n"); //BLEKFIEFF exz/lora
                Console.WriteLine("Connected to DB:  \n");
                ushort msgId = client.Subscribe(new string[] { settings.Topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
                client.MqttMsgPublishReceived += new MqttClient.MqttMsgPublishEventHandler(pubMessage.EventPublished);
            }
            else
            {
                Console.WriteLine("Cannot connect to Mqtt. Reload.");
                client.Disconnect();
            }
        }
        /// <summary>
        /// Disconnect from server Mqtt.
        /// </summary>
        public void DisconnectMqtt()
        {
            client.Disconnect();
            Console.WriteLine("MQTT Disconnect");

        }
    }
}
