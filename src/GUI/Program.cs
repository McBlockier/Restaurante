using System;
using System.Windows.Forms;

namespace Palacio_el_restaurante
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoginFrame());
            }
            catch (Exception ex)
            {
                CustomMessageBox.RJMessageBox.Show($"An unhandled exception occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
