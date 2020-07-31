using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETSPOO_RetanaR.DAO;
using System.Data;
using System.Data.SqlClient;


namespace ETSPOO_RetanaR.Modelos
{
    class Productos : Conexion
    {

        public int id_p { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public string descripcion { get; set; }


        public bool guardarProducto()
        {
            try
            {

                string query = "INSERT INTO Productos(id_producto, nombre, precio, descripcion) Values (@id, @nombre, @precio, @descripcion)";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@id", id_p);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                return (ejecutar(cmd) > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable obtenerProductos()
        {
            try
            {
                string query = "SELECT id_producto, nombre, CONVERT(varchar, CONVERT(varchar, cast(precio as money), 1)) as precio, descripcion FROM Productos";
                SqlCommand cmd = new SqlCommand(query);
                return Consultar(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool actualizarProducto()
        {
            string query = "UPDATE Productos SET nombre= @nombre, precio = @precio, descripcion = @d WHERE id_producto = @id";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id_p);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@precio", precio);
            cmd.Parameters.AddWithValue("@d", descripcion);
            return (ejecutar(cmd) > 0) ? true : false;
        }

        public bool borrarProducto()
        {
            string query = "DELETE FROM Productos WHERE id_Producto = @id";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id_p);
            return (ejecutar(cmd) > 0) ? true : false;
        }

        public DataTable buscarProducto()
        {
            try
            {
                string query = "SELECT * FROM Productos WHERE id_producto = @id";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@id", id_p);
                return Consultar(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
