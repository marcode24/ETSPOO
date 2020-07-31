using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ETSPOO_RetanaR.Modelos;
using System.Data.SqlClient;
using ETSPOO_RetanaR;

namespace ETSPOO_Retana
{
    public partial class misProductos : Form
    {

        public misProductos()
        {
            InitializeComponent();
            obtenerNO();
            miP();
        }
        Productos producto = new Productos();
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == string.Empty || txtNombre.Text.Trim() == string.Empty || txtPrecio.Text == string.Empty || txtDescripcion.Text == string.Empty)
            {
                MessageBox.Show("Verifique que los campos no esten vacios", "Error al guardar");
            }
            else
            {
                producto.id_p = Convert.ToInt32(txtID.Text);
                producto.nombre = txtNombre.Text;
                producto.precio = Convert.ToDouble(txtPrecio.Text);
                producto.descripcion = txtDescripcion.Text;

                if (producto.guardarProducto())
                {
                    MessageBox.Show("Producto agregado correctamente");
                    obtenerNO();
                    borrarCampos();
                    dgvProductos.DataSource = producto.obtenerProductos();
                    dgvProductos.ReadOnly = true;

                }
                else
                {
                    MessageBox.Show("Ocurrio un error");

                }

            }

        }

        public void borrarCampos()
        {
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtDescripcion.Text = "";
        }


        string miconexion = @"Data Source=.;Initial Catalog=miTienda;Integrated Security=True";
        string numero;
        int no2;

        public void obtenerNO()
        {
            using (SqlConnection conexion = new SqlConnection(miconexion))
            {
                conexion.Open();
                string query = "select max (id_producto) as Ultimo from Productos";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    numero = reader["Ultimo"].ToString();

                    if (numero == "")
                    {
                        txtID.Text = 1.ToString();
                    }
                    else
                    {
                        no2 = int.Parse(numero) + 1;
                        txtID.Text = no2.ToString();
                    }
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty)
            {
                MessageBox.Show("Seleccione un producto");
            }
            else
            {
                producto.id_p = Convert.ToInt32(txtID.Text);
                producto.nombre = txtNombre.Text;
                string precio = txtPrecio.Text;
                producto.precio = Convert.ToDouble(precio);
                producto.descripcion = txtDescripcion.Text;
                if (producto.actualizarProducto())
                {
                    MessageBox.Show("Producto actualizado");
                    borrarCampos();
                    btnGuardar.Enabled = true;
                    dgvProductos.DataSource = producto.obtenerProductos();
                    dgvProductos.ReadOnly = true;
                    obtenerNO();

                }
            }
        }

        public void miP()
        {
            dgvProductos.DataSource = producto.obtenerProductos();
            dgvProductos.ReadOnly = true;
            dgvProductos.Columns["id_Producto"].DataPropertyName = "id_Producto";
            dgvProductos.Columns["Nombre"].DataPropertyName = "nombre";
            dgvProductos.Columns["precio"].DataPropertyName = "precio";
            dgvProductos.Columns["descripcion"].DataPropertyName = "descripcion";
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null && dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv.SelectedRows[0];
                if (row != null)
                {
                    btnActualizar.Enabled = true;
                    btnBorrar.Enabled = true;
                    btnGuardar.Enabled = false;
                    txtID.Text = row.Cells[0].Value.ToString();
                    txtNombre.Text = row.Cells[1].Value.ToString();
                    txtPrecio.Text = row.Cells[2].Value.ToString();
                    txtDescripcion.Text = row.Cells[3].Value.ToString();
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty)
            {
                MessageBox.Show("Seleccione un producto");
            }
            else
            {
                producto.id_p = Convert.ToInt32(txtID.Text);
                if (producto.borrarProducto())
                {
                    MessageBox.Show("Producto eliminado");
                    borrarCampos();
                    btnGuardar.Enabled = true;
                    dgvProductos.DataSource = producto.obtenerProductos();
                    dgvProductos.ReadOnly = true;
                    obtenerNO();

                }
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarPrecio(e, sender);
        }
        public void validarPrecio(KeyPressEventArgs e, object sender)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvProductos_SelectionChanged_1(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null && dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv.SelectedRows[0];
                if (row != null)
                {
                    btnActualizar.Enabled = true;
                    btnBorrar.Enabled = true;
                    btnGuardar.Enabled = false;
                    txtID.Text = row.Cells[0].Value.ToString();
                    txtNombre.Text = row.Cells[1].Value.ToString();
                    txtPrecio.Text = row.Cells[2].Value.ToString();
                    txtDescripcion.Text = row.Cells[3].Value.ToString();
                }
            }
        }
    }
}
