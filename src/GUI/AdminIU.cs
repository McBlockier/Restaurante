using CustomMessageBox;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using Palacio_el_restaurante.src.Conection;
using Palacio_el_restaurante.src.UI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace Palacio_el_restaurante.src.GUI
{
    public partial class AdminIU : Form
    {
        public int xClick = 0, yClick = 0;
        private InsertGUI insertForm;
        private int s = 0;
        private PediProve pedi;
        private String getUserName;
        private String cacheSQL = "";
        public String getRank { get; set; }
        private Stopwatch stopwatch = new Stopwatch();
        private int count = 0, countSQL = 0, countStaff = 0;
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
        public AdminIU()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;

            s1.Visible = true;
            s2.Visible = false;
            s3.Visible = false;
            s4.Visible = false;
            rjJob.Visible = false;

            fillBoxes();
            setHeader();
            stopwatch.Start();
            InitPanel();
            SubscribeEventArgs();

            timer2.Interval = 1000;
            showBattery.Visible = false;

        }
        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            try
            {
                if (e.Mode == PowerModes.StatusChange)
                {
                    UpdateBatteryIcon();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void UpdateBatteryIcon()
        {
            try
            {
                if (SystemInformation.PowerStatus.BatteryChargeStatus == BatteryChargeStatus.Charging)
                {
                    showBattery.Image = Properties.Resources.carga;
                    int batteryPercentage = (int)(SystemInformation.PowerStatus.BatteryLifePercent * 100);
                    percent.Text = batteryPercentage.ToString() + "%";
                    showBattery.Visible = true;
                }
                else
                {
                    int batteryPercentage = (int)(SystemInformation.PowerStatus.BatteryLifePercent * 100);
                    percent.Text = batteryPercentage.ToString() + "%";
                    if(batteryPercentage >= 90)
                    {
                        showBattery.Image = Properties.Resources.bateria_llena;
                    }
                    if (batteryPercentage >= 80)
                    {
                        showBattery.Image = Properties.Resources._80_;
                    }
                    else if (batteryPercentage >= 50)
                    {
                        showBattery.Image = Properties.Resources._50_;
                    }
                    else if (batteryPercentage >= 30)
                    {
                        showBattery.Image = Properties.Resources._30_;
                    }
                    else if (batteryPercentage >= 10)
                    {
                        showBattery.Image = Properties.Resources._10_;
                    }
                    else
                    {
                        showBattery.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void SubscribeEventArgs()
        {
            insertForm = new InsertGUI();
            insertForm.ProductInserted += () =>
            {
                sql();
            };
            insertForm.ProductRemoved += () =>
            {
                sql();
            };
            insertForm.ProductChanged += () =>
            {
                sql();
            };
        }

        private void InitPanel()
        {
            panelSQL.Visible = true;
            panelStaff.Visible = false;
            panelinv.Visible = false;
        }
        private void setHeader()
        {
            timer1.Interval = 1000;
            timer1.Start();
            time.Text = DateTime.Now.ToShortTimeString();
            date.Text = DateTime.Now.ToLongDateString();
        }
        private void fillBoxes()
        {
            rjInventory.Items.Clear();
            rjInventory.Items.Add("Consumibles mas vendidos");
            rjInventory.Items.Add("Precio promedio");
            rjInventory.Items.Add("Total de ventas de consumibles");
            rjInventory.Items.Add("Consumibles que no se han vendido");
            rjInventory.Items.Add("Consumibles más caro");


            rjStaff.Items.Clear();
            rjStaff.Items.Add("Empleado del mes");
            rjStaff.Items.Add("Ganacias generadas");
            rjStaff.Items.Add("Empleados con al menos 10 ventas de un tipo específico");
            rjStaff.Items.Add("Consumibles consumidos por empleado");
            rjStaff.Items.Add("Personal masculino");
            rjStaff.Items.Add("Personal femenino");

            rjTipo.Items.Clear();
            rjTipo.Items.Add("Platillo fuerte");
            rjTipo.Items.Add("Postre");
            rjTipo.Items.Add("Bebida");
            rjTipo.Items.Add("Entrada");

        }
        public void RefreshData()
        {
            sql();
        }
        public void sql()
        {
            Connection con = new Connection();
            MySqlConnection connection = con.getConnection();
            try
            {
                rjDataInv.SetDatabaseConnection(connection);
                rjDataInv.ExecuteSqlQuery("SELECT * FROM consumible");
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        private void setVisiblePanels()
        {
            panelSQL.Visible = true;
        }

        private void leftPanel_MouseMove(object sender, MouseEventArgs e)
        {
            panel1_MouseMove(sender, e);
        }

        private void rjPictureRounded4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rjPictureRounded6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void rjPictureRounded1_Click(object sender, EventArgs e)
        {
            s1.Visible = true;
            s2.Visible = false;
            s3.Visible = false;
            s4.Visible = false;

            panelSQL.Visible = true;
            panelinv.Visible = false;
            panelStaff.Visible = false;

        }

        private void rjPictureRounded2_Click(object sender, EventArgs e)
        {
            s1.Visible = false;
            s2.Visible = true;
            s3.Visible = false;
            s4.Visible = false;

            panelSQL.Visible = false;
            panelinv.Visible = true;
            panelStaff.Visible = false;

            rjButtonSQL.Image = Properties.Resources.SQL_Off;
            rjPictureRounded2.Image = Properties.Resources.portapapeles;
            rjButtonStaff.Image = Properties.Resources.consulta;

            sql();
        }

        private void rjPictureRounded3_Click(object sender, EventArgs e)
        {
            s1.Visible = false;
            s2.Visible = false;
            s3.Visible = true;
            s4.Visible = false;

            panelSQL.Visible = false;
            panelinv.Visible = false;
            panelStaff.Visible = true;
            sqlStaff();
        }
        public void sqlStaff()
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection connection = con.getConnection();
                rjDataStaff.SetDatabaseConnection(connection);
                rjDataStaff.ExecuteSqlQuery("SELECT * FROM usuario");

            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                 System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        private void rjPictureRounded5_Click(object sender, EventArgs e)
        {
            s1.Visible = false;
            s2.Visible = false;
            s3.Visible = false;
            s4.Visible = true;
            LoginFrame loginFrame = new LoginFrame();
            loginFrame.Show();
            this.Hide();
        }
        
        private void Execute_Click(object sender, EventArgs e)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection connection = conn.getConnection();
                rjData.SetDatabaseConnection(connection);
                rjData.ExecuteSqlQuery(rjSQL.GetAllText());
                cacheSQL = rjSQL.GetAllText();
                rjSQL.Clear();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                 System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void Upload_Click(object sender, EventArgs e)
        {
            this.Upload.Image = Properties.Resources.foto_Upload;
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.png)|*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = openFileDialog.FileName;
                try
                {
                    Image imagenOriginal = Image.FromFile(rutaArchivo);
                    bool esTransparente = imagenOriginal is Bitmap && ((Bitmap)imagenOriginal).PixelFormat == PixelFormat.Format32bppArgb;

                    if (!esTransparente)
                    {
                        imagenOriginal = RemoveWhiteBackground(imagenOriginal);
                    }
                    byte[] imagenBytes = ImageToByteArray(imagenOriginal);
                    InquiriesDB DB2 = new InquiriesDB();
                    DataGridViewCell celdaSeleccionada = rjDataInv.CurrentCell;
                    object valorCelda = celdaSeleccionada.Value;
                    if (DB2.existImage(valorCelda) != true)
                    {
                        if (celdaSeleccionada != null)
                        {
                            InquiriesDB DB = new InquiriesDB();
                            if (DB.uploadImage(valorCelda, imagenBytes))
                            {
                                RJMessageBox.Show("It was uploaded successfully", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Upload.Image = Properties.Resources.foto_Off;
                            }
                            else
                            {
                                RJMessageBox.Show("It wasn't uploaded successfully", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Upload.Image = Properties.Resources.foto_Off;
                            }
                        }
                        else
                        {
                            RJMessageBox.Show("You need to select the name column and the" +
                                " name of who you are going to upload the image to", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Upload.Image = Properties.Resources.foto_Off;
                        }
                    }
                    else
                    {
                        DialogResult result = RJMessageBox.Show("You already have a linked image, " +
                              "do you want to update it?", "QUESTION", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            InquiriesDB DB = new InquiriesDB();
                            if (DB.updateImage(valorCelda, imagenBytes))
                            {
                                RJMessageBox.Show("It was uploaded successfully", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Upload.Image = Properties.Resources.foto_Off;
                            }
                            else
                            {
                                RJMessageBox.Show("It wasn't uploaded successfully", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Upload.Image = Properties.Resources.foto_Off;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show($"An error occurred while loading the image of type: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Upload.Image = Properties.Resources.foto_Off;
                }
            }
        }
        private byte[] ImageToByteArray(Image imagen)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                imagen.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }
        private Image RemoveWhiteBackground(Image imagen)
        {
            Bitmap bmp = new Bitmap(imagen);
            bmp.MakeTransparent(Color.White);
            return bmp;
        }
        private void rjExecuteIn_Click(object sender, EventArgs e)
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection connection = con.getConnection();
                rjDataInv.SetDatabaseConnection(connection);
                rjDataInv.ExecuteSqlQuery(rjSQLInv.GetAllText());
                rjSQLInv.Clear();
                sql();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                 System.Windows.Forms.MessageBoxIcon.Error);

            }
        }
        private void rjExecute_Click(object sender, EventArgs e)
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection connection = con.getConnection();
                rjDataInv.SetDatabaseConnection(connection);
                rjDataInv.ExecuteSqlQuery(rjSQLStaff.GetAllText());
                rjSQLStaff.Clear();
                sqlStaff();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                 System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void rjSQLStaff_Click(object sender, EventArgs e)
        {
            if (countStaff == 0)
            {
                countStaff++;
                DialogResult result = RJMessageBox.Show("Are you accessing full control of queries, are you sure of what you are doing, " +
               "can the changes not be undone once executed?", "ATTENTION!", System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Exclamation);
                if (result.Equals(DialogResult.Yes))
                {
                    rjSQLStaff.ReadOnly = false;
                }
                else
                {
                    rjSQLStaff.ReadOnly = true;
                }
            }
        }
        private void rjSQL_Click(object sender, EventArgs e)
        {
            if (countSQL == 0)
            {
                countSQL++;
                DialogResult result = RJMessageBox.Show("Are you accessing full control of queries, are you sure of what you are doing, " +
               "can the changes not be undone once executed?", "ATTENTION!", System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Exclamation);
                if (result.Equals(DialogResult.Yes))
                {
                    rjSQL.ReadOnly = false;
                }
                else
                {
                    rjSQL.ReadOnly = true;
                }
            }
        }

        private void rjInsertPanel_Click(object sender, EventArgs e)
        {
            if (getRank == "Miguel")
            {
                insertForm.fillBoxSpecial();
                insertForm.Show();
            }
            else
            {
                insertForm.Show();
            }
        }

        private void rjAutoStaff_Click(object sender, EventArgs e)
        {
            UserGUI user = new UserGUI();
            user.Show();
        }

        private void rjDataInv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                object valorCelda = rjDataInv.Rows[e.RowIndex].Cells[0].Value;

                if (valorCelda != null)
                {
                    insertForm.ValorDeCelda0 = valorCelda.ToString();
                }
                else
                {
                    RJMessageBox.Show("The cell is empty", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void AdminIU_Load(object sender, EventArgs e)
        {
            timer2.Start();
        }

        public void loadDataAdmin(String username)
        {
            getUserName = username;
            setName.Text = username;
            setPorfile.Image = Properties.Resources.desconocido;
            if (username == "Alexis")
            {
                rjJob.Visible = true;

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            showBattery.Visible = true;
            if (s == 1)
            {
                int batteryPercentage = (int)(SystemInformation.PowerStatus.BatteryLifePercent * 100);
                percent.Text = batteryPercentage.ToString() + "%";
                UpdateBatteryIcon();
                s += 0;
            }
            else
            {
                s++;
            }
        }
        private void panelinv_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void rjDataInv_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void panelStaff_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void rjDataStaff_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void panelSQL_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void rjData_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        //ComoBox de inventario (Consumibles)
        private void rjInventory_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            MySqlConnection connection = con.getConnection();
            switch (rjInventory.SelectedItem as String)
            {
                case "Consumibles mas vendidos":
                    rjDataInv.SetDatabaseConnection(connection);
                    rjDataInv.ExecuteSqlQuery("select consumible.clurp, consumible.nombre, venta.idPlato, venta.precio\r\nfrom consumible\r\ninner join venta\r\non consumible.clurp=venta.idPlato;");
                    connection.Close();
                    break;
                case "Precio promedio":
                    rjDataInv.SetDatabaseConnection(connection);
                    rjDataInv.ExecuteSqlQuery("SELECT AVG(venta.precio) AS precio_promedio\r\nFROM venta;\r\n");
                    connection.Close();
                    break;
                case "Total de ventas de consumibles":
                    rjDataInv.SetDatabaseConnection(connection);
                    rjDataInv.ExecuteSqlQuery("SELECT consumible.nombre, COUNT(venta.idVenta) AS total_ventas\r\nFROM consumible\r\nLEFT JOIN venta ON consumible.clurp = venta.idPlato\r\nGROUP BY consumible.nombre;\r\n");
                    connection.Close();
                    break;
                case "Consumibles que no se han vendido":
                    rjDataInv.SetDatabaseConnection(connection);
                    rjDataInv.ExecuteSqlQuery("SELECT consumible.clurp, consumible.nombre\r\nFROM consumible\r\nLEFT JOIN venta ON consumible.clurp = venta.idPlato\r\nWHERE venta.idPlato IS NULL;\r\n");
                    connection.Close();
                    break;
                case "Consumibles más caro":
                    rjDataInv.SetDatabaseConnection(connection);
                    rjDataInv.ExecuteSqlQuery("SELECT c.tipo, MAX(c.precio) AS precio_mas_alto\r\nFROM consumible AS c\r\nGROUP BY c.tipo\r\nORDER BY precio_mas_alto DESC\r\nLIMIT 10;\r\n");
                    connection.Close();
                    break;
            }
        }
        //ComoBox de personal
        private void rjStaff_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            MySqlConnection connection = con.getConnection();
            switch (rjStaff.SelectedItem as String)
            {
                case "Empleado del mes":
                    rjDataStaff.SetDatabaseConnection(connection);
                    rjDataStaff.ExecuteSqlQuery("SELECT v.Idemple AS IdEmpleado, c.nombre AS NombrePlato, c.tipo AS TipoPlato, v.cantidad, (c.precio * v.cantidad) AS MontoGenerado\r\nFROM venta v, consumible c\r\nWHERE v.idPlato = c.clurp AND v.Idemple = (SELECT Idemple FROM venta GROUP BY Idemple ORDER BY SUM(cantidad) DESC LIMIT 1);");
                    connection.Close();
                    break;
                case "Ganacias generadas":
                    rjDataStaff.SetDatabaseConnection(connection);
                    rjDataStaff.ExecuteSqlQuery("SELECT v.Idemple AS IdEmpleado, SUM(v.cantidad) AS TotalVentas, SUM(c.precio * v.cantidad) AS MontoTotalGenerado\r\nFROM venta v, consumible c\r\nWHERE v.idPlato = c.clurp\r\nGROUP BY v.Idemple;");
                    connection.Close();
                    break;
                case "Empleados con al menos 10 ventas de un tipo específico":
                    rjDataStaff.SetDatabaseConnection(connection);
                    rjDataStaff.ExecuteSqlQuery("SELECT v.Idemple AS IdEmpleado, e.nombre AS NombreEmpleado, c.tipo AS TipoPlato, SUM(v.cantidad) AS TotalVentas\r\nFROM venta v, empleado e, consumible c\r\nWHERE v.Idemple = e.id AND v.idPlato = c.clurp\r\nGROUP BY Idemple, c.tipo\r\nHAVING SUM(v.cantidad) >= 10;");
                    connection.Close();
                    break;
                case "Consumibles consumidos por empleado":
                    rjDataStaff.SetDatabaseConnection(connection);
                    rjDataStaff.ExecuteSqlQuery("SELECT e.id AS empleado_id, e.nombre AS empleado_nombre, COUNT(c.clurp) AS cantidad_consumida\r\nFROM empleado AS e\r\nCROSS JOIN consumible AS c\r\nGROUP BY e.id, e.nombre;\r\n");
                    connection.Close();
                    break;
                case "Personal masculino":
                    rjDataStaff.SetDatabaseConnection(connection);
                    rjDataStaff.ExecuteSqlQuery("select * from empleado\r\n  where find_in_set('M',sexo)>0;");
                    connection.Close();
                    break;
                case "Personal femenino":
                    rjDataStaff.SetDatabaseConnection(connection);
                    rjDataStaff.ExecuteSqlQuery("select * from empleado\r\n  where find_in_set('F',sexo)>0;");
                    connection.Close();
                    break;

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            foodV();
        }
        private void foodV()
        {
            FoodUI food = new FoodUI();
            food.panelOrder.Visible = true;
            food.panelRecord.Visible = true;
            food.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            foodV();
        }


        private void rjJob_Click(object sender, EventArgs e)
        {
            FormM migue = new FormM();
            migue.getUserName = this.getUserName;
            migue.Show();
        }
        private void ExportToExcel_Click(object sender, EventArgs e)
        {
            InquiriesDB DB = new InquiriesDB();
            DB.GetDataTable("SELECT * FROM consumible");
        }
        private void rjDataInv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetAllCellValues();
        }
        private object CellsValues;

        private void GetAllCellValues()
        {
            for (int row = 0; row < rjDataInv.Rows.Count; row++)
            {
                for (int col = 0; col < rjDataInv.Columns.Count; col++)
                {
                    object cellValue = rjDataInv.Rows[row].Cells[col].Value;
                    if (cellValue != null)
                    {
                        CellsValues = cellValue;
                        Console.WriteLine($"Valor de la celda en la fila {row}, columna {col}: {cellValue.ToString()}");
                    }
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            InquiriesDB DB = new InquiriesDB();
            DB.GetDataTable("SELECT * FROM usuario");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(rjSQL.GetAllText()))
                {
                    InquiriesDB DB = new InquiriesDB();
                    DB.GetDataTable(rjSQL.GetAllText());
                }
                else
                {
                    InquiriesDB DB = new InquiriesDB();
                    DB.GetDataTable(cacheSQL);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rjTipo_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection connection = con.getConnection();
                rjDataInv.SetDatabaseConnection(connection);
                String getTypeFilter = rjTipo.SelectedItem as String;
                rjDataInv.ExecuteSqlQuery($"SELECT * FROM consumible WHERE tipo = '{getTypeFilter}';");

            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            sql();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan tiempoTranscurrido = stopwatch.Elapsed;
            SetLap.Text = tiempoTranscurrido.ToString(@"hh\:mm\:ss");
        }

        private void rjSQLInv_Click(object sender, EventArgs e)
        {
            if (count == 0)
            {
                count++;
                DialogResult result = RJMessageBox.Show("Are you accessing full control of queries, are you sure of what you are doing, " +
               "can the changes not be undone once executed?", "ATTENTION!", System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Exclamation);
                if (result.Equals(DialogResult.Yes))
                {
                    rjSQLInv.ReadOnly = false;
                }
                else
                {
                    rjSQLInv.ReadOnly = true;
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