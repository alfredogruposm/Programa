using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquimarFac.DAO;

namespace EquimarFac.GUI.CatalogosForms
{
    public partial class FacturasCtrl : Form
    {
        
        public FacturasCtrl()
        {
            
            InitializeComponent();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.ClientesBusqueda clientes = new ClientesBusqueda(this);
            clientes.MdiParent = this.MdiParent;
            clientes.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //GUI.CatalogosForms.RemolcadoresBusqueda remolcadores = new RemolcadoresBusqueda(this);
            //remolcadores.Text = "1";
            //remolcadores.MdiParent = this.MdiParent;
            //remolcadores.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //GUI.CatalogosForms.RemolcadoresBusqueda remolcadores = new RemolcadoresBusqueda(this);
            //remolcadores.Text = "2";
            //remolcadores.MdiParent = this.MdiParent;
            //remolcadores.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //GUI.CatalogosForms.RemolcadoresBusqueda remolcadores = new RemolcadoresBusqueda(this);
            //remolcadores.Text = "3";
            //remolcadores.MdiParent = this.MdiParent;
            //remolcadores.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //GUI.CatalogosForms.BarcosBusqueda barcos = new BarcosBusqueda(this);
            //barcos.MdiParent = this.MdiParent;
            //barcos.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //GUI.CatalogosForms.ServiciosBusqueda servicios = new ServiciosBusqueda(this);
            //servicios.MdiParent = this.MdiParent;
            //servicios.Show();
        }

        //public int numeroinsertados()
        //{
        //    //DAO.FacturasDAO facturas=new EquimarFac.DAO.FacturasDAO();
        //    //return facturas.devuelveidremolcadores(); 
        //}


        //public string insertaremolcadores()
        //{
        //    //try
        //    //{
        //    if (lbl_rinsertados.Text == "1")
        //    {
        //        return "Correcto";
        //    }
        //    else
        //    {
        //        DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
        //        facturas.Remolcador1 = int.Parse(id_R1.Text);

        //        if (id_R2.Text != "")
        //        {
        //            facturas.Remolcador2 = int.Parse(id_R2.Text);
        //        }

        //        if (id_R3.Text != "")
        //        {
        //            facturas.Remolcador3 = int.Parse(id_R3.Text);
        //        }

