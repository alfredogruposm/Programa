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
    public partial class Compras : Form
    {
        public Compras()
        {
            InitializeComponent();
        }
        public void actualizagrid()
        {
            DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
            if (comboBox1.Text == "Canceladas")
            {
                dataGridView1.DataSource = facturas.devuelvecomprascanceladas();
            }
            else
            {
                dataGridView1.DataSource = facturas.devuelvecompras();
            }
        }
        private void Compras_Load(object sender, EventArgs e)
        {
            actualizagrid();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = comboBox1.Text;
                DataView dv;
                DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();

                if (campo == "Canceladas")
                {
                    actualizagrid();
                }
                else
                {
                    dv = new DataView(facturas.devuelvecompras());
                    dv.RowFilter = campo + " like '%" + textBox8.Text + "%'";

                    dataGridView1.DataSource = dv;

                }

            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.ComprasCtrl facturas = new ComprasCtrl();
            facturas.MdiParent = this.MdiParent;
            facturas.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿De verdad desea cancelar esta factura?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    
                        DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
                        facturas.IDFactura = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                        string resultado = facturas.cancelacompras();
                        if (resultado != "Correcto")
                        {
                            MessageBox.Show(resultado);
                        }
                        else
                        {
                            actualizagrid();
                        }
                    
                }
            }
            catch
            {

            }
        }
    }
}
