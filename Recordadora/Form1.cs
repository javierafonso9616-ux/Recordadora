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
        public Form1()
        {
            /*
            using (var Formlogo = new Logo())
            {

                Formlogo.ShowDialog();
            }*/

            InitializeComponent();

            this.Padding = new Padding(20, 80, 20, 20);


            // gochada maxima para centrar el titulo del averno porque no habia manera de otra forma
            this.Text = "                                                            " +
                        "                                                            " +
                        "                                                  RECORDADORA";

            // Configuración de MaterialSkin para el tema y los colores
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

        // FORM LOAD

        private void Form1_Load(object sender, System.EventArgs e)
        {
            CargarDatos();
            ConfigurarGrid();
            ConfigurarCalendar();

            // foco en la imagen para quitar el foco del resto
            ActiveControl = pictureBoxLogo;
        }

        // CONFIGURAR CALENDARIO
        private void ConfigurarCalendar()
        {

            mcCalendario.TitleBackColor = Color.FromArgb(13, 71, 161); // blue900
            mcCalendario.TitleForeColor = Color.White;
            mcCalendario.TrailingForeColor = Color.FromArgb(230, 230, 230);
            mcCalendario.Font = new Font("Segoe UI", 15F, FontStyle.Regular);
        }

        // CONFIGURAR GRID
        public void ConfigurarGrid()
        {

            // --- 1. COLORES Y ESTILO VISUAL ---
            Color azulOscuro = Color.FromArgb(13, 71, 161);
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.FromArgb(230, 230, 230);

            // Cabeceras
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = azulOscuro;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 40;

            // Filas (Configuración general)
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Por defecto, permitimos multilínea para que DESCRIPCIÓN y SOLUCIÓN crezcan
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowHeadersVisible = false;

            // --- 2. COMPORTAMIENTO DE COLUMNAS ---

            // Columnas que se estiran (DESCRIPCION y SOLUCION)
            if (dataGridView1.Columns.Contains("DESCRIPCION"))
            {
                dataGridView1.Columns["DESCRIPCION"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns["DESCRIPCION"].FillWeight = 150;
            }

            if (dataGridView1.Columns.Contains("SOLUCION"))
            {
                dataGridView1.Columns["SOLUCION"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns["SOLUCION"].FillWeight = 150;
            }

            // Columnas que se ajustan al contenido (FECHA y ESTADO)
            if (dataGridView1.Columns.Contains("FECHA"))
            {
                dataGridView1.Columns["FECHA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["FECHA"].MinimumWidth = 20;
                //  dataGridView1.Columns["FECHA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dataGridView1.Columns.Contains("ESTADO"))
            {
                dataGridView1.Columns["ESTADO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["ESTADO"].MinimumWidth = 20;
                //   dataGridView1.Columns["ESTADO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // --- 3. CONFIGURACIÓN ESPECÍFICA PARA TÍTULO ---
            if (dataGridView1.Columns.Contains("TITULO"))
            {
                dataGridView1.Columns["TITULO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["TITULO"].MinimumWidth = 50;
                // FORZAMOS UNA SOLA LÍNEA: Desactivamos el WrapMode solo para esta columna
                dataGridView1.Columns["TITULO"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            }
        }


        // CARGA DE DATOS INICIAL
        public void CargarDatos()
        {

            string consulta = "SELECT FECHA, TITULO, DESCRIPCION, SOLUCION, ESTADO FROM TABLA_RECORDADORA";
            DataTable dt = ad.ObtenerDatos(consulta);

            if (dt != null)
            {


                dataGridView1.DataSource = dt;
                ConfigurarGrid();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.MinimumWidth = 100;
                }

            }

        }



        // EVENTOS

        // FILTRADO POR FECHA (AL SELECCIONAR UNA FECHA O UN RANGO EN EL CALENDARIO)
        private void mcCalendario_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (dataGridView1.DataSource is DataTable dt)
            {
                DataView dv = dt.DefaultView;

                // 2. Comprobamos si es un solo día o un rango
                if (e.Start == e.End)
                {
                    // --- CASO 1: UN SOLO DÍA ---
                    // Formateamos la fecha (ajusta "dd/MM/yyyy" según cómo guardes en tu BD)
                    string fechaFiltro = e.Start.ToString("dd/MM/yyyy");
                    dv.RowFilter = string.Format("FECHA = '{0}'", fechaFiltro);
                }
                else
                {
                    // --- CASO 2: RANGO DE FECHAS ---
                    string fechaInicio = e.Start.ToString("dd/MM/yyyy");
                    string fechaFin = e.End.ToString("dd/MM/yyyy");

                    // Filtro dinámico: Fecha >= Inicio Y Fecha <= Fin
                    dv.RowFilter = string.Format("FECHA >= '{0}' AND FECHA <= '{1}'", fechaInicio, fechaFin);
                }
            }

        }

        // FILTRADO POR MES (AL CAMBIAR DE MES EN EL CALENDARIO)
        private void mcCalendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (dataGridView1.DataSource is DataTable dt)
            {
                DataView dv = dt.DefaultView;

                // 1. Obtenemos el mes y el año que el usuario está viendo ahora
                // Usamos e.Start porque al cambiar de mes, el calendario selecciona 
                // por defecto el primer día del nuevo mes visible.
                int mesVisible = e.Start.Month;
                int anioVisible = e.Start.Year;

                // 2. Creamos un rango que cubra todo ese mes
                DateTime inicioMes = new DateTime(anioVisible, mesVisible, 1);
                DateTime finMes = inicioMes.AddMonths(1); // Primer día del mes siguiente

                // 3. Aplicamos el filtro: "Cualquier fecha dentro de este mes"
                // Usamos el formato ISO yyyy-MM-dd para que no haya fallos de región
                dv.RowFilter = string.Format("FECHA >= '{0:yyyy-MM-dd}' AND FECHA < '{1:yyyy-MM-dd}'",
                                            inicioMes, finMes);
            }
        }
        // FILTRADO HOY(RESETEA FILTROS Y MUESTRA SOLO HOY) AL HACER CLIC EN EL LINK "HOY:" DEL CALENDARIO
        private void mcCalendario_MouseUp(object sender, MouseEventArgs e)
        {
            // HitTest analiza qué hay bajo el ratón justo al soltar el clic
            MonthCalendar.HitTestInfo info = mcCalendario.HitTest(e.X, e.Y);

            // Si el usuario soltó el clic sobre el link de "Hoy:"
            if (info.HitArea == MonthCalendar.HitArea.TodayLink)
            {
                // 1. Limpiamos filtros previos
                if (dataGridView1.DataSource is DataTable dt)
                    dt.DefaultView.RowFilter = "";

                // 2. Recargamos datos (tu función de la DB)
                CargarDatos();

                // 3. Movemos el foco visual del calendario a hoy
                mcCalendario.SetDate(DateTime.Now);
            }
        }

        // FILTRADO ESTADO
        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource is DataTable dt)
            {
                DataView dv = dt.DefaultView;

                // 1. Obtenemos el texto seleccionado
                string estadoSeleccionado = cbEstado.SelectedItem.ToString();

                // 2. Lógica de filtrado
                if (estadoSeleccionado == "(Seleccione un estado)")
                {
                    // Si elige la opción por defecto, limpiamos el filtro y recargamos
                    dv.RowFilter = "";
                    CargarDatos();
                }
                else
                {
                    // Filtramos por la columna ESTADO

                    dv.RowFilter = string.Format("ESTADO = '{0}'", estadoSeleccionado);
                }
            }
        }
    }
}
