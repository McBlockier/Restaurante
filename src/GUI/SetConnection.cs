using CustomMessageBox;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palacio_el_restaurante.src.Conection
{
    public partial class SetConnection : Form
    {
        public int xClick = 0, yClick = 0;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
    (
        int nLeftRect,     // x-coordinate of upper-left corner
        int nTopRect,      // y-coordinate of upper-left corner
        int nRightRect,    // x-coordinate of lower-right corner
        int nBottomRect,   // y-coordinate of lower-right corner
        int nWidthEllipse, // height of ellipse
        int nHeightEllipse // width of ellipse
    );
        public SetConnection()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 14, 14));
        }
        private async void rjButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(getServer.Texts) &&
                    !String.IsNullOrEmpty(getPort.Texts) &&
                    !String.IsNullOrEmpty(getDataBase.Texts) &&
                    !String.IsNullOrEmpty(getUsername.Texts) &&
                    !String.IsNullOrEmpty(getPassword.Texts))
                {
                    ConnectionInfo info = new ConnectionInfo
                    {
                        Server = getServer.Texts,
                        Port = getPort.Texts,
                        Database = getDataBase.Texts,
                        Uid = getUsername.Texts,
                        Pwd = getPassword.Texts
                    };
                    string json = JsonConvert.SerializeObject(info);
                    string jsonFileName = "connection.json";

                    lock (new object())
                    {
                        using (var streamWriter = new StreamWriter(jsonFileName, false, Encoding.UTF8))
                        {
                            streamWriter.Write(json);
                        }
                    }

                    RJMessageBox.Show("Connection information has been saved.", "Success",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Information);
                        LoginFrame login = new LoginFrame();
                        login.Show();
                        this.Hide();
                                                    
                }
                else
                {
                    RJMessageBox.Show("You must enter all data for the database", "WARNING!",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Warning);
                }
            }catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                   System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void clearFiels()
        {
            getDataBase.Texts = String.Empty;
            getPassword.Texts = String.Empty;
            getServer.Texts = String.Empty;
            getPort.Texts = String.Empty;
            getUsername.Texts = String.Empty;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }
    }
}
