using System.Drawing;
using System.Windows.Forms;

namespace Palacio_el_restaurante.src.Controls
{
    public class RjPanel : Panel
    {

        private int borderRadius = 10;
        private Color borderColor = Color.Black;

        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                Invalidate();
            }
        }
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        public RjPanel()
        {
            DoubleBuffered = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (var brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }

            using (var pen = new Pen(borderColor, 2))
            {
                Rectangle rect = ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;
                e.Graphics.DrawRoundedRectangle(pen, rect, borderRadius);
            }
        }
        //Fin de la clase
    }
}
