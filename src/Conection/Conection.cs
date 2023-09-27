using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OfficeOpenXml.ExcelErrorValue;
using System.Web.Services.Description;
using System.Windows.Documents;
using System.Windows;

namespace Palacio_el_restaurante.src.Conection
{
    public class Connection
    {
        private static MySqlConnection connection;
        private static string server, port, password, user, database;

        // Método que establece la conexión con el servidor MySQL
        public static MySqlConnection GetConnection()
        {
            server = "Matebook16s";
            port = "3308";
            user = "McBlockier";
            password = "root";
            database = "palacio";

            string stringConnection = $"Server={server}; Port={port}; Database={database}; User={user}; Password={password};";

            connection = new MySqlConnection(stringConnection);

            return connection;
        }
    }
}
