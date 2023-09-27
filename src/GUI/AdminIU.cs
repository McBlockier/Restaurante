using CustomMessageBox;
using Palacio_el_restaurante.src.Conection;
using Palacio_el_restaurante.src.Controls;
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
    public partial class AdminIU : Form
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
        public AdminIU()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            s1.Visible = true;
            s2.Visible = false;
            s3.Visible = false;
            s4.Visible = false;
        }
        private void setVisiblePanels()
        {
            panelSQL.Visible = true;
        }

        private void leftPanel_MouseMove(object sender, MouseEventArgs e)
        {
            panel1_MouseMove(sender, e);
        }

        private void rjPictureRounded4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rjPictureRounded6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void rjPictureRounded1_Click(object sender, EventArgs e)
        {
            s1.Visible = true;
            s2.Visible = false;
            s3.Visible = false;
            s4.Visible = false;

            panelSQL.Visible = true;
            panelinv.Visible = false;
            panelStaff.Visible = false;
         
        }

        private void rjPictureRounded2_Click(object sender, EventArgs e)
        {
            s1.Visible = false;
            s2.Visible = true;
            s3.Visible = false;
            s4.Visible = false;

            panelSQL.Visible = false;
            panelinv.Visible = true;
            panelStaff.Visible = false;
        }

        private void rjPictureRounded3_Click(object sender, EventArgs e)
        {
            s1.Visible = false;
            s2.Visible = false;
            s3.Visible = true;
            s4.Visible = false;


            panelSQL.Visible = false;
            panelinv.Visible = false;
            panelStaff.Visible = true;
        }

        private void rjPictureRounded5_Click(object sender, EventArgs e)
        {
            s1.Visible = false;
            s2.Visible = false;
            s3.Visible = false;
            s4.Visible = true;
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
