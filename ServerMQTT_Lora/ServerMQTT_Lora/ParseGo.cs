using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMQTT_Lora
{
    class ParseGo
    {
        public void Parsego()
        {
            string query = "{\n    \"cmd\": \"rx\",\n    \"EUI\": \"01a3f037\",\n    \"ts\": 81159620,\n    \"fcnt\": \"0\",\n    \"port\": \"2\",\n    \"ack\": \"false\",\n    \"data\": \"424d000030017613050670300000020034400009990000000000000000000000000000\"\n}";

            List<string> list = new List<string>();
            list = ParseByNewLines(query).ToList();
            string strtemp = GetData(list[2]);
            string temp = GetData(list[7]);
        }


        private IEnumerable<string> ParseByNewLines(string strToParse)
        {
            return strToParse.Split(Environment.NewLine.ToCharArray());
        }

        private string GetData(string EUIstring)
        {
            return EUIstring.Split(new[] { "\"" }, StringSplitOptions.None).ToList()[3];
        }

    }
}
