using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using Palacio_el_restaurante.src.Conection;

namespace Palacio_el_restaurante
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                string filePath = "system_info.enc";

                if (File.Exists(filePath))
                {
                    RunApplication();
                }
                else
                {
                    string deviceName = Environment.MachineName;
                    string localIp = GetLocalIpAddress();
                    string osVersion = Environment.OSVersion.VersionString;
                    string executionDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    var systemInfo = new
                    {
                        DeviceName = deviceName,
                        LocalIp = localIp,
                        OSVersion = osVersion,
                        ExecutionDateTime = executionDateTime,
                        AdditionalInfo = GetAdditionalSystemInfo()
                    };

                    string jsonSystemInfo = JsonConvert.SerializeObject(systemInfo);
                    string encryptedJson = EncryptString(jsonSystemInfo, "AlphaPrime");
                    File.WriteAllText(filePath, encryptedJson);
                    RunApplication();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private static void RunApplication()
        {
            Application.Run(new LoginFrame());
        }

        private static void HandleException(Exception ex)
        {
            CustomMessageBox.RJMessageBox.Show($"An unhandled exception occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static string GetLocalIpAddress()
        {
            string localIp = "";
            try
            {
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        localIp = ip.ToString();
                        break;
                    }
                }
            }
            catch (Exception)
            {
                localIp = "N/A";
            }
            return localIp;
        }

        private static string EncryptString(string plainText, string password)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = new Rfc2898DeriveBytes(password, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 }).GetBytes(32);
                aesAlg.IV = new Rfc2898DeriveBytes(password, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 }).GetBytes(16);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        private static string GetAdditionalSystemInfo()
        {
            string additionalInfo = "";
            string processorArchitecture = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
            additionalInfo += "Processor Architecture: " + processorArchitecture + Environment.NewLine;
            int processorCores = Environment.ProcessorCount;
            additionalInfo += "Processor Cores: " + processorCores + Environment.NewLine;

            return additionalInfo;
        }
    }
}


