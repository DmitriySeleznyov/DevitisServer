using Npgsql;
using ServerMQTT_Lora.DBWorking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMQTT_Lora
{
    public class WorkDb
    {
        private string connectionstring = "Server = postgres9.1gb.ua; Port = 5432; User Id = xgbua_x_exz; Password = cf4d55a7nm; Database = xgbua_x_exz; ";
        private string server = "postgres9.1gb.ua";
        private string port = "5432";
        private string user = "xgbua_x_exz";
        private string password = "cf4d55a7nm";
        private string database = "xgbua_x_exz";

        
        public void AddInfo()
        {
            Connection connection = new Connection(connectionstring);
            connection.Connect();

            connection.Disconect();
        }

        public string GetsubjId(string sub_code)
        {
            Connection connection = new Connection(this.connectionstring);
            connection.Connect();
            NpgsqlCommand command = new NpgsqlCommand("SELECT \"subject_id\" FROM \"Subject\" WHERE \"subject_code\" = '"+ sub_code + "'", connection.connection);
            NpgsqlDataReader dataReader = command.ExecuteReader();
            dataReader.Read();
            connection.Disconect();
            return dataReader[0].ToString();
        }

        
    }
}
