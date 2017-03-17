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
    public partial class ComprasCtrl : Form
    {
        public ComprasCtrl()
        {
            InitializeComponent();
        }

        public void actualizaproductosproveedor()
        {
            DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
            catalogosdao.idproveedor = int.Parse(lbl_idCliente.Text);
            dataGridView2.DataSource = catalogosdao.devuelveproductosproveedores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.BarcosBusqueda barcos = new BarcosBusqueda(this);
            barcos.MdiParent = this.MdiParent;
            barcos.Show();
        }
        public string insertafacturaparcial()
        {
            try
            {
                //(this.Fecha, this.ClienteFactura, this.Moneda, this.tipodecambio, this.FechaTipoCambio_datetime, this.metodoDePago, this.Cuenta)
                DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
                facturasdao.Fecha = Convert.ToDateTime(dateTimePicker4.Value.ToShortDateString());
                facturasdao.ClienteFactura = int.Parse(lbl_idCliente.Text);
                facturasdao.Moneda = comboBox3.Text;
                if (textBox18.Text != "")
                {
                    facturasdao.TipoDeCambio_decimal = decimal.Parse(textBox18.Text);
                }
                else
                {
                    facturasdao.TipoDeCambio_decimal = 0;
                }
                facturasdao.FechaTipoCambio_datetime = DateTime.Now.Date;
                facturasdao.metodoDePago = comboBox1.Text;
                facturasdao.Cuenta = textBox2.Text;
                return facturasdao.insertaparcialcompra();
            }
            catch
            {
                return "Error, vuelva a intentarlo";
            }
        }

        public int numerocompras()
        {
            DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
            return facturas.devuelveidcompras();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((lbl_idCliente.Text != "") && (comboBox1.SelectedIndex != -1) && (comboBox3.SelectedIndex != -1))
            {
                if (lbl_idfactura.Text == "")
                {

                    string resultado2 = insertafacturaparcial();
                    if (resultado2 != "Correcto")
                    {
                        MessageBox.Show(resultado2);
                    }
                    else
                    {
                        lbl_idfactura.Text = numerocompras().ToString();
                        button7.Enabled = true;

                    }
                }

            }
        }

        public void actualizagrid()
        {
            DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
            facturasdao.IDFactura = int.Parse(lbl_idfactura.Text);
            dataGridView1.DataSource = facturasdao.devuelveserviciosf();
        }

        public void calculatotales()
        {
            try
            {
                double resultado = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    resultado += Convert.ToDouble(row.Cells["Importe"].Value);
                }
                if (resultado != 0)
                {
                    textBox13.Text = Convert.ToString(resultado);
                    textBox14.Text = (resultado * .16).ToString();
                    textBox15.Text = (resultado * 1.16).ToString();
                    
                }
                else
                {
                    textBox13.Text = "";
                    textBox14.Text = "";
                    textBox15.Text = "";
                    

                }
            }
            catch
            {
                MessageBox.Show("Error en el calculo de totales");
            }
        }

        public string descargainventarios()
        {
            try
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    decimal descarga = decimal.Parse(row.Cells[4].Value.ToString());
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.IDProducto = int.Parse(row.Cells[6].Value.ToString());
                    catalogosdao.Cantidad = descarga;
                    catalogosdao.modificaexistencias();
                }
                return "Correcto";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text != "")
                {
                    //(this.IDFactura, this.IDFServicios, this.Cantidad, this.Importe)
                    DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
                    facturasdao.IDFactura = int.Parse(lbl_idfactura.Text);
                    facturasdao.IDFServicios = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                    facturasdao.Cantidad = int.Parse(textBox5.Text);
                    facturasdao.Importe = decimal.Parse(dataGridView2.CurrentRow.Cells[3].Value.ToString());
                    string resultado = facturasdao.insertaservicioscompra();
                    if (resultado != "Correcto")
                    {
                        MessageBox.Show(resultado);
                    }
                    else
                    {
                        actualizagrid();
                        calculatotales();
                    }
                }
                else
                {
                    DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
                    facturasdao.IDFactura = int.Parse(lbl_idfactura.Text);
                    facturasdao.IDFServicios = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                    facturasdao.Cantidad = 1;
                    facturasdao.Importe = decimal.Parse(dataGridView2.CurrentRow.Cells[3].Value.ToString());
                    string resultado = facturasdao.insertaservicioscompra();
                    if (resultado != "Correcto")
                    {
                        MessageBox.Show(resultado);
                    }
                    else
                    {
                        actualizagrid();
                        calculatotales();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
            facturas.IDFServicios = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string resultado = facturas.eliminaservicioscompra();
            if (resultado != "Correcto")
            {
                MessageBox.Show(resultado);
            }
            else
            {
                actualizagrid();
                calculatotales();
            }
        }

        //private void button9_Click(object sender, EventArgs e)
        //{
        //    DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
        //    facturas.IDFServicios = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
        //    string resultado = facturas.eliminaserviciosfac();
        //    if (resultado != "Correcto")
        //    {
        //        MessageBox.Show(resultado);
        //    }
        //    else
        //    {
        //        actualizagrid();
        //        calculatotales();
        //    }
        //}

        private void button9_Click(object sender, EventArgs e)
        {

            try
            {
                DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
                facturasdao.IDFactura = int.Parse(lbl_idfactura.Text);
                facturasdao.Subtotal = decimal.Parse(textBox13.Text);
                facturasdao.Iva = decimal.Parse(textBox14.Text);
                facturasdao.Total = decimal.Parse(textBox15.Text);
                


                if (textBox16.Text != "")
                {
                    facturasdao.Descuento_decimal = ((decimal.Parse(textBox16.Text) * decimal.Parse("100")) / ((decimal.Parse(textBox16.Text))));

                }
                else
                {
                   // facturasdao.descuento = "";
                   // facturasdao.PorcentajeDescuento_decimal = int.Parse(textBox16.Text);
                }
                
                facturasdao.motivodescuento = textBox17.Text;

                string resultado = facturasdao.actualizacompratermina();
                if (resultado != "Correcto")
                {
                    MessageBox.Show(resultado);
                }
                else
                {
                    
                    
                        string resultado2 = descargainventarios();
                        if (resultado2 == "Correcto")
                        {
                            MessageBox.Show("Correcto");
                            GUI.CatalogosForms.Compras facturasgui = new Compras();
                            facturasgui.MdiParent = this.MdiParent;
                            facturasgui.Show();

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(resultado2);
                        }


                    
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo algun error en la informacion " + ex);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = "Descripcion";
                DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                catalogosdao.idproveedor = int.Parse(lbl_idCliente.Text);
                DataView dv = new DataView(catalogosdao.devuelveproductosproveedores());
                dv.RowFilter = campo + " like '%" + textBox3.Text + "%'";

                dataGridView2.DataSource = dv;
            }
            catch
            {
            }
        }
    }
}
