using System;
using System.Text;
using Npgsql;
using ServerMQTT_Lora.ConfigModel;
using ServerMQTT_Lora.MQTTWorking;

namespace ServerMQTT_Lora.DBWorking
{
    public class Connection
    {
        private string string_connection;
        public NpgsqlConnection connection;
       
        /// <summary>
        /// конструктор с параметрами
        /// пример 
        /// "postgres9.1gb.ua", "5432", "xgbua_x_exz", "cf4d55a7nm", "xgbua_x_exz"
        /// </summary>
        /// <param name="server">адрес сервера</param>
        /// <param name="port">порт</param>
        /// <param name="user">пользователь</param>
        /// <param name="password">пароль</param>
        /// <param name="database">база</param>
        public Connection(DBSettingsModel settings)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Server = " + settings.server + "; Port = " + settings.port + "; User Id = " + settings.user + "; Password = " + settings.password + "; Database =  " + settings.database);
            this.string_connection = stringBuilder.ToString();
            Console.WriteLine("DB add line succesfully!");

        }
        
        /// <summary>
        /// Coonect to DB
        /// </summary>
        public void Connect()
        {
            this.connection = new NpgsqlConnection(this.string_connection);
            connection.Open();
        }

        /// <summary>
        /// Disconnect DB connection
        /// </summary>
        public void Disconect()
        {
            connection.Close();
        }

        /// <summary>
        /// Asych connection to DB
        /// </summary>
        public void ConnectAsync()
        {
            this.connection = new NpgsqlConnection(this.string_connection);
            connection.OpenAsync();
        }

        /// <summary>
        /// Disconnection async DB connection
        /// </summary>
        public void DisconnectAsync()
        {
            connection.Close();
        }
    }
}