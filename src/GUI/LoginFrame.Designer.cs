namespace Palacio_el_restaurante
{
    partial class LoginFrame
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFrame));
            this.resetPassword = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panelL = new System.Windows.Forms.Panel();
            this.loadPicture = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.create = new System.Windows.Forms.PictureBox();
            this.showPassword = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button_login = new Palacio_el_restaurante.src.Controls.RJButton();
            this.getPassword = new Palacio_el_restaurante.src.Controls.RJTextBoxRounded();
            this.getUsername = new Palacio_el_restaurante.src.Controls.RJTextBoxRounded();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panelL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.create)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // resetPassword
            // 
            this.resetPassword.AutoSize = true;
            this.resetPassword.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetPassword.Location = new System.Drawing.Point(485, 287);
            this.resetPassword.Name = "resetPassword";
            this.resetPassword.Size = new System.Drawing.Size(237, 22);
            this.resetPassword.TabIndex = 5;
            this.resetPassword.TabStop = true;
            this.resetPassword.Text = "Forgot username/password?";
            this.resetPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.resetPassword_LinkClicked);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = global::Palacio_el_restaurante.Properties.Resources.newCandado;
            this.pictureBox2.Location = new System.Drawing.Point(438, 225);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::Palacio_el_restaurante.Properties.Resources.newUsuario;
            this.pictureBox1.Location = new System.Drawing.Point(433, 174);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // leftPanel
            // 
            this.leftPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("leftPanel.BackgroundImage")));
            this.leftPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leftPanel.Controls.Add(this.pictureBox2);
            this.leftPanel.Location = new System.Drawing.Point(-2, -1);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(469, 495);
            this.leftPanel.TabIndex = 0;
            this.leftPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Palacio_el_restaurante.Properties.Resources.PALACIOOOOOOO3;
            this.pictureBox4.Location = new System.Drawing.Point(364, 15);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(380, 141);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox4_MouseMove);
            // 
            // panelL
            // 
            this.panelL.Controls.Add(this.loadPicture);
            this.panelL.Location = new System.Drawing.Point(516, 352);
            this.panelL.Name = "panelL";
            this.panelL.Size = new System.Drawing.Size(169, 140);
            this.panelL.TabIndex = 11;
            // 
            // loadPicture
            // 
            this.loadPicture.Image = global::Palacio_el_restaurante.Properties.Resources.conexion;
            this.loadPicture.Location = new System.Drawing.Point(23, 2);
            this.loadPicture.Name = "loadPicture";
            this.loadPicture.Size = new System.Drawing.Size(125, 128);
            this.loadPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadPicture.TabIndex = 10;
            this.loadPicture.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Palacio_el_restaurante.Properties.Resources.espaguetis;
            this.pictureBox3.Location = new System.Drawing.Point(681, 48);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(74, 75);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // create
            // 
            this.create.BackColor = System.Drawing.Color.Transparent;
            this.create.Cursor = System.Windows.Forms.Cursors.Hand;
            this.create.Image = global::Palacio_el_restaurante.Properties.Resources.addUser;
            this.create.Location = new System.Drawing.Point(771, 429);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(71, 53);
            this.create.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.create.TabIndex = 13;
            this.create.TabStop = false;
            this.create.Click += new System.EventHandler(this.create_Click);
            this.create.MouseLeave += new System.EventHandler(this.create_MouseLeave);
            this.create.MouseHover += new System.EventHandler(this.create_MouseHover);
            // 
            // showPassword
            // 
            this.showPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.showPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showPassword.Location = new System.Drawing.Point(745, 226);
            this.showPassword.Name = "showPassword";
            this.showPassword.Size = new System.Drawing.Size(38, 40);
            this.showPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.showPassword.TabIndex = 14;
            this.showPassword.TabStop = false;
            this.showPassword.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // button_login
            // 
            this.button_login.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.button_login.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.button_login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_login.BackgroundImage")));
            this.button_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_login.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.button_login.BorderRadius = 20;
            this.button_login.BorderSize = 0;
            this.button_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_login.FlatAppearance.BorderSize = 0;
            this.button_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_login.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_login.ForeColor = System.Drawing.Color.White;
            this.button_login.Location = new System.Drawing.Point(500, 313);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(206, 41);
            this.button_login.TabIndex = 6;
            this.button_login.Text = "LOGIN";
            this.button_login.TextColor = System.Drawing.Color.White;
            this.button_login.UseVisualStyleBackColor = false;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // getPassword
            // 
            this.getPassword.BackColor = System.Drawing.Color.Gainsboro;
            this.getPassword.BorderColor = System.Drawing.Color.Transparent;
            this.getPassword.BorderFocusColor = System.Drawing.Color.HotPink;
            this.getPassword.BorderRadius = 10;
            this.getPassword.BorderSize = 2;
            this.getPassword.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.getPassword.Location = new System.Drawing.Point(478, 224);
            this.getPassword.Margin = new System.Windows.Forms.Padding(4);
            this.getPassword.Multiline = false;
            this.getPassword.Name = "getPassword";
            this.getPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.getPassword.PasswordChar = true;
            this.getPassword.PlaceholderColor = System.Drawing.Color.Gray;
            this.getPassword.PlaceholderText = "Password";
            this.getPassword.Size = new System.Drawing.Size(260, 40);
            this.getPassword.TabIndex = 2;
            this.getPassword.Texts = "";
            this.getPassword.UnderlinedStyle = false;
            // 
            // getUsername
            // 
            this.getUsername.BackColor = System.Drawing.Color.Gainsboro;
            this.getUsername.BorderColor = System.Drawing.Color.Transparent;
            this.getUsername.BorderFocusColor = System.Drawing.Color.HotPink;
            this.getUsername.BorderRadius = 10;
            this.getUsername.BorderSize = 2;
            this.getUsername.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.getUsername.Location = new System.Drawing.Point(478, 174);
            this.getUsername.Margin = new System.Windows.Forms.Padding(4);
            this.getUsername.Multiline = false;
            this.getUsername.Name = "getUsername";
            this.getUsername.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.getUsername.PasswordChar = false;
            this.getUsername.PlaceholderColor = System.Drawing.Color.Gray;
            this.getUsername.PlaceholderText = "Username";
            this.getUsername.Size = new System.Drawing.Size(260, 40);
            this.getUsername.TabIndex = 1;
            this.getUsername.Texts = "";
            this.getUsername.UnderlinedStyle = false;
            // 
            // LoginFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(848, 494);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.create);
            this.Controls.Add(this.panelL);
            this.Controls.Add(this.showPassword);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.resetPassword);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.getPassword);
            this.Controls.Add(this.getUsername);
            this.Controls.Add(this.leftPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.leftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panelL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loadPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.create)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private src.Controls.RJTextBoxRounded getPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel resetPassword;
        private src.Controls.RJButton button_login;
        private System.Windows.Forms.PictureBox loadPicture;
        private System.Windows.Forms.Panel panelL;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox create;
        private System.Windows.Forms.PictureBox showPassword;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox4;
        public src.Controls.RJTextBoxRounded getUsername;
    }
}