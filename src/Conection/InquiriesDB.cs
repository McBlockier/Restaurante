using CustomMessageBox;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Palacio_el_restaurante.src.Conection
{
    //Clase de consultas a la base de datos
    public class InquiriesDB
    {      
        private  Boolean value = false;
        public  Boolean registerUser(Persona persona)
        {
            SecureEncryptor encrypt = new SecureEncryptor(persona.Password);
            String getPassword = SecureEncryptor.EncryptPassword(persona.Password);
            
            try
            {
                Connection connection = new Connection();
                MySqlConnection con = connection.getConnection();
                con.Open();
                String SQL = "INSERT INTO usuario(idUser, nombre, lastNameP, lastNameM, " +
                    "password, id_jerarquia, street1, street2, locacion, telefono) VALUES (@idUser, @nombre, " +
                    "@lastNameP, @lastNameM, @password, @id_jerarquia, @street1, @street2, @locacion, @telefono)";

                MySqlCommand command = new MySqlCommand(SQL, con);
                command.Parameters.AddWithValue("@idUser", persona.IdUser);
                command.Parameters.AddWithValue("@nombre", persona.Name);
                command.Parameters.AddWithValue("@lastNameP", persona.LastNameP);
                command.Parameters.AddWithValue("@lastNameM", persona.LastNameM);
                command.Parameters.AddWithValue("@password", persona.Password);
                command.Parameters.AddWithValue("@id_jerarquia", 2);
                command.Parameters.AddWithValue("@street1", persona.PrimaryStreet);
                command.Parameters.AddWithValue("@street2", persona.SecondaryStreet);
                command.Parameters.AddWithValue("@locacion", persona.Settlement_type1);
                command.Parameters.AddWithValue("@telefono", persona.PhoneNumber);
                int result = command.ExecuteNonQuery();
                if(result != 1)
                {
                    value = false;
                    con.Close();
                }
                else
                {
                    value = true;
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }                    
            return value;
        }

        public  Boolean valueLogin(String username, String password)
        {
            SecureEncryptor encrypt = new SecureEncryptor(password);
            string getPassword = SecureEncryptor.EncryptPassword(password);
            try
            {
                Connection connection = new Connection();
                MySqlConnection con = connection.getConnection();
                con.Open();
                String SQL = "SELECT idUser, password FROM usuario WHERE idUser LIKE @idUser";
                MySqlCommand command = new MySqlCommand(SQL, con);
                command.Parameters.AddWithValue("idUser", username);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    String DbPassword = (String)reader["password"];
                    if(password.Equals(DbPassword))
                    {
                        value = true;
                        con.Close();
                    }
                }
                else
                {
                    value = false;
                    con.Close();
                }
            }catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            
            return value;
        }

        public Boolean resetPassword(Persona persona)
        {
            try
            {
                Connection connection = new Connection();
                MySqlConnection con = connection.getConnection();
                con.Open();
                String SQL = "UPDATE usuario SET password = @password WHERE idUser = @idUser";
                MySqlCommand command = new MySqlCommand(SQL, con);
                command.Parameters.AddWithValue("@password", persona.Password);
                command.Parameters.AddWithValue("@idUser", persona.IdUser);            
                int result = command.ExecuteNonQuery();
                if(result == 1)
                {
                    value = true;
                    con.Close();
                }
                else
                {
                    value = false;
                    con.Close();
                }

            }catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            return value;
        }




        
    }
}
