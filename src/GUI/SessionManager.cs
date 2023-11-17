using CustomMessageBox;
using Newtonsoft.Json;
using Palacio_el_restaurante.src.Conection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palacio_el_restaurante.src.GUI
{
    public class SessionInfo
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LoginDateTime { get; set; }
        public string Device { get; set; }
        public string Rank { get; set; }
    }
    public class SessionManager
    {
        private string fileName = "Session.json";
        private SessionInfo sessionInfo;

        public SessionManager()
        {
            sessionInfo = ReadSessionInfoFromJson();
        }

        public SessionInfo GetSessionInfo()
        {
            return sessionInfo;
        }

        public void SaveSession(string username, string password)
        {
            sessionInfo = new SessionInfo
            {
                Username = username,
                Password = password,
                LoginDateTime = DateTime.Now,
                Device = Environment.MachineName,
                Rank = GetRank(username)
            };

            SaveSessionInfoToJson(sessionInfo);
        }

        private void SaveSessionInfoToJson(SessionInfo sessionInfo)
        {
            try
            {
                var json = JsonConvert.SerializeObject(sessionInfo);
                using (var streamWriter = new StreamWriter(fileName))
                {
                    streamWriter.Write(json);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private SessionInfo ReadSessionInfoFromJson()
        {
            if (File.Exists(fileName))
            {
                try
                {
                    using (var streamReader = new StreamReader(fileName))
                    {
                        var json = streamReader.ReadToEnd();
                        return JsonConvert.DeserializeObject<SessionInfo>(json);
                    }
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return null;
        }

        private string GetRank(string username)
        {
            InquiriesDB DB = new InquiriesDB();
            switch(DB.getRank(username))
            {
                case 1:
                    return "Administrador";
                 case 2:
                    return "Usuario"; 
                case 3:
                    return "Repartidor";
            }

            return "";
        }
    }
}