        //        return facturas.insertaRemolcadores();
        //    }
        //    //}
        //    //catch
        //    //{
        //    //    return "Error (inserta remolcadores)";
        //    //}
        //}

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
                return facturasdao.insertaparcialfactura();
            }
            catch
            {
                return "Error, vuelva a intentarlo";
            }
        }

        public int numerofactura()
        {
            DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
            return facturas.devuelveidfacturas();
        }
        string descuentot="";
        decimal descuento=0;
        //public decimal calculaimporte()
        //{
        //    try
        //    {
        //        decimal DCB1 = decimal.Parse(CB1.Text);
        //        decimal DCB2 = decimal.Parse(CB2.Text);
        //        decimal DCB3 = decimal.Parse(CB3.Text);
        //        decimal DCB4 = decimal.Parse(CB4.Text);
        //        decimal DREP = decimal.Parse(REP.Text);
        //        decimal DREM = decimal.Parse(REM.Text);
        //        decimal DREG = decimal.Parse(REG.Text);
        //        decimal DSCA = decimal.Parse(SCA.Text);
        //        decimal DSCB = decimal.Parse(SCB.Text);
        //        decimal DSCC = decimal.Parse(SCC.Text);
        //        decimal importehoras = decimal.Truncate(Convert.ToDecimal((dateTimePicker3.Value - dateTimePicker2.Value).TotalMinutes / 60));
        //        decimal numerominutos = Convert.ToDecimal((dateTimePicker3.Value - dateTimePicker2.Value).Minutes); ;
        //        decimal cuotabasica = 0;
        //        decimal costototal = 0;
        //        decimal ServicioContinuoR1 = 0, ServicioContinuoR2 = 0, ServicioContinuoR3 = 0;
        //        int trb = int.Parse(textBox9.Text);
        //        if (importehoras < 1)
        //        {
        //            importehoras = 1;
        //            numerominutos = 0;

        //        }
        //        //if (importehoras == 1)
        //        //{
        //        //    numerominutos = 0;
        //        //}
        //        //if (importehoras > 1)
        //        //{
        //        //    //numerominutos = Convert.ToDecimal((((((dateTimePicker3.Value - dateTimePicker2.Value).TotalMinutes / 60) % 1) * 15) / 25));
        //        //    numerominutos = Convert.ToDecimal((dateTimePicker3.Value - dateTimePicker2.Value).Minutes);
        //        //}
        //        decimal importeminutos = 0;
        //        if ((numerominutos >= 1)&&(numerominutos <= 15))
        //        {
        //            importeminutos = 25;
        //        }
        //        if ((numerominutos > 15) && (numerominutos <= 30))
        //        {
        //            importeminutos = 50;
        //        }
        //        if ((numerominutos > 30) && (numerominutos <= 45))
        //        {
        //            importeminutos = 75;
        //        }
        //        if ((numerominutos > 45) && (numerominutos <= 59))
        //        {
        //            importeminutos = 100;
        //        }

        //        if (checkBox1.Checked == true)
        //        {
        //            if (lbl_tamaño1.Text == "Pequeño")
        //            {
        //                ServicioContinuoR1 = DSCA;
        //            }
        //            if (lbl_tamaño1.Text == "Mediano")
        //            {
        //                ServicioContinuoR1 = DSCB;
        //            }
        //            if (lbl_tamaño1.Text == "Grande")
        //            {
        //                ServicioContinuoR1 = DSCC;
        //            }

        //            if (id_R2.Text != "")
        //            {
        //                if (lbl_tamaño2.Text == "Pequeño")
        //                {
        //                    ServicioContinuoR2 = DSCA;
        //                }
        //                if (lbl_tamaño2.Text == "Mediano")
        //                {
        //                    ServicioContinuoR2 = DSCB;
        //                }
        //                if (lbl_tamaño2.Text == "Grande")
        //                {
        //                    ServicioContinuoR2 = DSCC;
        //                }
        //            }

        //            if (id_R3.Text != "")
        //            {
        //                if (lbl_tamaño3.Text == "Pequeño")
        //                {
        //                    ServicioContinuoR3 = DSCA;
        //                }
        //                if (lbl_tamaño3.Text == "Mediano")
        //                {
        //                    ServicioContinuoR3 = DSCB;
        //                }
        //                if (lbl_tamaño3.Text == "Grande")
        //                {
        //                    ServicioContinuoR3 = DSCC;
        //                }
        //            }

        //            if (checkBox2.Checked == true)
        //            {
        //                cuotabasica = (ServicioContinuoR1 + ServicioContinuoR2 + ServicioContinuoR3) * Convert.ToDecimal(1.5);
        //            }
        //            else
        //            {
        //                cuotabasica = ServicioContinuoR1 + ServicioContinuoR2 + ServicioContinuoR3;
        //            }

        //            costototal = (cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100));

        //        }
        //        else
        //        {


        //            if ((trb >= 1501) && (trb <= 4500))
        //            {
        //                cuotabasica = DCB1;
        //            }

        //            if ((trb >= 4501) && (trb <= 10000))
        //            {
        //                cuotabasica = DCB2;
        //            }

        //            if ((trb >= 10001) && (trb <= 15000))
        //            {
        //                cuotabasica = DCB3;
        //            }

        //            if ((trb > 15000))
        //            {
        //                cuotabasica = DCB4;
        //            }


        //            if ((trb <= 500) | ((trb >= 501) && (trb <= 1500)))
        //            {
        //                if (checkBox2.Checked == true)
        //                {
        //                    cuotabasica = Convert.ToDecimal(DCB1 * Convert.ToDecimal(1.5));
        //                }
        //                else
        //                {
        //                    cuotabasica = DCB1;
        //                }

        //                ////if ((id_R1.Text != "") && (id_R2.Text == "") && (id_R3.Text == ""))
        //                ////{
        //                ////    descuentot += " 10% descuento sobre Cuota basica por 1 remolcador";
        //                ////    descuento += cuotabasica * Convert.ToDecimal(.10);
        //                ////    cuotabasica = cuotabasica * Convert.ToDecimal(.90);

        //                ////}
        //                if (trb <= 500)
        //                {
        //                    descuentot += " 30% Descuento sobre total por TRB Menor a 500 Ton";

        //                    costototal = ((cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100))) * Convert.ToDecimal(.70);
        //                    descuento += ((cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100))) * Convert.ToDecimal(.30);
        //                }
        //                if ((trb >= 501) && (trb <= 1500))
        //                {
        //                    descuentot += " 5% Descuento sobre total por TRB Menor a 1500 Ton";
        //                    costototal = ((cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100))) * Convert.ToDecimal(.95);
        //                    descuento += ((cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100))) * Convert.ToDecimal(.05);

        //                }
        //            }
        //            else
        //            {


        //                if (checkBox2.Checked == true)
        //                {
        //                    cuotabasica = cuotabasica * Convert.ToDecimal(1.5);
        //                }

        //                //if ((id_R1.Text != "") && (id_R2.Text == "") && (id_R3.Text == ""))
        //                //{
        //                //    descuentot += " 10% descuento sobre Cuota basica por 1 remolcador";
        //                //    descuento += cuotabasica * Convert.ToDecimal(.10);
        //                //    cuotabasica = cuotabasica * Convert.ToDecimal(.90);
        //                //}
        //            }

        //            if (id_R3.Text == "")
        //            {
        //                costototal = (cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100));
        //            }
        //            else
        //            {
        //                if (lbl_tamaño3.Text == "Pequeño")
        //                {
        //                    cuotabasica = cuotabasica + DREP;
        //                    costototal = (cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100));
        //                }
        //                if (lbl_tamaño3.Text == "Mediano")
        //                {
        //                    cuotabasica = cuotabasica + DREM;
        //                    costototal = (cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100));
        //                }
        //                if (lbl_tamaño3.Text == "Grande")
        //                {
        //                    cuotabasica = cuotabasica + DREG;
        //                    costototal = (cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100));
        //                }
        //            }


                    
        //        }

        //        if (textBox16.Text != "")
        //        {
        //            descuentot += " " +textBox16.Text +"% de descuento";
        //            descuento += costototal * ((decimal.Parse(textBox16.Text)) / 100);
        //            costototal = costototal * ((100 - decimal.Parse(textBox16.Text)) / 100);
        //        }

        //        if (comboBox3.Text == "USD")
        //        {
        //            if (checkBox4.Checked)
        //            {
        //                return costototal;
        //            }
        //            else
        //            {
        //                if (textBox18.Text != "")
        //                {
        //                    return costototal / decimal.Parse(textBox18.Text);
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Es necesario que especifique el tipo de cambio");
        //                    return -1;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            return costototal;
        //        }

                
        //    }
        //    catch
        //    {
        //        return -1;
        //    }
        //}

        public void actualizagrid()
        {
            DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
            facturasdao.IDFactura = int.Parse(lbl_idfactura.Text);
            dataGridView1.DataSource = facturasdao.devuelveserviciosfac();
        }
        public void actualizagrid2()
        {
            DAO.CatalogosDAO catalogosdao = new CatalogosDAO();
            dataGridView2.DataSource = catalogosdao.devuelveProductos();
        }
        //public void insertaviaje()
        //{
        //    try
        //    {
        //        DAO.FacturasDAO fac = new FacturasDAO();
        //        fac.IDFactura = int.Parse(lbl_idfactura.Text);
        //        fac.viaje = textBox20.Text;
        //        fac.insertaviaje();
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error insertaviaje");
        //    }
        //}

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text != "")
                {
                    //(this.IDFactura, this.IDFServicios, this.Cantidad, this.Importe)
                    DAO.FacturasDAO facturasdao = new FacturasDAO();
                    facturasdao.IDFactura = int.Parse(lbl_idfactura.Text);
                    facturasdao.IDFServicios = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                    facturasdao.Cantidad = int.Parse(textBox5.Text);
                    facturasdao.Importe = (decimal.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString()) * decimal.Parse(textBox5.Text));
                    string resultado = facturasdao.insertaserviciosfactura();
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
                    DAO.FacturasDAO facturasdao = new FacturasDAO();
                    facturasdao.IDFactura = int.Parse(lbl_idfactura.Text);
                    facturasdao.IDFServicios = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                    facturasdao.Cantidad = 1;
                    facturasdao.Importe = decimal.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());
                    string resultado = facturasdao.insertaserviciosfactura();
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        

        public void limpiatextos()
        {
            //textBox11.Text = "";
            textBox16.Text = "";
            //textBox12.Text = "";
            //checkBox6.CheckState = CheckState.Unchecked;
            //checkBox5.CheckState = CheckState.Unchecked;
            //checkBox3.CheckState = CheckState.Unchecked;
            //checkBox2.CheckState = CheckState.Unchecked;
            //checkBox1.CheckState = CheckState.Unchecked;
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
                    catalogosdao.Cantidad = -descarga;
                    catalogosdao.modificaexistencias();
                }
                return "Correcto";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        //private void checkBox6_Click(object sender, EventArgs e)
        //{
        //    if (checkBox6.Checked)
        //    {
        //        checkBox5.CheckState = CheckState.Unchecked;
        //        checkBox3.CheckState = CheckState.Unchecked;
        //    }
            
        //}

        //private void checkBox5_Click(object sender, EventArgs e)
        //{
        //    if (checkBox5.Checked)
        //    {
        //        checkBox6.CheckState = CheckState.Unchecked;
        //        checkBox3.CheckState = CheckState.Unchecked;
        //    }
        //}

        private void button8_Click(object sender, EventArgs e)
        {
            DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
            facturas.IDFServicios = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string resultado=facturas.eliminaserviciosfac();
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
        
        private void button9_Click(object sender, EventArgs e)
        {
            
            try
            {
                DAO.FacturasDAO facturasdao = new FacturasDAO();
                facturasdao.IDFactura = int.Parse(lbl_idfactura.Text);
                
                Numalet let = new Numalet();
                if (comboBox3.Text == "USD")
                {
                    let.MascaraSalidaDecimal = "00'/100 USD'";
                    let.SeparadorDecimalSalida = "Dolares";
                    //observar que sin esta propiedad queda "veintiuno pesos" en vez de "veintiún pesos":
                    let.ApocoparUnoParteEntera = true;
                    facturasdao.TotalLetras = ("Son: " + let.ToCustomCardinal(textBox15.Text));
                    //Son: un mil ciento veintiún pesos 24/100 M.N.
                }
                else
                {
                    let.MascaraSalidaDecimal = "00'/100 MXN'";
                    let.SeparadorDecimalSalida = "Pesos";
                    //observar que sin esta propiedad queda "veintiuno pesos" en vez de "veintiún pesos":
                    let.ApocoparUnoParteEntera = true;
                    facturasdao.TotalLetras = ("Son: " + let.ToCustomCardinal(textBox15.Text));
                    //Son: un mil ciento veintiún pesos 24/100 M.N.
                }
                //this.ClaveCFDI, this.formaDePago, this.metodoDePago, this.descuento, this.porcentajeDescuento, this.motivodescuento, this.tipodecambio, 
                //this.fechatipodecambio, this.totalImpuestosretenidos, this.totalimpuestostrasladados, this.LugarExpedicion);
                
                
                facturasdao.formaDePago = "Pago en una sola exhibición";
                if (textBox16.Text != "")
                {
                    facturasdao.Descuento_decimal = ((decimal.Parse(textBox16.Text) * decimal.Parse(textBox13.Text)) / ((decimal.Parse("100"))));
                    facturasdao.PorcentajeDescuento_decimal = int.Parse(textBox16.Text);
                    facturasdao.Subtotal = decimal.Parse(textBox13.Text);
                    decimal ivadespuesdescuento = (decimal.Parse(textBox13.Text) - ((decimal.Parse(textBox16.Text) * decimal.Parse(textBox13.Text)) / ((decimal.Parse("100"))))) * decimal.Parse("0.16");
                    decimal subtotaldespuesdescuento = decimal.Parse(textBox13.Text) - ((decimal.Parse(textBox16.Text) * decimal.Parse(textBox13.Text)) / ((decimal.Parse("100"))));
                    facturasdao.Iva = ivadespuesdescuento;
                    facturasdao.Total = subtotaldespuesdescuento + ivadespuesdescuento;
                }
                else
                {
                    facturasdao.descuento = "";
                    //facturasdao.PorcentajeDescuento_decimal = int.Parse(textBox16.Text);
                    facturasdao.Subtotal = decimal.Parse(textBox13.Text);
                    facturasdao.Iva = decimal.Parse(textBox14.Text);
                    facturasdao.Total = decimal.Parse(textBox15.Text);
                }
                
                facturasdao.motivodescuento = textBox17.Text;
                
                facturasdao.totalImpuestosretenidos = "";
                facturasdao.totalimpuestostrasladados = textBox14.Text;
                facturasdao.LugarExpedicion = "Merida, Yucatan";
                string resultado = facturasdao.actualizafacturatermina();
                if (resultado != "Correcto")
                {
                    MessageBox.Show(resultado);
                }
                else
                {
                    facturasdao.facturaimpresa = "";
                    facturasdao.ClaveCFDI = "";
                    resultado = facturasdao.insertanumfacturaimpresa();
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
                            GUI.CatalogosForms.Facturas facturasgui = new Facturas();
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
                

            }
            catch(Exception ex)
            {
                MessageBox.Show("Hubo algun error en la informacion " + ex);
            }
        }
        public void SetMyCustomFormat()
        {
            // Set the Format type and the CustomFormat string.
            //dateTimePicker2.Format = DateTimePickerFormat.Custom;
            //dateTimePicker2.CustomFormat = "HH':'mm' Hrs.'";
            //dateTimePicker3.Format = DateTimePickerFormat.Custom;
            //dateTimePicker3.CustomFormat = "HH':'mm' Hrs.'";
        }

        private void FacturasCtrl_Load(object sender, EventArgs e)
        {
            SetMyCustomFormat();
            DAO.CatalogosDAO catalogosdao = new CatalogosDAO();
            dataGridView2.DataSource = catalogosdao.devuelveProductos();
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            //if (checkBox3.Checked)
            //{
            //    if (checkBox6.Checked)
            //    {
            //        checkBox5.CheckState = CheckState.Unchecked;
            //    }
            //    if (checkBox5.Checked)
            //    {
            //        checkBox6.CheckState = CheckState.Unchecked;
            //    }
            //}
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //private void button10_Click(object sender, EventArgs e)
        //{
        //    GUI.CatalogosForms.TarifasBusqueda tarifas = new TarifasBusqueda(this);
        //    tarifas.MdiParent = this.MdiParent;
        //    tarifas.Show();
        //}

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            if (textBox16.Text == "")
            {
                textBox17.Enabled = false;
                textBox17.Text = "";
            }
            else
            {
                textBox17.Enabled = true;
            }
            if ((textBox17.Text == ""))
            {
                button7.Enabled = false;
            }
            else
            {
                button7.Enabled = true;
            }

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            button7.Enabled = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
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
                        lbl_idfactura.Text = numerofactura().ToString();
                        button7.Enabled = true;

                    }
                }
                
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = "Descripcion";
                DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();

                DataView dv = new DataView(catalogosdao.devuelveProductos());
                dv.RowFilter = campo + " like '%" + textBox3.Text + "%'";

                dataGridView2.DataSource = dv;
            }
            catch
            {
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if ((textBox6.Text != "") && (textBox7.Text != "") && (textBox8.Text != ""))
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.Descripcion = textBox6.Text;
                    catalogosdao.idproveedor = int.Parse("100");
                    catalogosdao.Presentacion = textBox7.Text;
                    catalogosdao.Precio = Decimal.Parse(textBox8.Text);
                    catalogosdao.Cantidad = 0;
                    catalogosdao.Inventariable = 1;



                    string resultado = catalogosdao.insertaProductos();
                    if (resultado != "Correcto")
                    {
                        MessageBox.Show(resultado);
                    }
                    else
                    {
                        actualizagrid2();
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
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
    }
}
