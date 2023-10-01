using CustomMessageBox;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Palacio_el_restaurante.src.Conection
{
    public class InquiriesDB
    {
        private Boolean value = false;
        public Boolean registerUser(Persona persona)
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
                if (String.IsNullOrEmpty(persona.Rank.ToString()))
                {
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
                }
                else
                {
                    command.Parameters.AddWithValue("@idUser", persona.IdUser);
                    command.Parameters.AddWithValue("@nombre", persona.Name);
                    command.Parameters.AddWithValue("@lastNameP", persona.LastNameP);
                    command.Parameters.AddWithValue("@lastNameM", persona.LastNameM);
                    command.Parameters.AddWithValue("@password", persona.Password);
                    command.Parameters.AddWithValue("@id_jerarquia", persona.Rank);
                    command.Parameters.AddWithValue("@street1", persona.PrimaryStreet);
                    command.Parameters.AddWithValue("@street2", persona.SecondaryStreet);
                    command.Parameters.AddWithValue("@locacion", persona.Settlement_type1);
                    command.Parameters.AddWithValue("@telefono", persona.PhoneNumber);
                }
                            
                int result = command.ExecuteNonQuery();
                if (result != 1)
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
        public Boolean updateUser(Persona persona)
        {
            String SQL = "";
            try
            {
                Connection connection = new Connection();
                MySqlConnection con = connection.getConnection();   
                con.Open();
                if (!String.IsNullOrEmpty(persona.IdUser) && !String.IsNullOrEmpty(persona.Name) &&
                    !String.IsNullOrEmpty(persona.LastNameP) && !String.IsNullOrEmpty(persona.LastNameM) &&
                    !String.IsNullOrEmpty(persona.PrimaryStreet) && !String.IsNullOrEmpty(persona.SecondaryStreet) &&
                    !String.IsNullOrEmpty(persona.Settlement_type1) && !String.IsNullOrEmpty(persona.PhoneNumber) &&
                    !String.IsNullOrEmpty(persona.Rank.ToString()) && !String.IsNullOrEmpty(persona.Password))
                {
                    SQL = "UPDATE usuario SET nombre=@nombre,lastNameP=@lastNameP," +
                        "lastNameM=@lastNameM,password=@password,id_jerarquia=@id_jerarquia," +
                        "street1=@street1,street2=@street2,locacion=@locacion,telefono=@telefono WHERE idUser LIKE @idUser";

                    MySqlCommand command = new MySqlCommand(SQL, con);
                    command.Parameters.AddWithValue("@idUser", persona.IdUser);
                    command.Parameters.AddWithValue("@nombre", persona.Name);
                    command.Parameters.AddWithValue("@lastNameP", persona.LastNameP);
                    command.Parameters.AddWithValue("@lastNameM", persona.LastNameM);
                    command.Parameters.AddWithValue("@password", persona.Password);
                    command.Parameters.AddWithValue("@id_jerarquia", persona.Rank);
                    command.Parameters.AddWithValue("@street1", persona.PrimaryStreet);
                    command.Parameters.AddWithValue("@street2", persona.SecondaryStreet);
                    command.Parameters.AddWithValue("@locacion", persona.Settlement_type1);
                    command.Parameters.AddWithValue("@telefono", persona.PhoneNumber);
                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        value = true;
                        con.Close();
                    }
                    else
                    {
                        value = false;
                        con.Close();
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(persona.IdUser))
                    {
                        //Primer sección
                        if (!String.IsNullOrEmpty(persona.Name))
                        {
                            SQL = "UPDATE usuario SET nombre=@nombre WHERE idUser LIKE @idUser";
                            MySqlCommand command = new MySqlCommand(SQL, con);
                            command.Parameters.AddWithValue("@idUser", persona.IdUser);
                            command.Parameters.AddWithValue("@nombre", persona.Name);
                            int i = command.ExecuteNonQuery();
                            if (i > 0)
                            {
                                value = true;
                                con.Close();
                            }
                            else
                            {
                                value = false;
                                con.Close();
                            }
                        }else
                        if (!String.IsNullOrEmpty(persona.Password))
                        {
                            SQL = "UPDATE usuario SET password=@password WHERE idUser LIKE @idUser";
                            MySqlCommand command = new MySqlCommand(SQL, con);
                            command.Parameters.AddWithValue("@idUser", persona.IdUser);
                            command.Parameters.AddWithValue("@password", persona.Password);
                            int i = command.ExecuteNonQuery();
                            if (i > 0)
                            {
                                value = true;
                                con.Close();
                            }
                            else
                            {
                                value = false;
                                con.Close();
                            }
                        }else
                        if (!String.IsNullOrEmpty(persona.LastNameP))
                        {
                            SQL = "UPDATE usuario SET lastNameP=@lastNameP WHERE idUser LIKE @idUser";
                            MySqlCommand command = new MySqlCommand(SQL, con);
                            command.Parameters.AddWithValue("@idUser", persona.IdUser);
                            command.Parameters.AddWithValue("@lastNameP", persona.LastNameP);
                            int i = command.ExecuteNonQuery();
                            if (i > 0)
                            {
                                value = true;
                                con.Close();
                            }
                            else
                            {
                                value = false;
                                con.Close();
                            }
                        }else
                        if (!String.IsNullOrEmpty(persona.LastNameM))
                        {
                            SQL = "UPDATE usuario SET lastNameM=@lastNameM WHERE idUser LIKE @idUser";
                            MySqlCommand command = new MySqlCommand(SQL, con);
                            command.Parameters.AddWithValue("@idUser", persona.IdUser);
                            command.Parameters.AddWithValue("@lastNameM", persona.LastNameM);
                            int i = command.ExecuteNonQuery();
                            if (i > 0)
                            {
                                value = true;
                                con.Close();
                            }
                            else
                            {
                                value = false;
                                con.Close();
                            }
                        }else

                        //Segunda sección
                        if (!String.IsNullOrEmpty(persona.PrimaryStreet))
                        {
                            SQL = "UPDATE usuario SET street1=@street1 WHERE idUser LIKE @idUser";
                            MySqlCommand command = new MySqlCommand(SQL, con);
                            command.Parameters.AddWithValue("@idUser", persona.IdUser);
                            command.Parameters.AddWithValue("@street1", persona.PrimaryStreet);
                            int i = command.ExecuteNonQuery();
                            if (i > 0)
                            {
                                value = true;
                                con.Close();
                            }
                            else
                            {
                                value = false;
                                con.Close();
                            }
                        }else
                        if (!String.IsNullOrEmpty(persona.SecondaryStreet))
                        {
                            SQL = "UPDATE usuario SET street2=@street2 WHERE idUser LIKE @idUser";
                            MySqlCommand command = new MySqlCommand(SQL, con);
                            command.Parameters.AddWithValue("@idUser", persona.IdUser);
                            command.Parameters.AddWithValue("@street2", persona.SecondaryStreet);
                            int i = command.ExecuteNonQuery();
                            if (i > 0)
                            {
                                value = true;
                                con.Close();
                            }
                            else
                            {
                                value = false;
                                con.Close();
                            }
                        }else
                        if (!String.IsNullOrEmpty(persona.Settlement_type1))
                        {
                            SQL = "UPDATE usuario SET locacion=@locacion WHERE idUser LIKE @idUser";
                            MySqlCommand command = new MySqlCommand(SQL, con);
                            command.Parameters.AddWithValue("@idUser", persona.IdUser);
                            command.Parameters.AddWithValue("@locacion", persona.Settlement_type1);
                            int i = command.ExecuteNonQuery();
                            if (i > 0)
                            {
                                value = true;
                                con.Close();
                            }
                            else
                            {
                                value = false;
                                con.Close();
                            }
                        }else
                        if (!String.IsNullOrEmpty(persona.PhoneNumber))
                        {
                            SQL = "UPDATE usuario SET telefono=@telefono WHERE idUser LIKE @idUser";
                            MySqlCommand command = new MySqlCommand(SQL, con);
                            command.Parameters.AddWithValue("@idUser", persona.IdUser);
                            command.Parameters.AddWithValue("@telefono", persona.PhoneNumber);
                            int i = command.ExecuteNonQuery();
                            if (i > 0)
                            {
                                value = true;
                                con.Close();
                            }
                            else
                            {
                                value = false;
                                con.Close();
                            }
                        }else
                        if (!String.IsNullOrEmpty(persona.Rank.ToString()))
                        {
                            SQL = "UPDATE usuario SET id_jerarquia=@id_jerarquia WHERE idUser LIKE @idUser";
                            MySqlCommand command = new MySqlCommand(SQL, con);
                            command.Parameters.AddWithValue("@idUser", persona.IdUser);
                            command.Parameters.AddWithValue("@id_jerarquia", persona.Rank);
                            int i = command.ExecuteNonQuery();
                            if (i > 0)
                            {
                                value = true;
                                con.Close();
                            }
                            else
                            {
                                value = false;
                                con.Close();
                            }
                        }
                    }
                    else
                    {
                        RJMessageBox.Show("The user cannot be empty, you must enter the user you want to update",
                                      "INFORMATION!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return value;
        }

        public Boolean deleteUser(Persona persona)
        {
            try
            {
                Connection connection = new Connection();
                MySqlConnection con = connection.getConnection();
                con.Open();
                String SQL = "DELETE FROM usuario WHERE idUser LIKE @idUser";
                MySqlCommand command = new MySqlCommand(SQL, con);
                command.Parameters.AddWithValue("@idUser", persona.IdUser);
                int i = command.ExecuteNonQuery();
                if(i > 0)
                {
                    value = true;
                    con.Close();
                }
                else
                {
                    value = false;
                    con.Close();
                }

            }catch(Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            return value;
        }

        public int getRank(String username)
        {
            int rank = 0;
            try
            {
                Connection connection = new Connection();
                MySqlConnection con = connection.getConnection();
                con.Open();
                String SQL = "SELECT id_jerarquia FROM usuario WHERE idUser LIKE @idUser";
                MySqlCommand command = new MySqlCommand(SQL, con);
                command.Parameters.AddWithValue("@idUser", username);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    rank = (int)reader["id_jerarquia"];
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                  System.Windows.Forms.MessageBoxIcon.Error);
            }
            return rank;
        }

        public Boolean valueLogin(String username, String password)
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
                    if (password.Equals(DbPassword))
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
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            return value;
        }
        public Boolean uploadImage(object nameProduct, byte[] image)
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection connection = con.getConnection();
                connection.Open();
                String SQL = "INSERT INTO imagenconsumible(nombreConsumible, imagen)VALUES(@nombreConsumible, @imagen)";
                MySqlCommand command = new MySqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@nombreConsumible", nameProduct.ToString());
                command.Parameters.AddWithValue("@imagen", image);
                int i = command.ExecuteNonQuery();
                if (i != 1)
                {
                    value = false;
                }
                else
                {
                    value = true;
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            return value;
        }
        public Boolean existImage(object nameProduct)
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection connection = con.getConnection();
                connection.Open();
                String SQL = "SELECT image FROM imagenconsumible WHERE nombreConsumible LIKE @nombreConsumible";
                MySqlCommand command = new MySqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@nombreConsumible", nameProduct.ToString());
                int i = command.ExecuteNonQuery();
                if (i != 1)
                {
                    value = false;
                }
                else
                {
                    value = true;
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            return value;
        }
        public Boolean deleteProduct(String clurp)
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection connection = con.getConnection();
                connection.Open();
                String SQL = "DELETE FROM consumible WHERE clurp LIKE @clurp";
                MySqlCommand command = new MySqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@clurp", clurp);
                int i = command.ExecuteNonQuery();  
                if (i != 1)
                {
                    value = false;
                    connection.Close();
                }
                else
                {
                    value = true;
                    connection.Close();
                }

            }catch(Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            return value;
        }
        public Boolean existProduct(int Clurp)
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection connection = con.getConnection();
                connection.Open();
                String SQL = "SELECT nombre FROM consumible WHERE clurp LIKE @clurp";
                MySqlCommand command = new MySqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@clurp", Clurp);
                int i = command.ExecuteNonQuery();
                if( i != 0)
                {
                    value = true;
                    connection.Close();
                }
                else
                {
                    value = false;
                    connection.Close();
                }
            }catch(Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            return value;
        }
        public Boolean updateProduct(Product producto)
        {
            Connection con = new Connection();
            MySqlConnection connection = con.getConnection();
            connection.Open();
            String SQL = "";
            MySqlCommand command;
            try
            {             

            if(!String.IsNullOrEmpty(producto.Name) && !String.IsNullOrEmpty(producto.Description)
                    && !String.IsNullOrEmpty(producto.Price.ToString()) && !String.IsNullOrEmpty(producto.Type))
                {
                    SQL = "UPDATE consumible SET nombre=@nombre, tipo=@tipo, precio=@precio, descri=@descri WHERE clurp LIKE @clurp";
                    MySqlCommand command2 = new MySqlCommand(SQL, connection);
                    command2.Parameters.AddWithValue("@clurp", producto.Clurp);
                    command2.Parameters.AddWithValue("@nombre", producto.Name);
                    command2.Parameters.AddWithValue("@tipo", producto.Type);
                    command2.Parameters.AddWithValue("@precio", producto.Price);
                    command2.Parameters.AddWithValue("@descri", producto.Description);
                    int j = command2.ExecuteNonQuery();
                    if(j > 0)
                    {
                        value = true;
                        connection.Close();
                    }
                    else
                    {
                        value = false;
                        connection.Close();
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(producto.Name))
                    {
                        SQL = "UPDATE consumible SET nombre=@nombre WHERE clurp LIKE @clurp";
                        command = new MySqlCommand(SQL, connection);
                        command.Parameters.AddWithValue("@clurp", producto.Clurp);
                        command.Parameters.AddWithValue("@nombre", producto.Name);
                        int i = command.ExecuteNonQuery();
                        if(i > 0)
                        {
                            value = true;
                            connection.Close();
                        }
                        else
                        {
                            value = false;
                            connection.Close();
                        }
                    }                   
                    else if (!String.IsNullOrEmpty(producto.Description))
                    {
                        SQL = "UPDATE consumible SET descri=@descri WHERE clurp LIKE @clurp ";
                        command = new MySqlCommand(SQL, connection);
                        command.Parameters.AddWithValue("@clurp", producto.Clurp);
                        command.Parameters.AddWithValue("@descri", producto.Description);
                        int i = command.ExecuteNonQuery();
                        if (i > 0)
                        {
                            value = true;
                            connection.Close();
                        }
                        else
                        {
                            value = false;
                            connection.Close();
                        }
                    }
                    else if (!String.IsNullOrEmpty(producto.Price.ToString()))
                    {
                        SQL = "UPDATE consumible SET precio=@precio WHERE clurp LIKE @clurp";
                        command = new MySqlCommand(SQL, connection);
                        command.Parameters.AddWithValue("@clurp", producto.Clurp);
                        command.Parameters.AddWithValue("@precio", producto.Price);
                        int i = command.ExecuteNonQuery();
                        if (i > 0)
                        {
                            value = true;
                            connection.Close();
                        }
                        else
                        {
                            value = false;
                            connection.Close();
                        }
                    }
                    else if (!String.IsNullOrEmpty(producto.Type))
                    {
                        SQL = "UPDATE consumible SET tipo=@tipo WHERE clurp LIKE @clurp";
                        command = new MySqlCommand(SQL, connection);
                        command.Parameters.AddWithValue("@clurp", producto.Clurp);
                        command.Parameters.AddWithValue("@tipo", producto.Type);
                        int i = command.ExecuteNonQuery();
                        if (i > 0)
                        {
                            value = true;
                            connection.Close();
                        }
                        else
                        {
                            value = false;
                            connection.Close();
                        }
                    }
                }             

            }catch(Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                  System.Windows.Forms.MessageBoxIcon.Error);
            }
            return value;
        }
        public Boolean addProduct(Product producto)
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection connection = con.getConnection();
                connection.Open();
                String SQL = "INSERT INTO consumible(clurp, nombre, tipo, precio, descri) " +
                    "VALUES(@clurp, @nombre, @tipo, @precio, @descri)";
                MySqlCommand command = new MySqlCommand( SQL, connection);
                command.Parameters.AddWithValue("@clurp", producto.Clurp);
                command.Parameters.AddWithValue("@nombre", producto.Name);
                command.Parameters.AddWithValue("@tipo", producto.Type);
                command.Parameters.AddWithValue("@precio", producto.Price);
                command.Parameters.AddWithValue("@descri", producto.Description);
                int i = command.ExecuteNonQuery();
                if(i != 1)
                {
                    value = false;
                    connection.Close();
                }
                else
                {
                    value = true;
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            return value;
        }

        public Boolean updateImage(object nameProduct, byte[] newImage)
        {
            Boolean getValue = existImage(nameProduct);
            if (getValue)
            {
                Connection con = new Connection();
                MySqlConnection connection = con.getConnection();
                connection.Open();
                String SQL = $"UPDATE imagenconsumible SET imagen={newImage} WHERE nombreConsumible LIKE @nombreConsumible";
                MySqlCommand command = new MySqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@nombreConsumible", nameProduct.ToString());
                int i = command.ExecuteNonQuery();
                if (i != 1)
                {
                    value = false;
                }
                else
                {
                    value = true;
                }
            }
            else
            {
                RJMessageBox.Show("The image you are trying to update isn't accessible", "WARNING!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);
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
                if (result == 1)
                {
                    value = true;
                    con.Close();
                }
                else
                {
                    value = false;
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
    }
}
