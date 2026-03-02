using MaterialSkin;
using MaterialSkin.Controls;
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


        private void Form1_Load(object sender, System.EventArgs e)
        {
            CargarDatos();
            configurarCalendario();

            // foco en la imagen para quitar el foco del resto
            ActiveControl = pictureBoxLogo;
        }


        private void configurarCalendario()
        {

            mcCalendario.TitleBackColor = Color.FromArgb(13, 71, 161);
            mcCalendario.TitleForeColor = Color.White;
            mcCalendario.TrailingForeColor = Color.Silver;
            mcCalendario.ShowTodayCircle = false;
            mcCalendario.ShowToday = false;


            mcCalendario.Padding = new Padding(5);
        }



        // configuracion del grid, colores, fuentes, etc
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



        // carga de datos inicial
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

        // eventos

    }
}
