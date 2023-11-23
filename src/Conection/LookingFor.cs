using CustomMessageBox;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palacio_el_restaurante.src.Conection
{
    public class Consumible
    {
        public string Clurp { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public float Precio { get; set; }
        public string Descri { get; set; }
    }
    public class Empleado
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }

    }
    public class Usuario
    {
        public string IdUser { get; set; }
        public string Nombre { get; set; }
        public string LastNameP { get; set; }
        public string LastNameM { get; set; }
        public string Password { get; set; }
        public int IdJerarquia { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Locacion { get; set; }
        public string Telefono { get; set; }

    }
    public class Jerarquia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    public class Venta
    {
        public int IdVenta { get; set; }
        public string IdPlato { get; set; }
        public int Cantidad { get; set; }
        public string IdEmpleado { get; set; }
        public float Precio { get; set; }
        public DateTime Fecha { get; set; }
    }
    public class PedidoProve
    {
        public string Contra { get; set; }
        public string IdPed { get; set; }
        public string RepNam { get; set; }
    }
    public class Proveedor
    {
        public string Folio { get; set; }
        public string Marca { get; set; }
        public float Precio { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
    }

    public class LookingFor
    {
        public async Task<List<Consumible>> BuscarConsumibles(string keyWord)
        {
            List<Consumible> consumibles = new List<Consumible>();

            try
            {
                Connection con = new Connection();
                using (MySqlConnection connection = con.getConnection())
                {
                    await connection.OpenAsync();

                    string storedProcedure = "BuscarConsumibles";

                    using (MySqlCommand cmd = new MySqlCommand(storedProcedure, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@keyword", keyWord);

                        using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Consumible consumible = new Consumible
                                {
                                    Clurp = reader["clurp"].ToString(),
                                    Nombre = reader["nombre"].ToString(),
                                    Tipo = reader["tipo"].ToString(),
                                    Precio = Convert.ToSingle(reader["precio"]),
                                    Descri = reader["descri"].ToString()
                                };

                                consumibles.Add(consumible);
                            }
                        }
                    }
                }

                return consumibles;
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error en la búsqueda de consumibles: " + ex.Message);
                return null;
            }
        }


        public async Task<List<Empleado>> lookingEmpleado(string keyWord)
        {
            List<Empleado> empleados = new List<Empleado>();

            try
            {
                Connection con = new Connection();
                using (MySqlConnection connection = con.getConnection())
                {
                    await connection.OpenAsync();

                    string query = "SELECT * FROM empleado WHERE id LIKE @keyword OR nombre LIKE @keyword";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyWord + "%");

                        using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Empleado empleado = new Empleado
                                {
                                    Id = reader["id"].ToString(),
                                    Nombre = reader["nombre"].ToString(),
                                    Telefono = reader["telefono"].ToString(),
                                    Sexo = reader["sexo"].ToString()
                                };

                                empleados.Add(empleado);
                            }
                        }
                    }
                }

                return empleados;
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error en la búsqueda de empleados: " + ex.Message);
                return null;
            }
        }


        public async Task<List<Usuario>> BuscarUsuarios(string keyWord)
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                Connection con = new Connection();
                using (MySqlConnection connection = con.getConnection())
                {
                    await connection.OpenAsync();

                    string storedProcedure = "BuscarUsuarios";

                    using (MySqlCommand cmd = new MySqlCommand(storedProcedure, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@keyword", keyWord);

                        using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Usuario usuario = new Usuario
                                {
                                    IdUser = reader["idUser"].ToString(),
                                    Nombre = reader["nombre"].ToString(),
                                    LastNameP = reader["lastNameP"].ToString(),
                                    LastNameM = reader["lastNameM"].ToString(),
                                    Password = reader["password"].ToString(),
                                    IdJerarquia = Convert.ToInt32(reader["id_jerarquia"]),
                                    Street1 = reader["street1"].ToString(),
                                    Street2 = reader["street2"].ToString(),
                                    Locacion = reader["locacion"].ToString(),
                                    Telefono = reader["telefono"].ToString()
                                };

                                usuarios.Add(usuario);
                            }
                        }
                    }
                }

                return usuarios;
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error en la búsqueda de usuarios: " + ex.Message);
                return null;
            }
        }


        public async Task<List<Jerarquia>> BuscarJerarquias(string keyWord)
        {
            List<Jerarquia> jerarquias = new List<Jerarquia>();

            try
            {
                Connection con = new Connection();
                using (MySqlConnection connection = con.getConnection())
                {
                    await connection.OpenAsync();

                    string storedProcedure = "BuscarJerarquias";

                    using (MySqlCommand cmd = new MySqlCommand(storedProcedure, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@keyword", keyWord);

                        using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Jerarquia jerarquia = new Jerarquia
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Nombre = reader["nombre"].ToString()
                                };

                                jerarquias.Add(jerarquia);
                            }
                        }
                    }
                }

                return jerarquias;
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error en la búsqueda de jerarquías: " + ex.Message);
                return null;
            }
        }


        public async Task<List<Venta>> BuscarVentas(string keyWord)
        {
            List<Venta> ventas = new List<Venta>();

            try
            {
                Connection con = new Connection();
                using (MySqlConnection connection = con.getConnection())
                {
                    await connection.OpenAsync();

                    string storedProcedure = "BuscarVentas";

                    using (MySqlCommand cmd = new MySqlCommand(storedProcedure, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@keyword", keyWord);

                        using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Venta venta = new Venta
                                {
                                    IdVenta = Convert.ToInt32(reader["idVenta"]),
                                    IdPlato = reader["idPlato"].ToString(),
                                    Cantidad = Convert.ToInt32(reader["cantidad"]),
                                    IdEmpleado = reader["Idemple"].ToString(),
                                    Precio = Convert.ToSingle(reader["precio"]),
                                    Fecha = Convert.ToDateTime(reader["fecha"])
                                };

                                ventas.Add(venta);
                            }
                        }
                    }
                }

                return ventas;
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error en la búsqueda de ventas: " + ex.Message);
                return null;
            }
        }


        public async Task<List<PedidoProve>> lookingPedidoProve(string keyWord)
        {
            List<PedidoProve> pedidosProve = new List<PedidoProve>();

            try
            {
                Connection con = new Connection();
                using (MySqlConnection connection = con.getConnection())
                {
                    await connection.OpenAsync();

                    string query = "SELECT * FROM pedidoprove WHERE contra LIKE @keyword OR idPed LIKE @keyword OR repNam LIKE @keyword";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyWord + "%");

                        using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                PedidoProve pedidoProve = new PedidoProve
                                {
                                    Contra = reader["contra"].ToString(),
                                    IdPed = reader["idPed"].ToString(),
                                    RepNam = reader["repNam"].ToString()
                                };

                                pedidosProve.Add(pedidoProve);
                            }
                        }
                    }
                }

                return pedidosProve;
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error en la búsqueda de pedidos a proveedores: " + ex.Message);
                return null;
            }
        }

        public async Task<List<Proveedor>> lookingProveedor(string keyWord)
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            try
            {
                Connection con = new Connection();
                using (MySqlConnection connection = con.getConnection())
                {
                    await connection.OpenAsync();

                    string query = "SELECT * FROM proveedor WHERE folio LIKE @keyword OR marca LIKE @keyword OR precio LIKE @keyword OR cantidad LIKE @keyword OR fecha LIKE @keyword OR nombre LIKE @keyword";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyWord + "%");

                        using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Proveedor proveedor = new Proveedor
                                {
                                    Folio = reader["folio"].ToString(),
                                    Marca = reader["marca"].ToString(),
                                    Precio = Convert.ToSingle(reader["precio"]),
                                    Cantidad = Convert.ToInt32(reader["cantidad"]),
                                    Fecha = Convert.ToDateTime(reader["fecha"]),
                                    Nombre = reader["nombre"].ToString()
                                };

                                proveedores.Add(proveedor);
                            }
                        }
                    }
                }

                return proveedores;
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error en la búsqueda de proveedores: " + ex.Message);
                return null;
            }
        }

        public async Task<string> BuscarClurpConsumible(string nombre, string descripcion, float precio)
        {
            try
            {
                Connection con = new Connection();
                using (MySqlConnection connection = con.getConnection())
                {
                    await connection.OpenAsync();

                    string storedProcedure = "BuscarClurpConsumible";

                    using (MySqlCommand cmd = new MySqlCommand(storedProcedure, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombreConsumible", nombre);
                        cmd.Parameters.AddWithValue("@descripcionConsumible", descripcion);
                        cmd.Parameters.AddWithValue("@precioConsumible", precio);

                        object result = await cmd.ExecuteScalarAsync();
                        return result?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error en la búsqueda del clurp del consumible: " + ex.Message);
                return null;
            }
        }






    }

}