using ServerMQTT_Lora.ConfigModel;
using System.Xml;

namespace ServerMQTT_Lora
{
    public class ConfigDBReader
    {
        public DBSettingsModel DBReader()
        {
            DBSettingsModel db = new DBSettingsModel();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("Config.xml");

            XmlElement xRoot = xmldoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                foreach (XmlNode fchildnode in xRoot.ChildNodes)
                {

                    if (fchildnode.Name == "DataBaseConnectSettings")
                    {

                        foreach (XmlNode childnode in fchildnode.ChildNodes)
                        {
                            if (childnode.Name == "server")
                            {
                                db.server = childnode.InnerText;
                            }
                            if (childnode.Name == "port")
                            {
                                db.port = childnode.InnerText;
                            }
                            if (childnode.Name == "user")
                            {
                                db.user = childnode.InnerText;
                            }
                            if (childnode.Name == "database")
                            {
                                db.database = childnode.InnerText;
                            }
                            if (childnode.Name == "password")
                            {
                                db.password = childnode.InnerText;
                            }
                        }
                    }
                }
            }
            return db;
        }
    }
}