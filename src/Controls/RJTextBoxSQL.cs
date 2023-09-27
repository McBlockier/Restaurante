using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Palacio_el_restaurante.src.Controls
{
    public class RJTextBoxSQL : System.Windows.Forms.RichTextBox
    {

        private List<string> palabrasResaltadas = new List<string> {
        "SELECT", "select", "FROM", "from", "WHERE", "where", "INNER JOIN", "inner join",
        "LEFT JOIN", "left join", "RIGHT JOIN", "right join", "OUTER JOIN", "outer join",
        "GROUP BY", "group by", "HAVING", "having", "ORDER BY", "order by", "ASC", "asc",
        "DESC", "desc", "INSERT INTO", "insert into", "VALUES", "values",
        "UPDATE", "update", "SET", "set", "DELETE", "delete", "CREATE TABLE", "create table",
        "ALTER TABLE", "alter table", "DROP TABLE", "drop table", "AS", "as",
        "DISTINCT", "distinct", "COUNT", "count", "SUM", "sum", "AVG", "avg", "MAX", "max",
        "MIN", "min", "AND", "and", "OR", "or", "NOT", "not", "IN", "in", "LIKE", "like",
        "BETWEEN", "between", "NULL", "null", "IS NULL", "is null", "IS NOT NULL", "is not null",
        "UNION", "union", "ALL", "all", "CASE", "case", "WHEN", "when", "THEN", "then",
        "ELSE", "else", "END", "end"
};

        public int FirstVisibleLine { get; private set; }
        string textoActual = "";
        string text = "";

        public RJTextBoxSQL()
        {
            this.Multiline = true;
            this.ScrollBars = RichTextBoxScrollBars.Vertical;
            this.WordWrap = true;
            this.TextChanged += CustomRichTextBox_TextChanged;
            this.text += GetText(); // Almacena el texto inicial
        }
        private void CustomRichTextBox_TextChanged(object sender, EventArgs e)
        {
             textoActual = this.Text;
            ResaltarPalabrasYConvertirAMayusculas(textoActual);
        }

        private void ResaltarPalabrasYConvertirAMayusculas(string texto)
        {
            int inicioSeleccion = this.SelectionStart;
            int longitudSeleccion = this.SelectionLength;

            this.SuspendLayout();

            this.SelectAll();
            this.SelectionColor = Color.Black;
            this.SelectionFont = new Font(this.Font, FontStyle.Regular);

            foreach (var palabra in palabrasResaltadas)
            {
                int inicio = 0;
                int indice = texto.IndexOf(palabra, inicio, StringComparison.OrdinalIgnoreCase);

                while (indice != -1 && indice < inicioSeleccion + longitudSeleccion)
                {
                    int inicioPalabra = indice;
                    int finPalabra = indice + palabra.Length;

                    this.Select(inicioPalabra, palabra.Length);
                    this.SelectionColor = Color.Blue;
                    this.SelectionFont = new Font(this.Font, FontStyle.Bold);

                    texto = texto.Remove(inicioPalabra, palabra.Length);
                    texto = texto.Insert(inicioPalabra, palabra.ToUpper());

                    inicio = indice + palabra.Length;
                    indice = texto.IndexOf(palabra, inicio, StringComparison.OrdinalIgnoreCase);
                }
            }
            this.Select(inicioSeleccion, longitudSeleccion);

            this.ResumeLayout();
            ScrollToPosition(inicioSeleccion);
        }

        private void ScrollToPosition(int posicionScroll)
        {
            int linea = this.GetLineFromCharIndex(posicionScroll);
            int primeraLineaVisible = GetFirstVisibleLine();
            int nuevaLineaVisible = primeraLineaVisible + linea;
            this.FirstVisibleLine = nuevaLineaVisible;
        }

        private int GetFirstVisibleLine()
        {
            int primeraLineaVisible = this.GetLineFromCharIndex(this.GetCharIndexFromPosition(new Point(0, 0)));
            return primeraLineaVisible;
        }

        public string GetText()
        {
            string originalText = this.Text;
            Color colorActual = this.SelectionColor;
            Font fontActual = this.SelectionFont;

            this.SelectAll();
            this.SelectionColor = Color.Black;
            this.SelectionFont = new Font(this.Font, FontStyle.Regular);

            string textoCompleto = this.SelectedText;

            this.Select(0, 0); 
            this.SelectionColor = colorActual;
            this.SelectionFont = fontActual;
            this.Text = originalText;

            return textoCompleto;
        }
        public string GetAllText()
        {
            string originalText = this.Text;
            Color colorActual = this.SelectionColor;
            Font fontActual = this.SelectionFont;

            Color colorAzul = Color.Blue;
            Font fuenteNegrita = new Font(this.Font, FontStyle.Bold);

            this.SelectAll();
            this.SelectionColor = colorAzul; 
            this.SelectionFont = fuenteNegrita; 
            string textoCompleto = this.SelectedText;

            this.Select(0, 0); 
            this.SelectionColor = colorActual;
            this.SelectionFont = fontActual;
            this.Text = originalText;

            return text + textoCompleto;
        }



        //Fin clase
    }
    //Fin espacio
}
