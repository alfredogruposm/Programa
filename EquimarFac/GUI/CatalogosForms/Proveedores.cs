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
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            actualizagrid();
        }

        public void actualizagrid()
        {
            DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
            dataGridView1.DataSource = catalogosdao.devuelveproveedores();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["NombreComercialProveedor"].Value);
                textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["TelefonoProveedor"].Value);
                textBox5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["RFCProveedor"].Value);
                textBox6.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["ContactoProveedor"].Value);
                lbl_id.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["IDProveedor"].Value);
                textBox14.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["DireccionProveedor"].Value);
                textBox9.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["EmailProveedor"].Value);
                textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["RazonSocialProveedor"].Value);
            }
            catch
            {

            }
        }

        public void limpiatextos()
        {
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            lbl_id.Text = "";
            lbl_naviera.Text = "";
            textBox14.Text = "";
            //comboBox2.Text = "";
            //comboBox3.Text = "";
            textBox9.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text != "") && (textBox3.Text != ""))
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.nombrecomercial = textBox1.Text;
                    catalogosdao.telefono = textBox4.Text;
                    catalogosdao.rfc = textBox5.Text;
                    catalogosdao.contacto = textBox6.Text;
                    catalogosdao.RazonSocial = textBox3.Text;
                    
                    
                    catalogosdao.ReferenciasDir = textBox14.Text;
                    catalogosdao.Email = textBox9.Text;


                    string resultado = catalogosdao.insertaProveedores();
                    if (resultado != "Correcto")
                    {
                        MessageBox.Show(resultado);
                    }
                    else
                    {
                        actualizagrid();
                        limpiatextos();
                    }
                }
                else
                {
                    MessageBox.Show("Es necesario escribir los datos minimos primero");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((lbl_id.Text != ""))
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.idproveedor = int.Parse(lbl_id.Text);
                    catalogosdao.nombrecomercial = textBox1.Text;
                    catalogosdao.telefono = textBox4.Text;
                    catalogosdao.rfc = textBox5.Text;
                    catalogosdao.contacto = textBox6.Text;
                    catalogosdao.RazonSocial = textBox3.Text;


                    catalogosdao.ReferenciasDir = textBox14.Text;
                    catalogosdao.Email = textBox9.Text;


                    string resultado = catalogosdao.modifica_Proveedores();
                    if (resultado != "Correcto")
                    {
                        MessageBox.Show(resultado);
                    }
                    else
                    {
                        actualizagrid();
                        limpiatextos();
                    }
                }
                else
                {
                    MessageBox.Show("Es necesario escribir los datos minimos primero");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿De verdad desea eliminar el proveedor seleccionado?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.idproveedor = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDProveedor"].Value);
                    string resultado = catalogosdao.elimina_Proveedores();
                    if (resultado != "Correcto")
                    {
                        MessageBox.Show(resultado);
                    }
                    else
                    {
                        actualizagrid();
                        limpiatextos();
                    }
                }

            }
            catch
            {
                MessageBox.Show("Es necesario escojer un proveedor primero");
            }
        }
    }
}
