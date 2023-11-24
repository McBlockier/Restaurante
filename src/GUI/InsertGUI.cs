using CustomMessageBox;
using MySql.Data.MySqlClient;
using Palacio_el_restaurante.src.Conection;
using Palacio_el_restaurante.src.Controls;
using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading;
using System.Web.Services.Protocols;
using System.Windows.Forms;

namespace Palacio_el_restaurante.src.GUI
{
    public partial class InsertGUI : Form
    {
        public int xClick = 0, yClick = 0;
        public event Action ProductInserted;
        public event Action ProductRemoved;
        public event Action ProductChanged;

        private String itemSeleccionado = "";
        public string ValorDeCelda0 { get; set; }
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
        public void fillBoxSpecial()
        {
            FillComboBox(rjOperation, new string[] { "Update", "Add Up" });
            FillComboBox(rjType, new string[] { "Café", "Té", "Jugo", "Platillo fuerte", "Comida marina" });
            rjDelete.Visible = false;
        }
        private void rjInsert_Click(object sender, EventArgs e)
        {
            InquiriesDB DB = new InquiriesDB();
            DialogResult result = RJMessageBox.Show("Be sure to do this operation, the changes cannot be reversed?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.Yes))
            {
                if (String.IsNullOrEmpty(DB.GetClurp().ToString()) && String.IsNullOrEmpty(itemSeleccionado)
                    && String.IsNullOrEmpty(getName.Texts) && String.IsNullOrEmpty(getPrice.Texts)
                    && String.IsNullOrEmpty(getDescription.Texts))
                {
                    RJMessageBox.Show("You cannot leave empty fields or you must select the operation to be performed.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Product producto = new Product();
                    producto.Clurp = int.Parse(DB.GetClurp().ToString());
                    producto.Name = getName.Texts;
                    producto.Description = getDescription.Texts;
                    producto.Price = float.Parse(getPrice.Texts);
                    producto.Type = rjType.SelectedItem as String;

                    if (DB.addProduct(producto))
                    {
                        RJMessageBox.Show("Consumable added correctly", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearFiels();
                        ProductInserted?.Invoke();                      
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
        private async void rjUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = RJMessageBox.Show("Be sure to do this operation, the changes cannot be reversed?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result.Equals(DialogResult.Yes))
                {
                    InquiriesDB DB = new InquiriesDB();

                    if (String.IsNullOrEmpty(ValorDeCelda0))
                    {
                        RJMessageBox.Show("You must enter a valid CLURP or one that exists in the database", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {


                        LookingFor looking = new LookingFor();
                        // Obtener el clurp del consumible
                        string clurp = await looking.BuscarClurpConsumible(getName.Texts, getDescription.Texts, float.Parse(getPrice.Texts));

                        Product producto = new Product();
                        producto.Clurp = int.Parse(ValorDeCelda0);

                        // Asignar null a los campos que no se desean actualizar
                        producto.Name = String.IsNullOrEmpty(getName.Texts) ? null : getName.Texts;
                        producto.Description = String.IsNullOrEmpty(getDescription.Texts) ? null : getDescription.Texts;
                        producto.Type = String.IsNullOrEmpty(rjType.SelectedItem as String) ? null : rjType.SelectedItem as String;

                        float precio;                      
                        if (float.TryParse(getPrice.Texts, out precio))
                        {
                            producto.Price = precio;
                        }
                        else
                        {
                            producto.Price = DB.getPriceProduct(ValorDeCelda0);
                        }

                        if (DB.updateProduct(producto))
                        {
                            RJMessageBox.Show("The consumable was successfully updated", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearFiels();
                            ProductChanged?.Invoke();
                        }
                        else
                        {
                            RJMessageBox.Show("The consumable was not updated correctly", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    
                    }
                }
                 }catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                RJMessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Borrar
        private void rjDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = RJMessageBox.Show("Be sure to do this operation, the changes cannot be reversed?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                InquiriesDB DB = new InquiriesDB();
                if (DB.deleteProduct(ValorDeCelda0))
                {
                    RJMessageBox.Show("It was successfully removed", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearFiels();
                    ProductRemoved?.Invoke();
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
            FillComboBox(rjType, new string[] { "Café","Té","Jugo", "Platillo fuerte", "Comida marina" });
        }

        private void rjPictureRounded6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void FillComboBox(RJComboBox comboBox, string[] items)
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(items);
        }
    }
}
