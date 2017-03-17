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
    public partial class RemolcadoresBusqueda : Form
    {
        GUI.CatalogosForms.Productos facturagui;
        public RemolcadoresBusqueda(GUI.CatalogosForms.Productos fr1)
        {
            facturagui = new Productos();
            facturagui = fr1;
            InitializeComponent();
        }

        private void RemolcadoresBusqueda_Load(object sender, EventArgs e)
        {
            DAO.CatalogosDAO catalogos = new EquimarFac.DAO.CatalogosDAO();
            dataGridView1.DataSource = catalogos.devuelveproveedores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                facturagui.lbl_proveedor.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                facturagui.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Tiene que agregar primero al catalogo");
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = "NombreComercialProveedor";
                DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();

                DataView dv = new DataView(catalogosdao.devuelveproveedores());
                dv.RowFilter = campo + " like '%" + textBox8.Text + "%'";

                dataGridView1.DataSource = dv;
            }
            catch
            {
            }
        }
    }
}
