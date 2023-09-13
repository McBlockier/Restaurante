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

namespace Palacio_el_restaurante.src.UI
{
    public partial class FoodUI : Form
    {
        public int xClick = 0, yClick = 0;
        private int ss;

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
        public FoodUI()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            picture_out.Enabled = false;
            picture_setting.Enabled = false;

        }
        //Function of motion panel or frame
        private void motionFrame(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ss += 1;
            if(ss == 15)
            {
                resetTimer();
                LoginFrame login = new LoginFrame();
                login.Show();
                login.Visible = true;
                this.Hide();               
            }
        }
        private void resetTimer()
        {
            ss = 0;
            timer1.Stop();
        }
        private void picture_out_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            picture_out.Enabled = true;
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            picture_setting.Enabled = true;
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            picture_setting.Enabled = false;
        }

        private void picture_out_MouseLeave(object sender, EventArgs e)
        {
            picture_out.Enabled = false;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            picture_out.Enabled = false;
        }

        private void FoodUI_MouseMove(object sender, MouseEventArgs e)
        {
            motionFrame(sender, e);
        }

    }
}