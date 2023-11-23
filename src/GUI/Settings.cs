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

namespace Palacio_el_restaurante.src.GUI
{
    public partial class Settings : Form
    {
        public int xClick = 0, yClick = 0;
        private Color SelectedColor;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
      (
          int nLeftRect,     
          int nTopRect,     
          int nRightRect,    
          int nBottomRect,  
          int nWidthEllipse,
          int nHeightEllipse 
      );
       
        public Settings()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            loadSettings();
            fillBoxes();
        }
        private void fillBoxes()
        {
            rjFormats.Items.Clear();
            rjFormats.Items.Add("XLSX");
            rjFormats.Items.Add("PDF");
            rjFormats.Items.Add("DOCX");

            rjStyle.Items.Clear();
            rjStyle.Items.Add("Donut");
            rjStyle.Items.Add("Table");
        }
        private void loadSettings()
        {
            try
            {
                if (File.Exists("settings.json"))
                {
                    string json = File.ReadAllText("settings.json");
                    SettingsJSON settings = JsonConvert.DeserializeObject<SettingsJSON>(json);

                    getThread.Checked = settings.Thread;
                    getAddi.Checked = settings.Addi;
                    getTriggers.Checked = settings.Triggers;
                    rjFormats.Texts = settings.Format;
                    rjStyle.Texts = settings.StyleFormat;

                }
                else
                {
                    RJMessageBox.Show("Missing root file dependencies", "WARNING!",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }

        }

        private void rjPictureRounded4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void rjPictureRounded6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void rjButton_Save_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsJSON settings = new SettingsJSON
                {
                    Thread = getThread.Checked,
                    Addi = getAddi.Checked,
                    Triggers = getTriggers.Checked,
                    StyleFormat = rjStyle.SelectedItem as String,
                    Format = rjFormats.SelectedItem as String                   
                };

                string json = JsonConvert.SerializeObject(settings);
                File.WriteAllText("settings.json", json);

                RJMessageBox.Show("The are save successfully!", "INFORMATION!", System.Windows.Forms.MessageBoxButtons.OK,
                 System.Windows.Forms.MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                 System.Windows.Forms.MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void rjButton1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void Settings_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void getTriggers_CheckedChanged(object sender, EventArgs e)
        {
            if (getTriggers.Checked)
            {
               DialogResult result = RJMessageBox.Show("They will alter communication with the database", "INFORMATION!", 
                 System.Windows.Forms.MessageBoxButtons.YesNo,
                 System.Windows.Forms.MessageBoxIcon.Question);

                if (result.Equals(DialogResult.No))
                {
                    getTriggers.Checked = false;
                }

            }
        }

    }
}
