using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerMQTT_Lora
{
    class ParseGo
    {
        /// <param name="sub_code"></param>
        /// <param name="sum_pot"></param>
        /// <param name="pol_pot"></param>
        /// <param name="curr"></param>
        /// <param name="volt"></param>
        /// <param name="temper"></param>
        /// <param name="state"></param>
        public void Parsego(string query)
        {
            try
            {
                List<string> list = new List<string>();
                list = ParseByNewLines(query).ToList();
                string subjectCode = GetData(list[2]);
                string temp = GetData(list[7]);
                ParseNumbers parseNumbers = new ParseNumbers();
                List<string> checking = parseNumbers.ParseToRegisters(temp).ToList();

                List<double> res = new List<double>();

                bool oursubj = parseNumbers.IsUs(checking[0]);
                for (int i = 1; i <= 9; i++)
                {
                    res.Add(parseNumbers.GetNumber(checking[i]));
                }
                WorkDb db = new WorkDb();
                db.Run(subjectCode, res[0].ToString(), res[1].ToString(), res[2].ToString(), res[3].ToString(), res[4].ToString(), res[5].ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message);
            }
        }

        /// <summary>
        /// Возвращает набор строк
        /// </summary>
        /// <param name="strToParse"></param>
        /// <returns></returns>
        private IEnumerable<string> ParseByNewLines(string strToParse)
        {
            return strToParse.Split(Environment.NewLine.ToCharArray());
        }

        /// <summary>
        /// Возвращает значение из строки в байтовом виде,способ передачи строка
        /// </summary>
        /// <param name="EUIstring"></param>
        /// <returns></returns>
        private string GetData(string EUIstring)
        {
            return EUIstring.Split(new[] { "\"" }, StringSplitOptions.None).ToList()[3];
        }
    }
}
