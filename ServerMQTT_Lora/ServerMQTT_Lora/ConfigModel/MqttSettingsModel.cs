using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMQTT_Lora.MQTTWorking
{
    public class MqttSettingsModel
    {
        public string HostName { get; set; }
        public string Port { get; set; }
        public string Topic { get; set; }

        public MqttSettingsModel(string host, string port, string topic)
        {
            HostName = host;
            Port = port;
            Topic = topic;
        }
    }
}
