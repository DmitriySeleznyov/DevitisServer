using ServerMQTT_Lora.MQTTWorking;
using System.IO;
using System.Xml;

namespace ServerMQTT_Lora
{
    public class ConfigXMLReader
    {
        public MqttSettingsModel XMLReader()
        {
            MqttSettingsModel mqtt = new MqttSettingsModel();

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Directory.GetCurrentDirectory()+"\\Config.xml");

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
                            { mqtt.HostName = childnode.InnerText; }
                            if (childnode.Name == "port")
                            { mqtt.Port = childnode.InnerText; }
                            if (childnode.Name == "topic")
                            { mqtt.Topic = childnode.InnerText; }
                        }
                    }
                }
            }
            return mqtt;
        }
    }
}
