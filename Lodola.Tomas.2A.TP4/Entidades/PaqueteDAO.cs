using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        /// <summary>
        /// Constructor estatico de la clase que instancia el comando, sus caracteristicas y la conexion
        /// </summary>
        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
            PaqueteDAO.comando.CommandType = CommandType.Text;
        }

        /// <summary>
        /// Guarda los datos de un paquete en la base de datos
        /// </summary>
        /// <param name="p">El paquete a guardar</param>
        /// <returns>Retorna true si se pudo establecer conexion y se pudieron guardar los datos del paquete, false caso contrario</returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;

            try
            {
                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando.CommandText = "INSERT INTO [correo-sp-2017].dbo.Paquetes(direccionEntrega, trackingID, alumno) VALUES('" + p.DireccionEntrega + "', '" + p.TrackingID + "', 'Lodola Tomas')";
                PaqueteDAO.comando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                PaqueteDAO.conexion.Close();
            }

            return retorno;
        }
    }
}
