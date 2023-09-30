﻿using CustomMessageBox;
using MySql.Data.MySqlClient;
using Palacio_el_restaurante.src.Conection;
using Palacio_el_restaurante.src.Controls;
using Palacio_el_restaurante.src.GUI;
using Palacio_el_restaurante.src.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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
        public LoginFrame()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            toolTip1.OwnerDraw = true;
            toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw);
            toolTip1.Popup += new PopupEventHandler(toolTip1_Popup);

            panelL.Hide();
            loadPicture.Hide();
            getPassword.PasswordChar = true;
            showPassword.Image = Properties.Resources.ojo_off;
            resetPassword.Visible = false;

        }
        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            string texto = e.AssociatedControl.Text; 
            Size textSize = TextRenderer.MeasureText(texto, e.AssociatedControl.Font);
            int margen = 5; 
            e.ToolTipSize = new Size(textSize.Width + margen, textSize.Height + margen);

            Point cursorPos = Cursor.Position;
            if (cursorPos.X + e.ToolTipSize.Width > Screen.PrimaryScreen.Bounds.Right)
            {
                cursorPos.X = Screen.PrimaryScreen.Bounds.Right - e.ToolTipSize.Width;
            }

            if (cursorPos.Y + e.ToolTipSize.Height > Screen.PrimaryScreen.Bounds.Bottom)
            {
                cursorPos.Y = Screen.PrimaryScreen.Bounds.Bottom - e.ToolTipSize.Height;
            }

            toolTip1.Show(texto, e.AssociatedControl, cursorPos, 3000); 
        }


        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();

            Font font = new Font("Arial", 12, FontStyle.Bold);
            Brush textColor = Brushes.White; 

            e.Graphics.DrawString(e.ToolTipText, font, textColor, e.Bounds.X + 6, e.Bounds.Y + 6);
        }
 
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }
        private void button_login_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(getUsername.Texts) || String.IsNullOrEmpty(getPassword.Texts))
            {
                RJMessageBox.Show("You can't leave empty spaces",
                    "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {   
                InquiriesDB DB = new InquiriesDB();
                if(DB.valueLogin(getUsername.Texts, getPassword.Texts))
                {
                    panelL.Show();
                    resetPassword.Hide();
                    create.Hide();
                    button_login.Hide();
                    loadPicture.Show();
                    timer1.Start();
                    
                }
                else
                {
                    RJMessageBox.Show("Username or password aren't correct, please check out it",
                    "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    resetPassword.Visible = true;
                }                                        
            }
        }
        private void resetTimer()
        {
            ss = 0;
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ss += 1;
           if(ss == 32)
            {
                InquiriesDB DB = new InquiriesDB();
                resetTimer();
                timer1.Stop();
                switch (DB.getRank(getUsername.Texts))
                {
                    case 1:
                        AdminIU admin = new AdminIU();
                        admin.Show();
                        this.Hide();
                        break;
                    case 2:
                        FoodUI food = new FoodUI();
                        food.Show();
                        this.Hide();
                        break;
                    case 3:
                        break;
                }
                
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           if(getPassword.PasswordChar != true)
            {
                showPassword.Image = Properties.Resources.ojo_off;
                getPassword.PasswordChar = true;
            }
            else
            {
                showPassword.Image = Properties.Resources.ojo_on;
                getPassword.PasswordChar = false;
            }
            
        }
        private void resetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (String.IsNullOrEmpty(getUsername.Texts))
            {
                RJMessageBox.Show("User must enter",
                   "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.Visible = false;
                LoginReset loginReset = new LoginReset();
                loginReset.Show();
                loginReset.getUserName(getUsername.Texts);
            }
        }

        private void create_Click(object sender, EventArgs e)
        {
            LoginCreateA loginA = new LoginCreateA();
            loginA.Show();
            this.Hide();
        }

        private void create_MouseHover(object sender, EventArgs e)
        {
            create.Image = Properties.Resources.agregar_usuario;
        }

        private void create_MouseLeave(object sender, EventArgs e)
        {
            create.Image = Properties.Resources.addUser;
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