namespace Palacio_el_restaurante.src.GUI
{
    partial class AdminIU
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
            this.rjPanel1 = new Palacio_el_restaurante.src.Controls.RjPanel();
            this.SuspendLayout();
            // 
            // rjPanel1
            // 
            this.rjPanel1.BorderColor = System.Drawing.Color.Black;
            this.rjPanel1.BorderRadius = 10;
            this.rjPanel1.Location = new System.Drawing.Point(0, 3);
            this.rjPanel1.Name = "rjPanel1";
            this.rjPanel1.Size = new System.Drawing.Size(107, 697);
            this.rjPanel1.TabIndex = 0;
            // 
            // AdminIU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1004, 701);
            this.Controls.Add(this.rjPanel1);
            this.Name = "AdminIU";
            this.Text = "AdminIU";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.RjPanel rjPanel1;
    }
}