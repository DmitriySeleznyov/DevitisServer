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

        public void Connect()
        {
               client = new MqttClient("broker.hivemq.com");
                /*new MqttClient("broker.hivemq.com",
                            MqttSettings.MQTT_BROKER_DEFAULT_SSL_PORT,
                             true,
                             new X509Certificate(ResourceSet.m2mqtt_ca));*/
                /*byte code = client.Connect(Guid.NewGuid().ToString(), null, null,
                           false, // will retain flag
                           MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, // will QoS
                           true, // will flag
                           topic, // will topic
                           client.WillMessage,
                           true,
                           60);*/
            byte code = client.Connect(Guid.NewGuid().ToString());
            client.ProtocolVersion = MqttProtocolVersion.Version_3_1;
            ushort msgId = client.Subscribe(new string[] { "BLEKFIEFF" },new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE});

        }
        public void DisconnectMqtt()
        {
            client.Disconnect();
            Console.WriteLine("MQTT Disconnect");

        }
    }
}
