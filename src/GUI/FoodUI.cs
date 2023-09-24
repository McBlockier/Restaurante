using CustomMessageBox;
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
        private int countA, countS, countI;

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
            LoginFrame login = new LoginFrame();
            login.Show();
            this.Hide();
        }

        private void pictureLogOut_Click(object sender, EventArgs e)
        {
            LoginFrame login = new LoginFrame();
            login.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void FoodUI_MouseMove(object sender, MouseEventArgs e)
        {
            motionFrame(sender, e);
        }

       

        private void clickMore(String type)
        {
            switch (type)
            {
                case "Amount":
                    switch (countA)
                    {
                        case 0:
                            showCount1.Image = Properties.Resources.cero;
                            break;
                        case 1:
                            showCount1.Image = Properties.Resources.uno;
                            break;
                        case 2:
                            showCount1.Image = Properties.Resources.dos;
                            break;
                        case 3:
                            showCount1.Image = Properties.Resources.tres;
                            break;
                        case 4:
                            showCount1.Image = Properties.Resources.cuatro;
                            break;
                        case 5:
                            showCount1.Image = Properties.Resources.cinco;
                            break;
                        case 6:
                            showCount1.Image = Properties.Resources.seis;
                            break;
                        case 7:
                            showCount1.Image = Properties.Resources.siete;
                            break;
                        case 8:
                            showCount1.Image = Properties.Resources.ocho;
                            break;
                        case 9:
                            showCount1.Image = Properties.Resources.nueve;
                            break;
                        case 10:
                            showCount1.Image = Properties.Resources.diez;
                            break;
                        default:
                            if (countA > 9)
                            {
                                RJMessageBox.Show("You don't put more ice", "Warning!",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                countA = 10;
                            }
                            break;
                    }
                    break;
                case "Sugar":
                    switch (countS)
                    {
                        case 0:
                            showCount3.Image = Properties.Resources.cero;
                            break;
                        case 1:
                            showCount3.Image = Properties.Resources.uno;
                            break;
                        case 2:
                            showCount3.Image = Properties.Resources.dos;
                            break;
                        case 3:
                            showCount3.Image = Properties.Resources.tres;
                            break;
                        case 4:
                            showCount3.Image = Properties.Resources.cuatro;
                            break;
                        case 5:
                            showCount3.Image = Properties.Resources.cinco;
                            break;
                        case 6:
                            showCount3.Image = Properties.Resources.seis;
                            break;
                        case 7:
                            showCount3.Image = Properties.Resources.siete;
                            break;
                        case 8:
                            showCount3.Image = Properties.Resources.ocho;
                            break;
                        case 9:
                            showCount3.Image = Properties.Resources.nueve;
                            break;
                        case 10:
                            showCount3.Image = Properties.Resources.diez;
                            break;
                        default:
                            if (countS > 9)
                            {
                                RJMessageBox.Show("You don't put more ice", "Warning!",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                countS = 10;
                            }
                            break;
                    }
                    break;
                case "Ice":
                    switch (countI)
                    {
                        case 0:
                            showCount4.Image = Properties.Resources.cero;
                            break;
                        case 1:
                            showCount4.Image = Properties.Resources.uno;
                            break;
                        case 2:
                            showCount4.Image = Properties.Resources.dos;
                            break;
                        case 3:
                            showCount4.Image = Properties.Resources.tres;
                            break;
                        case 4:
                            showCount4.Image = Properties.Resources.cuatro;
                            break;
                        case 5:
                            showCount4.Image = Properties.Resources.cinco;
                            break;
                        case 6:
                            showCount4.Image = Properties.Resources.seis;
                            break;
                        case 7:
                            showCount4.Image = Properties.Resources.siete;
                            break;
                        case 8:
                            showCount4.Image = Properties.Resources.ocho;
                            break;
                        case 9:
                            showCount4.Image = Properties.Resources.nueve;
                            break;
                        case 10:
                            showCount4.Image = Properties.Resources.diez;
                            break;
                        default:
                            if(countI > 9)
                            {
                                RJMessageBox.Show("You don't put more ice", "Warning!",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                countI = 10;
                            }                          
                            break;
                    }
                    break;
            }
        }
        private void button_MoreC_Click(object sender, EventArgs e)
        {
            countA++;
            clickMore("Amount");
        }

        private void rjPictureRounded5_Click(object sender, EventArgs e)
        {
            countS++;
            clickMore("Sugar");
        }

        private void rjPictureRounded8_Click(object sender, EventArgs e)
        {
            countI++;
            clickMore("Ice");
        }

        private void button_MinusS_Click(object sender, EventArgs e)
        {
            Image imgOff = Properties.Resources.letra_l_Off;
            Image imgOn = Properties.Resources.letra_l;
            if(button_MinusS.Image != imgOn)
            {
                button_MinusS.Image = imgOn;
            }
            else
            {
                if(button_MinusS.Image != imgOff)
                {
                    button_MinusS.Image = imgOff;
                }
            }

        }

        private void button_MinusC_Click(object sender, EventArgs e)
        {
            countA--;
            clickMore("Amount");

        }
        private void rjPictureRounded4_Click(object sender, EventArgs e)
        {
            countS--;
            clickMore("Sugar");
        }
        private void rjPictureRounded7_Click(object sender, EventArgs e)
        {
            countA--;
            clickMore("Ice");
        }

    }
}