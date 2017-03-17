using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rnd = EquimarFac.FelWebService;


namespace EquimarFac.GUI.CatalogosForms
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            actualizagrid();
        }

        public void actualizagrid()
        {
            DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
            dataGridView1.DataSource = catalogosdao.devuelveclientes();
        }
        

        
        public void limpiatextos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            lbl_id.Text = "";
            lbl_naviera.Text = "";
            textBox13.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox15.Text = "";
            textBox14.Text = "";
            //comboBox2.Text = "";
            //comboBox3.Text = "";
            textBox9.Text = "";
            textBox17.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != ""))
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.nombrecomercial = textBox1.Text;
                    catalogosdao.Localidad = textBox13.Text;
                    catalogosdao.calle = textBox2.Text;
                    catalogosdao.telefono = textBox4.Text;
                    catalogosdao.rfc = textBox5.Text;
                    catalogosdao.contacto = textBox6.Text;
                    catalogosdao.RazonSocial = textBox3.Text;
                    catalogosdao.Municipio = textBox13.Text;
                    catalogosdao.calle = textBox2.Text;
                    catalogosdao.NumExt = textBox10.Text;
                    catalogosdao.NumInt = textBox11.Text;
                    catalogosdao.Colonia = textBox12.Text;
                    catalogosdao.Localidad = textBox15.Text;
                    catalogosdao.ReferenciasDir = textBox14.Text;
                    catalogosdao.Estado = comboBox2.Text;
                    catalogosdao.Pais = comboBox3.Text;
                    catalogosdao.Email = textBox9.Text;
                    catalogosdao.CodigoPostal = textBox17.Text;

                    
                    string resultado = catalogosdao.insertaclientes();
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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["NombreComercialCliente"].Value);
                textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["calleCliente"].Value);
                textBox13.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["MunicipioCliente"].Value);
                textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["TelefonoCliente"].Value);
                textBox5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["RFCCliente"].Value);
                textBox6.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["ContactoCliente"].Value);
                lbl_id.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["IDCliente"].Value);
                textBox10.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["NumExtCliente"].Value);
                textBox11.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["NumIntCliente"].Value);
                textBox12.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["ColoniaCliente"].Value);
                textBox15.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["LocalidadCliente"].Value);
                textBox14.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["ReferenciasDireccionCliente"].Value);
                comboBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["EstadoCliente"].Value);
                comboBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["PaisCliente"].Value);
                textBox9.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["EmailCliente"].Value);
                textBox17.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["CodigoPostalCliente"].Value);
                textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["RazonSocialCliente"].Value);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((lbl_id.Text != ""))
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.idcliente = int.Parse(lbl_id.Text);
                    catalogosdao.nombrecomercial = textBox1.Text;
                    catalogosdao.Localidad = textBox13.Text;
                    catalogosdao.calle = textBox2.Text;
                    catalogosdao.telefono = textBox4.Text;
                    catalogosdao.rfc = textBox5.Text;
                    catalogosdao.contacto = textBox6.Text;
                    catalogosdao.RazonSocial = textBox3.Text;
                    catalogosdao.Municipio = textBox13.Text;
                    catalogosdao.calle = textBox2.Text;
                    catalogosdao.NumExt = textBox10.Text;
                    catalogosdao.NumInt = textBox11.Text;
                    catalogosdao.Colonia = textBox12.Text;
                    catalogosdao.Localidad = textBox15.Text;
                    catalogosdao.ReferenciasDir = textBox14.Text;
                    catalogosdao.Estado = comboBox2.Text;
                    catalogosdao.Pais = comboBox3.Text;
                    catalogosdao.Email = textBox9.Text;
                    catalogosdao.CodigoPostal = textBox17.Text;

                    string resultado = catalogosdao.modifica_clientes();
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
            catch
            {
                MessageBox.Show("Es necesario escojer una naviera primero");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿De verdad desea eliminar el cliente seleccionado?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.idcliente = int.Parse(lbl_id.Text);
                    string resultado = catalogosdao.elimina_clientes();
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

        private void button4_Click(object sender, EventArgs e)
        {
            //GUI.CatalogosForms.NavierasBusqueda navierasgui = new NavierasBusqueda(this);
            //navierasgui.MdiParent = this.MdiParent;
            //navierasgui.Show();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = "NombreComercialCliente";
                DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                
                DataView dv = new DataView(catalogosdao.devuelveclientes());
                dv.RowFilter = campo + " like '%" + textBox8.Text + "%'";

                dataGridView1.DataSource = dv;
            }
            catch
            {
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void lbl_naviera_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbl_id_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }






    }
}
