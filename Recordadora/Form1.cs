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

            // comentar estas dos lineas para quitar el logo de carga inicial
            // FormLogo formLogo = new FormLogo();
            // formLogo.ShowDialog();



            // Activamos DoubleBuffered a nivel de Form
            this.DoubleBuffered = true;

            // Gochada para centrar el titulo
            this.Text = "                                                              " +
                        "                                                              " +
                        "                                                          TAREAS";

            // MARETIAL SKIN MANAGER PARA EL TEMA DE ESTILOS DE MATERIAL DESIGN (GOOGLE ANDROID)
            var materialSkinManager = MaterialSkinManager.Instance;

            materialSkinManager.AddFormToManage(this);

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue900,// COLOR PRINCIPAL (BARRA DE TITULO, BOTONES SELECCIONADOS, ETC)
                Primary.Blue900,// COLOR SECUNDARIO (BARRA DE TITULO CUANDO LA VENTANA NO ESTA ACTIVA)
                Primary.Blue400,// COLOR DE FONDO DE LOS CONTROLES (BOTONES, TEXTBOX, ETC)
                Accent.Blue700,// COLOR DE LOS BOTONES DE ACCION (BOTON AÑADIR, BOTON EXPORTAR, ETC)
                TextShade.WHITE // COLOR DE LOS TEXTOS (TITULOS, TEXTO DE LOS BOTONES, ETC)
            );



            // Maximizamos antes de mostrar para evitar saltos de resolución
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            // LLAMADA A METODO DOBLE BUFFER
            HabilitarDoubleBuffer(dgPrincipal);
            HabilitarDoubleBuffer(dgPendientes);
            HabilitarDoubleBuffer(dgHistorial);

            CargarDatos();

            ConfigurarCalendar();
            BotonRedondoExcel();

            ActiveControl = pictureBoxLogo;
        }

        // MÉTODO PARA ACTIVAR DOUBLE BUFFER EN LOS DATAGRIDVIEW Y EVITAR EL PARPADEO AL CARGAR DATOS
        private void HabilitarDoubleBuffer(DataGridView dgv)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, dgv, new object[] { true });
        }

        // BOTON REDONDO (NI TOCAR)
        private void BotonRedondoExcel()
        {
            btExportarExcel.Text = "";
            btExportarExcel.BackColor = Color.White;
            btExportarExcel.FlatStyle = FlatStyle.Flat;
            btExportarExcel.FlatAppearance.BorderSize = 0;

            bool ratonEncima = false;

            btExportarExcel.MouseEnter += (s, ev) => { ratonEncima = true; btExportarExcel.Invalidate(); };
            btExportarExcel.MouseLeave += (s, ev) => { ratonEncima = false; btExportarExcel.Invalidate(); };

            btExportarExcel.Paint += (s, ev) =>
            {
                ev.Graphics.Clear(Color.White);
                ev.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int margen = 4;
                int anchoReal = btExportarExcel.Width - margen - 1;
                int altoReal = btExportarExcel.Height - margen - 1;

                using (SolidBrush brochaSombra = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
                {
                    ev.Graphics.FillEllipse(brochaSombra, 2, 3, anchoReal, altoReal);
                }

                using (SolidBrush brochaVerde = new SolidBrush(Color.FromArgb(0, 192, 0)))
                {
                    ev.Graphics.FillEllipse(brochaVerde, 0, 0, anchoReal, altoReal);
                }

                if (ratonEncima)
                {
                    using (SolidBrush brochaHover = new SolidBrush(Color.FromArgb(50, 255, 255, 255)))
                    {
                        ev.Graphics.FillEllipse(brochaHover, 0, 0, anchoReal, altoReal);
                    }
                }

                Image iconoExcel = Properties.Resources.icons8_export_excel_32;
                if (iconoExcel != null)
                {
                    int x = (anchoReal - iconoExcel.Width) / 2;
                    int y = (altoReal - iconoExcel.Height) / 2;
                    ev.Graphics.DrawImage(iconoExcel, x, y, iconoExcel.Width, iconoExcel.Height);
                }
            };


        }

        // CONFIGURACION DE CALENDARIO PARA QUE COINCIDA CON EL ESTILO MATERIAL Y SEA MAS LEGIBLE
        private void ConfigurarCalendar()
        {
            mcCalendario.TitleBackColor = Color.FromArgb(13, 71, 161);
            mcCalendario.TitleForeColor = Color.White;
            mcCalendario.TrailingForeColor = Color.FromArgb(230, 230, 230);
            mcCalendario.Font = new Font("Segoe UI", 15F, FontStyle.Regular);
        }

        // CONFIGURACION DE GRIDS PARA QUE COINCIDA CON EL ESTILO MATERIAL, SEA MAS LEGIBLE Y EVITAR EL PARPADEO AL CARGAR DATOS
        public void ConfigurarGrid(DataGridView grid)
        {
            Color azulOscuro = Color.FromArgb(13, 71, 161);

            // DESACTIVAMOS LA POSIBILIDAD DE CAMBIAR EL TAMAÑO DE FILAS Y
            // CABECERAS PARA EVITAR EL PARPADEO DE LOS GRIDS AL CARGAR DATOS
            grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grid.AllowUserToResizeRows = false;

            // ESTILO GENERAL
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(230, 230, 230);

            // ESTILO ENCABEZADOS
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = azulOscuro;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);// FUENTE ENCABEZADOS
            grid.ColumnHeadersHeight = 40;

            // ESTILO CELDAS
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9); // FUENTE CELDAS
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grid.RowHeadersVisible = false;

            // PROPIEDADES PARA EVITAR QUE EL USUARIO PUEDA EDITAR DIRECTAMENTE EN LOS GRIDS Y EVITAR EL PARPADEO AL CARGAR DATOS
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;

            if (grid.Columns.Contains("ID")) grid.Columns["ID"].Visible = false;

            // Ajuste de columnas optimizado
            if (grid.Columns.Contains("DESCRIPCION")) grid.Columns["DESCRIPCION"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (grid.Columns.Contains("SOLUCION")) grid.Columns["SOLUCION"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (grid.Columns.Contains("TITULO")) grid.Columns["TITULO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            if (grid.Columns.Contains("FECHA"))
            {
                grid.Columns["FECHA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                grid.Columns["FECHA"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                grid.Columns["FECHA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (grid.Columns.Contains("ESTADO")) grid.Columns["ESTADO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // Forzamos el ajuste de filas una sola vez al configurar para evitar el parpadeo
            grid.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
        }

        public void CargarDatos()
        {
            // Suspendemos el dibujo para que no se vea el proceso de carga
            dgPrincipal.SuspendLayout();
            dgPendientes.SuspendLayout();
            dgHistorial.SuspendLayout();

            // CONSULTA COMPLETA PARA OBTENER TODOS LOS DATOS DE LA TABLA,
            // LUEGO FILTRAREMOS EN MEMORIA PARA MOSTRAR SOLO LO NECESARIO EN CADA GRID
            string consulta = "SELECT ID, FECHA, TITULO, DESCRIPCION, SOLUCION, ESTADO FROM TABLA_RECORDADORA";
            DataTable dt = ad.ObtenerDatos(consulta);

            if (dt != null)
            {

                //DATA SOURCE PRINCIPAL: MOSTRAMOS SOLO LAS TAREAS DEL DÍA SELECCIONADO (POR DEFECTO HOY)
                dgPrincipal.DataSource = dt;
                ConfigurarGrid(dgPrincipal);
                string hoy = DateTime.Now.ToString("yyyy-MM-dd");
                string manana = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                dt.DefaultView.RowFilter = string.Format("FECHA >= '{0}' AND FECHA < '{1}'", hoy, manana);

                //DATA SOURCE PENDIENTES MOSTRAMOS SOLO LAS TAREAS PENDIENTES ORDENADAS POR FECHA ASCENDENTE

                DataView dvPendientes = new DataView(dt);
                dvPendientes.RowFilter = "ESTADO = 'PENDIENTE'";
                dvPendientes.Sort = "FECHA ASC";
                dgPendientes.DataSource = dvPendientes;
                ConfigurarGrid(dgPendientes);

                //DATA SOURCE HISTORIAL MOSTRAMOS SOLO LAS TAREAS COMPLETADAS ORDENADAS POR FECHA DESCENDENTE
                DataView dvHistorial = new DataView(dt);
                dvHistorial.Sort = "FECHA DESC";
                dgHistorial.DataSource = dvHistorial;
                ConfigurarGrid(dgHistorial);
            }

            // Reanudamos el dibujo
            dgPrincipal.ResumeLayout();
            dgPendientes.ResumeLayout();
            dgHistorial.ResumeLayout();
        }

        // FILTRO POR FECHA: AL CAMBIAR EL MES O AÑO EN EL CALENDARIO, MOSTRAMOS
        // SOLO LAS TAREAS DE ESE MES. SI SE SELECCIONA UN RANGO DENTRO DEL MISMO MES, MOSTRAMOS SOLO LAS TAREAS DE ESE RANGO
        private void mcCalendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (dgPrincipal.DataSource is DataTable dt)
            {
                DataView dv = dt.DefaultView;
                if (e.Start.Month != mesActual || e.Start.Year != anioActual)
                {
                    mesActual = e.Start.Month;
                    anioActual = e.Start.Year;
                    DateTime inicioMes = new DateTime(anioActual, mesActual, 1);
                    DateTime finMes = inicioMes.AddMonths(1);
                    dv.RowFilter = string.Format("FECHA >= '{0:yyyy-MM-dd}' AND FECHA < '{1:yyyy-MM-dd}'", inicioMes, finMes);

                    mcCalendario.DateChanged -= mcCalendario_DateChanged;
                    mcCalendario.SelectionRange = new SelectionRange(inicioMes, inicioMes);
                    mcCalendario.DateChanged += mcCalendario_DateChanged;
                }
                else
                {
                    dv.RowFilter = string.Format("FECHA >= '{0:yyyy-MM-dd}' AND FECHA < '{1:yyyy-MM-dd}'", e.Start.Date, e.End.Date.AddDays(1));
                }
            }
        }

        // AL HACER CLICK EN EL LINK DE HOY, MOSTRAMOS SOLO LAS TAREAS DEL DÍA ACTUAL Y RESETEAMOS EL CALENDARIO A HOY
        private void mcCalendario_MouseUp(object sender, MouseEventArgs e)
        {
            MonthCalendar.HitTestInfo info = mcCalendario.HitTest(e.X, e.Y);
            if (info.HitArea == MonthCalendar.HitArea.TodayLink)
            {
                if (dgPrincipal.DataSource is DataTable dt) dt.DefaultView.RowFilter = "";
                CargarDatos();
                mesActual = DateTime.Now.Month;
                anioActual = DateTime.Now.Year;
                mcCalendario.SetDate(DateTime.Now);
            }
        }

        // FILTRO POR ESTADO: AL SELECCIONAR UN ESTADO EN EL COMBOBOX,
        // MOSTRAMOS SOLO LAS TAREAS CON ESE ESTADO. SI SE SELECCIONA LA OPCION
        // DE "SELECCIONAR UN ESTADO", MOSTRAMOS TODAS LAS TAREAS DEL MES SELECCIONADO
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

        // FILTRO POR TEXTO: AL ESCRIBIR EN EL TEXTBOX DE BUSQUEDA,
        // MOSTRAMOS SOLO LAS TAREAS QUE CONTENGAN EL TEXTO EN EL TITULO, DESCRIPCION O SOLUCION


        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text.Trim();


            // Si detectamos que el usuario está escribiendo una sentencia SQL, 
            // abortamos el filtrado normal para no interferir ni provocar errores.
            if (busqueda.ToUpper().StartsWith("SELECT"))
            {
                return;
            }

            if (dgPrincipal.DataSource is DataTable dt)
            {
                DataView dv = dt.DefaultView;

                if (string.IsNullOrEmpty(busqueda))
                {
                    CargarDatos();
                }
                else
                {
                    dv.RowFilter = string.Format("TITULO LIKE '%{0}%' OR DESCRIPCION LIKE '%{0}%' OR SOLUCION LIKE '%{0}%'", busqueda);
                }
            }
        }
        // CUANDO EL USUARIO PRESIONA ENTER EN EL TEXTBOX DE BUSQUEDA,
        // SI EL TEXTO ES UNA SENTENCIA SQL, LA EJECUTAMOS Y MOSTRAMOS LOS RESULTADOS EN EL GRID PRINCIPAL
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // Evita que el control procese la tecla Enter
                e.SuppressKeyPress = true; // Evita el sonido de "ding"

                string consulta = txtBuscar.Text.Trim();


                if (consulta.ToUpper().StartsWith("SELECT"))
                {
                    // --- BLOQUEO DE SEGURIDAD BÁSICO ---
                    if (consulta.Contains(";") ||
                        consulta.Contains("DELETE") ||
                        consulta.Contains("UPDATE") ||
                        consulta.Contains("DROP") ||
                        consulta.Contains("INSERT"))
                    {
                        MessageBox.Show("¡Operación no permitida! Solo se pueden hacer consultas de lectura.", "Alerta de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Cortamos la ejecución aquí mismo
                    }
                    // 1. Obtenemos los datos ejecutando SQL
                    DataTable dtPersonalizado = ad.ObtenerDatos(consulta);

                    // 2. Si la consulta no dio error y devolvió algo
                    if (dtPersonalizado != null)
                    {
                        // 3. Suspendemos el dibujo para que no parpadee
                        dgPrincipal.SuspendLayout();

                        // 4. Le inyectamos la nueva tabla cruda al Grid
                        dgPrincipal.DataSource = dtPersonalizado;


                        ConfigurarGrid(dgPrincipal);

                        dgPrincipal.ResumeLayout();
                    }
                }
            }
        }

        // AL HACER DOBLE CLICK EN CUALQUIER FILA DE CUALQUIER GRID,
        // SE ABRE EL FORMULARIO DE EDICION CON LOS DATOS DE ESA TAREA.
        // AL GUARDAR LOS CAMBIOS O ELIMINAR LA TAREA, SE RECARGAN LOS DATOS EN LOS GRIDS
        private void DataGridView_CellDoubleClickGlobal(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView gridClicado = sender as DataGridView;
                DataGridViewRow fila = gridClicado.Rows[e.RowIndex];

                int idTarea = Convert.ToInt32(fila.Cells["ID"].Value);
                DateTime fecha = Convert.ToDateTime(fila.Cells["FECHA"].Value);
                string titulo = fila.Cells["TITULO"].Value?.ToString() ?? "";
                string descripcion = fila.Cells["DESCRIPCION"].Value?.ToString() ?? "";
                string solucion = fila.Cells["SOLUCION"].Value?.ToString() ?? "";
                string estado = fila.Cells["ESTADO"].Value?.ToString() ?? "";

                //ABRIMOS EL FORMULARIO DE EDICION PASANDO LOS DATOS DE LA TAREA SELECCIONADA
                FormEdicion frm = new FormEdicion(idTarea, fecha, titulo, descripcion, solucion, estado);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // SI SE GUARDAN LOS CAMBIOS O SE ELIMINA LA TAREA, RECARGAMOS LOS DATOS EN LOS GRIDS
                    CargarDatos();
                }
            }
        }

        // BOTONO AÑADIR, ABRE UN FOMULARIO DE EDICION EN BLANCO
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FormEdicion frm = new FormEdicion();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // SI SE GUARDAN LOS CAMBIOS, RECARGAMOS LOS DATOS EN LOS GRIDS
                CargarDatos();
            }
        }

        // BOTON EXPORTAR A EXCEL, ABRE EL FORMULARIO DE EXPORTACION PASANDO LOS 3 GRIDS
        // COMO PARAMETRO PARA QUE EL USUARIO PUEDA SELECCIONAR CUAL DE LOS 3 GRIDS DESEA EXPORTAR A EXCEL
        private void btExportarExcel_Click(object sender, EventArgs e)
        {
            FormExportar frm = new FormExportar(dgPrincipal, dgPendientes, dgHistorial);
            frm.ShowDialog();
        }

        // AL HACER CLICK EN EL LOGO, SE ABRE LA PAGINA WEB DEL HOSPITAL
        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://hospitalcrgijon.com/");
        }


    }
}