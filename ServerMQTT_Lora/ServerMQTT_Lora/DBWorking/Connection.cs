using System;
using System.Text;
using Npgsql;
using ServerMQTT_Lora.ConfigModel;

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
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("Server = " + settings.server + "; Port = " + settings.port + "; User Id = " + settings.user + "; Password = " + settings.password + "; Database =  " + settings.database);
                this.string_connection = stringBuilder.ToString();
                Console.WriteLine("DB add line succesfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message);
            }
        }
        
        /// <summary>
        /// Coonect to DB
        /// </summary>
        public void Connect()
        {
            try
            {
                this.connection = new NpgsqlConnection(this.string_connection);
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message);
            }
        }

        /// <summary>
        /// Disconnect DB connection
        /// </summary>
        public void Disconect()
        {
            try
            { 
            connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message);
            }
        }

        /// <summary>
        /// Asych connection to DB
        /// </summary>
        public void ConnectAsync()
        {
            try
            { 
                this.connection = new NpgsqlConnection(this.string_connection);
                connection.OpenAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message);
            }
}

        /// <summary>
        /// Disconnection async DB connection
        /// </summary>
        public void DisconnectAsync()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message);
            }
        }
    }
}