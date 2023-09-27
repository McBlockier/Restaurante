using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SortOrder = System.Windows.Forms.SortOrder;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Threading;
using MySql.Data.MySqlClient;

namespace Palacio_el_restaurante.src.Controls
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    internal class CustomPopupForm : Form
    {
        private RichTextBox richTextBox;
        private Button zoomInButton;
        private Button zoomOutButton;

        private int zoomLevel = 100;

        public CustomPopupForm(string documentationText)
        {
            // Configuración de la ventana emergente
            this.Text = "Documentación de RJDataGridView";
            this.Size = new Size(600, 400);

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

        private void ZoomInButton_Click(object sender, EventArgs e)
        {
            // Incrementar el nivel de zoom
            zoomLevel += 10;
            richTextBox.ZoomFactor = zoomLevel / 100f;
        }

        private void ZoomOutButton_Click(object sender, EventArgs e)
        {
            // Decrementar el nivel de zoom
            if (zoomLevel > 10)
            {
                zoomLevel -= 10;
                richTextBox.ZoomFactor = zoomLevel / 100f;
            }
        }
    }


    public class RJDataGridView : DataGridView
    {
        private Button exportToExcelButton;
        private SortOrder sortOrder = SortOrder.None;
        private BindingSource bindingSource;
        private MySqlConnection databaseConnection;


        public RJDataGridView()
        {
            InitializeCustomStyles();
            InitializeSorting();
            InitializeExportToExcelButton();
        }

        private void InitializeExportToExcelButton()
        {
            exportToExcelButton = new Button();
            exportToExcelButton.Text = "Exportar a Excel";
            exportToExcelButton.Width = 100;
            exportToExcelButton.Height = 30;
            exportToExcelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            exportToExcelButton.Visible = false;
            exportToExcelButton.Click += ExportToExcelButton_Click;
            Controls.Add(exportToExcelButton);
        }
        public void SetDatabaseConnection(MySqlConnection customConnection)
        {
            databaseConnection = customConnection;
        }
        public void ExecuteSqlQuery(string sqlQuery)
        {
            if (string.IsNullOrEmpty(sqlQuery))
            {
                MessageBox.Show("La consulta SQL está vacía.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (databaseConnection == null)
            {
                MessageBox.Show("La conexión a la base de datos no está configurada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (databaseConnection.State == ConnectionState.Closed)
            {
                databaseConnection.Open();
            }

            using (MySqlCommand cmd = new MySqlCommand(sqlQuery, databaseConnection))
            {
                DataTable dataTable = new DataTable();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }

                if (dataTable.Rows.Count > 0)
                {
                    LoadData(dataTable);
                }
                else
                {
                    MessageBox.Show("No se encontraron resultados para la consulta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (databaseConnection.State == ConnectionState.Open)
            {
                databaseConnection.Close();
            }
        }

        private void ExportToExcelButton_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void InitializeCustomStyles()
        {
            if (this.Parent != null)
            {
                DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
                headerStyle.BackColor = Color.FromArgb(63, 81, 181); // Color de encabezado azul
                headerStyle.ForeColor = Color.White;
                headerStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);

                this.ColumnHeadersDefaultCellStyle = headerStyle;

                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                cellStyle.BackColor = this.Parent.BackColor; // Color de fondo de las celdas
                cellStyle.ForeColor = Color.Blue; // Color de texto azul
                cellStyle.Font = new Font("Segoe UI", 12);
                cellStyle.SelectionBackColor = Color.FromArgb(192, 192, 255);
                cellStyle.SelectionForeColor = Color.Black;
                cellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                cellStyle.WrapMode = DataGridViewTriState.True;
                cellStyle.Padding = new Padding(6);

                this.DefaultCellStyle = cellStyle;

                this.BackgroundColor = this.Parent.BackColor;
                this.BorderStyle = BorderStyle.None;
                this.EnableHeadersVisualStyles = false;
                this.GridColor = Color.FromArgb(224, 224, 224);

                foreach (DataGridViewColumn column in Columns)
                {
                    column.DefaultCellStyle = cellStyle;
                }

                DoubleBuffered = true;
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                SetStyle(ControlStyles.UserPaint, true);
                UpdateStyles();
            }
        }


        private void InitializeSorting()
        {
            this.ColumnHeaderMouseClick += CustomDataGridView_ColumnHeaderMouseClick;
        }

        private void CustomDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn clickedColumn = this.Columns[e.ColumnIndex];

            if (sortOrder == SortOrder.Ascending)
            {
                clickedColumn.HeaderCell.SortGlyphDirection = SortOrder.Descending;
                sortOrder = SortOrder.Descending;
            }
            else
            {
                clickedColumn.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                sortOrder = SortOrder.Ascending;
            }

            SortByColumn(clickedColumn.Name, sortOrder);
        }

        private void SortByColumn(string columnName, SortOrder sortOrder)
        {
            if (bindingSource != null)
            {
                DataView dataView = (DataView)bindingSource.List;
                dataView.Sort = columnName + (sortOrder == SortOrder.Ascending ? " ASC" : " DESC");
            }
        }

        public void LoadData(DataTable dataTable)
        {
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;
            this.DataSource = bindingSource;
            exportToExcelButton.Visible = true;
        }

        private void ExportToExcel()
        {
            try
            {
                if (this.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar a Excel.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Guardar datos en Excel";
                saveFileDialog.DefaultExt = "xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    using (var package = new ExcelPackage(new FileInfo(filePath)))
                    {
                        var worksheet = package.Workbook.Worksheets.Add("Datos");
                        worksheet.Cells["A1"].LoadFromDataTable(bindingSource.DataSource as DataTable, PrintHeaders: true);
                        worksheet.Cells.AutoFitColumns();
                        worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        worksheet.Cells.Style.WrapText = true;

                        package.Save();
                    }

                    MessageBox.Show($"Los datos se han exportado exitosamente en '{filePath}'.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar los datos a Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ShowExportToExcelButton(bool show)
        {
            exportToExcelButton.Visible = show;
        }

        public void Documentation()
        {
            string documentation = @"
        *** Documentación de RJDataGridView ***

        RJDataGridView es una extensión personalizada de DataGridView
        que proporciona características adicionales y estilos personalizados.

        - Constructor RJDataGridView:
          - Uso: Crea una instancia de RJDataGridView.

        - Método SetDatabaseConnection(MySqlConnection customConnection):
          - Uso: Establece una conexión personalizada a la base de datos MySQL.
          - Ejemplo: 
            MySqlConnection customConnection = new MySqlConnection(""TuCadenaDeConexion"");
            dataGridView.SetDatabaseConnection(customConnection);

        - Método ExecuteSqlQuery(string sqlQuery):
          - Uso: Ejecuta una consulta SQL y carga los resultados en el control.
          - Ejemplo:
            string sqlQuery = ""SELECT * FROM TuTabla"";
            dataGridView.ExecuteSqlQuery(sqlQuery);

        - Método ShowExportToExcelButton(bool show):
          - Uso: Controla la visibilidad del botón ""Exportar a Excel"".
          - Ejemplo:
            dataGridView.ShowExportToExcelButton(true);

        - Evento ExportToExcelButton_Click:
          - Uso: Se activa al hacer clic en el botón ""Exportar a Excel"".

        - Exportación a Excel:
          - Método ExportToExcel(): Exporta los datos a un archivo Excel.
          - Método LoadData(DataTable dataTable): Carga datos en el control desde una DataTable.

        - Estilos y Configuración de Estilos:
          - Método InitializeCustomStyles(): Establece estilos personalizados.
          - Métodos relacionados con la ordenación de columnas.

        *** Ejemplos de Uso ***

        Ejemplo 1: Cargar y Mostrar Datos desde una Base de Datos MySQL
        ------------------------------------------------------------------------
        // Establecer la conexión a la base de datos MySQL
        MySqlConnection customConnection = new MySqlConnection(""TuCadenaDeConexion"");
        dataGridView.SetDatabaseConnection(customConnection);

        // Ejecutar una consulta SQL y cargar los resultados
        string sqlQuery = ""SELECT * FROM TuTabla"";
        dataGridView.ExecuteSqlQuery(sqlQuery);

        // Mostrar u ocultar el botón de exportación a Excel
        dataGridView.ShowExportToExcelButton(true);

        Ejemplo 2: Exportar Datos a Excel
        ------------------------------------------------------------------------
        // Exportar los datos a Excel al hacer clic en el botón
        dataGridView.ExportToExcel();

        Ejemplo 3: Personalizar los Estilos
        ------------------------------------------------------------------------
        // Cambiar el color de fondo de las celdas
        dataGridView.DefaultCellStyle.BackColor = Color.LightGray;

        // Cambiar el color del texto en las celdas
        dataGridView.DefaultCellStyle.ForeColor = Color.Black;

        // Cambiar el color de fondo de los encabezados de columna
        dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(63, 81, 181);

        // Cambiar el color del texto en los encabezados de columna
        dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        // Ocultar la columna de índice 0
        dataGridView.Columns[0].Visible = false;

        Ejemplo 4: Ordenar Columnas al Hacer Clic en los Encabezados
        ------------------------------------------------------------------------
        // Los encabezados de columna serán clicables para ordenar
        // automáticamente ascendente/descendente al hacer clic en ellos.

        Para obtener más detalles y ejemplos, utilice el método Documentation().
        ";

            CustomPopupForm popupForm = new CustomPopupForm(documentation);
            popupForm.ShowDialog();
        }




    }
 }
