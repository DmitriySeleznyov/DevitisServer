using ServerMQTT_Lora.MQTTWorking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ServerMQTT_Lora
{
    public class ConfigXMLReader
    {
        public MqttSettingsModel XMLReader()
        {
            string host = "";
            string port = "";
            string topic = "";

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("Config.xml");

            XmlElement xRoot = xmldoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                foreach (XmlNode fchildnode in xRoot.ChildNodes)
                {

                    if (fchildnode.Name == "MqttConnectSettings")
                    {

                        foreach (XmlNode childnode in fchildnode.ChildNodes)
                        {
                            if (childnode.Name == "hostName")
                            { host = childnode.InnerText; }
                            if (childnode.Name == "port")
                            { port = childnode.InnerText; }
                            if (childnode.Name == "topic")
                            { topic = childnode.InnerText; }
                        }
                    }
                }
            }
            return new MqttSettingsModel(host, port, topic);
        }
    }
}
