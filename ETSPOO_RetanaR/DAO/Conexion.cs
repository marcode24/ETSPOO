using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace ETSPOO_RetanaR.DAO
{
    public class Conexion
    {
        protected string cadena_conexion;
        protected SqlConnection cnn;
        protected string tabla;

        public Conexion()
        {
            try
            {
                cadena_conexion = @"Data Source=.;Initial Catalog=miTienda;Integrated Security=True";
                cnn = new SqlConnection(cadena_conexion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected DataTable consultar(SqlCommand cmd)
        {
            try
            {
                if (cnn.State == ConnectionState.Closed) cnn.Open();

                cmd.Connection = cnn;
                SqlDataReader lector = cmd.ExecuteReader();
                DataTable tabla = new DataTable();
                tabla.Load(lector);
                cnn.Close();
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected int ejecutar(SqlCommand cmd)
        {
            try
            {
                if (cnn.State == ConnectionState.Closed) cnn.Open();
                cmd.Connection = cnn;
                int resultado = cmd.ExecuteNonQuery();
                cnn.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected DataTable Consultar(SqlCommand cmd)
        {
            try
            {
                if (cnn.State == ConnectionState.Closed) cnn.Open();
                cmd.Connection = cnn;
                SqlDataReader lector = cmd.ExecuteReader();
                DataTable tabla = new DataTable();
                tabla.Load(lector);
                cnn.Close();
                return tabla;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}