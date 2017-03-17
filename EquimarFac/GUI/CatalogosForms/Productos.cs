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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿De verdad desea eliminar el producto seleccionado?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.IDProducto = int.Parse(lbl_id.Text);
                    string resultado = catalogosdao.elimina_Productos();
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
                MessageBox.Show("Es necesario escojer un cliente primero");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.CheckState == CheckState.Checked)
                {
                    if ((textBox3.Text != "") && (lbl_proveedor.Text != ""))
                    {
                        DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                        catalogosdao.IDProducto = int.Parse(lbl_id.Text);
                        catalogosdao.Cantidad = decimal.Parse(textBox3.Text);
                        string resultado = catalogosdao.modificaexistencias();
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
                else
                {
                    if ((textBox1.Text != "") && (textBox4.Text != "") && (textBox5.Text != "") && (lbl_proveedor.Text != ""))
                    {
                        DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                        catalogosdao.IDProducto = int.Parse(lbl_id.Text);
                        catalogosdao.Descripcion = textBox1.Text;
                        catalogosdao.idproveedor = int.Parse(lbl_proveedor.Text);
                        catalogosdao.Presentacion = textBox4.Text;
                        catalogosdao.Precio = Decimal.Parse(textBox5.Text);
                        catalogosdao.Inventariable = comboBox1.SelectedIndex;



                        string resultado = catalogosdao.modifica_Productos();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text != "") && (textBox4.Text != "") && (textBox5.Text != "") && (lbl_proveedor.Text != ""))
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.Descripcion = textBox1.Text;
                    catalogosdao.idproveedor = int.Parse(lbl_proveedor.Text);
                    catalogosdao.Presentacion = textBox4.Text;
                    catalogosdao.Precio = Decimal.Parse(textBox5.Text);
                    catalogosdao.Cantidad = 0;
                    catalogosdao.Inventariable = comboBox1.SelectedIndex;
                    


                    string resultado = catalogosdao.insertaProductos();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Productos_Load(object sender, EventArgs e)
        {
            actualizagrid();
        }

        public void actualizagrid()
        {
            DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
            dataGridView1.DataSource = catalogosdao.devuelveProductos();
        }

        public void limpiatextos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            label3.Text = "Cantidad";
            lbl_id.Text = "";
            lbl_proveedor.Text = "";
            comboBox1.SelectedIndex = -1;
            textBox1.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            button4.Enabled = true;
            checkBox1.Checked = false;
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Descripcion"].Value);
                textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["NombreComercialProveedor"].Value);
                textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Presentacion"].Value);
                textBox5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Precio"].Value);
                lbl_proveedor.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["IDProveedor"].Value);
                lbl_id.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["IDProducto"].Value);
                textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Cantidad"].Value);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = "Descripcion";
                DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();

                DataView dv = new DataView(catalogosdao.devuelveProductos());
                dv.RowFilter = campo + " like '%" + textBox8.Text + "%'";

                dataGridView1.DataSource = dv;
            }
            catch
            {
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.RemolcadoresBusqueda remolcadores = new RemolcadoresBusqueda(this);
            remolcadores.MdiParent = this.MdiParent;
            remolcadores.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked == true)
            //{
            //    checkBox1.Checked = textBox3.Enabled;
            //    textBox3.Text = "";
            //    label3.Text = "Cantidad A AGREGAR";
            //    textBox1.Enabled = false;
            //    textBox3.Enabled = false;
            //    textBox4.Enabled = false;
            //    textBox5.Enabled = false;
            //    button4.Enabled = false;
            //}
            //else
            //{
            //    checkBox1.Checked = textBox3.Enabled;
            //    textBox3.Text = "";
            //    textBox1.Enabled = true;
            //    textBox3.Enabled = true;
            //    textBox4.Enabled = true;
            //    textBox5.Enabled = true;
            //    button4.Enabled = true;
            //}
            
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                
                textBox1.Enabled = false;
                
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                button4.Enabled = false;
            }
            else
            {
                
                textBox1.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                button4.Enabled = true;
            }
        }
    }
}
