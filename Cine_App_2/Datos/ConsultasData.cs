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

    private static SqlCommand AbrirConexion(string Query, bool boProcedure = true, List<Parametros> parametros = null)
    {
        conexion = conexion == null ? conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()) : conexion;
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

    public static DataTable ejecutarConsulta(string consulta, List<Parametros> parametros = null)
    {

        comando = AbrirConexion(consulta);
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

    //SObreCArga
    public static int ReturnValueIntOFQuery(string consulta, List<Parametros> parametros = null)
    {
        comando = AbrirConexion(consulta, false);
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

    public static DataTable ejecutarSpParams(string nombreSp, List<Parametros> parametros = null)
    {
        comando = AbrirConexion(nombreSp, true , parametros);
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

    public static void ejecutarSp(string nombreSp, List<Parametros> parametros = null)
    {
        comando = AbrirConexion(nombreSp, true, parametros);
        try
        {
            comando.ExecuteScalar();
        }
        //catch (e) 
        //{
        //  return ("Error datos tecnicos" e);
        //}
        finally
        {
            conexion.Close();
        }
    }

    //
    //    public static DataGridView ejecutarConsulta(string consulta)
    //    {
    //        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
    //        conexion.Open();
    //        SqlDataAdapter adp = new SqlDataAdapter();
    //        SqlCommand cmd = new SqlCommand(consulta, conexion);
    //        adp.SelectCommand = cmd;
    //        DataTable tabla = new DataTable();
    //        adp.SelectCommand = cmd;
    //        adp.Fill(tabla);
    //        conexion.Close();
    //        conexion.Dispose();
    //        DataGridView result = new DataGridView();
    //        result.DataSource = tabla;
    //        return result;
    //    }

    //    public static void ejecutarSp(string nombreSp, SqlCommand comando)
    //    {
    //        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
    //        conexion.Open();
    //        comando.Connection = conexion;
    //        comando.CommandText = nombreSp;
    //        comando.ExecuteNonQuery();
    //    }

    //    public static DataTable obtenerCombo(string nombreSp)
    //    {
    //        try
    //        {
    //            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
    //            conexion.Open();
    //            SqlCommand cmd = new SqlCommand();
    //            cmd.Connection = conexion;
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cmd.CommandText = nombreSp;
    //            DataTable tabla = new DataTable();
    //            tabla.Load(cmd.ExecuteReader());
    //            conexion.Close();
    //            return tabla;
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

    //    public static DataTable ejecutarSpParams(string nombreSp, SqlCommand cmd)
    //    {
    //        try
    //        {
    //            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
    //            conexion.Open();
    //            cmd.Connection = conexion;
    //            cmd.CommandText = nombreSp;
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            DataTable tabla = new DataTable();
    //            tabla.Load(cmd.ExecuteReader());
    //            conexion.Close();
    //            return tabla;
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

     }


}