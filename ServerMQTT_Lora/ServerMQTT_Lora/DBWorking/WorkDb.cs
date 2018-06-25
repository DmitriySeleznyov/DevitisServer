using ServerMQTT_Lora.DBWorking;
using System;

namespace ServerMQTT_Lora
{
    public class WorkDb
    {
        /// <summary>
        /// Запуск сохранения в БД
        /// </summary>
        /// <param name="sub_code"></param>
        /// <param name="sum_pot"></param>
        /// <param name="pol_pot"></param>
        /// <param name="curr"></param>
        /// <param name="volt"></param>
        /// <param name="temper"></param>
        /// <param name="state"></param>
        public void Run(string sub_code, string sum_pot, string pol_pot, string curr, string volt, string temper, string state)
        {
            try
            {
                ConfigDBReader dbconf = new ConfigDBReader();
                Connection connection = new Connection(dbconf.DBReader());
                connection.Connect();
                AddToDb db = new AddToDb();
                db.AddWithoutOpenConnection(sub_code, sum_pot, pol_pot, curr, volt, temper, state, connection);
                connection.Disconect();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message);
            }
        }
    }
}
