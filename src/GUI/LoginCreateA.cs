using CustomMessageBox;
using Palacio_el_restaurante.src.Conection;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Palacio_el_restaurante.src.UI
{
    public partial class LoginCreateA : Form
    {
        public int xClick = 0, yClick = 0;
        private int ss = 0;
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
            switch (typeButton)
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
            if (String.IsNullOrEmpty(rjStreet1.Texts) && String.IsNullOrEmpty(rjStreet2.Texts))
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
                        if (String.IsNullOrEmpty(username.Texts) && String.IsNullOrEmpty(password.Texts))
                        {
                            RJMessageBox.Show("The username and password spaces must not be empty", "Warning");
                        }
                        else
                        {

                            DialogResult result = RJMessageBox.Show("¿Esta seguro(a) de crear el usuario?", "Pregunta", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                InquiriesDB DB = new InquiriesDB();
                                Persona persona = new Persona();
                                persona.IdUser = username.Texts;
                                persona.Password = password.Texts;
                                persona.Name = rjName.Texts;
                                persona.LastNameP = lastNameP.Texts;
                                persona.LastNameM = lastNameM.Texts;
                                persona.PhoneNumber = tel.Texts;
                                persona.Settlement_type1 = valueLocation;
                                persona.PrimaryStreet = rjStreet1.Texts;
                                persona.SecondaryStreet = rjStreet2.Texts;
                                if (DB.registerUser(persona))
                                {
                                    rjButton1.Hide();
                                    pictureAcces.Show();
                                    timer1.Start();
                                }
                                else
                                {
                                    RJMessageBox.Show("Something went wrong during registration", "INFORMATION!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
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

        private void tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (tel.Texts.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void hover_Effect_Left(String typeButton)
        {
            Color hoverLeft = Color.FromArgb(174, 238, 239);
            switch (typeButton)
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
