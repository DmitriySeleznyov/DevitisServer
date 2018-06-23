using ServerMQTT_Lora.DBWorking;

namespace ServerMQTT_Lora
{
    public class WorkDb
    {
        private string connectionstring = "Server = postgres9.1gb.ua; Port = 5432; User Id = xgbua_x_exz; Password = cf4d55a7nm; Database = xgbua_x_exz; ";
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
            Connection connection = new Connection(connectionstring);
            connection.Connect();
            AddToDb db = new AddToDb();
            db.AddWithoutOpenConnection(sub_code, sum_pot, pol_pot, curr, volt, temper, state, connection);
            connection.Disconect();
        }
    }
}
