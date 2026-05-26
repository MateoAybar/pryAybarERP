using System.Drawing;
using System.Windows.Forms;

namespace pryAYbarERP.Clases
{
    internal static class EstilosFormularios
    {
        private static readonly Color Fondo = Color.FromArgb(240, 243, 239);
        private static readonly Color Superficie = Color.FromArgb(248, 250, 247);
        private static readonly Color Borde = Color.FromArgb(198, 209, 224);
        private static readonly Color Texto = Color.FromArgb(31, 41, 55);
        private static readonly Color TextoSuave = Color.FromArgb(82, 96, 115);
        private static readonly Color Primario = Color.FromArgb(30, 86, 160);
        private static readonly Color PrimarioOscuro = Color.FromArgb(23, 61, 115);
        private static readonly Color Secundario = Color.FromArgb(14, 116, 144);
        private static readonly Color Exito = Color.FromArgb(32, 128, 92);
        private static readonly Color Advertencia = Color.FromArgb(180, 83, 9);
        private static readonly Color Peligro = Color.FromArgb(185, 28, 28);

        public static void Aplicar(Form formulario)
        {
            formulario.BackColor = Fondo;
            formulario.Font = new Font("Segoe UI", 9F);

            foreach (Control control in formulario.Controls)
                AplicarAControl(control);
        }

        private static void AplicarAControl(Control control)
        {
            if (control is TabControl)
                AplicarTabControl((TabControl)control);
            else if (control is TabPage)
                AplicarTabPage((TabPage)control);
            else if (control is GroupBox)
                AplicarGroupBox((GroupBox)control);
            else if (control is TextBox)
                AplicarTextBox((TextBox)control);
            else if (control is ComboBox)
                AplicarComboBox((ComboBox)control);
            else if (control is Button)
                AplicarBoton((Button)control);
            else if (control is CheckBox)
                AplicarCheckBox((CheckBox)control);
            else if (control is Label)
                AplicarLabel((Label)control);
            else if (control is DataGridView)
                AplicarGrilla((DataGridView)control);
            else if (control is Panel)
                AplicarPanel((Panel)control);

            foreach (Control hijo in control.Controls)
                AplicarAControl(hijo);
        }

        private static void AplicarTabControl(TabControl tab)
        {
            tab.BackColor = Fondo;
        }

        private static void AplicarTabPage(TabPage page)
        {
            page.BackColor = Fondo;
            page.ForeColor = Texto;
        }

        private static void AplicarGroupBox(GroupBox group)
        {
            group.BackColor = Color.FromArgb(243, 246, 242);
            group.ForeColor = PrimarioOscuro;
            group.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        }

        private static void AplicarTextBox(TextBox textBox)
        {
            textBox.BackColor = Color.White;
            textBox.ForeColor = Texto;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = new Font("Segoe UI", 9.5F);
        }

        private static void AplicarComboBox(ComboBox combo)
        {
            combo.BackColor = Color.White;
            combo.ForeColor = Texto;
            combo.FlatStyle = FlatStyle.Flat;
            combo.Font = new Font("Segoe UI", 9.5F);
        }

        private static void AplicarLabel(Label label)
        {
            if (label.Parent != null && label.Parent.Name.ToLower().Contains("header"))
            {
                label.ForeColor = Color.White;
                label.Font = new Font("Segoe UI", label.Font.Size, FontStyle.Bold);
                return;
            }

            if (label.Font.Size >= 13)
            {
                label.ForeColor = Primario;
                label.Font = new Font("Segoe UI", label.Font.Size, FontStyle.Bold);
            }
            else
            {
                label.ForeColor = TextoSuave;
            }
        }

        private static void AplicarBoton(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.ForeColor = Color.White;
            boton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            boton.UseVisualStyleBackColor = false;

            string nombre = boton.Name.ToLower();
            if (nombre.Contains("eliminar") || nombre.Contains("baja"))
                boton.BackColor = Peligro;
            else if (nombre.Contains("registrar") || nombre.Contains("guardar") || nombre.Contains("agregar"))
                boton.BackColor = Exito;
            else if (nombre.Contains("limpiar"))
                boton.BackColor = Advertencia;
            else if (nombre.Contains("map"))
                boton.BackColor = Secundario;
            else
                boton.BackColor = Primario;
        }

        private static void AplicarGrilla(DataGridView grilla)
        {
            grilla.BackgroundColor = Superficie;
            grilla.BorderStyle = BorderStyle.FixedSingle;
            grilla.GridColor = Borde;
            grilla.EnableHeadersVisualStyles = false;
            grilla.ColumnHeadersDefaultCellStyle.BackColor = PrimarioOscuro;
            grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grilla.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grilla.DefaultCellStyle.BackColor = Color.White;
            grilla.DefaultCellStyle.ForeColor = Texto;
            grilla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(207, 236, 242);
            grilla.DefaultCellStyle.SelectionForeColor = Texto;
            grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(246, 248, 251);
        }

        private static void AplicarPanel(Panel panel)
        {
            if (panel.Name.ToLower().Contains("header"))
            {
                panel.BackColor = PrimarioOscuro;
                return;
            }

            panel.BackColor = Color.FromArgb(245, 247, 244);
            panel.BorderStyle = BorderStyle.FixedSingle;
        }

        private static void AplicarCheckBox(CheckBox checkBox)
        {
            checkBox.ForeColor = Texto;
            checkBox.BackColor = Color.Transparent;
            checkBox.Font = new Font("Segoe UI", 9F);
        }
    }
}
