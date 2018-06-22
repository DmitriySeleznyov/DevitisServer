using System.Text;
using Npgsql;

namespace ServerMQTT_Lora.DBWorking
{
    public class Connection
    {
        private string string_connection;
        public NpgsqlConnection connection;

        /// <summary>
        /// конструктор с параметром строка подключения
        /// пример корректной строки подключения к базе:
        /// "Server = postgres9.1gb.ua; Port = 5432; User Id = xgbua_x_exz; Password = cf4d55a7nm; Database = xgbua_x_exz; "
        /// </summary>
        /// <param name="stringtoconnection">строка подключения к базе</param>
        public Connection(string stringtoconnection)
        {
            this.string_connection = stringtoconnection;
        }

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
        public Connection(string server , string port , string user , string password , string database)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Server = " + server + "; Port = " + port + "; User Id = " + user + "; Password = " + password + "; Database =  " + database);
            this.string_connection = stringBuilder.ToString();
            
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