using CustomMessageBox;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using Palacio_el_restaurante.src.Conection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palacio_el_restaurante.src.GUI
{
    public partial class FormM : Form
    {
        public int xClick = 0, yClick = 0;
        private int contadorAperturas = 0;
        private PediProve pediProve;
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
        public FormM()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            fillData();
        }
        private void fillData()
        {
            Connection con = new Connection();
            MySqlConnection connection = con.getConnection();
            try
            {
                
                rjDataV.SetDatabaseConnection(connection);
                rjDataV.ExecuteSqlQuery("SELECT * FROM venta");

                rjDataPe.SetDatabaseConnection(connection);
                rjDataPe.ExecuteSqlQuery("SELECT * FROM pedidoprove");

            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.Message);
            }
        }      
        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (contadorAperturas < 2)
            {
                if (pediProve == null || pediProve.IsDisposed)
                {
                    pediProve = new PediProve();
                    pediProve.fillBoxV();
                }

                pediProve.Show();
                contadorAperturas++;
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

        private void rjButton_V_Click(object sender, EventArgs e)
        {
            RJMessageBox.Show("Sale cannot be modified, it is read only", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void rjButton_pe_Click(object sender, EventArgs e)
        {
            DialogResult result = RJMessageBox.Show("You are about to modify or alter something about the entity, " +
                "this action cannot be reversed. Continue?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result.Equals(DialogResult.Yes))
            {
                try
                {
                    Connection con = new Connection();
                    MySqlConnection connection = con.getConnection();
                    rjDataPe.SetDatabaseConnection(connection);
                    rjDataPe.ExecuteSqlQuery(rjPe.GetAllText());

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }     
        }

        private void FormM_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }
    }
}
