using System;
using System.Collections.Generic;

namespace ServerMQTT_Lora
{
    public class ParseNumbers
    {
        /// <summary>
        /// Возвращяет разделенную строку на подстроки
        /// </summary>
        /// <param name="input_data"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Возвращает значение в кореектном виде из байтов
        /// </summary>
        /// <param name="intputnumber"></param>
        /// <returns></returns>
        public double GetNumber(string intputnumber)
        {
            double num = 0;
            string number = intputnumber.Substring(2, 5);
            if (intputnumber.Substring(0, 1).ToString() == "1")
            {
                num = double.Parse(number) * (-1);
            }
            else
            {
                num = double.Parse(number);
            }
            num /= Math.Pow(10, int.Parse(intputnumber.Substring(1, 1).ToString()));
            return num;
        }
        
        /// <summary>
        /// Возвращает наш ли аппарат
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool IsUs(string input)
        {
            if (input.Substring(0, 4).ToUpper() == "424D")
                return true;
            else return false;
        }
    }
}
