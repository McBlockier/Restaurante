using CustomMessageBox;
using MySql.Data.MySqlClient;
using Palacio_el_restaurante.src.Conection;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Palacio_el_restaurante.src.GUI
{
    public partial class FormM : Form
    {
        public int xClick = 0, yClick = 0;
        private int contadorAperturas = 0;
        private PediProve pediProve;
        private int countHover = 0;
        private int cSMS = 0;
        private String cacheSQL = "";
        public String getUserName { get; set; }
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
                Console.WriteLine(ex.Message);
            }
        }
        private void rjButton1_Click(object sender, EventArgs e)
        {

            if (getUserName != "Miguel" || getUserName != "Jesus")
            {

                if (contadorAperturas < 2)
                {
                    if (pediProve == null || pediProve.IsDisposed)
                    {
                        pediProve = new PediProve();
                        pediProve.boxesAdmin();
                    }

                    pediProve.Show();
                    contadorAperturas++;
                }
            }
            else
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

            if (cSMS == 0)
            {
                cSMS = 1;
                DialogResult result = RJMessageBox.Show("You are accessing full control, the actions cannot be undone," +
                   " once executed. Do you want to continue?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result.Equals(DialogResult.Yes))
                {
                    rjPe.ReadOnly = false;
                    if (!String.IsNullOrEmpty(rjPe.GetAllText()))
                    {
                        DialogResult result2 = RJMessageBox.Show("You are about to modify or alter something about the entity, " +
                            "this action cannot be reversed. Continue?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result2.Equals(DialogResult.Yes))
                        {
                            try
                            {
                                Connection con = new Connection();
                                MySqlConnection connection = con.getConnection();
                                rjDataPe.SetDatabaseConnection(connection);
                                rjDataPe.ExecuteSqlQuery(rjPe.GetAllText());
                                cacheSQL = rjPe.GetAllText();

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                    else
                    {
                        RJMessageBox.Show("There is no SQL statement to execute", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    rjPe.ReadOnly = true;
                }
            }
            else
            {

                if (!String.IsNullOrEmpty(rjPe.GetAllText()))
                {

                    try
                    {
                        Connection con = new Connection();
                        MySqlConnection connection = con.getConnection();
                        rjDataPe.SetDatabaseConnection(connection);
                        rjDataPe.ExecuteSqlQuery(rjPe.GetAllText());
                        cacheSQL = rjPe.GetAllText();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    RJMessageBox.Show("There is no SQL statement to execute", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void rjV_TextChanged(object sender, EventArgs e)
        {
            RJMessageBox.Show("You are accessing full control, the actions cannot be undone," +
            " once executed", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            rjV.ReadOnly = true;
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            if (countHover == 0)
            {
                countHover++;
                rjBPe.Focus();
            }
            else
            {
                countHover--;
                rjButton_V.Focus();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(cacheSQL))
                {
                    InquiriesDB DB = new InquiriesDB();
                    DB.GetDataTable(cacheSQL);
                }
                else
                {
                    InquiriesDB DB = new InquiriesDB();
                    DB.GetDataTable("SELECT * FROM pedidoprove");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                RJMessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                InquiriesDB DB = new InquiriesDB();
                DB.GetDataTable("SELECT * FROM pedidoprove");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
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