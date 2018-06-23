using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ServerMQTT_Lora
{
    
    public class PublishedMessage
    {
        MqttClient client;
        delegate void SetTextCallback(string text);


        public void PublishMess()
        {
                client = new MqttClient("broker.hivemq.com");
                byte code = client.Connect(Guid.NewGuid().ToString());
                client.ProtocolVersion = MqttProtocolVersion.Version_3_1;

            if (client.IsConnected)
            {   
                Console.WriteLine("Connected to Mqtt: ");
                ushort msgId = client.Subscribe(new string[] { "exz/lora" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
                client.MqttMsgPublishReceived += new MqttClient.MqttMsgPublishEventHandler(EventPublished);
            }
            else
            {
                Console.WriteLine("Cannot connect to Mqtt. Reload.");
            }
        }
        
        private void EventPublished(Object sender, MqttMsgPublishEventArgs e)
        {
            try
            {
                SetText("*** Received Message");
                SetText("*** Topic: " + e.Topic);
                SetText("*** Message: " + Encoding.UTF8.GetString(e.Message));
                SetText("");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        private void SetText(string text)
        {
            Console.WriteLine(text);
        }
    }
}
