using MaterialSkin.Controls;
using System.Data;
using System.Windows.Forms;

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
            } */

            InitializeComponent();


            this.Padding = new Padding(3, 70, 3, 3);
            this.Text = "                                                            " +
                        "                                                            " +
                        "                                                  RECORDADORA";
            this.WindowState = FormWindowState.Maximized;
        }


        private void Form1_Load(object sender, System.EventArgs e)
        {
            CargarDatos();
        }

        public void CargarDatos()
        {

            string consulta = "SELECT FECHA, TITULO, DESCRIPCION, SOLUCION, ESTADO FROM TABLA_RECORDADORA";
            DataTable dt = ad.ObtenerDatos(consulta);

            if (dt != null)
            {

                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    column.MinimumWidth = 100;
                }

            }

        }
    }
}
