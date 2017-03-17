using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquimarFac.GUI.CatalogosForms
{
    public partial class BarcosBusqueda : Form
    {
        GUI.CatalogosForms.ComprasCtrl facturagui;
        public BarcosBusqueda(GUI.CatalogosForms.ComprasCtrl fr1)
        {
            facturagui = new ComprasCtrl();
            facturagui = fr1;
            InitializeComponent();
        }

        private void BarcosBusqueda_Load(object sender, EventArgs e)
        {
            DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
            dataGridView1.DataSource = catalogosdao.devuelveproveedores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                facturagui.lbl_idCliente.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                facturagui.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                facturagui.textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                facturagui.actualizaproductosproveedor();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Tiene que agregar primero al catalogo");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = "NombreComercialProveedor";
                DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();

                DataView dv = new DataView(catalogosdao.devuelveproveedores());
                dv.RowFilter = campo + " like '%" + textBox3.Text + "%'";

                dataGridView1.DataSource = dv;
            }
            catch
            {
            }
        }
    }
}
