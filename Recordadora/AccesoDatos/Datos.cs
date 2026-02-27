using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Recordadora.AccesoDatos
{
    internal class Datos
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["RECORDADORA"].ConnectionString;

        public DataTable ObtenerDatos(string consulta, SqlParameter[] parametros = null)
        {

            DataTable dt = new DataTable();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    if (parametros != null) { cmd.Parameters.AddRange(parametros); }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch (Exception ex)
                { MessageBox.Show("Error SQL(ObtenerDatos: " + ex.Message); }


            }
            return dt;


        }

        public void EjecutarComando(string consulta, SqlParameter[] parametros)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error SQL(EjecutarComando)" + ex.Message);
                }
            }
        }
    }
}








