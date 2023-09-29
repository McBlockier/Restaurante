using CustomMessageBox;
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

namespace Palacio_el_restaurante.src.UI
{
    public partial class LoginReset : Form
    {
        public int xClick = 0, yClick = 0;
        private int ss = 0;
        private String UserName = "";

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
        public LoginReset()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            smsP.Visible = false;
            passwordLoad.Visible = false;
            button_reset.Enabled = false;
            getPassword.TextChanged += TextBox_TextChanged;;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginFrame loginFrame = new LoginFrame();
            loginFrame.Show();
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (getPassword.Texts.Length >= 8)
            {
                button_reset.Enabled = true;
            }
            else
            {
                button_reset.Enabled = false;
            }
        }

        private void button_reset_MouseHover(object sender, EventArgs e)
        {
            if (getPassword.Texts.Length > 0 & getPassowrdC.Texts.Length > 0)
            {
                if(getPassword.Texts.Length == getPassowrdC.Texts.Length)
                {
                    smsP.Visible = false;
                }
                else
                {
                    smsP.Visible =true;
                    smsP.Text = "Passwords must match!";
                }
            }         
        }
        public  void getUserName(String userName)
        {
           UserName = userName;
        }
        //Button for reset passwords
        private void button_reset_Click(object sender, EventArgs e)
        {
           DialogResult  result = RJMessageBox.Show("¿Esta seguro de ingresar la nueva contraseña?", "Pregunta", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //Aqui va la logica para reiniciar la contraseña
                InquiriesDB DB = new InquiriesDB();
                Persona persona = new Persona();
                if(getPassword.Texts.Length > 7 && getPassowrdC.Texts.Length > 7)
                {
                    if (getPassword.Texts.Equals(getPassowrdC.Texts))
                    {
                        persona.Password = getPassword.Texts;
                        persona.IdUser = UserName;
                        if (DB.resetPassword(persona))
                        {
                            passwordLoad.Visible = true;
                            timer1.Start();
                        }
                        else
                        {
                            RJMessageBox.Show("The password could not be changed", "INFORMATION!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        RJMessageBox.Show("Passwords don't match", "INFORMATION!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    RJMessageBox.Show("There are empty spaces", "INFORMATION!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ss += 1;
            if (ss == 23)
            {
                resetTimer();
                timer1.Stop();
                LoginFrame login = new LoginFrame();
                login.Show();
                this.Hide();
            }
        }
        private void resetTimer()
        {
            ss = 0;
            timer1.Stop();
        }

        private void getPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (getPassword.Texts.Length >= 7)
            {
                button_reset.Enabled = true;
            }
            else
            {
                button_reset.Enabled = false;
            }
        }

        //End

        private void LoginReset_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }
    }
}
