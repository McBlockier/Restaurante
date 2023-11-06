using CustomMessageBox;
using IronXL;
using MathNet.Numerics.LinearAlgebra;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Palacio_el_restaurante.src.Conection
{
    public class InquiriesDB
    {
        private Boolean value = false;
        private int count = 0, countP = 0;
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
                if (!String.IsNullOrEmpty(persona.Rank.ToString()))
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

                if (!String.IsNullOrEmpty(persona.IdUser))
                {
                    List<string> updatedFields = new List<string>();
                    SQL = "UPDATE usuario SET ";
                    if (persona.FieldsToUpdate["Name"])
                    {
                        SQL += "nombre=@nombre, ";
                        updatedFields.Add("nombre");
                    }
                    if (persona.FieldsToUpdate["LastNameP"])
                    {
                        SQL += "lastNameP=@lastNameP, ";
                        updatedFields.Add("lastNameP");
                    }
                    if (persona.FieldsToUpdate["LastNameM"])
                    {
                        SQL += "lastNameM=@lastNameM, ";
                        updatedFields.Add("lastNameM");
                    }
                    if (persona.FieldsToUpdate["Password"])
                    {
                        SQL += "password=@password, ";
                        updatedFields.Add("password");
                    }
                    if (persona.FieldsToUpdate["Rank"])
                    {
                        SQL += "id_jerarquia=@id_jerarquia, ";
                        updatedFields.Add("id_jerarquia");
                    }
                    if (persona.FieldsToUpdate["PrimaryStreet"])
                    {
                        SQL += "street1=@street1, ";
                        updatedFields.Add("street1");
                    }
                    if (persona.FieldsToUpdate["SecondaryStreet"])
                    {
                        SQL += "street2=@street2, ";
                        updatedFields.Add("street2");
                    }
                    if (persona.FieldsToUpdate["Settlement_type1"])
                    {
                        SQL += "locacion=@locacion, ";
                        updatedFields.Add("locacion");
                    }
                    if (persona.FieldsToUpdate["PhoneNumber"])
                    {
                        SQL += "telefono=@telefono, ";
                        updatedFields.Add("telefono");
                    }
                    SQL = SQL.TrimEnd(',', ' ');
                    SQL += " WHERE idUser LIKE @idUser";

                    MySqlCommand command = new MySqlCommand(SQL, con);
                    command.Parameters.AddWithValue("@idUser", persona.IdUser);
                    foreach (var field in updatedFields)
                    {
                        switch (field)
                        {
                            case "nombre":
                                command.Parameters.AddWithValue("@nombre", persona.Name);
                                break;
                            case "lastNameP":
                                command.Parameters.AddWithValue("@lastNameP", persona.LastNameP);
                                break;
                            case "lastNameM":
                                command.Parameters.AddWithValue("@lastNameM", persona.LastNameM);
                                break;
                            case "password":
                                command.Parameters.AddWithValue("@password", persona.Password);
                                break;
                            case "id_jerarquia":
                                command.Parameters.AddWithValue("@id_jerarquia", persona.Rank);
                                break;
                            case "street1":
                                command.Parameters.AddWithValue("@street1", persona.PrimaryStreet);
                                break;
                            case "street2":
                                command.Parameters.AddWithValue("@street2", persona.SecondaryStreet);
                                break;
                            case "locacion":
                                command.Parameters.AddWithValue("@locacion", persona.Settlement_type1);
                                break;
                            case "telefono":
                                command.Parameters.AddWithValue("@telefono", persona.PhoneNumber);
                                break;
                        }
                    }

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
                    RJMessageBox.Show("The user cannot be empty, you must enter the user you want to update",
                                    "INFORMATION!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return value;
        }

        
        public bool deleteUser(Persona persona)
        {
            Connection con = new Connection();
            using (MySqlConnection connection = con.getConnection())
            {
                try
                {
                    connection.Open();
                    string SQL = "DELETE FROM usuario WHERE idUser = @idUser";
                    MySqlCommand command = new MySqlCommand(SQL, connection);
                    command.Parameters.AddWithValue("@idUser", persona.IdUser);
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }


        public void GetConsultInv(String typeConsult)
        {
            
            try
            {
                Connection con = new Connection();
                MySqlConnection connection = con.getConnection();             
                switch(typeConsult)
                {
                    case "a":
                        String SQL1 = "";
                        break;
                    case "s":
                        String SQL2 = "";
                        break;
                }
            }catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
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

        public int GetClurp()
        {
            int newClurp = 0;
          try {
            
                Connection connection = new Connection();
                MySqlConnection con = connection.getConnection();
                con.Open();
                string SQL = "SELECT LPAD(CONVERT(clurp, SIGNED) + 1, 3, '0') AS new_clurp " +
                         "FROM consumible " +
                         "ORDER BY CONVERT(clurp, SIGNED) DESC " +
                         "LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(SQL, con))
                {
                    newClurp = Convert.ToInt32(cmd.ExecuteScalar());
                    return newClurp;
                }               
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                  System.Windows.Forms.MessageBoxIcon.Error);
            }
            return newClurp;
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
        public Image getImage(object nameProduct)
        {
            try
            {
                Connection con = new Connection();
                using (MySqlConnection connection = con.getConnection())
                {
                    connection.Open();
                    string SQL = "SELECT imagen FROM imagenconsumible WHERE nombreConsumible LIKE @nombreConsumible";
                    using (MySqlCommand command = new MySqlCommand(SQL, connection))
                    {
                        command.Parameters.AddWithValue("@nombreConsumible", nameProduct);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                byte[] imageData = (byte[])reader["imagen"];
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    return Image.FromStream(ms);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null; 
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

            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            return value;
        }

        public String[] infoProduct(String clurp)
        {
            String[] getInfoProduct = new String[10];
            try
            {
                Connection con = new Connection();
                MySqlConnection connection = con.getConnection();
                connection.Open();
                String SQL = "SELECT * FROM consumible WHERE clurp LIKE @clurp";
                MySqlCommand command = new MySqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@clurp", clurp);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    getInfoProduct[0] = reader["nombre"].ToString();
                    getInfoProduct[1] = reader["tipo"].ToString();
                    getInfoProduct[2] = reader["precio"].ToString();
                    getInfoProduct[3] = reader["descri"].ToString();
                }
                else
                {
                    if (countP == 0)
                    {
                        RJMessageBox.Show("The producto aren't exists in the data base", "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Information);
                        countP++;
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                   System.Windows.Forms.MessageBoxIcon.Error);
            }
            return getInfoProduct;
        }
        public bool existProduct(int Clurp)
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection connection = con.getConnection();
                connection.Open();
                string SQL = "SELECT COUNT(*) FROM consumible WHERE clurp = @clurp";
                MySqlCommand command = new MySqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@clurp", Clurp.ToString());

                int count = Convert.ToInt32(command.ExecuteScalar());
                value = count > 0;
                connection.Close();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                value = false;
            }
            return value;
        }

        public String[] searchInfoUser(String username)
        {
            String[] getInfo = new String[9];
            try
            {
                Connection con = new Connection();
                MySqlConnection connection = con.getConnection();
                connection.Open();
                String SQL = "SELECT * FROM usuario WHERE idUser LIKE @idUser";
                MySqlCommand command = new MySqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@idUser", username);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    getInfo[0] = reader["nombre"].ToString();
                    getInfo[1] = reader["lastNameP"].ToString();
                    getInfo[2] = reader["lastNameM"].ToString();
                    getInfo[3] = reader["password"].ToString();
                    getInfo[4] = reader["id_jerarquia"].ToString();
                    getInfo[5] = reader["street1"].ToString();
                    getInfo[6] = reader["street2"].ToString();
                    getInfo[7] = reader["locacion"].ToString();
                    getInfo[8] = reader["telefono"].ToString();
                }
                else
                {
                    if (count == 0)
                    {
                        RJMessageBox.Show("The infor of username aren't exists in the data base",
                                      "INFORMATION!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        count++;
                    }
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                   System.Windows.Forms.MessageBoxIcon.Error);
            }
            return getInfo;
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

                if (!String.IsNullOrEmpty(producto.Name) && !String.IsNullOrEmpty(producto.Description)
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
                    if (j > 0)
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

            }
            catch (Exception ex)
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
                MySqlCommand command = new MySqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@clurp", producto.Clurp);
                command.Parameters.AddWithValue("@nombre", producto.Name);
                command.Parameters.AddWithValue("@tipo", producto.Type);
                command.Parameters.AddWithValue("@precio", producto.Price);
                command.Parameters.AddWithValue("@descri", producto.Description);
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

        //FoodGUI


        public List<String> getConsumable(String category)
        {
            List<string> consumables = new List<string>();
            try
            {
                Connection connection = new Connection();
                MySqlConnection con = connection.getConnection();
                con.Open();
                String SQL = "SELECT nombre FROM consumible WHERE tipo LIKE @tipo";
                MySqlCommand command = new MySqlCommand(SQL, con);
                command.Parameters.AddWithValue("@tipo", category);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string consumableName = reader.GetString("nombre");
                    consumables.Add(consumableName);
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            return consumables;
        }
        public List<String> GetEmployes(String[] idEmploye)
        {
            List<String> getEmployes = new List<String>();
            try
            {
                Connection connection = new Connection();
                MySqlConnection con = connection.getConnection();
                con.Open();
                String SQL = "SELECT nombre FROM empleado WHERE id LIKE @id";
                MySqlCommand command = new MySqlCommand(SQL, con);
                command.Parameters.AddWithValue("@id", idEmploye);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string employeName = reader.GetString("nombre");
                    getEmployes.Add(employeName);
                }

            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            return getEmployes;

        }
        public int GetIdSale(Sale venta)
        {
            int lastInsertedId = 0;
            try
            {
                Connection con = new Connection();
                MySqlConnection connection = con.getConnection();
                connection.Open();
                string getLastIdQuery = "SELECT MAX(idVenta) FROM venta;";
                MySqlCommand getLastIdCommand = new MySqlCommand(getLastIdQuery, connection);
                lastInsertedId = Convert.ToInt32(getLastIdCommand.ExecuteScalar());
                venta.IdSale = lastInsertedId;
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            return lastInsertedId;
        }
        public Boolean registSale(Sale venta)
        {
            String[] id = { "1A", "1B", "1C", "1D", "1E", "1F" };
            try
            {
                Connection con = new Connection();
                MySqlConnection connection = con.getConnection();
                connection.Open();
                Random random = new Random();
                int indiceAleatorio = random.Next(0, id.Length);
                String SQL = "INSERT INTO venta(idVenta,idPlato,cantidad,Idemple,precio,fecha)" +
                    "VALUES(@idVenta,@idPlato,@cantidad,@Idemple,@precio,@fecha) ";
                MySqlCommand command = new MySqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@idVenta", GetIdSale(venta) + 1);
                command.Parameters.AddWithValue("@idPlato", venta.IdDish);
                command.Parameters.AddWithValue("@cantidad", venta.Amount);
                command.Parameters.AddWithValue("@Idemple", id[indiceAleatorio]);
                command.Parameters.AddWithValue("@precio", venta.Price * venta.Amount);
                command.Parameters.AddWithValue("@fecha", venta.Date);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    value = true;
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);
            }
            return value;
        }
        public String[] GetClurp(String nameDrink)
        {
            String[] clurp = new String[6];
            try
            {
                Connection connection = new Connection();
                MySqlConnection con = connection.getConnection();
                con.Open();
                String SQL = "SELECT clurp, precio FROM consumible WHERE nombre LIKE @nombre";
                MySqlCommand command = new MySqlCommand(SQL, con);
                command.Parameters.AddWithValue("@nombre", nameDrink);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    clurp[0] = reader.GetString("clurp");
                    clurp[1] = reader.GetString("precio");
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);
            }
            return clurp;
        }
        public List<String> GetFood(String category)
        {
            List<string> consumables = new List<string>();
            try
            {
                Connection connection = new Connection();
                MySqlConnection con = connection.getConnection();
                con.Open();
                String SQL = "SELECT nombre FROM consumible WHERE tipo LIKE @tipo";
                MySqlCommand command = new MySqlCommand(SQL, con);
                command.Parameters.AddWithValue("@tipo", category);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string consumableName = reader.GetString("nombre");
                    consumables.Add(consumableName);
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            return consumables;
        }

        public bool AcctionProve(string Operation, string Contra, string idPed, string repNam)
        {
            Connection con = new Connection();
            MySqlConnection connection = con.getConnection();
            MySqlCommand cmd = new MySqlCommand();
            connection.Open();

            cmd.Connection = connection;

            switch (Operation)
            {
                case "Update":
                    string updateQuery = "UPDATE pedidoprove SET repNam = @repNam, idPed = @idPed WHERE contra = @contra";
                    cmd.CommandText = updateQuery;
                    cmd.Parameters.AddWithValue("@repNam", repNam);
                    cmd.Parameters.AddWithValue("@contra", Contra);
                    cmd.Parameters.AddWithValue("@idPed", idPed);
                    break;

                case "Delete":
                    string deleteQuery = "DELETE FROM pedidoprove WHERE contra = @contra";
                    cmd.CommandText = deleteQuery;
                    cmd.Parameters.AddWithValue("@contra", Contra);
                    break;

                case "Add Up":
                    string insertQuery = "INSERT INTO pedidoprove (contra, idPed, repNam) VALUES (@contra, @idPed, @repNam)";
                    cmd.CommandText = insertQuery;
                    cmd.Parameters.AddWithValue("@contra", Contra);
                    cmd.Parameters.AddWithValue("@idPed", idPed);
                    cmd.Parameters.AddWithValue("@repNam", repNam);
                    break;
            }
            int rowsAffected = cmd.ExecuteNonQuery();
            connection.Close();
            return rowsAffected > 0;
        }


        public void GetDataTable(String SQL)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            try
            {
                Connection con = new Connection();
                MySqlConnection connection = con.getConnection();
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(SQL, connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Resultados");
                if (dataSet.Tables["Resultados"].Rows.Count == 0)
                {
                    MessageBox.Show("There is no data to export", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string defaultFileName = "Resultados.xlsx";

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    saveFileDialog.Title = "Save data in excel";
                    saveFileDialog.FileName = defaultFileName;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        if (string.IsNullOrWhiteSpace(filePath))
                        {
                            MessageBox.Show("The file name is invalid", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        FileInfo newFile = new FileInfo(filePath);

                        using (ExcelPackage package = new ExcelPackage(newFile))
                        {
                            using (FileStream templateStream = new FileStream("modelo2.xlsx", FileMode.Open))
                            {
                                package.Load(templateStream);
                            }

                            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                            worksheet.Cells["A2"].LoadFromDataTable(dataSet.Tables["Resultados"], true);
                            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                            using (ExcelRange cells = worksheet.Cells[worksheet.Dimension.Address])
                            {
                               
                                cells.Style.Font.Size = 12;
                                cells.Style.Font.Bold = true;
                                cells.Style.Font.Color.SetColor(System.Drawing.Color.Black);
                                cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                cells.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                            }

                            package.Save();
                        }

                        MessageBox.Show($"The data has been exported successfully in '{filePath}'.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }
    }
}