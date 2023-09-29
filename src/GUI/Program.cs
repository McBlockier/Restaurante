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
            
            Application.Run(new LoginFrame());
        }

    }
}
