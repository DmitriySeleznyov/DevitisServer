using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ServerMQTT_Lora
{
    public class SubcribeMqtt
    {
        ConnectMqtt client = new ConnectMqtt();

        public void Sub()
        {
            //client.MqttMsgSubscribed += client_MqttMsgSubscribed;

            //ushort msgId = client.Subscribe(new string[] { "/topic_1", "/topic_2" },
            //    new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
            //        MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });


        }
        public void client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            Debug.WriteLine("Subscribed for id = " + e.MessageId);
            Console.WriteLine("Subscribed for id = " + e.MessageId);
        }

    }
}
