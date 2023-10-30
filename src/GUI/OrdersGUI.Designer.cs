namespace Palacio_el_restaurante.src.GUI
{
    partial class OrdersGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdersGUI));
            this.rjPanel1 = new Palacio_el_restaurante.src.Controls.RjPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.rjPictureRounded1 = new Palacio_el_restaurante.src.Controls.RJPictureRounded();
            this.panelOrders = new System.Windows.Forms.Panel();
            this.rjPictureRounded4 = new Palacio_el_restaurante.src.Controls.RJPictureRounded();
            this.rjDataOrders = new Palacio_el_restaurante.src.Controls.RJDataGridView();
            this.rjDone = new Palacio_el_restaurante.src.Controls.RJButton();
            this.rjPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rjPictureRounded1)).BeginInit();
            this.panelOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rjPictureRounded4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rjDataOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // rjPanel1
            // 
            this.rjPanel1.BorderColor = System.Drawing.Color.Blue;
            this.rjPanel1.BorderRadius = 15;
            this.rjPanel1.BorderThickness = 2F;
            this.rjPanel1.Controls.Add(this.label1);
            this.rjPanel1.Controls.Add(this.rjPictureRounded1);
            this.rjPanel1.Location = new System.Drawing.Point(1, 1);
            this.rjPanel1.Name = "rjPanel1";
            this.rjPanel1.Size = new System.Drawing.Size(117, 483);
            this.rjPanel1.TabIndex = 0;
            this.rjPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rjPanel1_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Deliveries";
            // 
            // rjPictureRounded1
            // 
            this.rjPictureRounded1.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjPictureRounded1.BorderColor = System.Drawing.Color.RoyalBlue;
            this.rjPictureRounded1.BorderColor2 = System.Drawing.Color.HotPink;
            this.rjPictureRounded1.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjPictureRounded1.BorderSize = 2;
            this.rjPictureRounded1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjPictureRounded1.GradientAngle = 50F;
            this.rjPictureRounded1.Image = global::Palacio_el_restaurante.Properties.Resources.caja_de_entrega__1_;
            this.rjPictureRounded1.Location = new System.Drawing.Point(26, 32);
            this.rjPictureRounded1.Name = "rjPictureRounded1";
            this.rjPictureRounded1.Size = new System.Drawing.Size(59, 59);
            this.rjPictureRounded1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjPictureRounded1.TabIndex = 0;
            this.rjPictureRounded1.TabStop = false;
            // 
            // panelOrders
            // 
            this.panelOrders.Controls.Add(this.rjPictureRounded4);
            this.panelOrders.Controls.Add(this.rjDataOrders);
            this.panelOrders.Controls.Add(this.rjDone);
            this.panelOrders.Location = new System.Drawing.Point(117, 1);
            this.panelOrders.Name = "panelOrders";
            this.panelOrders.Size = new System.Drawing.Size(753, 483);
            this.panelOrders.TabIndex = 1;
            this.panelOrders.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelOrders_MouseMove);
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
            this.rjPictureRounded4.Location = new System.Drawing.Point(725, 1);
            this.rjPictureRounded4.Name = "rjPictureRounded4";
            this.rjPictureRounded4.Size = new System.Drawing.Size(18, 18);
            this.rjPictureRounded4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjPictureRounded4.TabIndex = 4;
            this.rjPictureRounded4.TabStop = false;
            this.rjPictureRounded4.Click += new System.EventHandler(this.rjPictureRounded4_Click);
            // 
            // rjDataOrders
            // 
            this.rjDataOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rjDataOrders.Location = new System.Drawing.Point(3, 22);
            this.rjDataOrders.Name = "rjDataOrders";
            this.rjDataOrders.RowHeadersWidth = 51;
            this.rjDataOrders.RowTemplate.Height = 24;
            this.rjDataOrders.Size = new System.Drawing.Size(744, 299);
            this.rjDataOrders.TabIndex = 1;
            this.rjDataOrders.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rjDataOrders_MouseMove);
            // 
            // rjDone
            // 
            this.rjDone.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjDone.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rjDone.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjDone.BorderRadius = 20;
            this.rjDone.BorderSize = 0;
            this.rjDone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjDone.FlatAppearance.BorderSize = 0;
            this.rjDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjDone.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.rjDone.ForeColor = System.Drawing.Color.White;
            this.rjDone.Location = new System.Drawing.Point(577, 433);
            this.rjDone.Name = "rjDone";
            this.rjDone.Size = new System.Drawing.Size(150, 40);
            this.rjDone.TabIndex = 0;
            this.rjDone.Text = "Delivered";
            this.rjDone.TextColor = System.Drawing.Color.White;
            this.rjDone.UseVisualStyleBackColor = false;
            this.rjDone.Click += new System.EventHandler(this.rjDone_Click);
            // 
            // OrdersGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 486);
            this.Controls.Add(this.panelOrders);
            this.Controls.Add(this.rjPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrdersGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrdersGUI";
            this.rjPanel1.ResumeLayout(false);
            this.rjPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rjPictureRounded1)).EndInit();
            this.panelOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rjPictureRounded4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rjDataOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.RjPanel rjPanel1;
        private System.Windows.Forms.Panel panelOrders;
        private Controls.RJPictureRounded rjPictureRounded1;
        private Controls.RJButton rjDone;
        private System.Windows.Forms.Label label1;
        private Controls.RJDataGridView rjDataOrders;
        private Controls.RJPictureRounded rjPictureRounded4;
    }
}