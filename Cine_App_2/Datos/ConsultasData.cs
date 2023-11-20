using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Cine_App_2.Datos
{
    public class ConsultasData
    {
         
        private static SqlConnection conexion;
        private static SqlCommand comando;
        private static string cadenaConexion = "Data Source=Usuario-PC\\SQLEXPRESS;Initial Catalog=DB_CINEMA;Integrated Security=True";
        //ConfigurationManager.ConnectionStrings["cnnString"].ToString()) : conexion;
        private static SqlCommand AbrirConexion(string Query, bool boProcedure = true, List<Parametros> parametros = null)
        {
            conexion = conexion == null ? conexion = new SqlConnection(cadenaConexion) : conexion;

            conexion.Open();
            
            comando = new SqlCommand(Query, conexion);
            if (boProcedure)
                comando.CommandType = CommandType.StoredProcedure;
            if (parametros != null)
                Chargeparameters(parametros);

            comando.CommandText = Query;
            return comando;
        }

        private static void Chargeparameters(List<Parametros> parametros)
        {
            foreach (Parametros p in parametros)
            {
                if (p.TipoDato == "int")
                    comando.Parameters.Add(p.Key, SqlDbType.Int).Value = p.Value;
                else
                    comando.Parameters.AddWithValue(p.Key, p.Value);
            }
        }

        public static int ConsultaRetornaInt(string consulta, bool boProcedure = false, List<Parametros> parametros = null)
        {
            comando = AbrirConexion(consulta, boProcedure, parametros);
            try
            {
                var resultado = comando.ExecuteScalar();
                return (int)resultado;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                conexion.Close();
            }
        }

        public static DataTable ConsultaTablaRetorno(string consulta, bool boProcedure = false, List<Parametros> parametros = null)
        {
            comando = AbrirConexion(consulta, boProcedure, parametros);
            DataTable tabla = new DataTable();
            try
            {
                tabla.Load(comando.ExecuteReader());
                return tabla;
            }
            catch (Exception)
            {
                return tabla;
            }
            finally
            {
                conexion.Close();
            }
        }
        public static void EjecutarSP(string nombreSp, bool boProcedure = false, List<Parametros> parametros = null) 
        {
            comando = AbrirConexion(nombreSp, boProcedure, parametros);
            try
            {
                comando.ExecuteScalar();
            }
            catch (Exception e) 
            {
                throw e;
            }
            finally
            {
                conexion.Close();
            }
        }

        public static string ConsultaRetornaString(string nombreSp, bool boProcedure = false, List<Parametros> parametros = null)
        {
            comando = AbrirConexion(nombreSp, boProcedure, parametros);
            try
            {
                var resultado = comando.ExecuteScalar();
                return resultado.ToString();
            }
            catch (Exception e)
            {
                return "";
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}