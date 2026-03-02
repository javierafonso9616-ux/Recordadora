using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Recordadora
{
    public partial class FormEdicion : MaterialForm
    {
        // Variable global para saber qué ID estamos editando. 
        // Si es 0, significa que estamos creando una tarea NUEVA.
        private int idTareaActual = 0;
        AccesoDatos.Datos ad = new AccesoDatos.Datos();

        // CONSTRUCTOR PARA CREAR UNA TAREA NUEVA
        public FormEdicion()
        {
            InitializeComponent();
            ConfigurarMaterialSkin();

            dtpFecha.Value = DateTime.Now;

            this.Text = "Nueva Tarea";
            materialButton1.Visible = false; // Si es nuevo, no se puede eliminar
            cbEstado.SelectedIndex = 0; // PENDIENTE por defecto
        }

        // CONSTRUCTOR PARA EDITAR UNA TAREA EXISTENTE (El que usará el doble clic)
        public FormEdicion(int id, DateTime fecha, string titulo, string descripcion, string solucion, string estado)
        {
            InitializeComponent();
            ConfigurarMaterialSkin();

            this.Text = "Editar Tarea";
            this.idTareaActual = id;

            // Volcamos los datos en los controles de la pantalla
            dtpFecha.Value = fecha;
            txtTitulo.Text = titulo;
            txtDescripcion.Text = descripcion;
            txtSolucion.Text = solucion;
            cbEstado.SelectedItem = estado;
        }

        private void ConfigurarMaterialSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            // materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue900,
                Primary.Blue900,
                Primary.Blue200,
                Accent.Blue700,
                TextShade.WHITE);
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validación básica
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción no puede estar vacía.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string consulta = "";

            // 2. Preparamos los parámetros (AÑADIMOS LA FECHA AQUÍ)
            SqlParameter[] parametros = new SqlParameter[]
            {
        new SqlParameter("@FECHA", dtpFecha.Value), // Cogemos la fecha exacta del control
        new SqlParameter("@TITULO", txtTitulo.Text.Trim()),
        new SqlParameter("@DESCRIPCION", txtDescripcion.Text.Trim()),
        new SqlParameter("@SOLUCION", txtSolucion.Text.Trim()),
        new SqlParameter("@ESTADO", cbEstado.SelectedItem.ToString())
            };

            // 3. Decidimos si es INSERT o UPDATE
            if (idTareaActual == 0)
            {
                // INSERT: AÑADIMOS LA FECHA A LA CONSULTA
                consulta = "INSERT INTO TABLA_RECORDADORA (FECHA, TITULO, DESCRIPCION, SOLUCION, ESTADO) " +
                           "VALUES (@FECHA, @TITULO, @DESCRIPCION, @SOLUCION, @ESTADO)";
            }
            else
            {
                // UPDATE: AÑADIMOS LA FECHA A LA CONSULTA PARA QUE SE PUEDA CAMBIAR
                consulta = "UPDATE TABLA_RECORDADORA SET " +
                           "FECHA = @FECHA, " +
                           "TITULO = @TITULO, " +
                           "DESCRIPCION = @DESCRIPCION, " +
                           "SOLUCION = @SOLUCION, " +
                           "ESTADO = @ESTADO " +
                           "WHERE ID = @ID";

                // Añadimos el parámetro del ID para el UPDATE
                Array.Resize(ref parametros, parametros.Length + 1);
                parametros[parametros.Length - 1] = new SqlParameter("@ID", idTareaActual);
            }

            // 4. Ejecutamos el comando
            ad.EjecutarComando(consulta, parametros);

            // 5. Cerramos devolviendo OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}