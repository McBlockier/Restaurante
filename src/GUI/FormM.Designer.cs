namespace Palacio_el_restaurante.src.GUI
{
    partial class FormM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormM));
            this.rjDataV = new Palacio_el_restaurante.src.Controls.RJDataGridView();
            this.rjDataPe = new Palacio_el_restaurante.src.Controls.RJDataGridView();
            this.rjBPe = new Palacio_el_restaurante.src.Controls.RJButton();
            this.rjButton_V = new Palacio_el_restaurante.src.Controls.RJButton();
            this.rjButton_pe = new Palacio_el_restaurante.src.Controls.RJButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rjPictureRounded4 = new Palacio_el_restaurante.src.Controls.RJPictureRounded();
            this.rjPictureRounded6 = new Palacio_el_restaurante.src.Controls.RJPictureRounded();
            this.rjV = new Palacio_el_restaurante.src.Controls.RJTextBoxSQL();
            this.rjPe = new Palacio_el_restaurante.src.Controls.RJTextBoxSQL();
            ((System.ComponentModel.ISupportInitialize)(this.rjDataV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rjDataPe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rjPictureRounded4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rjPictureRounded6)).BeginInit();
            this.SuspendLayout();
            // 
            // rjDataV
            // 
            this.rjDataV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rjDataV.Location = new System.Drawing.Point(0, 221);
            this.rjDataV.Name = "rjDataV";
            this.rjDataV.RowHeadersWidth = 51;
            this.rjDataV.RowTemplate.Height = 24;
            this.rjDataV.Size = new System.Drawing.Size(562, 360);
            this.rjDataV.TabIndex = 0;
            // 
            // rjDataPe
            // 
            this.rjDataPe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rjDataPe.Location = new System.Drawing.Point(576, 221);
            this.rjDataPe.Name = "rjDataPe";
            this.rjDataPe.RowHeadersWidth = 51;
            this.rjDataPe.RowTemplate.Height = 24;
            this.rjDataPe.Size = new System.Drawing.Size(563, 360);
            this.rjDataPe.TabIndex = 1;
            // 
            // rjBPe
            // 
            this.rjBPe.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjBPe.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rjBPe.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjBPe.BorderRadius = 15;
            this.rjBPe.BorderSize = 0;
            this.rjBPe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjBPe.FlatAppearance.BorderSize = 0;
            this.rjBPe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjBPe.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.rjBPe.ForeColor = System.Drawing.Color.White;
            this.rjBPe.Location = new System.Drawing.Point(625, 177);
            this.rjBPe.Name = "rjBPe";
            this.rjBPe.Size = new System.Drawing.Size(116, 38);
            this.rjBPe.TabIndex = 23;
            this.rjBPe.Text = "Automatic";
            this.rjBPe.TextColor = System.Drawing.Color.White;
            this.rjBPe.UseVisualStyleBackColor = false;
            this.rjBPe.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // rjButton_V
            // 
            this.rjButton_V.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton_V.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton_V.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton_V.BorderRadius = 15;
            this.rjButton_V.BorderSize = 0;
            this.rjButton_V.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjButton_V.FlatAppearance.BorderSize = 0;
            this.rjButton_V.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton_V.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.rjButton_V.ForeColor = System.Drawing.Color.White;
            this.rjButton_V.Location = new System.Drawing.Point(346, 177);
            this.rjButton_V.Name = "rjButton_V";
            this.rjButton_V.Size = new System.Drawing.Size(120, 39);
            this.rjButton_V.TabIndex = 24;
            this.rjButton_V.Text = "Execute";
            this.rjButton_V.TextColor = System.Drawing.Color.White;
            this.rjButton_V.UseVisualStyleBackColor = false;
            this.rjButton_V.Click += new System.EventHandler(this.rjButton_V_Click);
            // 
            // rjButton_pe
            // 
            this.rjButton_pe.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton_pe.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton_pe.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton_pe.BorderRadius = 15;
            this.rjButton_pe.BorderSize = 0;
            this.rjButton_pe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjButton_pe.FlatAppearance.BorderSize = 0;
            this.rjButton_pe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton_pe.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.rjButton_pe.ForeColor = System.Drawing.Color.White;
            this.rjButton_pe.Location = new System.Drawing.Point(923, 176);
            this.rjButton_pe.Name = "rjButton_pe";
            this.rjButton_pe.Size = new System.Drawing.Size(120, 39);
            this.rjButton_pe.TabIndex = 25;
            this.rjButton_pe.Text = "Execute";
            this.rjButton_pe.TextColor = System.Drawing.Color.White;
            this.rjButton_pe.UseVisualStyleBackColor = false;
            this.rjButton_pe.Click += new System.EventHandler(this.rjButton_pe_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Location = new System.Drawing.Point(564, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 579);
            this.panel1.TabIndex = 26;
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
            this.rjPictureRounded4.Location = new System.Drawing.Point(1120, 1);
            this.rjPictureRounded4.Name = "rjPictureRounded4";
            this.rjPictureRounded4.Size = new System.Drawing.Size(18, 18);
            this.rjPictureRounded4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjPictureRounded4.TabIndex = 27;
            this.rjPictureRounded4.TabStop = false;
            this.rjPictureRounded4.Click += new System.EventHandler(this.rjPictureRounded4_Click);
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
            this.rjPictureRounded6.Location = new System.Drawing.Point(1099, 1);
            this.rjPictureRounded6.Name = "rjPictureRounded6";
            this.rjPictureRounded6.Size = new System.Drawing.Size(18, 18);
            this.rjPictureRounded6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjPictureRounded6.TabIndex = 28;
            this.rjPictureRounded6.TabStop = false;
            this.rjPictureRounded6.Click += new System.EventHandler(this.rjPictureRounded6_Click);
            // 
            // rjV
            // 
            this.rjV.BlockGetText = false;
            this.rjV.Location = new System.Drawing.Point(0, 2);
            this.rjV.Name = "rjV";
            this.rjV.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rjV.Size = new System.Drawing.Size(508, 158);
            this.rjV.TabIndex = 29;
            this.rjV.Text = "";
            // 
            // rjPe
            // 
            this.rjPe.BlockGetText = false;
            this.rjPe.Location = new System.Drawing.Point(581, 2);
            this.rjPe.Name = "rjPe";
            this.rjPe.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rjPe.Size = new System.Drawing.Size(512, 158);
            this.rjPe.TabIndex = 30;
            this.rjPe.Text = "";
            // 
            // FormM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 584);
            this.Controls.Add(this.rjPe);
            this.Controls.Add(this.rjV);
            this.Controls.Add(this.rjPictureRounded6);
            this.Controls.Add(this.rjPictureRounded4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rjButton_pe);
            this.Controls.Add(this.rjButton_V);
            this.Controls.Add(this.rjBPe);
            this.Controls.Add(this.rjDataPe);
            this.Controls.Add(this.rjDataV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormM";
            this.Text = "FormM";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormM_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.rjDataV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rjDataPe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rjPictureRounded4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rjPictureRounded6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.RJDataGridView rjDataV;
        private Controls.RJDataGridView rjDataPe;
        private Controls.RJButton rjBPe;
        private Controls.RJButton rjButton_V;
        private Controls.RJButton rjButton_pe;
        private System.Windows.Forms.Panel panel1;
        private Controls.RJPictureRounded rjPictureRounded4;
        private Controls.RJPictureRounded rjPictureRounded6;
        private Controls.RJTextBoxSQL rjV;
        private Controls.RJTextBoxSQL rjPe;
    }
}