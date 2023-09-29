namespace Palacio_el_restaurante.src.UI
{
    partial class LoginReset
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginReset));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.smsP = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordLoad = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_reset = new Palacio_el_restaurante.src.Controls.RJButton();
            this.getPassowrdC = new Palacio_el_restaurante.src.Controls.RJTextBoxRounded();
            this.getPassword = new Palacio_el_restaurante.src.Controls.RJTextBoxRounded();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reset Password";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Palacio_el_restaurante.Properties.Resources.flecha_izquierda;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 31);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // smsP
            // 
            this.smsP.AutoSize = true;
            this.smsP.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smsP.ForeColor = System.Drawing.Color.DarkRed;
            this.smsP.Location = new System.Drawing.Point(93, 253);
            this.smsP.Name = "smsP";
            this.smsP.Size = new System.Drawing.Size(46, 20);
            this.smsP.TabIndex = 10;
            this.smsP.Text = "smsP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(28, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(327, 60);
            this.label2.TabIndex = 11;
            this.label2.Text = "Enter your new password for you account,\r\nyour password might be 8 characters min" +
    "im\r\nyou might remember that.\r\n";
            // 
            // passwordLoad
            // 
            this.passwordLoad.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("passwordLoad.BackgroundImage")));
            this.passwordLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.passwordLoad.Image = global::Palacio_el_restaurante.Properties.Resources.contrasena;
            this.passwordLoad.Location = new System.Drawing.Point(363, 12);
            this.passwordLoad.Name = "passwordLoad";
            this.passwordLoad.Size = new System.Drawing.Size(82, 76);
            this.passwordLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.passwordLoad.TabIndex = 14;
            this.passwordLoad.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_reset
            // 
            this.button_reset.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button_reset.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.button_reset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_reset.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.button_reset.BorderRadius = 15;
            this.button_reset.BorderSize = 0;
            this.button_reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_reset.FlatAppearance.BorderSize = 0;
            this.button_reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_reset.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_reset.ForeColor = System.Drawing.Color.White;
            this.button_reset.Location = new System.Drawing.Point(97, 396);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(258, 41);
            this.button_reset.TabIndex = 7;
            this.button_reset.Text = "Reset Password";
            this.button_reset.TextColor = System.Drawing.Color.White;
            this.button_reset.UseVisualStyleBackColor = false;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            this.button_reset.MouseHover += new System.EventHandler(this.button_reset_MouseHover);
            // 
            // getPassowrdC
            // 
            this.getPassowrdC.BackColor = System.Drawing.Color.Gainsboro;
            this.getPassowrdC.BorderColor = System.Drawing.Color.Transparent;
            this.getPassowrdC.BorderFocusColor = System.Drawing.Color.HotPink;
            this.getPassowrdC.BorderRadius = 10;
            this.getPassowrdC.BorderSize = 2;
            this.getPassowrdC.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getPassowrdC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.getPassowrdC.Location = new System.Drawing.Point(69, 293);
            this.getPassowrdC.Margin = new System.Windows.Forms.Padding(4);
            this.getPassowrdC.Multiline = false;
            this.getPassowrdC.Name = "getPassowrdC";
            this.getPassowrdC.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.getPassowrdC.PasswordChar = true;
            this.getPassowrdC.PlaceholderColor = System.Drawing.Color.Gray;
            this.getPassowrdC.PlaceholderText = "Password";
            this.getPassowrdC.Size = new System.Drawing.Size(288, 40);
            this.getPassowrdC.TabIndex = 4;
            this.getPassowrdC.Texts = "";
            this.getPassowrdC.UnderlinedStyle = false;
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
            this.getPassword.Location = new System.Drawing.Point(69, 209);
            this.getPassword.Margin = new System.Windows.Forms.Padding(4);
            this.getPassword.Multiline = false;
            this.getPassword.Name = "getPassword";
            this.getPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.getPassword.PasswordChar = true;
            this.getPassword.PlaceholderColor = System.Drawing.Color.Gray;
            this.getPassword.PlaceholderText = "Password";
            this.getPassword.Size = new System.Drawing.Size(286, 40);
            this.getPassword.TabIndex = 3;
            this.getPassword.Texts = "";
            this.getPassword.UnderlinedStyle = false;
            this.getPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.getPassword_KeyPress);
            // 
            // LoginReset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(467, 473);
            this.Controls.Add(this.passwordLoad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.smsP);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.getPassowrdC);
            this.Controls.Add(this.getPassword);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginReset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginReset";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoginReset_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordLoad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Controls.RJTextBoxRounded getPassword;
        private Controls.RJTextBoxRounded getPassowrdC;
        private Controls.RJButton button_reset;
        private System.Windows.Forms.Label smsP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox passwordLoad;
        private System.Windows.Forms.Timer timer1;
    }
}