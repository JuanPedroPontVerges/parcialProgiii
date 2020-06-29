using ParcialPontVerges.Models;
using ParcialPontVerges.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ParcialPontVerges.AccesoDatos
{
    public class Ad
    {
        public static List<TipoDocVM> obtenerListaDoc()
        {
            List<TipoDocVM> resultado = new List<TipoDocVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand(); 
                string consulta = "SELECT * FROM TiposDocumentos";
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
                        TipoDocVM aux = new TipoDocVM();
                        aux.idTipoDoc = int.Parse(dr["Id"].ToString());
                        aux.nombre = dr["Nombre"].ToString();

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

        public static List<DeporteVM> obtenerListaDeportes()
        {
            List<DeporteVM> resultado = new List<DeporteVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT * FROM Deportes";
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
                        aux.idDeporte = int.Parse(dr["Id"].ToString());
                        aux.nombre = dr["Nombre"].ToString();

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

        public static List<Socio> ObtenerListaSocios()
        {
            List<Socio> resultado = new List<Socio>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand(); 
                string consulta = "SELECT * FROM Socios";
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
                        Socio aux = new Socio();
                        aux.id = int.Parse(dr["Id"].ToString());
                        aux.nombre = dr["Nombre"].ToString();
                        aux.apellido = dr["Apellido"].ToString();
                        aux.idTipoDoc = int.Parse(dr["IdTipoDocumento"].ToString());
                        aux.idDeporte = int.Parse(dr["IdDeporte"].ToString());
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

        public static bool InsertarNuevaPersona(Socio s)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "INSERT INTO Socios VALUES(@nombre,@apellido,@idTipoDoc,@nroDoc,@idDeporte)";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@nombre", s.nombre);
                cmd.Parameters.AddWithValue("@apellido", s.apellido);
                cmd.Parameters.AddWithValue("@idTipoDoc", s.idTipoDoc);
                cmd.Parameters.AddWithValue("@nroDoc", s.nroDoc);
                cmd.Parameters.AddWithValue("@idDeporte", s.idDeporte);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;

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