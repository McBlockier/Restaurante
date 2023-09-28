using CustomMessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palacio_el_restaurante.src.UI
{
    public partial class LoginCreateA : Form
    {
        public int xClick = 0, yClick = 0;
        private String hotel = "Hotel_Button";
        private String villa = "Villa_Button";
        private String valueLocation = "";

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

        private void LoginCreateA_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        public LoginCreateA()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            panelData.Hide();
            pictureAcces.Hide();
            pictureLocation.Hide(); 
            logo.BackColor = Color.FromArgb(3, 47, 186);
            pictureLogo.BackColor = Color.FromArgb(3, 47, 186);
            
        }

        private void rjHotel_MouseHover(object sender, EventArgs e)
        {
            hover_Effect(hotel);
        }


        private void hover_Effect(String typeButton)
        {
            Color hover = Color.FromArgb(156, 215, 214);
            switch(typeButton)
            {
                case "Hotel_Button":
                    this.pictureHotel.BackColor = hover;
                    this.lb_Hotel.BackColor = hover;
                    break;
                case "Villa_Button":
                    this.pictureVilla.BackColor = hover;
                    this.lb_Villa.BackColor = hover;
                    break;
            }
        }
       

        private void rjHotel_MouseLeave(object sender, EventArgs e)
        {
            hover_Effect_Left(hotel);
        }

        private void rjVilla_MouseHover(object sender, EventArgs e)
        {
            hover_Effect(villa);
        }

        private void rjVilla_MouseLeave(object sender, EventArgs e)
        {
            hover_Effect_Left(villa);
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(rjStreet1.Texts) && String.IsNullOrEmpty(rjStreet2.Texts))
            {
                RJMessageBox.Show("Both streets must enter", "Warning");
            }
            else
            {
                if (String.IsNullOrEmpty(valueLocation))
                {
                    RJMessageBox.Show("Select your residence", "Warnign");
                }
                else
                {
                    if (String.IsNullOrEmpty(rjAreaCity.Texts))
                    {
                        RJMessageBox.Show("You need to enter your area or city", "Warnign");
                    }
                    else
                    {
                        pictureLocation.Hide();
                        panelData.Show();
                    }
                }
                
            }
        }

        private void rjHotel_Click(object sender, EventArgs e)
        {
            valueLocation = "Hotel";
        }

        private void rjVilla_Click(object sender, EventArgs e)
        {
            valueLocation = "Casa propia";
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(rjName.Texts))
            {
                RJMessageBox.Show("Must at least have a  name", "Warning");
            }
            else
            {
                if (String.IsNullOrEmpty(lastNameP.Texts))
                {
                    RJMessageBox.Show("Must at least have a last name", "Warning");
                }
                else
                {
                    if (String.IsNullOrEmpty(tel.Texts))
                    {
                        RJMessageBox.Show("Must at least have a phone number", "Warning");
                    }
                    else
                    {
                        if(String.IsNullOrEmpty(username.Texts) && String.IsNullOrEmpty(password.Texts))
                        {
                            RJMessageBox.Show("The username and password spaces must not be empty", "Warning");
                        }
                        else
                        {

                            DialogResult result = RJMessageBox.Show("¿Esta seguro(a) de crear el usuario?", "Pregunta", MessageBoxButtons.YesNo);
                            if(result == DialogResult.Yes)
                            {
                                //Aqui va la logica para registrar el usuario
                                rjButton1.Hide();
                                pictureAcces.Show();
                            }                           
                        }
                    }
                }
            }
        }

        private void rjAreaCity_MouseLeave(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            pictureLocation.Enabled = false;
        }

        private void rjAreaCity_MouseEnter(object sender, EventArgs e)
        {

        }

        private void rjAreaCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rjAreaCity.Texts.Length > 3)
            {
                pictureLocation.Show();
                pictureLocation.Enabled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginFrame loginFrame = new LoginFrame();
            loginFrame.Show();
        }

        private void hover_Effect_Left(String typeButton)
        {
            Color hoverLeft = Color.FromArgb(174, 238, 239);
            switch(typeButton)
            {
                case "Hotel_Button":
                    this.pictureHotel.BackColor = hoverLeft;
                    this.lb_Hotel.BackColor = hoverLeft;
                    break;
                case "Villa_Button":
                    this.pictureVilla.BackColor = hoverLeft;
                    this.lb_Villa.BackColor = hoverLeft;
                    break;
            }
        }

    }
}
