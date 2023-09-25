using Palacio_el_restaurante.src.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palacio_el_restaurante
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            List<Form> hiddenForms = new List<Form>();
            using (LoginFrame login = new LoginFrame())
            {
                login.FormClosed += (sender, e) =>
                {
                    hiddenForms.Remove(login);
                    ReleaseResources(login);
                };

                hiddenForms.Add(login);
                Application.Run(login);
            }
            LoginCreateA loginCreateA = new LoginCreateA();
            LoginReset loginReset = new LoginReset();
            FoodUI foodUI = new FoodUI();

            loginCreateA.FormClosed += (sender, e) => ReleaseResources(loginCreateA);
            loginReset.FormClosed += (sender, e) => ReleaseResources(loginReset);
            foodUI.FormClosed += (sender, e) => ReleaseResources(foodUI);

            foreach (var form in hiddenForms)
            {
                ReleaseResources(form);
            }
        }

        private static void ReleaseResources(Form form)
        {
            form.Dispose();

            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }

    }
}
