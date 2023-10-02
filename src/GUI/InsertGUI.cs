using CustomMessageBox;
using Palacio_el_restaurante.src.Conection;
using Palacio_el_restaurante.src.Controls;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Palacio_el_restaurante.src.GUI
{
    public partial class InsertGUI : Form
    {
        public int xClick = 0, yClick = 0;
        private String itemSeleccionado = "";
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

        private void rjPictureRounded4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        public InsertGUI()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            fillBox();
        }
        private void rjInsert_Click(object sender, EventArgs e)
        {
            DialogResult result = RJMessageBox.Show("Be sure to do this operation, the changes cannot be reversed?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.Yes))
            {
                if (String.IsNullOrEmpty(getClurp.Texts) && String.IsNullOrEmpty(itemSeleccionado)
                    && String.IsNullOrEmpty(getName.Texts) && String.IsNullOrEmpty(getPrice.Texts)
                    && String.IsNullOrEmpty(getDescription.Texts))
                {
                    RJMessageBox.Show("You cannot leave empty fields or you must select the operation to be performed.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Product producto = new Product();
                    InquiriesDB DB = new InquiriesDB();
                    producto.Clurp = int.Parse(getClurp.Texts);
                    producto.Name = getName.Texts;
                    producto.Description = getDescription.Texts;
                    producto.Price = float.Parse(getPrice.Texts);
                    producto.Type = rjType.SelectedItem as String;

                    if (DB.addProduct(producto))
                    {
                        RJMessageBox.Show("Consumable added correctly", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearFiels();
                    }
                    else
                    {
                        RJMessageBox.Show("Consumable was not added correctly", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        clearFiels();
                    }
                }
            }
        }
        private void clearFiels()
        {
            getName.Texts = String.Empty;
            getPrice.Texts = String.Empty;
            getDescription.Texts = String.Empty;
            getClurp.Texts = String.Empty;
        }

        private void getClurp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            else if (getClurp.Texts.Length >= 3 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            if (check.Checked && getClurp.Texts.Length >= 3)
            {
                try
                {
                    InquiriesDB DB = new InquiriesDB();
                    Product producto = new Product();

                    if (DB.existProduct(int.Parse(getClurp.Texts)))
                    {
                        producto.Clurp = int.Parse(getClurp.Texts);
                        getName.Texts = DB.infoProduct(getClurp.Texts)[0];
                        switch (DB.infoProduct(getClurp.Texts)[1])
                        {
                            case "Bebida":
                                rjType.Texts = "Bebida";
                                break;
                            case "Platillo fuerte":
                                rjType.Texts = "Platillo fuerte";
                                break;
                            case "Platillo Fuerte":
                                rjType.Texts = "Platillo fuerte";
                                break;
                            case "Postre":
                                rjType.Texts = "Postre";
                                break;
                            case "Entrada":
                                rjType.Texts = "Entrada";
                                break;
                        }

                        getPrice.Texts = DB.infoProduct(getClurp.Texts)[2];
                        getDescription.Texts = DB.infoProduct(getClurp.Texts)[3];
                    }
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                  System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }

        private void rjOperation_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            itemSeleccionado = rjOperation.SelectedItem as String;
            switch (itemSeleccionado)
            {
                case "Update":
                    rjInsert.Visible = false;
                    rjDelete.Visible = false;
                    rjUpdate.Visible = true;
                    getName.Enabled = true;
                    getPrice.Enabled = true;
                    break;
                case "Delete":
                    rjInsert.Visible = false;
                    rjDelete.Visible = true;
                    rjUpdate.Visible = false;
                    getName.Enabled = false;
                    getPrice.Enabled = false;
                    getDescription.Enabled = false;
                    break;
                case "Add Up":
                    rjInsert.Visible = true;
                    rjDelete.Visible = false;
                    rjUpdate.Visible = false;
                    break;
            }
        }
        //Actualizar
        private void rjUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = RJMessageBox.Show("Be sure to do this operation, the changes cannot be reversed?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.Yes))
            {
                InquiriesDB DB = new InquiriesDB();
                if (String.IsNullOrEmpty(getClurp.Texts))
                {
                    RJMessageBox.Show("You must enter a valid CLURP or one that exists in the database", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (DB.existProduct(int.Parse(getClurp.Texts)))
                    {
                        if (!String.IsNullOrEmpty(getName.Texts) && !String.IsNullOrEmpty(getClurp.Texts)
                       && !String.IsNullOrEmpty(getDescription.Texts) && !String.IsNullOrEmpty(getPrice.Texts)
                       && !String.IsNullOrEmpty(rjType.SelectedItem as String))
                        {
                            RJMessageBox.Show("The CLURP cannot be updated, it is unique and cannot be modified.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Product producto = new Product();
                            producto.Clurp = int.Parse(getClurp.Texts);
                            producto.Name = getName.Texts;
                            producto.Description = getDescription.Texts;
                            producto.Price = float.Parse(getPrice.Texts);
                            producto.Type = rjType.SelectedItem as String;
                            if (DB.updateProduct(producto))
                            {
                                RJMessageBox.Show("The consumable was successfully updated", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearFiels();
                                AdminIU admin = new AdminIU();
                                admin.sql();
                            }
                            else
                            {
                                RJMessageBox.Show("The consumable was not updated correctly", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(getClurp.Texts) && DB.existProduct(int.Parse(getClurp.Texts)))
                            {
                                Product producto = new Product();
                                producto.Clurp = int.Parse(getClurp.Texts);
                                if (!String.IsNullOrEmpty(getName.Texts))
                                {
                                    producto.Name = getName.Texts;
                                }
                                if (!String.IsNullOrEmpty(getPrice.Texts))
                                {
                                    producto.Price = float.Parse(getPrice.Texts);
                                }
                                if (!String.IsNullOrEmpty(getDescription.Texts))
                                {
                                    producto.Description = getDescription.Texts;
                                }
                                if (!String.IsNullOrEmpty(rjType.SelectedItem as String))
                                {
                                    producto.Type = rjType.SelectedItem as String;
                                }
                                if (DB.updateProduct(producto))
                                {
                                    RJMessageBox.Show("The consumable was successfully updated", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    clearFiels();
                                    AdminIU admin = new AdminIU();
                                    admin.sql();
                                }
                                else
                                {
                                    RJMessageBox.Show("The consumable wasn't successfully updated", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    clearFiels();
                                }
                            }
                            else
                            {
                                RJMessageBox.Show("You must enter a valid CLURP or one that exists in the database", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        RJMessageBox.Show("CLURP not that exists in the database", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        //Borrar
        private void rjDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = RJMessageBox.Show("Be sure to do this operation, the changes cannot be reversed?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                InquiriesDB DB = new InquiriesDB();
                if (DB.deleteProduct(getClurp.Texts))
                {
                    RJMessageBox.Show("It was successfully removed", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearFiels();
                }
                else
                {
                    RJMessageBox.Show("Could not remove product", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void fillBox()
        {
            FillComboBox(rjOperation, new string[] { "Update", "Delete", "Add Up" });
            FillComboBox(rjType, new string[] { "Bebida", "Platillo fuerte", "Postre", "Entrada" });
        }

        private void rjPictureRounded6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void getClurp_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (getClurp.Texts.Length == 3 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '\r')
            {
                try
                {
                    InquiriesDB DB = new InquiriesDB();
                    String[] getInfo = new string[10];
                    int i = 0;
                    foreach (String s in DB.infoProduct(getClurp.Texts))
                    {
                        getInfo[i] = s;
                        i++;
                    }
                    getName.Texts = getInfo[0];
                    getPrice.Texts = getInfo[2];
                    getDescription.Texts = getInfo[3];
                    switch (getInfo[1])
                    {
                        case "Bebida":
                            break;
                        case "Platillo fuerte":
                            break;
                        case "Entrada":
                            break;
                    }
                }catch (Exception ex)
                {
                    RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                  System.Windows.Forms.MessageBoxIcon.Error);
                }
            }           
        }

        private void FillComboBox(RJComboBox comboBox, string[] items)
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(items);
        }

    }
}
