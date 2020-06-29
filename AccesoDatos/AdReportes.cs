using ParcialPontVerges.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.AccesoDatos
{
    public class AD_Reportes
    {
        public static List<DeporteVM> ObtenerCantidadPorDeporte()
        {
            List<DeporteVM> resultado = new List<DeporteVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = @"SELECT d.Nombre AS 'Deporte', COUNT(*) AS 'Cantidad'
                    FROM Deportes d
                    JOIN Socios s ON s.IdDeporte=d.Id
                    GROUP BY d.Nombre";

                cmd.Parameters.Clear();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        DeporteVM aux = new DeporteVM();

                        aux.nombre = dr["Deporte"].ToString();
                        aux.cantidad = int.Parse(dr["Cantidad"].ToString());

                        resultado.Add(aux);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                cn.Close();

            }
            return resultado;
        }


        public static List<SocioItemVM> ObtenerReportePersona()
        {
            List<SocioItemVM> resultado = new List<SocioItemVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = @"SELECT s.Id, s.Nombre, s.Apellido, s.IdTipoDocumento, s.NroDocumento, d.Nombre AS 'Deporte'
                                    FROM Socios s
                                    INNER JOIN Deportes d ON s.IdDeporte= d.Id";

                cmd.Parameters.Clear();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        SocioItemVM aux = new SocioItemVM();
                        aux.id = int.Parse(dr["Id"].ToString());
                        aux.nombre = dr["Nombre"].ToString();
                        aux.apellido = dr["Apellido"].ToString();
                        aux.nombreTipoDoc = dr["IdTipoDocumento"].ToString();
                        aux.nroDoc = int.Parse(dr["NroDocumento"].ToString());
                        aux.nombreDeporte = dr["Nombre"].ToString();

                        resultado.Add(aux);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                cn.Close();

            }
            return resultado;
        }
    }
}











