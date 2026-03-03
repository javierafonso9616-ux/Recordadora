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

            //this.Padding = new Padding(20, 80, 20, 20);

            // Gochada para centrar el titulo
            this.Text = "                                                             " +
                        "                                                             " +
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


        }

        // --- FORM LOAD ---
        private void Form1_Load(object sender, System.EventArgs e)
        {

            CargarDatos();

            ConfigurarGrid(dgPrincipal);
            ConfigurarGrid(dgPendientes);
            ConfigurarGrid(dgHistorial);

            ConfigurarCalendar();

            BotonRedondoExcel();

            // Foco inicial
            ActiveControl = pictureBoxLogo;

            // --- MAXIMIZAR LA VENTANA AL INICIO ---
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
            this.WindowState = FormWindowState.Maximized;


        }

        // --- BOTÓN REDONDO EXPORTAR CON ICONO ---
        private void BotonRedondoExcel()
        {

            // --- BOTÓN REDONDO EXPORTAR CON ICONO Y HOVER ---

            mbExportarExcel.Text = "";
            mbExportarExcel.BackColor = Color.White;
            mbExportarExcel.FlatStyle = FlatStyle.Flat;
            mbExportarExcel.FlatAppearance.BorderSize = 0;

            // 1. Variable para saber si el ratón está encima
            bool ratonEncima = false;

            // 2. Eventos para detectar cuándo entra y sale el ratón
            mbExportarExcel.MouseEnter += (s, ev) =>
            {
                ratonEncima = true;
                mbExportarExcel.Invalidate(); // Fuerza al botón a redibujarse
            };

            mbExportarExcel.MouseLeave += (s, ev) =>
            {
                ratonEncima = false;
                mbExportarExcel.Invalidate(); // Fuerza al botón a redibujarse
            };


            // 3. La lógica de dibujo con SOMBRA Y HOVER MATERIAL DESIGN
            mbExportarExcel.Paint += (s, ev) =>
            {
                ev.Graphics.Clear(Color.White);
                ev.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int margen = 4;
                int anchoReal = mbExportarExcel.Width - margen - 1;
                int altoReal = mbExportarExcel.Height - margen - 1;

                // --- 1. DIBUJAMOS LA SOMBRA ---
                using (SolidBrush brochaSombra = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
                {
                    ev.Graphics.FillEllipse(brochaSombra, 2, 3, anchoReal, altoReal);
                }

                // --- 2. DIBUJAMOS EL BOTÓN VERDE (Siempre el color base) ---
                using (SolidBrush brochaVerde = new SolidBrush(Color.FromArgb(0, 192, 0)))
                {
                    ev.Graphics.FillEllipse(brochaVerde, 0, 0, anchoReal, altoReal);
                }

                // --- 3. EFECTO HOVER ESTILO MATERIAL DESIGN ("La Lejía") ---
                if (ratonEncima)
                {
                    // Pintamos un círculo blanco al 20% de opacidad (50 sobre 255) justo encima del verde
                    using (SolidBrush brochaHover = new SolidBrush(Color.FromArgb(50, 255, 255, 255)))
                    {
                        ev.Graphics.FillEllipse(brochaHover, 0, 0, anchoReal, altoReal);
                    }
                }

                // --- 4. DIBUJAMOS EL ICONO CENTRADO ---
                Image iconoExcel = Properties.Resources.icons8_export_excel_32;

                if (iconoExcel != null)
                {
                    int x = (anchoReal - iconoExcel.Width) / 2;
                    int y = (altoReal - iconoExcel.Height) / 2;
                    ev.Graphics.DrawImage(iconoExcel, x, y, iconoExcel.Width, iconoExcel.Height);
                }
            };

        }



        // --- CONFIGURACIÓN ---
        //--- CONFIGURAR CALENDARIO ---
        private void ConfigurarCalendar()
        {
            mcCalendario.TitleBackColor = Color.FromArgb(13, 71, 161); // Blue900
            mcCalendario.TitleForeColor = Color.White;
            mcCalendario.TrailingForeColor = Color.FromArgb(230, 230, 230);
            mcCalendario.Font = new Font("Segoe UI", 15F, FontStyle.Regular);
        }

        //--- CONFIGURAR GRID ---
        // Ahora el método recibe "qué" DataGridView quieres configurar
        public void ConfigurarGrid(DataGridView grid)
        {
            Color azulOscuro = Color.FromArgb(13, 71, 161);

            // Aplicamos los estilos al "grid" que nos hayan pasado
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(230, 230, 230);

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = azulOscuro;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            grid.ColumnHeadersHeight = 40;

            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            grid.RowHeadersVisible = false;

            // --- BLOQUEO DE EDICIÓN ---
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;

            // --- OCULTAR EL ID (Si lo tiene) ---
            if (grid.Columns.Contains("ID"))
            {
                grid.Columns["ID"].Visible = false;
            }

            // --- Ajuste de columnas específicas (Solo si el grid las tiene) ---
            if (grid.Columns.Contains("DESCRIPCION")) grid.Columns["DESCRIPCION"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (grid.Columns.Contains("SOLUCION")) grid.Columns["SOLUCION"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (grid.Columns.Contains("FECHA")) grid.Columns["FECHA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            if (grid.Columns.Contains("ESTADO")) grid.Columns["ESTADO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            if (grid.Columns.Contains("TITULO"))
            {
                grid.Columns["TITULO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grid.Columns["TITULO"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            }
        }

        //--- CARGAR DATOS ---
        public void CargarDatos()
        {
            // 1. Nos traemos TODO de la base de datos de un solo golpe. (Máxima velocidad)
            string consulta = "SELECT ID, FECHA, TITULO, DESCRIPCION, SOLUCION, ESTADO FROM TABLA_RECORDADORA";

            DataTable dt = ad.ObtenerDatos(consulta);

            if (dt != null)
            {
                // ====================================================================
                // GRID 1: PRINCIPAL (El que interactúa con el Calendario)
                // ====================================================================
                dgPrincipal.DataSource = dt; // Este usa la vista por defecto de la tabla
                ConfigurarGrid(dgPrincipal);

                foreach (DataGridViewColumn column in dgPrincipal.Columns)
                {
                    column.MinimumWidth = 100;
                }

                // Filtro visual inicial (SOLO HOY)
                string hoy = DateTime.Now.ToString("yyyy-MM-dd");
                string manana = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                dt.DefaultView.RowFilter = string.Format("FECHA >= '{0}' AND FECHA < '{1}'", hoy, manana);


                // ====================================================================
                // GRID 2: PENDIENTES (Solo tareas pendientes)
                // ====================================================================

                DataView dvPendientes = new DataView(dt);
                dvPendientes.RowFilter = "ESTADO = 'PENDIENTE'";
                dvPendientes.Sort = "FECHA ASC";

                dgPendientes.DataSource = dvPendientes;
                ConfigurarGrid(dgPendientes);

                foreach (DataGridViewColumn column in dgPendientes.Columns)
                {
                    column.MinimumWidth = 100;
                }


                // ====================================================================
                // GRID 3: HISTORIAL (Todos los datos ordenados por fecha)
                // ====================================================================
                DataView dvHistorial = new DataView(dt);

                dvHistorial.Sort = "FECHA DESC";

                dgHistorial.DataSource = dvHistorial;
                ConfigurarGrid(dgHistorial);

                foreach (DataGridViewColumn column in dgHistorial.Columns)
                {
                    column.MinimumWidth = 100;
                }
            }
        }

        // --- EVENTOS DE FILTRADO ---

        // Gestiona tanto el clic en un día como la navegación por meses 
        private void mcCalendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (dgPrincipal.DataSource is DataTable dt)
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
                if (dgPrincipal.DataSource is DataTable dt)
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
            if (dgPrincipal.DataSource is DataTable dt)
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

        // BUSCADOR GENERAL: FILTRA POR TÍTULO, DESCRIPCIÓN O SOLUCIÓN
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (dgPrincipal.DataSource is DataTable dt)
            {
                DataView dv = dt.DefaultView;
                string busqueda = txtBuscar.Text.Trim();

                // Si el buscador está vacío (el usuario ha borrado el texto)
                if (string.IsNullOrEmpty(busqueda))
                {
                    // Volvemos a la vista normal (recargando los filtros de hoy)
                    CargarDatos();
                }
                else
                {
                    // Filtro

                    dv.RowFilter = string.Format("TITULO LIKE '%{0}%' OR DESCRIPCION LIKE '%{0}%' OR SOLUCION LIKE '%{0}%'", busqueda);
                }
            }
        }

        // DOBLE CLICK CELDA: ABRIR FORMULARIO DE EDICIÓN 

        private void DataGridView_CellDoubleClickGlobal(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que no hayan hecho clic en la cabecera de las columnas (eso sería el índice -1)
            if (e.RowIndex >= 0)
            {

                // Puede ser dgPrincipal, dgPendientes o dgHistorial, 
                DataGridView gridClicado = sender as DataGridView;

                // 1. Pillamos la fila completa de ESE grid en concreto
                DataGridViewRow fila = gridClicado.Rows[e.RowIndex];

                // 2. Extraemos todos los datos usando el nombre de la columna en la BD
                int idTarea = Convert.ToInt32(fila.Cells["ID"].Value);
                DateTime fecha = Convert.ToDateTime(fila.Cells["FECHA"].Value);
                string titulo = fila.Cells["TITULO"].Value?.ToString() ?? "";
                string descripcion = fila.Cells["DESCRIPCION"].Value?.ToString() ?? "";
                string solucion = fila.Cells["SOLUCION"].Value?.ToString() ?? "";
                string estado = fila.Cells["ESTADO"].Value?.ToString() ?? "";

                // Abrimos el formulario pasándole todos los datos de la fila
                FormEdicion frm = new FormEdicion(idTarea, fecha, titulo, descripcion, solucion, estado);

                // ShowDialog hace que el formulario se abra por encima y bloquee el principal hasta que se cierre
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Si cerramos el formulario dándole a Guardar, recargamos los Grids
                    CargarDatos();
                }
            }
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FormEdicion frm = new FormEdicion();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarDatos();

            }
        }

        private void mbExportarExcel_Click(object sender, EventArgs e)
        {
            // Le pasamos los 3 DataGridViews al formulario en el momento de crearlo
            FormExportar frm = new FormExportar(dgPrincipal, dgPendientes, dgHistorial);


            frm.ShowDialog();
        }
    }
}