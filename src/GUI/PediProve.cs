using CustomMessageBox;
using Palacio_el_restaurante.src.Conection;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Palacio_el_restaurante.src.GUI
{
    public partial class PediProve : Form
    {
        public String userValid { get; set; }
        public int xClick = 0, yClick = 0;
        public Boolean value;
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
        public PediProve()
        {
            InitializeComponent();
            fillBox();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        public void fillBoxV()
        {
            rjPe.Items.Clear();
            rjPe.Items.Add("Update");
            rjPe.Items.Add("Add Up");
            rjDelete.Visible = false;
            rjDelete.Enabled = false;
        }
        private void fillBox()
        {

            if (value)
            {
                rjPe.Items.Clear();
                rjPe.Items.Add("Update");
                rjPe.Items.Add("Add Up");
            }
            else
            {
                rjPe.Items.Clear();
                rjPe.Items.Add("Update");
                rjPe.Items.Add("Delete");
                rjPe.Items.Add("Add Up");
            }

        }
        private void rjAdd_Click(object sender, EventArgs e)
        {
            string contra = getContra.Text;
            string idPed = getIdPed.Text;
            string repNam = getNam.Text;
            InquiriesDB Db = new InquiriesDB();
            bool success = Db.AcctionProve("Add Up", contra, idPed, repNam);

            if (success)
            {
                RJMessageBox.Show("Éxito", "El registro se ha agregado correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getContra.Text = "";
                getIdPed.Text = "";
                getNam.Text = "";
            }
            else
            {
                RJMessageBox.Show("Error", "Hubo un problema al agregar el registro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rjUpdate_Click(object sender, EventArgs e)
        {
            string contra = getContra.Text;
            string idPed = getIdPed.Text;
            string repNam = getNam.Text;
            InquiriesDB Db = new InquiriesDB();
            bool success = Db.AcctionProve("Update", contra, idPed, repNam);

            if (success)
            {
                RJMessageBox.Show("Éxito", "El registro se ha actualizado correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                getContra.Text = "";
                getIdPed.Text = "";
                getNam.Text = "";
            }
            else
            {
                RJMessageBox.Show("Error", "Hubo un problema al actualizar el registro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rjDelete_Click(object sender, EventArgs e)
        {
            string contra = getContra.Text;
            InquiriesDB Db = new InquiriesDB();
            bool success = Db.AcctionProve("Delete", contra, "", "");

            if (success)
            {
                RJMessageBox.Show("Éxito", "El registro se ha eliminado correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getContra.Text = "";
            }
            else
            {
                RJMessageBox.Show("Error", "Hubo un problema al eliminar el registro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PediProve_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void rjPictureRounded4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void rjPictureRounded6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void rjPe_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rjPe.SelectedItem as String)
            {
                case "Update":
                    rjAdd.Visible = false;
                    rjDelete.Visible = false;
                    rjUpdate.Visible = true;
                    break;
                case "Add Up":
                    rjAdd.Visible = true;
                    rjDelete.Visible = false;
                    rjUpdate.Visible = false;
                    break;
                case "Delete":
                    rjAdd.Visible = false;
                    rjDelete.Visible = true;
                    rjUpdate.Visible = false;
                    break;
            }
        }
    }
}
