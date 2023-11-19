namespace Palacio_el_restaurante.src.GUI
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.panel1 = new System.Windows.Forms.Panel();
            this.rjButton_Save = new Palacio_el_restaurante.src.Controls.RJButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.getAddi = new Palacio_el_restaurante.src.Controls.ToggleButton();
            this.getThread = new Palacio_el_restaurante.src.Controls.ToggleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.getTriggers = new Palacio_el_restaurante.src.Controls.ToggleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rjPictureRounded6 = new Palacio_el_restaurante.src.Controls.RJPictureRounded();
            this.rjPictureRounded4 = new Palacio_el_restaurante.src.Controls.RJPictureRounded();
            this.rjButton1 = new Palacio_el_restaurante.src.Controls.RJButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rjPictureRounded6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rjPictureRounded4)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.rjButton_Save);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.getAddi);
            this.panel1.Controls.Add(this.getThread);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.getTriggers);
            this.panel1.Location = new System.Drawing.Point(-5, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 463);
            this.panel1.TabIndex = 4;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // rjButton_Save
            // 
            this.rjButton_Save.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton_Save.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton_Save.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton_Save.BorderRadius = 16;
            this.rjButton_Save.BorderSize = 0;
            this.rjButton_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjButton_Save.FlatAppearance.BorderSize = 0;
            this.rjButton_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton_Save.Font = new System.Drawing.Font("FZYaoTi", 12F, System.Drawing.FontStyle.Bold);
            this.rjButton_Save.ForeColor = System.Drawing.Color.White;
            this.rjButton_Save.Location = new System.Drawing.Point(562, 418);
            this.rjButton_Save.Name = "rjButton_Save";
            this.rjButton_Save.Size = new System.Drawing.Size(118, 40);
            this.rjButton_Save.TabIndex = 12;
            this.rjButton_Save.Text = "Save";
            this.rjButton_Save.TextColor = System.Drawing.Color.White;
            this.rjButton_Save.UseVisualStyleBackColor = false;
            this.rjButton_Save.Click += new System.EventHandler(this.rjButton_Save_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("FZYaoTi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(107, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Additional";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("FZYaoTi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(107, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Multi Threads";
            // 
            // getAddi
            // 
            this.getAddi.AutoSize = true;
            this.getAddi.Location = new System.Drawing.Point(40, 192);
            this.getAddi.MinimumSize = new System.Drawing.Size(45, 22);
            this.getAddi.Name = "getAddi";
            this.getAddi.OffBackColor = System.Drawing.Color.Gray;
            this.getAddi.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.getAddi.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.getAddi.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.getAddi.Size = new System.Drawing.Size(45, 22);
            this.getAddi.TabIndex = 8;
            this.getAddi.UseVisualStyleBackColor = true;
            // 
            // getThread
            // 
            this.getThread.AutoSize = true;
            this.getThread.Location = new System.Drawing.Point(40, 115);
            this.getThread.MinimumSize = new System.Drawing.Size(45, 22);
            this.getThread.Name = "getThread";
            this.getThread.OffBackColor = System.Drawing.Color.Gray;
            this.getThread.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.getThread.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.getThread.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.getThread.Size = new System.Drawing.Size(45, 22);
            this.getThread.TabIndex = 7;
            this.getThread.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("FZYaoTi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(107, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Triggers";
            // 
            // getTriggers
            // 
            this.getTriggers.AutoSize = true;
            this.getTriggers.Location = new System.Drawing.Point(40, 47);
            this.getTriggers.MinimumSize = new System.Drawing.Size(45, 22);
            this.getTriggers.Name = "getTriggers";
            this.getTriggers.OffBackColor = System.Drawing.Color.Gray;
            this.getTriggers.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.getTriggers.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.getTriggers.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.getTriggers.Size = new System.Drawing.Size(45, 22);
            this.getTriggers.TabIndex = 0;
            this.getTriggers.UseVisualStyleBackColor = true;
            this.getTriggers.CheckedChanged += new System.EventHandler(this.getTriggers_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.label1.Font = new System.Drawing.Font("FZYaoTi", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings";
            // 
            // rjPictureRounded6
            // 
            this.rjPictureRounded6.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.rjPictureRounded6.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjPictureRounded6.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.rjPictureRounded6.BorderColor2 = System.Drawing.Color.DeepSkyBlue;
            this.rjPictureRounded6.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjPictureRounded6.BorderSize = 2;
            this.rjPictureRounded6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjPictureRounded6.GradientAngle = 50F;
            this.rjPictureRounded6.Location = new System.Drawing.Point(641, 2);
            this.rjPictureRounded6.Name = "rjPictureRounded6";
            this.rjPictureRounded6.Size = new System.Drawing.Size(18, 18);
            this.rjPictureRounded6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjPictureRounded6.TabIndex = 3;
            this.rjPictureRounded6.TabStop = false;
            this.rjPictureRounded6.Click += new System.EventHandler(this.rjPictureRounded6_Click);
            // 
            // rjPictureRounded4
            // 
            this.rjPictureRounded4.BackColor = System.Drawing.Color.Red;
            this.rjPictureRounded4.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjPictureRounded4.BorderColor = System.Drawing.Color.Red;
            this.rjPictureRounded4.BorderColor2 = System.Drawing.Color.Red;
            this.rjPictureRounded4.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjPictureRounded4.BorderSize = 2;
            this.rjPictureRounded4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjPictureRounded4.GradientAngle = 50F;
            this.rjPictureRounded4.Location = new System.Drawing.Point(663, 2);
            this.rjPictureRounded4.Name = "rjPictureRounded4";
            this.rjPictureRounded4.Size = new System.Drawing.Size(18, 18);
            this.rjPictureRounded4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjPictureRounded4.TabIndex = 2;
            this.rjPictureRounded4.TabStop = false;
            this.rjPictureRounded4.Click += new System.EventHandler(this.rjPictureRounded4_Click);
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 20;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.Enabled = false;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(-9, -4);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(644, 59);
            this.rjButton1.TabIndex = 5;
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rjButton1_MouseMove);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 506);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rjPictureRounded6);
            this.Controls.Add(this.rjPictureRounded4);
            this.Controls.Add(this.rjButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Settings_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rjPictureRounded6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rjPictureRounded4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.RJPictureRounded rjPictureRounded4;
        private Controls.RJPictureRounded rjPictureRounded6;
        private System.Windows.Forms.Panel panel1;
        private Controls.RJButton rjButton1;
        private System.Windows.Forms.Label label1;
        private Controls.ToggleButton getTriggers;
        private System.Windows.Forms.Label label3;
        private Controls.ToggleButton getAddi;
        private Controls.ToggleButton getThread;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private Controls.RJButton rjButton_Save;
    }
}