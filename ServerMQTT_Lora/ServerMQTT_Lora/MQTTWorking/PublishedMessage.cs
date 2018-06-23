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
        /// <summary>
        /// Method getting message from Mqtt broker.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EventPublished(Object sender, MqttMsgPublishEventArgs e)
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
        /// <summary>
        /// Show message from Mqtt broke.
        /// </summary>
        /// <param name="text"></param>
        private void SetText(string text)
        {
            Console.WriteLine(text);
        }
    }
}
