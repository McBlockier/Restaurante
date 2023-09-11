using CustomMessageBox;
using Palacio_el_restaurante.src.Conection;
using Palacio_el_restaurante.src.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palacio_el_restaurante
{  
    public partial class LoginFrame : Form
    {
        public int xClick = 0, yClick = 0;
        private InquiriesDB request = new InquiriesDB();

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
        public LoginFrame()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            panelL.Hide();
            loadPicture.Hide();
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }
        private void ShowMessageError(String errorType)
        {
            switch (errorType)
            {
                case "password":
                    RJMessageBox.Show("");
                    break;
                case "username":
                    break;
                case "empty fields":
                    break;
                default:
                    break;
            }
           
        }
        private void button_login_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(getUsername.Texts) || String.IsNullOrEmpty(getPassword.Texts))
            {
                RJMessageBox.Show("The username or password is empty or incorrect",
                    "WARNING2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
            }
            else {
                /*
                panelL.Show();
                resetPassword.Hide();
                create.Hide();
                createP.Hide();
                button_login.Hide();
                loadPicture.Show();
                
                this.Hide();
                FoodUI foodGUI = new FoodUI();
                foodGUI.Show();   
                */
            }
        }
        private void resetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (String.IsNullOrEmpty(getUsername.Texts))
            {
                RJMessageBox.Show("The recipient user must enter first, " +
                    "you cannot leave that space blank",
                   "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.Hide();
                LoginReset loginReset = new LoginReset();
                loginReset.Show();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginCreateA create = new LoginCreateA();
            create.Show();
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }   
    }
}