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
            btEliminar.Visible = false; // Si es nuevo, no se puede eliminar
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
            string estadoSeleccionado = cbEstado.SelectedItem?.ToString() ?? "(Seleccione un estado)";

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción no puede estar vacía.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si no ha elegido nada válido, forzamos a PENDIENTE
            if (estadoSeleccionado == "(Seleccione un estado)")
            {
                estadoSeleccionado = "PENDIENTE";
            }
            string consulta = "";

            // 2. Preparamos los parámetros (AÑADIMOS LA FECHA AQUÍ)
            SqlParameter[] parametros = new SqlParameter[]
            {
        new SqlParameter("@FECHA", dtpFecha.Value), // Cogemos la fecha exacta del control
        new SqlParameter("@TITULO", txtTitulo.Text.Trim()),
        new SqlParameter("@DESCRIPCION", txtDescripcion.Text.Trim()),
        new SqlParameter("@SOLUCION", txtSolucion.Text.Trim()),
        new SqlParameter("@ESTADO", estadoSeleccionado)
            };

            // 3. Decidimos si es INSERT o UPDATE
            // Si es nuevo, el ID es 0, por lo que hacemos un INSERT. Si no, hacemos un UPDATE.
            if (idTareaActual == 0)
            {
                if (cbEstado.SelectedItem.ToString() != "(Seleccione un estado)")
                {
                    // INSERT: AÑADIMOS LA FECHA A LA CONSULTA
                    consulta = "INSERT INTO TABLA_RECORDADORA (FECHA, TITULO, DESCRIPCION, SOLUCION, ESTADO) " +
                               "VALUES (@FECHA, @TITULO, @DESCRIPCION, @SOLUCION, @ESTADO)";
                }
                else
                {
                    consulta = "INSERT INTO TABLA_RECORDADORA (FECHA, TITULO, DESCRIPCION, SOLUCION, ESTADO) " +
                               "VALUES (@FECHA, @TITULO, @DESCRIPCION, @SOLUCION, 'PENDIENTE')";
                }
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

        private void btEliminar_Click(object sender, EventArgs e)
        {
            // 1. Preguntamos al usuario si está seguro (Regla de oro de UX)
            DialogResult respuesta = MessageBox.Show(
                "¿Estás seguro de que deseas eliminar este registro? Esta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            // 2. Si el usuario dice que SÍ (Yes)
            if (respuesta == DialogResult.Yes)
            {
                // Preparamos la consulta SQL para borrar usando el ID de la tarea actual
                string consulta = "DELETE FROM TABLA_RECORDADORA WHERE ID = @ID";

                SqlParameter[] parametros = new SqlParameter[]
                {
            new SqlParameter("@ID", idTareaActual)
                };

                // Ejecutamos el comando en la base de datos
                ad.EjecutarComando(consulta, parametros);

                // Cerramos el formulario devolviendo OK para que el Form1 sepa que tiene que recargar los Grids
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}