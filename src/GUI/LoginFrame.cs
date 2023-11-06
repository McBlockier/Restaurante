using CustomMessageBox;
using Palacio_el_restaurante.src.Conection;
using Palacio_el_restaurante.src.GUI;
using Palacio_el_restaurante.src.UI;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Palacio_el_restaurante
{
    public partial class LoginFrame : Form
    {
        public int xClick = 0, yClick = 0;
        private InquiriesDB request = new InquiriesDB();
        private int ss = 0;
        public Form preloadedForm = null;

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
            timer2.Start();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 14, 14));

            ToolTipMessage();
            panelL.Hide();
            loadPicture.Hide();

            getPassword.PasswordChar = true;
            showPassword.Image = Properties.Resources.ojo_off;
            resetPassword.Visible = false;
            ErrorConnection.Visible = false;

            this.Shown += (sender, e) =>
            {
                Task.Run(async () => await keepSession());
            };

            this.Shown += (sender, e) =>
            {
                Invoke((MethodInvoker)(() =>
                {
                    ErrorConnection.Visible = true;
                    button_login.Enabled = false;
                    ErrorConnection.Image = Properties.Resources.trabajo_en_progreso;
                }));

                Task.Run(async () => await valueConnection());
            };           
        }
        private async Task keepSession()
        {
            try
            {
                SessionManager sessionManager = new SessionManager();
                SessionInfo sessionInfo = sessionManager.GetSessionInfo();

                if (sessionInfo != null)
                {
                    string username = sessionInfo.Username;
                    string password = sessionInfo.Password;

                    getUsername.Text = username;
                    getPassword.Text = password;

                    Invoke((MethodInvoker)(() =>
                    {
                        button_login.Focus();
                    }));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task valueConnection()
        {
            try
            {
                timer2.Start();
                Connection connection = new Connection();
                if (connection != null && connection.IsConnectionConfiguredAsync())
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        ErrorConnection.Visible = false;
                        button_login.Enabled = true;
                    }));
                }
                else
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        ErrorConnection.Image = Properties.Resources.setConnection;
                        ErrorConnection.Visible = true;
                        button_login.Enabled = false;
                    }));
                }
            }
            catch (Exception ex)
            {
                Invoke((MethodInvoker)(() =>
                {
                    RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }));
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                resetTimer2();
            }
        }
        private void ToolTipMessage()
        {
            toolTip1.SetToolTip(getPassword, "Set your password account");
            toolTip1.SetToolTip(resetPassword, "Reset your password");
            toolTip1.SetToolTip(button_login, "Log in");
            toolTip1.SetToolTip(create, "Create new account");
            toolTip1.SetToolTip(showPassword, "Show/Hide Password");
            toolTip1.SetToolTip(getUsername, "Set your username");
            toolTip1.SetToolTip(ErrorConnection, "Connection error");
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private async void saveSession()
        {
            try
            {
                SessionManager sessionManager = new SessionManager();
                sessionManager.SaveSession(getUsername.Texts, getPassword.Texts);

            }catch(Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                       System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private async void button_login_Click(object sender, EventArgs e)
        {        
            if (getUsername.Texts == "Miguel" || getUsername.Texts == "Jesus")
            {
                if (!String.IsNullOrEmpty(getUsername.Texts) && !String.IsNullOrEmpty(getPassword.Texts))
                {
                    if (getPassword.Texts == "root")
                    {
                        switch (getUsername.Texts)
                        {
                            case "Miguel":
                                panelL.Show();
                                resetPassword.Hide();
                                create.Hide();
                                button_login.Hide();
                                loadPicture.Show();
                                timer1.Start();
                                await loadFormDedicated("Miguel");

                                break;
                            case "Jesus":
                                panelL.Show();
                                resetPassword.Hide();
                                create.Hide();
                                button_login.Hide();
                                loadPicture.Show();
                                timer1.Start();
                                await loadFormDedicated("Jesus");
                                break;
                        }
                    }
                    else
                    {
                        RJMessageBox.Show("Username or password aren't correct, please check out it",
                            "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {

                try
                {
                    if (String.IsNullOrEmpty(getUsername.Texts) || String.IsNullOrEmpty(getPassword.Texts))
                    {
                        RJMessageBox.Show("You can't leave empty spaces",
                            "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        InquiriesDB DB = new InquiriesDB();
                        if (DB.valueLogin(getUsername.Texts, getPassword.Texts))
                        {
                            panelL.Show();
                            resetPassword.Hide();
                            create.Hide();
                            button_login.Hide();
                            loadPicture.Show();
                            timer1.Start();
                            saveSession();
                            await loadForms(false);

                        }
                        else
                        {
                            RJMessageBox.Show("Username or password aren't correct, please check out it",
                            "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            RJMessageBox.Show("Accede 191");
                            resetPassword.Visible = true;
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
        private void resetTimer()
        {
            ss = 0;
            timer1.Stop();
            loadForms(true);
        }
        private String userN = "";
        private async Task loadFormDedicated(String userName)
        {
            userN = userName;
            try
            {
                switch(userName)
                {
                    case "Miguel":
                        AdminIU adminUI = new AdminIU();
                        adminUI.panelSQL.Visible = false;
                        adminUI.panelStaff.Visible = false;
                        adminUI.rjButtonSQL.Enabled = false;
                        adminUI.rjButtonStaff.Enabled = false;
                        adminUI.panelinv.Visible = true;
                        adminUI.s1.Visible = false;
                        adminUI.s2.Visible = true;
                        adminUI.getRank = "Miguel";
                        adminUI.rjJob.Visible = true;
                        adminUI.loadDataAdmin("Miguel");
                        adminUI.Show();
                        this.Hide();
                        break;
                    case "Jesus":
                        AdminIU adminUI2 = new AdminIU();
                        adminUI2.rjInsertPanel.Visible = false;
                        adminUI2.s1.Visible = false;
                        adminUI2.rjJob.Visible = false;
                        adminUI2.rjExecuteIn.Visible = false;
                        adminUI2.Upload.Visible = false;
                        adminUI2.adminFood.Visible = false;
                        adminUI2.ExportToExcel.Visible = false;
                        adminUI2.rjButtonSQL.Enabled = false;
                        adminUI2.rjButtonStaff.Enabled = false;
                        adminUI2.panelinv.Visible = true;
                        adminUI2.loadDataAdmin("Jesus");
                        adminUI2.Show();
                        this.Hide();
                        break;
                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task loadForms(Boolean status)
        {
            try
            {
                InquiriesDB DB = new InquiriesDB();
                switch (DB.getRank(getUsername.Texts))
                {
                    case 1:                      
                            AdminIU adminFrame = new AdminIU();
                            if (status)
                            {
                                adminFrame.loadDataAdmin("Alexis");
                                adminFrame.Show();
                                this.Hide();
                            }                          
                        break;
                    case 2:
                        FoodUI food = new FoodUI();
                        food.panelOrder.Visible = false;
                        food.panelRecord.Visible = false;
                        if (status)
                        {
                            food.Show();
                            this.Hide();
                        }
                        break;
                    case 3:
                        FoodUI food2 = new FoodUI();
                        food2.panelOrder.Visible = true;
                        food2.panelRecord.Visible = false;
                        if (status)
                        {
                            food2.Show();
                            this.Hide();
                        }
                        break;
                    default:
                        if(userN == "Miguel" || userN == "Jesus")
                        {
                            this.Hide();
                        }
                        else
                        {
                            FoodUI food3 = new FoodUI();
                            food3.Show();
                            food3.panelOrder.Visible = false;
                            food3.panelRecord.Visible = false;
                            this.Hide();
                        }                 
                        break;
                }

            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "ERROR!", System.Windows.Forms.MessageBoxButtons.OK,
                   System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ss += 1;
            if (ss == 32)
            {
                resetTimer();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (getPassword.PasswordChar != true)
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
            this.Hide();
            LoginCreateA loginA = new LoginCreateA();
            loginA.Show();
        }

        private void create_MouseHover(object sender, EventArgs e)
        {
            create.Image = Properties.Resources.agregar_usuario;
        }

        private void create_MouseLeave(object sender, EventArgs e)
        {
            create.Image = Properties.Resources.addUser;
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void getUsername_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_login_Click(sender, e);
            }
        }

        private void getPassword_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_login_Click(sender, e);
            }
        }

        private void getPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                button_login_Click(sender, EventArgs.Empty);
            }
        }

        private void getUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                button_login_Click(sender, EventArgs.Empty);
            }
        }

        private void ErrorConnection_Click(object sender, EventArgs e)
        {
            SetConnection setConnection = new SetConnection();
            setConnection.Show();
            this.Hide();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            ss += 1;

        }
        private void resetTimer2()
        {
            timer2.Stop();
            ss += 0;          
        }

        private void getUsername_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string[] validNames = { "Miguel", "Jesus", "McBlockier" };
                string enteredName = getUsername.Texts.Trim();

                if (validNames.Contains(enteredName))
                {
                    switch (getUsername.Texts)
                    {
                        case "Miguel":
                            break;
                        case "Jesus":
                            break;
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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