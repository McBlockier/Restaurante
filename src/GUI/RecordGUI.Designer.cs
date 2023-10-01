namespace Palacio_el_restaurante.src.GUI
{
    partial class RecordGUI
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
            this.rjPictureRounded4 = new Palacio_el_restaurante.src.Controls.RJPictureRounded();
            this.rjDataV = new Palacio_el_restaurante.src.Controls.RJDataGridView();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rjPictureRounded4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rjDataV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
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
            this.rjPictureRounded4.Location = new System.Drawing.Point(777, 1);
            this.rjPictureRounded4.Name = "rjPictureRounded4";
            this.rjPictureRounded4.Size = new System.Drawing.Size(18, 18);
            this.rjPictureRounded4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjPictureRounded4.TabIndex = 3;
            this.rjPictureRounded4.TabStop = false;
            this.rjPictureRounded4.Click += new System.EventHandler(this.rjPictureRounded4_Click);
            // 
            // rjDataV
            // 
            this.rjDataV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rjDataV.Location = new System.Drawing.Point(1, 119);
            this.rjDataV.Name = "rjDataV";
            this.rjDataV.RowHeadersWidth = 51;
            this.rjDataV.RowTemplate.Height = 24;
            this.rjDataV.Size = new System.Drawing.Size(799, 331);
            this.rjDataV.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::Palacio_el_restaurante.Properties.Resources.desplazarse;
            this.pictureBox3.Location = new System.Drawing.Point(12, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(72, 76);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Heavy", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(90, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 36);
            this.label1.TabIndex = 5;
            this.label1.Text = "Record";
            // 
            // RecordGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.rjPictureRounded4);
            this.Controls.Add(this.rjDataV);
            this.Name = "RecordGUI";
            this.Text = "RecordGUI";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RecordGUI_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.rjPictureRounded4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rjDataV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.RJDataGridView rjDataV;
        private Controls.RJPictureRounded rjPictureRounded4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
    }
}