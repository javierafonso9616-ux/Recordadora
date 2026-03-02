using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ColorScheme = MaterialSkin.ColorScheme;

namespace Recordadora
{
    public partial class Form1 : MaterialForm
    {
        AccesoDatos.Datos ad = new AccesoDatos.Datos();
        private int mesActual = DateTime.Now.Month;
        private int anioActual = DateTime.Now.Year;

        public Form1()
        {
            InitializeComponent();

            this.Padding = new Padding(20, 80, 20, 20);

            // Título centrado (la famosa "gochada")
            this.Text = "                                                                            " +
                        "                                                                            " +
                        "                                                   RECORDADORA";

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue900,
                Primary.Blue900,
                Primary.Blue200,
                Accent.Blue700,
                TextShade.WHITE
            );

            this.WindowState = FormWindowState.Maximized;
        }

        // --- FORM LOAD ---
        private void Form1_Load(object sender, System.EventArgs e)
        {
            CargarDatos();
            ConfigurarGrid();
            ConfigurarCalendar();

            // Foco inicial
            ActiveControl = pictureBoxLogo;
        }

        // --- CONFIGURACIÓN ---
        private void ConfigurarCalendar()
        {
            mcCalendario.TitleBackColor = Color.FromArgb(13, 71, 161); // Blue900
            mcCalendario.TitleForeColor = Color.White;
            mcCalendario.TrailingForeColor = Color.FromArgb(230, 230, 230);
            mcCalendario.Font = new Font("Segoe UI", 15F, FontStyle.Regular);
        }

        public void ConfigurarGrid()
        {
            Color azulOscuro = Color.FromArgb(13, 71, 161);
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.FromArgb(230, 230, 230);

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = azulOscuro;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 40;

            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowHeadersVisible = false;

            // Ajuste de columnas
            if (dataGridView1.Columns.Contains("DESCRIPCION")) dataGridView1.Columns["DESCRIPCION"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (dataGridView1.Columns.Contains("SOLUCION")) dataGridView1.Columns["SOLUCION"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (dataGridView1.Columns.Contains("FECHA")) dataGridView1.Columns["FECHA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            if (dataGridView1.Columns.Contains("ESTADO")) dataGridView1.Columns["ESTADO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            if (dataGridView1.Columns.Contains("TITULO"))
            {
                dataGridView1.Columns["TITULO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["TITULO"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            }
        }

        public void CargarDatos()
        {
            string consulta = "SELECT FECHA, TITULO, DESCRIPCION, SOLUCION, ESTADO FROM TABLA_RECORDADORA";
            DataTable dt = ad.ObtenerDatos(consulta);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                ConfigurarGrid();
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.MinimumWidth = 100;
                }
            }
        }

        // --- EVENTOS DE FILTRADO ---

        // UNIFICADO: Gestiona tanto el clic en un día como la navegación por meses con "memoria"
        private void mcCalendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (dataGridView1.DataSource is DataTable dt)
            {
                DataView dv = dt.DefaultView;

                // 1. Comparamos el mes del evento con el mes que teníamos guardado (Variables globales)
                if (e.Start.Month != mesActual || e.Start.Year != anioActual)
                {
                    // =========================================================
                    // CASO A: HA CAMBIADO DE MES (NAVEGACIÓN CON FLECHAS)
                    // =========================================================

                    // Actualizamos nuestra memoria
                    mesActual = e.Start.Month;
                    anioActual = e.Start.Year;

                    // Filtramos todo el mes nuevo
                    DateTime inicioMes = new DateTime(anioActual, mesActual, 1);
                    DateTime finMes = inicioMes.AddMonths(1);
                    dv.RowFilter = string.Format("FECHA >= '{0:yyyy-MM-dd}' AND FECHA < '{1:yyyy-MM-dd}'",
                                                inicioMes, finMes);

                    // TRUCO MAESTRO: Nos desuscribimos un microsegundo, limpiamos el azul, y volvemos a suscribir
                    mcCalendario.DateChanged -= mcCalendario_DateChanged;
                    mcCalendario.SelectionRange = new SelectionRange(inicioMes, inicioMes);
                    mcCalendario.DateChanged += mcCalendario_DateChanged;
                }
                else
                {
                    // =========================================================
                    // CASO B: ESTÁ EN EL MISMO MES (CLIC O RANGO MANUAL)
                    // =========================================================

                    // Filtramos exactamente el día o los días que el técnico ha seleccionado con el ratón
                    dv.RowFilter = string.Format("FECHA >= '{0:yyyy-MM-dd}' AND FECHA < '{1:yyyy-MM-dd}'",
                                                e.Start.Date, e.End.Date.AddDays(1));
                }
            }
        }

        // Resetea filtros al pulsar en el link de "Hoy"
        private void mcCalendario_MouseUp(object sender, MouseEventArgs e)
        {
            MonthCalendar.HitTestInfo info = mcCalendario.HitTest(e.X, e.Y);

            if (info.HitArea == MonthCalendar.HitArea.TodayLink)
            {
                if (dataGridView1.DataSource is DataTable dt)
                    dt.DefaultView.RowFilter = "";

                CargarDatos();

                // Actualizamos las variables por si el usuario estaba en otro mes
                mesActual = DateTime.Now.Month;
                anioActual = DateTime.Now.Year;

                mcCalendario.SetDate(DateTime.Now);
            }
        }

        // Filtra por estado (PENDIENTE, REALIZADO, CANCELADO)
        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource is DataTable dt)
            {
                DataView dv = dt.DefaultView;
                string estadoSeleccionado = cbEstado.SelectedItem.ToString();

                if (estadoSeleccionado == "(Seleccione un estado)")
                {
                    dv.RowFilter = "";
                    CargarDatos();
                }
                else
                {
                    dv.RowFilter = string.Format("ESTADO = '{0}'", estadoSeleccionado);
                }
            }
        }

    }
}