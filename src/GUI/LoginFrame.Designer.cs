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
            this.label1 = new System.Windows.Forms.Label();
            this.create = new System.Windows.Forms.LinkLabel();
            this.createP = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.loadPicture = new System.Windows.Forms.PictureBox();
            this.panelL = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_login = new Palacio_el_restaurante.src.Controls.RJButton();
            this.getPassword = new Palacio_el_restaurante.src.Controls.RJTextBoxRounded();
            this.getUsername = new Palacio_el_restaurante.src.Controls.RJTextBoxRounded();
            ((System.ComponentModel.ISupportInitialize)(this.createP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadPicture)).BeginInit();
            this.panelL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // resetPassword
            // 
            this.resetPassword.AutoSize = true;
            this.resetPassword.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetPassword.Location = new System.Drawing.Point(491, 357);
            this.resetPassword.Name = "resetPassword";
            this.resetPassword.Size = new System.Drawing.Size(261, 25);
            this.resetPassword.TabIndex = 5;
            this.resetPassword.TabStop = true;
            this.resetPassword.Text = "Forgot username/password?";
            this.resetPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.resetPassword_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(565, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "USER LOGIN";
            // 
            // create
            // 
            this.create.AutoSize = true;
            this.create.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.create.Location = new System.Drawing.Point(512, 448);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(180, 25);
            this.create.TabIndex = 8;
            this.create.TabStop = true;
            this.create.Text = "Create you account";
            this.create.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // createP
            // 
            this.createP.BackgroundImage = global::Palacio_el_restaurante.Properties.Resources.flecha_derecha_recta;
            this.createP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.createP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createP.Location = new System.Drawing.Point(698, 448);
            this.createP.Name = "createP";
            this.createP.Size = new System.Drawing.Size(25, 23);
            this.createP.TabIndex = 9;
            this.createP.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::Palacio_el_restaurante.Properties.Resources.candado;
            this.pictureBox2.Location = new System.Drawing.Point(466, 200);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::Palacio_el_restaurante.Properties.Resources.usuario;
            this.pictureBox1.Location = new System.Drawing.Point(466, 126);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // leftPanel
            // 
            this.leftPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("leftPanel.BackgroundImage")));
            this.leftPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leftPanel.Location = new System.Drawing.Point(-2, -1);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(446, 495);
            this.leftPanel.TabIndex = 0;
            this.leftPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // loadPicture
            // 
            this.loadPicture.Image = global::Palacio_el_restaurante.Properties.Resources.conexion;
            this.loadPicture.Location = new System.Drawing.Point(59, 18);
            this.loadPicture.Name = "loadPicture";
            this.loadPicture.Size = new System.Drawing.Size(137, 117);
            this.loadPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadPicture.TabIndex = 10;
            this.loadPicture.TabStop = false;
            // 
            // panelL
            // 
            this.panelL.Controls.Add(this.loadPicture);
            this.panelL.Location = new System.Drawing.Point(496, 258);
            this.panelL.Name = "panelL";
            this.panelL.Size = new System.Drawing.Size(256, 156);
            this.panelL.TabIndex = 11;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Palacio_el_restaurante.Properties.Resources.espaguetis;
            this.pictureBox3.Location = new System.Drawing.Point(623, 21);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(69, 60);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.button_login.Location = new System.Drawing.Point(525, 268);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(217, 41);
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
            this.getPassword.Location = new System.Drawing.Point(512, 200);
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
            this.getUsername.Location = new System.Drawing.Point(512, 126);
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
            this.Controls.Add(this.panelL);
            this.Controls.Add(this.createP);
            this.Controls.Add(this.create);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.resetPassword);
            this.Controls.Add(this.pictureBox2);
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
            ((System.ComponentModel.ISupportInitialize)(this.createP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadPicture)).EndInit();
            this.panelL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private src.Controls.RJTextBoxRounded getUsername;
        private src.Controls.RJTextBoxRounded getPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel resetPassword;
        private src.Controls.RJButton button_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel create;
        private System.Windows.Forms.PictureBox createP;
        private System.Windows.Forms.PictureBox loadPicture;
        private System.Windows.Forms.Panel panelL;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Timer timer1;
    }
}