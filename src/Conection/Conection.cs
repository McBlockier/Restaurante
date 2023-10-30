using CustomMessageBox;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palacio_el_restaurante.src.Conection
{
    public class ConnectionInfo
    {
        public string Server { get; set; }
        public string Port { get; set; }
        public string Database { get; set; }
        public string Uid { get; set; }
        public string Pwd { get; set; }
    }

    public class Connection
    {
        private ConnectionInfo info;
        private Boolean valueUser = false;
        private String setConnectionUser = "";

        public Connection()
        {
            InitializeConnectionInfoAsync();
        }
        public void SetConnectionUser(String userName)
        {
            try
            {
                switch (userName)
                {
                    case "Miguel":
                        setConnectionUser = "Server=localhost;Database=palacio;User ID=Miguel;Password=root;";
                        valueUser = true;
                        break;
                    case "Jesus":
                        setConnectionUser = "Server=localhost;Database=palacio;User ID=Jesus;Password=root;";
                        valueUser = true;
                        break;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
         }
        public async void InitializeConnectionInfoAsync()
        {
            info = await valuesConnection();
        }

        private async Task<ConnectionInfo> valuesConnection()
        {
            ConnectionInfo connectionInfo = null;
            try
            {
                string jsonFileName = "connection.json";

                if (File.Exists(jsonFileName))
                {
                    using (var streamReader = new StreamReader(jsonFileName))
                    {
                        var json = await streamReader.ReadToEndAsync();
                        connectionInfo = JsonConvert.DeserializeObject<ConnectionInfo>(json);                      
                    }
                }
                else
                {
                    string defaultDatabaseFileName = "default_database.json";
                    if (File.Exists(defaultDatabaseFileName))
                    {
                        using (var streamReader = new StreamReader(defaultDatabaseFileName))
                        {
                            var defaultJson = await streamReader.ReadToEndAsync();
                            var defaultConnectionInfo = JsonConvert.DeserializeObject<ConnectionInfo>(defaultJson);
                            if (defaultConnectionInfo != null)
                            {
                                connectionInfo.Server = defaultConnectionInfo.Server;
                                connectionInfo.Port = defaultConnectionInfo.Port;
                                connectionInfo.Database = defaultConnectionInfo.Database;
                                connectionInfo.Uid = defaultConnectionInfo.Uid;
                                connectionInfo.Pwd = defaultConnectionInfo.Pwd;
                            }
                        }
                    }

                    var json = JsonConvert.SerializeObject(connectionInfo);
                    using (var streamWriter = new StreamWriter(jsonFileName))
                    {
                        await streamWriter.WriteAsync(json);
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return connectionInfo;
        }

        public MySqlConnection getConnection()
        {
            if (valueUser)
            {
                try
                {

                    MySqlConnection connection = new MySqlConnection(setConnectionUser);
                    return connection;

                }catch (Exception ex)
                {
                    RJMessageBox.Show("The database is not configured correctly", "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            else
            {
                ConnectionInfo connectionInfo = ReadConnectionInfoFromJson();
                if (connectionInfo != null)
                {
                    try
                    {
                        string stringConnection = $"Server={connectionInfo.Server};Port={connectionInfo.Port};Database={connectionInfo.Database};Uid={connectionInfo.Uid};Pwd={connectionInfo.Pwd}";
                        MySqlConnection connection = new MySqlConnection(stringConnection);
                        return connection;
                    }
                    catch (MySqlException ex)
                    {
                        RJMessageBox.Show("The database is not configured correctly", "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Error);
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        private ConnectionInfo ReadConnectionInfoFromJson()
        {
            ConnectionInfo connectionInfo = null;
            string jsonFileName = "connection.json";

            try
            {
                if (File.Exists(jsonFileName))
                {
                    using (var streamReader = new StreamReader(jsonFileName))
                    {
                        var json = streamReader.ReadToEnd();
                        connectionInfo = JsonConvert.DeserializeObject<ConnectionInfo>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return connectionInfo;
        }
        public bool IsConnectionConfiguredAsync()
        {
            ConnectionInfo connectionInfo = ReadConnectionInfoFromJson();

            if (connectionInfo == null)
            {
                RJMessageBox.Show("The database is not configured correctly", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                MySqlConnection testConnection = new MySqlConnection($"Server={connectionInfo.Server};Port={connectionInfo.Port};Database={connectionInfo.Database};Uid={connectionInfo.Uid};Pwd={connectionInfo.Pwd}");
                testConnection.Open();
                testConnection.Close();
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
