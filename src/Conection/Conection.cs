using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palacio_el_restaurante.src.Conection
{
    public class Conection
    {
        private static MySqlConnection connection;
        private static String server, port, password, user, database, stringConnection;
        //Clase que establece la conexión con el servidor local MySQL
        public static MySqlConnection getConnection()
        {
             server = "localhost";
             port = "3308";
             password = "root";
             user = "McBlockier";
             database = "rpalacio";

            stringConnection = "Database=" + database + "; Data Source=" 
                + server +"; port=" + port + "; User Id=" + user + "; Password=" + password + ";";

            connection = new MySqlConnection(stringConnection);
            return connection;           
        }
    }
}
