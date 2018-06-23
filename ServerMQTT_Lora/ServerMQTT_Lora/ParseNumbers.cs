using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMQTT_Lora
{
    public class ParseNumbers
    {
        //string input_data = "424d000000000000000000000000000000000000000000000000000000000000000000";
        //List<string> list = ParseToRegisters(input_data).ToList();
        //List<string> list = new List<string>();
        //list.Add("1303234");
        //double d = GetNumber(list[0]);


        public IEnumerable<string> ParseToRegisters(string input_data)
        {
            List<string> data = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                data.Add(input_data.Substring(0, 7));
                input_data = input_data.Remove(0, 7);
            }
            return data;
        }

        public double GetNumber(string intputnumber)
        {
            double num = 0;
            string number = intputnumber.Substring(2, 5);
            if (intputnumber.Substring(0, 1).ToString() == "1")
            {
                num = double.Parse(number) * (-1);
            }
            num /= Math.Pow(10, int.Parse(intputnumber.Substring(1, 1).ToString()));
            return num;
        }
    }
}
