using CustomMessageBox;
using MySql.Data.MySqlClient;
using Palacio_el_restaurante.src.Conection;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Palacio_el_restaurante.src.GUI
{
    public partial class OrdersGUI : Form
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
        public OrdersGUI()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            orders();
        }

        private void rjPictureRounded4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void rjPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void rjDataOrders_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void panelOrders_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void rjDone_Click(object sender, EventArgs e)
        {
            DialogResult result = RJMessageBox.Show("Do you wanna make this?", "QUESTION",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.Yes))
            {
                try
                {
                    rjDataOrders.DataSource = null;
                }
                catch (Exception)
                {

                }
            }        
        }

        private void orders()
        {
            try {
                Connection con = new Connection();
                MySqlConnection connection = con.getConnection();
                rjDataOrders.SetDatabaseConnection(connection);
                rjDataOrders.ExecuteSqlQuery("SELECT c.nombre AS NombreConsumible, \r\n       v.cantidad AS CantidadVendida, \r\n       v.fecha AS FechaVenta, \r\n       c.precio AS PrecioUnitario\r\nFROM venta AS v\r\nINNER JOIN consumible AS c ON v.idPlato = c.clurp;\r\n");
            
            }catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
