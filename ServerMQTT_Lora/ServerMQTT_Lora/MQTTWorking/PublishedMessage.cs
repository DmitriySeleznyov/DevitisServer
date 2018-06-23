using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ServerMQTT_Lora
{

    public class PublishedMessage
    {
        ParseGo ps = new ParseGo();
        /// <summary>
        /// Method getting message from Mqtt broker.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EventPublished(Object sender, MqttMsgPublishEventArgs e)
        {
            try
            {
                string query = Encoding.UTF8.GetString(e.Message);
                ps.Parsego(query);
                SetText("*** Received Message " + DateTime.Now.ToString());
                SetText("*** Topic: " + e.Topic);
                SetText("*** Message: " + query);
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
