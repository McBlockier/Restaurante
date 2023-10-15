using CustomMessageBox;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using Palacio_el_restaurante.src.Conection;
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
            
            s1.Visible = true;
            s2.Visible = false;
            s3.Visible = false;
            s4.Visible = false;
            fillBoxes();
            setHeader();
            stopwatch.Start();
            InitPanel();
            SubscribeEventArgs();

            timer2.Interval = 1000;
            showBattery.Visible = false;
            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
        }
        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.StatusChange)
            {
                UpdateBatteryIcon();
            }
        }

        private void UpdateBatteryIcon()
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
            rjInventory.Items.Add("");

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
            insertForm.Show();
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            showBattery.Visible = true;
            if(s == 1)
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
