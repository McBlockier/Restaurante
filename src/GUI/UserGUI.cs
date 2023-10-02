using CustomMessageBox;
using Palacio_el_restaurante.src.Conection;
using Palacio_el_restaurante.src.Controls;
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
            FillComboBox(rjRank, new string[] { "Administrador", "Repartidor", "Usuario" });
            FillComboBox(rjOperation, new string[] { "Update", "Delete", "Add Up" });
        }

        private void FillComboBox(RJComboBox comboBox, string[] items)
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(items);
        }

        private void rjOperation_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            getUsername.Enabled = true;
            getName.Enabled = true;
            getPhoneNumber.Enabled = true;
            getPassword.Enabled = true;
            getLastNameP.Enabled = true;
            getLastNameM.Enabled = true;
            getStreet1.Enabled = true;
            getStreet2.Enabled = true;
            getLocation.Enabled = true;
            rjRank.Enabled = true;

            rjUpdate.Visible = false;
            rjDelete.Visible = false;
            rjAddUp.Visible = false;

            switch (rjOperation.SelectedItem as string)
            {
                case "Update":
                    rjUpdate.Visible = true;
                    break;
                case "Delete":
                    rjDelete.Visible = true;
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
                    rjAddUp.Visible = true;
                    break;
            }
        }


        private void rjPictureRounded4_Click(object sender, EventArgs e)
        {
            AdminIU admin = new AdminIU();
            admin.sqlStaff();
            this.Hide();
        }
        private bool ValidateInput()
        {
            return !string.IsNullOrEmpty(getUsername.Texts)
                && !string.IsNullOrEmpty(getPassword.Texts)
                && !string.IsNullOrEmpty(getLastNameP.Texts)
                && !string.IsNullOrEmpty(getLastNameM.Texts)
                && !string.IsNullOrEmpty(getStreet1.Texts)
                && !string.IsNullOrEmpty(getStreet2.Texts)
                && !string.IsNullOrEmpty(getLocation.Texts)
                && !string.IsNullOrEmpty(getPhoneNumber.Texts)
                && !string.IsNullOrEmpty(rjRank.SelectedItem as string)
                && !string.IsNullOrEmpty(getName.Texts);
        }

        private void rjAddUp_Click(object sender, EventArgs e)
        {
            DialogResult result = RJMessageBox.Show("Are you sure to do this operation?",
                "QUESTION!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            if (ValidateInput())
            {
                Persona persona = new Persona
                {
                    IdUser = getUsername.Texts,
                    Name = getName.Texts,
                    LastNameP = getLastNameP.Texts,
                    LastNameM = getLastNameM.Texts,
                    Password = getPassword.Texts,
                    PhoneNumber = getPhoneNumber.Texts,
                    PrimaryStreet = getStreet1.Texts,
                    SecondaryStreet = getStreet2.Texts,
                    Settlement_type1 = getLocation.Texts
                };

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
        private int GetRankValue()
        {
            switch (rjRank.SelectedItem as String)
            {
                case "Administrador":
                    return 1;
                case "Usuario":
                    return 2;
                case "Repartidor":
                    return 3;
                default:
                    return 2;
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
                    persona.IdUser = getUsername.Texts;
                    persona.FieldsToUpdate["Name"] = !string.IsNullOrEmpty(getName.Texts);
                    persona.FieldsToUpdate["LastNameP"] = !string.IsNullOrEmpty(getLastNameP.Texts);
                    persona.FieldsToUpdate["LastNameM"] = !string.IsNullOrEmpty(getLastNameM.Texts);
                    persona.FieldsToUpdate["Password"] = !string.IsNullOrEmpty(getPassword.Texts);
                    persona.FieldsToUpdate["PhoneNumber"] = !string.IsNullOrEmpty(getPhoneNumber.Texts);
                    persona.FieldsToUpdate["PrimaryStreet"] = !string.IsNullOrEmpty(getStreet1.Texts);
                    persona.FieldsToUpdate["SecondaryStreet"] = !string.IsNullOrEmpty(getStreet2.Texts);
                    persona.FieldsToUpdate["Settlement_type1"] = !string.IsNullOrEmpty(getLocation.Texts);
                    persona.FieldsToUpdate["Rank"] = rjRank.SelectedItem != null;

                    foreach (var fieldToUpdate in persona.FieldsToUpdate)
                    {
                        if (fieldToUpdate.Value)
                        {
                            switch (fieldToUpdate.Key)
                            {
                                case "Name":
                                    persona.Name = getName.Texts;
                                    break;
                                case "LastNameP":
                                    persona.LastNameP = getLastNameP.Texts;
                                    break;
                                case "LastNameM":
                                    persona.LastNameM = getLastNameM.Texts;
                                    break;
                                case "Password":
                                    persona.Password = getPassword.Texts;
                                    break;
                                case "PhoneNumber":
                                    persona.PhoneNumber = getPhoneNumber.Texts;
                                    break;
                                case "PrimaryStreet":
                                    persona.PrimaryStreet = getStreet1.Texts;
                                    break;
                                case "SecondaryStreet":
                                    persona.SecondaryStreet = getStreet2.Texts;
                                    break;
                                case "Settlement_type1":
                                    persona.Settlement_type1 = getLocation.Texts;
                                    break;
                                case "Rank":
                                    persona.Rank = GetRankValue();
                                    break;
                            }
                        }
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
            if (check.Checked && getUsername.Texts.Length == 10)
            {
                try
                {
                    InquiriesDB DB = new InquiriesDB();
                    string[] userInfo = DB.searchInfoUser(getUsername.Texts);

                    if (userInfo.Length == 9)
                    {
                        getName.Texts = userInfo[0];
                        getLastNameP.Texts = userInfo[1];
                        getLastNameM.Texts = userInfo[2];
                        getPassword.Texts = userInfo[3];

                        switch (userInfo[4])
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

                        getStreet1.Texts = userInfo[5];
                        getStreet2.Texts = userInfo[6];
                        getLocation.Texts = userInfo[7];
                        getPhoneNumber.Texts = userInfo[8];
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void check_CheckedChanged(object sender, EventArgs e)
        {
            if (!check.Checked)
            {
                getUsername.Texts = string.Empty;
                getName.Texts = string.Empty;
                getLastNameP.Texts = string.Empty;
                getLastNameM.Texts = string.Empty;
                getPassword.Texts = string.Empty;
                rjRank.Texts = string.Empty;
                getStreet1.Texts = string.Empty;
                getStreet2.Texts = string.Empty;
                getLocation.Texts = string.Empty;
                getPhoneNumber.Texts = string.Empty;
                fillBoxes();
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
