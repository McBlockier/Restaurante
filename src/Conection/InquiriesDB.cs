using CustomMessageBox;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Palacio_el_restaurante.src.Conection
{
    //Clase de consultas a la base de datos
    internal class InquiriesDB
    {
        //Conexión global con la base de datos
        private static MySqlConnection connection = Conection.getConnection();
        private static Boolean value = false;

        public static Boolean registerUser(Persona persona)
        {

            //Aqui la lógica de consulta a las DB

            return value;
        }

        public static Boolean valueLogin(String username, String password)
        {
            SecureEncryptor encrypt = new SecureEncryptor(password);
            string getPassword = SecureEncryptor.EncryptPassword(password);

            //Aqui la logica de consulta a la DB
           
            


            return value;
        }


        
    }
}
