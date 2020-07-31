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

namespace ETSPOO_Retana
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            misProductos mi = new misProductos();
            mi.Show();
            this.Hide();
        }
        Productos pro = new Productos();
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text == string.Empty)
            {
                MessageBox.Show("No hay un id de producto");
            }
            else
            {
                pro.id_p = Convert.ToInt32(txtBuscar.Text);
                dgvVenta.DataSource = pro.buscarProducto();
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Venta realizada");
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
