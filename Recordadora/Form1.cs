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

            // Activamos DoubleBuffered a nivel de Form
            this.DoubleBuffered = true;

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

            // Maximizamos antes de mostrar para evitar saltos de resolución
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            // Activamos el anti-parpadeo mediante reflexión en los grids
            HabilitarDoubleBuffer(dgPrincipal);
            HabilitarDoubleBuffer(dgPendientes);
            HabilitarDoubleBuffer(dgHistorial);

            CargarDatos();

            ConfigurarCalendar();
            BotonRedondoExcel();

            ActiveControl = pictureBoxLogo;
        }

        private void HabilitarDoubleBuffer(DataGridView dgv)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, dgv, new object[] { true });
        }

        private void BotonRedondoExcel()
        {
            mbExportarExcel.Text = "";
            mbExportarExcel.BackColor = Color.White;
            mbExportarExcel.FlatStyle = FlatStyle.Flat;
            mbExportarExcel.FlatAppearance.BorderSize = 0;

            bool ratonEncima = false;

            mbExportarExcel.MouseEnter += (s, ev) => { ratonEncima = true; mbExportarExcel.Invalidate(); };
            mbExportarExcel.MouseLeave += (s, ev) => { ratonEncima = false; mbExportarExcel.Invalidate(); };

            mbExportarExcel.Paint += (s, ev) =>
            {
                ev.Graphics.Clear(Color.White);
                ev.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int margen = 4;
                int anchoReal = mbExportarExcel.Width - margen - 1;
                int altoReal = mbExportarExcel.Height - margen - 1;

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

        private void ConfigurarCalendar()
        {
            mcCalendario.TitleBackColor = Color.FromArgb(13, 71, 161);
            mcCalendario.TitleForeColor = Color.White;
            mcCalendario.TrailingForeColor = Color.FromArgb(230, 230, 230);
            mcCalendario.Font = new Font("Segoe UI", 15F, FontStyle.Regular);
        }

        public void ConfigurarGrid(DataGridView grid)
        {
            Color azulOscuro = Color.FromArgb(13, 71, 161);

            // Optimizaciones clave: Desactivamos el auto-tamaño constante que causa el parpadeo
            grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grid.AllowUserToResizeRows = false;

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
            grid.RowHeadersVisible = false;

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

            // Forzamos el ajuste de filas una sola vez al configurar para evitar el "baile"
            grid.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
        }

        public void CargarDatos()
        {
            // Suspendemos el dibujo para que no se vea el proceso de carga
            dgPrincipal.SuspendLayout();
            dgPendientes.SuspendLayout();
            dgHistorial.SuspendLayout();

            string consulta = "SELECT ID, FECHA, TITULO, DESCRIPCION, SOLUCION, ESTADO FROM TABLA_RECORDADORA";
            DataTable dt = ad.ObtenerDatos(consulta);

            if (dt != null)
            {
                dgPrincipal.DataSource = dt;
                ConfigurarGrid(dgPrincipal);

                string hoy = DateTime.Now.ToString("yyyy-MM-dd");
                string manana = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                dt.DefaultView.RowFilter = string.Format("FECHA >= '{0}' AND FECHA < '{1}'", hoy, manana);

                DataView dvPendientes = new DataView(dt);
                dvPendientes.RowFilter = "ESTADO = 'PENDIENTE'";
                dvPendientes.Sort = "FECHA ASC";
                dgPendientes.DataSource = dvPendientes;
                ConfigurarGrid(dgPendientes);

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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (dgPrincipal.DataSource is DataTable dt)
            {
                DataView dv = dt.DefaultView;
                string busqueda = txtBuscar.Text.Trim();
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

                FormEdicion frm = new FormEdicion(idTarea, fecha, titulo, descripcion, solucion, estado);
                if (frm.ShowDialog() == DialogResult.OK)
                {
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
            FormExportar frm = new FormExportar(dgPrincipal, dgPendientes, dgHistorial);
            frm.ShowDialog();
        }
    }
}