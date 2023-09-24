using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palacio_el_restaurante.src.Controls
{
    public static class GraphicsExtensions
    {
        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, Rectangle bounds, int cornerRadius)
        {
            int diameter = cornerRadius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            graphics.DrawArc(pen, arc, 180, 90);
            arc.X = bounds.Right - diameter;
            graphics.DrawArc(pen, arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            graphics.DrawArc(pen, arc, 0, 90);
            arc.X = bounds.Left;
            graphics.DrawArc(pen, arc, 90, 90);
            graphics.DrawLine(pen, bounds.Left + cornerRadius, bounds.Top, bounds.Right - cornerRadius, bounds.Top);
            graphics.DrawLine(pen, bounds.Left + cornerRadius, bounds.Bottom, bounds.Right - cornerRadius, bounds.Bottom);
            graphics.DrawLine(pen, bounds.Left, bounds.Top + cornerRadius, bounds.Left, bounds.Bottom - cornerRadius);
            graphics.DrawLine(pen, bounds.Right, bounds.Top + cornerRadius, bounds.Right, bounds.Bottom - cornerRadius);
        }
    }
}
