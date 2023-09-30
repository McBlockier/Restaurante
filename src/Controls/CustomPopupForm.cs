using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Palacio_el_restaurante.src.Controls
{
    public class CustomPopupForm : Form
    {
        private RichTextBox richTextBox;
        private Button zoomInButton;
        private Button zoomOutButton;
        public string SelectedText { get; private set; }

        private int zoomLevel = 100;
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
        public CustomPopupForm(string documentationText)
        {
            // Configuración de la ventana emergente
            this.Text = "PopupForm";
            this.Size = new Size(600, 400);
            this.Opacity = 0; // Establecer la opacidad inicial en 0 (invisible)

            // Crear el RichTextBox para mostrar la documentación
            richTextBox = new RichTextBox();
            richTextBox.Dock = DockStyle.Fill;
            richTextBox.Text = documentationText;
            richTextBox.ZoomFactor = zoomLevel / 100f; // Establecer el nivel de zoom inicial
            richTextBox.ReadOnly = true;

            // Botón de zoom in
            zoomInButton = new Button();
            zoomInButton.Text = "Zoom In (+)";
            zoomInButton.Dock = DockStyle.Bottom;
            zoomInButton.Click += ZoomInButton_Click;

            // Botón de zoom out
            zoomOutButton = new Button();
            zoomOutButton.Text = "Zoom Out (-)";
            zoomOutButton.Dock = DockStyle.Bottom;
            zoomOutButton.Click += ZoomOutButton_Click;

            // Agregar controles al formulario
            this.Controls.Add(richTextBox);
            this.Controls.Add(zoomInButton);
            this.Controls.Add(zoomOutButton);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Aplicar una animación suave al mostrar el formulario
            AnimateFormIn();
        }

        private async void AnimateFormIn()
        {
            const int animationDuration = 500; // Duración de la animación en milisegundos
            const double targetOpacity = 1.0; // Opacidad final

            for (int i = 0; i <= animationDuration; i += 10)
            {
                double opacity = i / (double)animationDuration * targetOpacity;
                this.Opacity = opacity;
                await System.Threading.Tasks.Task.Delay(10); // Pequeño retraso para la animación suave
            }

            this.Opacity = targetOpacity; // Asegurarse de que la opacidad sea exactamente 1.0 al final de la animación
        }

        private void ZoomInButton_Click(object sender, EventArgs e)
        {
            // Incrementar el nivel de zoom
            zoomLevel += 10;
            richTextBox.ZoomFactor = zoomLevel / 100f;

            // Actualizar la propiedad SelectedText
            SelectedText = richTextBox.SelectedText;
        }

        private void ZoomOutButton_Click(object sender, EventArgs e)
        {
            // Decrementar el nivel de zoom
            if (zoomLevel > 10)
            {
                zoomLevel -= 10;
                richTextBox.ZoomFactor = zoomLevel / 100f;

                // Actualizar la propiedad SelectedText
                SelectedText = richTextBox.SelectedText;
            }
        }
    }
}