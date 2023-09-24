using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palacio_el_restaurante.src.Controls
{
    public class CustomLinkLabel : Control
    {
        private Color linkColor = Color.Blue;
        private Color hoverColor = Color.Red;
        private bool isHovered = false;
        private int animationDuration = 200; // Duración de la animación en milisegundos
        private int animationSteps = 10;     // Número de pasos en la animación
        private Timer animationTimer;

        public event EventHandler LinkClicked;
        public event EventHandler HoverStateChanged;

        public CustomLinkLabel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Cursor = Cursors.Hand;

            animationTimer = new Timer();
            animationTimer.Interval = animationDuration / animationSteps;
            animationTimer.Tick += AnimationTimer_Tick;
        }

        public Color LinkColor
        {
            get { return linkColor; }
            set { linkColor = value; Invalidate(); }
        }

        public Color HoverColor
        {
            get { return hoverColor; }
            set { hoverColor = value; Invalidate(); }
        }

        public bool UnderlineOnHover { get; set; } = true;
        public bool BoldOnHover { get; set; } = false;
        public string LinkText { get; set; } = "";

        // Propiedades para animaciones personalizables
        public int AnimationDuration
        {
            get { return animationDuration; }
            set { animationDuration = value; }
        }

        public int AnimationSteps
        {
            get { return animationSteps; }
            set { animationSteps = value; }
        }

        public void StartAnimation()
        {
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            int deltaR = (hoverColor.R - linkColor.R) / animationSteps;
            int deltaG = (hoverColor.G - linkColor.G) / animationSteps;
            int deltaB = (hoverColor.B - linkColor.B) / animationSteps;

            linkColor = Color.FromArgb(linkColor.R + deltaR, linkColor.G + deltaG, linkColor.B + deltaB);
            Invalidate();

            if (linkColor == hoverColor)
            {
                animationTimer.Stop();
                HoverStateChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isHovered = true;
            if (UnderlineOnHover)
                Font = new Font(Font, FontStyle.Underline);
            if (BoldOnHover)
                Font = new Font(Font, FontStyle.Bold);
            StartAnimation();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isHovered = false;
            Font = new Font(Font, FontStyle.Regular);
            StartAnimation();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (LinkClicked != null)
                LinkClicked(this, EventArgs.Empty);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var textColor = isHovered ? linkColor : hoverColor;
            var textFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            e.Graphics.DrawString(LinkText, Font, new SolidBrush(textColor), ClientRectangle, textFormat);
        }
    }
}
