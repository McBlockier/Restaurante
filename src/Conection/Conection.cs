using MySql.Data.MySqlClient;
using System;


namespace Palacio_el_restaurante.src.Conection
{
    public class Connection
    {
        public Connection()
        {
            getConnection();
        }
        public MySqlConnection getConnection()
        {
            string stringConnection = "Server=127.0.0.1;Port=3308;Database=palacio;Uid=McBlockier;Pwd=root;";
            MySqlConnection connection = new MySqlConnection(stringConnection);
            return connection;
        }

      }
}
