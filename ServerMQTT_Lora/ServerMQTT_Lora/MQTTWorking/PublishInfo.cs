﻿using System;
using System.Text;

using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ServerMQTT_Lora
{
    public class PublishInfo
    {
        MqttClient client;

        /// <summary>
        /// Function for send data on Mqqt broker for choosen topic.
        /// </summary>
        public void PublishMessage()
        {
            try
            {
                client = new MqttClient("broker.hivemq.com");

                byte code = client.Connect(Guid.NewGuid().ToString());
                client.ProtocolVersion = MqttProtocolVersion.Version_3_1;

                client.MqttMsgPublished += client_MqttMsgPublished;

                Console.WriteLine("Write message(data) for sending: ");
                string mes = Console.ReadLine();// writting message for send
                Console.WriteLine("Write topic for sending on Mqtt broker: ");
                string topic = Console.ReadLine();// writting topic for send

                string defaultTopic = "exz/lora";//BLEKFIEFF  exz/lora
                ushort send = client.Publish(defaultTopic, Encoding.UTF8.GetBytes(mes),
                                                MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                                                true);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message);
            }
        }

        /// <summary>
        /// Acept that message was publish.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void client_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        {
            try
            {
                Console.WriteLine("MessageId = " + e.MessageId + " Published = " + e.IsPublished);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message);
            }
        }
    }
}
