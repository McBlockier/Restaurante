using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace Palacio_el_restaurante.src.Controls
{
    internal class ModernCheckBox: CheckBox
    {

        private Color uncheckedColor = Color.White;
        private Color checkedColor = Color.Green;
        private Color checkmarkColor = Color.White;

        public ModernCheckBox()
        {
            Appearance = Appearance.Button;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 1;
            FlatAppearance.BorderColor = uncheckedColor;
            Cursor = Cursors.Hand;
        }

        public Color UncheckedColor
        {
            get { return uncheckedColor; }
            set
            {
                uncheckedColor = value;
                FlatAppearance.BorderColor = uncheckedColor;
            }
        }

        public Color CheckedColor
        {
            get { return checkedColor; }
            set { checkedColor = value; }
        }

        public Color CheckmarkColor
        {
            get { return checkmarkColor; }
            set { checkmarkColor = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Cambia el color de fondo cuando se marca o desmarca
            FlatAppearance.MouseDownBackColor = Checked ? checkedColor : uncheckedColor;

            // Cambia el color de la marca de verificación
            ControlPaint.DrawCheckBox(e.Graphics, ClientRectangle, Checked ? ButtonState.Checked : ButtonState.Normal);
            using (var checkmarkPen = new Pen(checkmarkColor, 2))
            {
                e.Graphics.DrawLine(checkmarkPen, 6, Height / 2 - 3, Width / 2 - 2, Height - 5);
                e.Graphics.DrawLine(checkmarkPen, Width / 2 - 2, Height - 5, Width - 5, 5);
            }
        }

    }
}
