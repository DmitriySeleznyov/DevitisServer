using Npgsql;
using ServerMQTT_Lora.ConfigModel;
using System;
using System.Text;

namespace ServerMQTT_Lora.DBWorking
{
    public class AddToDb
    {
        /// <summary>
        /// Adding data with opening new connection
        /// </summary>
        /// <param name="sub_code">sub_code</param>
        /// <param name="sum_pot">sum_pot</param>
        /// <param name="pol_pot">pol_pot</param>
        /// <param name="curr">curr</param>
        /// <param name="volt">volt</param>
        /// <param name="temper">temper</param>
        /// <param name="state">state</param>
        /// <param name="connectionstring">connectionstring</param>
        public void AddWithOpenConnection(string sub_code, string sum_pot, string pol_pot, string curr, string volt, string temper, string state, DBSettingsModel settings)
        {
            Connection connection = new Connection(settings);
            connection.Connect();
            AddInfo(GetsubjId(sub_code,connection).ToString(), sum_pot, pol_pot, curr, volt, temper, state, connection);
            connection.Disconect();
        }

        /// <summary>
        /// Adding data
        /// </summary>
        /// <param name="sub_code">sub_code</param>
        /// <param name="sum_pot">sum_pot</param>
        /// <param name="pol_pot">pol_pot</param>
        /// <param name="curr">curr</param>
        /// <param name="volt">volt</param>
        /// <param name="temper">temper</param>
        /// <param name="state">state</param>
        /// <param name="connection">connection</param>
        public void AddWithoutOpenConnection(string sub_code , string sum_pot, string pol_pot, string curr, string volt, string temper, string state , Connection connection)
        {
            AddInfo(GetsubjId(sub_code, connection).ToString(), sum_pot, pol_pot, curr, volt, temper, state, connection);
        }

        /// <summary>
        /// Adding info to db
        /// </summary>
        /// <param name="subject_id">subject_id</param>
        /// <param name="sum_pot">sum_pot</param>
        /// <param name="pol_pot">pol_pot</param>
        /// <param name="curr">curr</param>
        /// <param name="volt">volt</param>
        /// <param name="temper">temper</param>
        /// <param name="state">state</param>
        /// <param name="connection">connection</param>
        private void AddInfo(string subject_id, string sum_pot, string pol_pot, string curr, string volt, string temper, string state, Connection connection)
        {
            connection.Disconect();
            connection.Connect();
            string query = "insert into \"Monitoring_BKMU\" (subject_id, sum_pot,pol_pot,curr,volt,temper,state,reg_time) " +
                "values('" + stringrefactor(subject_id) + "', '" + stringrefactor(sum_pot) + "' , '" + stringrefactor(pol_pot) + "' , '" + stringrefactor(curr) + "' , '" + stringrefactor(volt) + "' , '" + stringrefactor(temper) + "' , '+" + stringrefactor(state) + "' , '" + DateTime.Now.ToString() + "')";
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection.connection);
            cmd.ExecuteNonQuery();
            connection.Disconect();
        }

        private string stringrefactor(string str)
        {
            return str.Replace(',', '.');
        }

        /// <summary>
        /// Geting subId by subcode
        /// </summary>
        /// <param name="sub_code">sub_code</param>
        /// <param name="connection">connection</param>
        /// <returns></returns>
        private int GetsubjId(string sub_code , Connection connection)
        {
            connection.Disconect();
            connection.Connect();
            NpgsqlCommand command = new NpgsqlCommand("SELECT \"subject_id\" FROM \"Subject\" WHERE \"subject_code\" = '" + sub_code + "'", connection.connection);
            NpgsqlDataReader dataReader = command.ExecuteReader();
            dataReader.Read();
            return int.Parse(dataReader[0].ToString());
        }
    }
}
