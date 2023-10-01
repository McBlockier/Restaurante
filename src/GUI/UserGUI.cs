﻿using CustomMessageBox;
using Palacio_el_restaurante.src.Conection;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Palacio_el_restaurante.src.GUI
{
    public partial class UserGUI : Form
    {
        public int xClick = 0, yClick = 0;
        private String[] infoUsername = new String[11];
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
            switch (rjOperation.SelectedItem as String)
            {
                case "Update":
                    rjUpdate.Visible = true;
                    rjDelete.Visible = false;
                    rjAddUp.Visible = false;

                    getUsername.Enabled = true;
                    getName.Enabled = true;
                    getPhoneNumber.Enabled = true;
                    getPassword.Enabled = true;
                    getLastNameP.Enabled = true;
                    getLastNameM.Enabled = true;
                    getStreet1.Enabled = true;
                    getStreet2.Enabled = true;
                    getLocation.Enabled = true;
                    break;
                case "Delete":
                    rjUpdate.Visible = false;
                    rjDelete.Visible = true;
                    rjAddUp.Visible = false;


                    getUsername.Enabled = true;
                    getName.Enabled = false;
                    getPhoneNumber.Enabled = false;
                    getPassword.Enabled = false;
                    getLastNameP.Enabled = false;
                    getLastNameM.Enabled = false;
                    getStreet1.Enabled = false;
                    getStreet2.Enabled = false;
                    getLocation.Enabled = false;
                    rjRank.Enabled = false;

                    break;
                case "Add Up":
                    rjUpdate.Visible = false;
                    rjDelete.Visible = false;
                    rjAddUp.Visible = true;


                    getUsername.Enabled = true;
                    getName.Enabled = true;
                    getPhoneNumber.Enabled = true;
                    getPassword.Enabled = true;
                    getLastNameP.Enabled = true;
                    getLastNameM.Enabled = true;
                    getStreet1.Enabled = true;
                    getStreet2.Enabled = true;
                    getLocation.Enabled = true;
                    break;
            }
        }

        private void rjPictureRounded4_Click(object sender, EventArgs e)
        {
            AdminIU admin = new AdminIU();
            admin.sqlStaff();
            this.Hide();
        }

        private void rjAddUp_Click(object sender, EventArgs e)
        {
            DialogResult result = RJMessageBox.Show("Are you sure to do this operation?",
                    "QUESTION!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.Yes))
            {
                Persona persona = new Persona();
                if (!String.IsNullOrEmpty(getUsername.Texts) && !String.IsNullOrEmpty(getPassword.Texts) &&
                    !String.IsNullOrEmpty(getLastNameP.Texts) && !String.IsNullOrEmpty(getLastNameM.Texts) &&
                    !String.IsNullOrEmpty(getStreet1.Texts) && !String.IsNullOrEmpty(getStreet2.Texts) &&
                    !String.IsNullOrEmpty(getLocation.Texts) && !String.IsNullOrEmpty(getPhoneNumber.Texts) &&
                    !String.IsNullOrEmpty(rjRank.SelectedItem as String) && !String.IsNullOrEmpty(getName.Texts))
                {
                    persona.IdUser = getUsername.Texts;
                    persona.Name = getName.Texts;
                    persona.LastNameP = getLastNameP.Texts;
                    persona.LastNameM = getLastNameM.Texts;
                    persona.Password = getPassword.Texts;
                    persona.PhoneNumber = getPhoneNumber.Texts;
                    persona.PrimaryStreet = getStreet1.Texts;
                    persona.SecondaryStreet = getStreet2.Texts;
                    persona.Settlement_type1 = getLocation.Texts;
                    switch (rjRank.SelectedItem as String)
                    {
                        case "Administrador":
                            persona.Rank = 1;
                            break;
                        case "Usuario":
                            persona.Rank = 2;
                            break;
                        case "Repartidor":
                            persona.Rank = 3;
                            break;
                        default:
                            persona.Rank = 2;
                            break;
                    }
                    InquiriesDB DB = new InquiriesDB();
                    if (DB.registerUser(persona))
                    {
                        RJMessageBox.Show("Registered user successfully",
                        "INFORMATION!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearFields();
                    }
                    else
                    {
                        RJMessageBox.Show("User registration could not be done",
                        "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    RJMessageBox.Show("There can be no blank spaces",
                        "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void clearFields()
        {
            getUsername.Texts = String.Empty;
            getName.Texts = String.Empty;
            getPhoneNumber.Texts = String.Empty;
            getPassword.Texts = String.Empty;
            getLastNameP.Texts = String.Empty;
            getLastNameM.Texts = String.Empty;
            getStreet1.Texts = String.Empty;
            getStreet2.Texts = String.Empty;
            getLocation.Texts = String.Empty;
        }

        private void rjDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = RJMessageBox.Show("Are you sure to delete the user?",
                       "QUESTION!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.Yes))
            {
                Persona persona = new Persona();
                persona.IdUser = getUsername.Texts;
                InquiriesDB DB = new InquiriesDB();
                if (DB.deleteUser(persona))
                {
                    RJMessageBox.Show("The user was successfully removed",
                           "INFORMATION!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearFields();
                }
                else
                {
                    RJMessageBox.Show("The user wasn't successfully removed",
                           "INFORMATION!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void rjUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = RJMessageBox.Show("Are you sure to update the user?",
                                   "QUESTION!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.Yes))
            {
                try
                {
                    Persona persona = new Persona();
                    InquiriesDB DB = new InquiriesDB();
                    if (!String.IsNullOrEmpty(getUsername.Texts) && !String.IsNullOrEmpty(getPassword.Texts) &&
                        !String.IsNullOrEmpty(getLastNameP.Texts) && !String.IsNullOrEmpty(getLastNameM.Texts) &&
                        !String.IsNullOrEmpty(getStreet1.Texts) && !String.IsNullOrEmpty(getStreet2.Texts) &&
                        !String.IsNullOrEmpty(getLocation.Texts) && !String.IsNullOrEmpty(getPhoneNumber.Texts) &&
                        !String.IsNullOrEmpty(rjRank.SelectedItem as String) && !String.IsNullOrEmpty(getName.Texts))
                    {
                        persona.IdUser = getUsername.Texts;
                        persona.Name = getName.Texts;
                        persona.LastNameP = getLastNameP.Texts;
                        persona.LastNameM = getLastNameM.Texts;
                        persona.Password = getPassword.Texts;
                        persona.PhoneNumber = getPhoneNumber.Texts;
                        persona.PrimaryStreet = getStreet1.Texts;
                        persona.SecondaryStreet = getStreet2.Texts;
                        persona.Settlement_type1 = getLocation.Texts;
                        switch (rjRank.SelectedItem as String)
                        {
                            case "Administrador":
                                persona.Rank = 1;
                                break;
                            case "Usuario":
                                persona.Rank = 2;
                                break;
                            case "Repartidor":
                                persona.Rank = 3;
                                break;
                            default:
                                persona.Rank = 2;
                                break;
                        }
                        if (DB.updateUser(persona))
                        {
                            RJMessageBox.Show("The user was successfully updated",
                                       "INFORMATION!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearFields();
                        }
                        else
                        {
                            RJMessageBox.Show("The user wasn't successfully updated",
                                       "INFORMATION!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(getUsername.Texts))
                        {
                            if (!String.IsNullOrEmpty(getUsername.Texts))
                            {
                                persona.IdUser = getUsername.Texts;
                                DB.updateUser(persona);
                            }
                            if (!String.IsNullOrEmpty(getName.Texts))
                            {
                                persona.Name = getName.Texts;
                                DB.updateUser(persona);
                            }

                            if (!String.IsNullOrEmpty(getPassword.Texts))
                            {
                                persona.Password = getPassword.Texts;
                                DB.updateUser(persona);
                            }

                            if (!String.IsNullOrEmpty(getLastNameP.Texts))
                            {
                                persona.LastNameP = getLastNameP.Texts;
                                DB.updateUser(persona);
                            }

                            if (!String.IsNullOrEmpty(getLastNameM.Texts))
                            {
                                persona.LastNameM = getLastNameM.Texts;
                                DB.updateUser(persona);
                            }

                            if (!String.IsNullOrEmpty(getStreet1.Texts))
                            {
                                persona.PrimaryStreet = getStreet1.Texts;
                                DB.updateUser(persona);
                            }
                            if (!String.IsNullOrEmpty(getStreet2.Texts))
                            {
                                persona.SecondaryStreet = getStreet2.Texts;
                                DB.updateUser(persona);
                            }

                            if (!String.IsNullOrEmpty(getLocation.Texts))
                            {
                                persona.Settlement_type1 = getLocation.Texts;
                                DB.updateUser(persona);
                            }

                            if (!String.IsNullOrEmpty(getPhoneNumber.Texts))
                            {
                                persona.PhoneNumber = getPhoneNumber.Texts;
                                DB.updateUser(persona);
                            }

                            if (!String.IsNullOrEmpty(rjRank.SelectedItem as String))
                            {
                                switch (rjRank.SelectedItem as String)
                                {
                                    case "Administrador":
                                        persona.Rank = 1;
                                        break;
                                    case "Usuario":
                                        persona.Rank = 2;
                                        break;
                                    case "Repartidor":
                                        persona.Rank = 3;
                                        break;
                                    default:
                                        persona.Rank = 2;
                                        break;
                                }
                                DB.updateUser(persona);
                            }
                        }
                        else
                        {
                            RJMessageBox.Show("You must enter the recipient user to update",
                                      "INFORMATION!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                     System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }

        private void getPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (getPhoneNumber.Texts.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void getUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (check.Checked)
            {
                if (getUsername.Texts.Length == 10)
                {
                    InquiriesDB DB = new InquiriesDB();
                    try
                    {
                        getName.Texts = DB.searchInfoUser(getUsername.Texts)[0];
                        getLastNameP.Texts = DB.searchInfoUser(getUsername.Texts)[1];
                        getLastNameM.Texts = DB.searchInfoUser(getUsername.Texts)[2];
                        getPassword.Texts = DB.searchInfoUser(getUsername.Texts)[3];
                        switch (DB.searchInfoUser(getUsername.Texts)[4])
                        {
                            case "1":
                                rjRank.Texts = "Administrador";
                                break;
                            case "2":
                                rjRank.Texts = "Usuario";
                                break;
                            case "3":
                                rjRank.Texts = "Repartidor";
                                break;
                        }
                        getStreet1.Texts = DB.searchInfoUser(getUsername.Texts)[5];
                        getStreet2.Texts = DB.searchInfoUser(getUsername.Texts)[6];
                        getLocation.Texts = DB.searchInfoUser(getUsername.Texts)[7];
                        getPhoneNumber.Texts = DB.searchInfoUser(getUsername.Texts)[8];


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

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
