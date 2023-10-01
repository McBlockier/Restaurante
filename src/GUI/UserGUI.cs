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
    public partial class UserGUI : Form
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
        public UserGUI()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            fillBoxes();
        }

        private void fillBoxes()
        {
            rjRank.Items.Clear();
            rjOperation.Items.Clear();

            rjRank.Items.Add("Administrador");
            rjRank.Items.Add("Repartidor");
            rjRank.Items.Add("Usuario");

            rjOperation.Items.Add("Update");
            rjOperation.Items.Add("Delete");
            rjOperation.Items.Add("Add Up");
        }

        private void rjOperation_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch(rjOperation.SelectedItem as String) {
                case "Update":
                    rjUpdate.Visible = true;
                    rjDelete.Visible = false;
                    rjAddUp.Visible = false;
                    break;
                case "Delete":
                    rjUpdate.Visible = false;
                    rjDelete.Visible = true;
                    rjAddUp.Visible = false;
                    break;
                case "Add Up":
                    rjUpdate.Visible = false;
                    rjDelete.Visible = false;
                    rjAddUp.Visible = true;
                    break;
            }
        }

        private void rjPictureRounded4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void rjAddUp_Click(object sender, EventArgs e)
        {

        }

        private void rjDelete_Click(object sender, EventArgs e)
        {

        }
        private void rjUpdate_Click(object sender, EventArgs e)
        {

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
