using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace Palacio_el_restaurante.src.Controls
{
    public enum CustomProgressBarStyle
    {
        Horizontal,
        Circular,
        Spinner
    }
    internal class RJProgressBar : Control
    {
        private int minimum = 0;
        private int maximum = 100;
        private int value = 0;
        private CustomProgressBarStyle progressBarStyle = CustomProgressBarStyle.Horizontal;
        private System.Timers.Timer spinnerTimer;
        private int spinnerAngle = 0;
        private Bitmap circularProgressBarCache; // Cache para ProgressBar circular

        public RJProgressBar()
        {
            SetStyle(ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            spinnerTimer = new System.Timers.Timer(50);
            spinnerTimer.Elapsed += SpinnerTimer_Elapsed;
        }

        public int Minimum
        {
            get { return minimum; }
            set { minimum = value; Invalidate(); }
        }

        public int Maximum
        {
            get { return maximum; }
            set { maximum = value; Invalidate(); }
        }

        public int Value
        {
            get { return value; }
            set
            {
                if (value < minimum) value = minimum;
                if (value > maximum) value = maximum;
                this.value = value;
                Invalidate();
            }
        }

        public CustomProgressBarStyle ProgressBarStyle
        {
            get { return progressBarStyle; }
            set
            {
                progressBarStyle = value;
                if (progressBarStyle == CustomProgressBarStyle.Spinner)
                {
                    spinnerTimer.Start();
                }
                else
                {
                    spinnerTimer.Stop();
                }
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            switch (ProgressBarStyle)
            {
                case CustomProgressBarStyle.Horizontal:
                    DrawHorizontalProgressBar(e.Graphics);
                    break;
                case CustomProgressBarStyle.Circular:
                    DrawCircularProgressBar(e.Graphics);
                    break;
                case CustomProgressBarStyle.Spinner:
                    DrawSpinnerProgressBar(e.Graphics);
                    break;
            }
        }

        private void DrawHorizontalProgressBar(Graphics g)
        {
            float percent = (float)(value - minimum) / (maximum - minimum);
            int fillWidth = (int)(percent * Width);

            g.FillRectangle(SystemBrushes.Control, 0, 0, Width, Height);
            g.FillRectangle(Brushes.Blue, 0, 0, fillWidth, Height);
            g.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
        }

        private void DrawCircularProgressBar(Graphics g)
        {
            if (circularProgressBarCache == null || circularProgressBarCache.Size != Size)
            {
                // Crea una nueva imagen de caché si es nula o el tamaño cambió
                circularProgressBarCache?.Dispose();
                circularProgressBarCache = new Bitmap(Width, Height);
                using (Graphics cacheGraphics = Graphics.FromImage(circularProgressBarCache))
                {
                    int diameter = Math.Min(Width, Height);
                    int radius = diameter / 2;
                    int centerX = Width / 2;
                    int centerY = Height / 2;

                    cacheGraphics.FillEllipse(Brushes.LightGray, centerX - radius, centerY - radius, diameter, diameter);
                    cacheGraphics.DrawEllipse(Pens.Gray, centerX - radius, centerY - radius, diameter - 1, diameter - 1);

                    float percent = (float)(value - minimum) / (maximum - minimum);
                    int angle = (int)(360 * percent);

                    RectangleF gradientRect = new RectangleF(centerX - radius, centerY - radius, diameter, diameter);
                    using (PathGradientBrush pgb = new PathGradientBrush(new GraphicsPath()))
                    {
                        pgb.CenterPoint = new PointF(centerX, centerY);
                        pgb.SurroundColors = new Color[] { Color.LightGray };
                        pgb.CenterColor = Color.Blue;

                        GraphicsPath path = new GraphicsPath();
                        path.AddArc(gradientRect, -90, angle);
                        pgb.FocusScales = new PointF(0f, 0f);
                        cacheGraphics.FillPath(pgb, path);
                    }
                    cacheGraphics.DrawEllipse(Pens.Black, centerX - radius, centerY - radius, diameter - 1, diameter - 1);
                }
            }

            // Dibuja la imagen de caché
            g.DrawImage(circularProgressBarCache, 0, 0);
        }

        private void DrawSpinnerProgressBar(Graphics g)
        {
            int diameter = Math.Min(Width, Height);
            int radius = diameter / 2;
            int centerX = Width / 2;
            int centerY = Height / 2;

            g.FillEllipse(Brushes.LightGray, centerX - radius, centerY - radius, diameter, diameter);
            g.DrawEllipse(Pens.Gray, centerX - radius, centerY - radius, diameter - 1, diameter - 1);

            int spinnerRadius = radius / 2;
            int spinnerX = centerX + (int)(spinnerRadius * Math.Cos(spinnerAngle * Math.PI / 180));
            int spinnerY = centerY + (int)(spinnerRadius * Math.Sin(spinnerAngle * Math.PI / 180));

            g.FillEllipse(Brushes.Blue, spinnerX - 5, spinnerY - 5, 10, 10);

            spinnerAngle = (spinnerAngle + 10) % 360;
        }

        private void SpinnerTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Liberar recursos cuando se dispose el control
                spinnerTimer?.Dispose();
                circularProgressBarCache?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
