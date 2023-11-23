using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palacio_el_restaurante.src.GUI
{
    public class SettingsJSON
    {

        public bool Thread { get; set; }
        public bool Addi { get; set; }
        public bool Triggers { get; set; }
        public Color SelectedColor { get; set; }
        public String StyleFormat { get; set; }
        public String Format {  get; set; }
    }
}
