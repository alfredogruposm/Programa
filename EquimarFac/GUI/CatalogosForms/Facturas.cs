using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using CFDI;
namespace EquimarFac.GUI.CatalogosForms
{
    public partial class Facturas : Form
    {
        public Facturas()
        {
            InitializeComponent();
        }
        public void cargacuentas()
        {
            DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
            dataGridView2.DataSource = facturasdao.devuelvedatospac();
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                comboBox2.Items.Add(row.Cells[1].Value.ToString());
            }

        }
        private void Facturas_Load(object sender, EventArgs e)
        {
            actualizagrid();
            comboBox1.SelectedIndex = 0;
            cargacuentas();
        }

        public void actualizagrid()
        {
            DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
            if (comboBox1.Text == "Canceladas")
            {
                dataGridView1.DataSource = facturas.devuelvefacturascanceladas();
            }
            else
            {
                dataGridView1.DataSource = facturas.devuelvefacturas();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.FacturasCtrl facturas = new FacturasCtrl();
            facturas.MdiParent = this.MdiParent;
            facturas.Show();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.Reportes.ReporteFactura reporte = new EquimarFac.GUI.CatalogosForms.Reportes.ReporteFactura();
            reporte.factura = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            reporte.Show();
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
                    dv = new DataView(facturas.devuelvefacturas());
                    dv.RowFilter = campo + " like '%" + textBox8.Text + "%'";

                    dataGridView1.DataSource = dv;
                    
                }
                
            }
            catch
            {
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    GUI.CatalogosForms.IngresaFac facturas = new IngresaFac(this);
            //    facturas.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            //    facturas.MdiParent = this.MdiParent;
            //    facturas.Show();
            //}
            //catch
            //{
            //}
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿De verdad desea cancelar esta factura?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (dataGridView1.CurrentRow.Cells["ClaveCFDI"].Value.ToString() != "")
                    {
                        MessageBox.Show("Para cancelar una factura ya emitida, utilize la opcion correcta");
                    }
                    else
                    {
                        DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
                        facturas.IDFactura = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                        string resultado = facturas.cancelafactura();
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
            }
            catch
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == "Canceladas")
            {
                DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
                dataGridView1.DataSource = facturas.devuelvefacturascanceladas();
            }
            else
            {
                actualizagrid();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.CurrentRow.Cells["Factura"].Value.ToString() == "")
            //{
            //    MessageBox.Show("Es necesario primero emitir la factura");
            //}
            //else
            //{
            //    //if (dataGridView1.CurrentRow.Cells["NumeroProgresivo"].Value.ToString() != "")
            //    //{
            //    //    GUI.CatalogosForms.NotaCredito notas = new NotaCredito(this);
            //    //    notas.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            //    //    notas.textBox8.Text = dataGridView1.CurrentRow.Cells["NumeroProgresivo"].Value.ToString();
            //    //    notas.textBox13.Text = dataGridView1.CurrentRow.Cells["Subtotal Nota"].Value.ToString();
            //    //    notas.textBox14.Text = dataGridView1.CurrentRow.Cells["Iva Nota"].Value.ToString();
            //    //    notas.textBox15.Text = dataGridView1.CurrentRow.Cells["Total Nota"].Value.ToString();
            //    //    notas.richTextBox1.Text = dataGridView1.CurrentRow.Cells["Concepto"].Value.ToString();
            //    //    notas.lbl_moneda.Text = dataGridView1.CurrentRow.Cells["Moneda"].Value.ToString();
            //    //    notas.lblcantidad.Text = dataGridView1.CurrentRow.Cells["Subtotal"].Value.ToString();
            //    //    notas.Show();
            //    //}
            //    //else
            //    //{
            //        //GUI.CatalogosForms.NotaCredito notas = new NotaCredito(this);
            //        //notas.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            //        //notas.textBox8.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString(); 
            //        //notas.lbl_moneda.Text = dataGridView1.CurrentRow.Cells["Moneda"].Value.ToString();
            //        //notas.lblcantidad.Text = dataGridView1.CurrentRow.Cells["Subtotal"].Value.ToString();
            //        //notas.lblcliente.Text = dataGridView1.CurrentRow.Cells["Cliente"].Value.ToString();
            //        //notas.Show();
            //    //}
            //}
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void cargacliente()
        {
            DAO.CatalogosDAO catalogos = new EquimarFac.DAO.CatalogosDAO();
            catalogos.nombrecomercial = dataGridView1.CurrentRow.Cells["Cliente"].Value.ToString();
            dataGridView2.DataSource = catalogos.devuelveclientepornombre();
        }

        public void cargaconceptos()
        {
            DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
            facturasdao.IDFactura = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
            dataGridView2.DataSource = facturasdao.devuelveserviciosfac();
        }
        
        private void generarSFDIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DAO.FelWebServiceDAO felweb = new EquimarFac.DAO.FelWebServiceDAO();
            cargacliente();
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                felweb.NombreCliente = row.Cells[1].Value.ToString();
                felweb.Contacto = row.Cells[2].Value.ToString();
                felweb.Telefono = row.Cells[3].Value.ToString();
                felweb.Email = row.Cells[4].Value.ToString();
                felweb.rfcReceptor = row.Cells[5].Value.ToString();
                felweb.nombreReceptor = row.Cells[6].Value.ToString();
                felweb.calleReceptor = row.Cells[7].Value.ToString();
                felweb.noExteriorReceptor = row.Cells[8].Value.ToString();
                felweb.noInteriorReceptor = row.Cells[9].Value.ToString();
                felweb.coloniaReceptor = row.Cells[10].Value.ToString();
                felweb.localidadReceptor = row.Cells[11].Value.ToString();
                felweb.referenciaReceptor = row.Cells[12].Value.ToString();
                felweb.municipioReceptor = row.Cells[13].Value.ToString();
                felweb.estadoReceptor = row.Cells[14].Value.ToString();
                felweb.paisReceptor = row.Cells[15].Value.ToString();
                felweb.codigoPostalReceptor = row.Cells[16].Value.ToString();
            }
            felweb.ClaveCFDI = "FAC";
            felweb.formaDePago = dataGridView1.CurrentRow.Cells["formaDePago"].Value.ToString(); ;
            felweb.parcialidades = "";
            felweb.condicionesDePago = "";
            felweb.metodoDePago = dataGridView1.CurrentRow.Cells["metodoDePago"].Value.ToString();

            decimal descuento = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["descuento"].Value),
                porcentajedescuento = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["porcentajeDescuento"].Value),
                iva = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["totalImpuestosretenidos"].Value),
                total = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Total"].Value),
                subtotal = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Subtotal"].Value),
                tipodecambio = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["tipodecambio"].Value);
            
            string descuentostring = descuento.ToString("N4");
            string porcentajedescuentostring = porcentajedescuento.ToString("N4");
            string ivastring = iva.ToString("N4");
            string totalstring = total.ToString("N4");
            string subtotalstring = subtotal.ToString("N4");
            string tipodecambiostring = tipodecambio.ToString("N4");

            felweb.descuento = descuentostring;
            felweb.porcentajeDescuento = porcentajedescuentostring;
            felweb.motivoDescuento = dataGridView1.CurrentRow.Cells["motivodescuento"].Value.ToString();
            felweb.moneda = dataGridView1.CurrentRow.Cells["Moneda"].Value.ToString();
            felweb.tipoCambio = tipodecambiostring;
            felweb.fechaTipoCambio = dataGridView1.CurrentRow.Cells["fechatipodecambio"].Value.ToString();
            felweb.totalImpuestosRetenidos = "0.000000";
            felweb.totalImpuestosTrasladados = ivastring;
            felweb.subTotal = subtotalstring;
            felweb.total = totalstring;
            felweb.importeConLetra = dataGridView1.CurrentRow.Cells["TotalLetras"].Value.ToString();
            felweb.LugarExpedicion = dataGridView1.CurrentRow.Cells["LugarExpedicion"].Value.ToString();
            felweb.NumCuentaPago = dataGridView1.CurrentRow.Cells["NumCuenta"].Value.ToString(); ;
            felweb.FolioFiscalOrig = "";
            felweb.SerieFolioFiscalOrig = "";
            felweb.FechaFolioFiscalOrig = "";
            felweb.MontoFolioFiscalOrig = "";
            //Datos Varios
            felweb.datosEtiquetas1 = "";
            felweb.datosEtiquetas2 = "";
            List<string> datosConceptos = new List<string>(), datosInfoAduanera = new List<string>();
            cargaconceptos();
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
//El esquema, para incluir los conceptos sera el siguiente: | Cantidad | Unidad | noIdentificacion | Descripcion | valorUnitario | Importe |					
//Haciendo uso del caracter "|" pipe, para separar cada uno de los valores correspondientes. Ejemplo: |1|mtro.||alambre 1/2 pulgada|1.0|1.0|					

                datosConceptos.Add("|"+row.Cells["Cantidad"].Value.ToString()+"|"+row.Cells["Presentacion"].Value.ToString()+"||" + row.Cells["Descripcion"].Value.ToString() + "|" + row.Cells["Precio"].Value.ToString() + "|" + row.Cells["Importe"].Value.ToString() + "|");
                datosInfoAduanera.Add("");
            }
            felweb.conceptos = datosConceptos;
            felweb.infoaduanera = datosInfoAduanera;
            //felweb.datosConceptos = dataGridView1.CurrentRow.Cells["Cliente"].Value.ToString();
            //felweb.datosInfoAduanera = dataGridView1.CurrentRow.Cells["Cliente"].Value.ToString();
            felweb.datosRetenidosIVA = "";
            felweb.datosRetenidosISR = "";
            felweb.datosTraslados1 = "|IVA (IVA 16.00%)|IVA|16.00|" + dataGridView1.CurrentRow.Cells["totalimpuestostrasladados"].Value.ToString() + "|";
            felweb.datosRetenidosLocales1 = "";
            felweb.datosRetenidosLocales2 = "";
            felweb.datosTrasladosLocales1 = "";
            string[] respuesta = new string[4];
            respuesta = felweb.GenerarCDFI();
            if (respuesta[0] == "true")
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(respuesta[3]);
                xmldoc.Save("C:\\MiXML_Timbrado.xml");
                DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
                facturasdao.IDFactura = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                facturasdao.facturaimpresa = xmldoc.Attributes.GetNamedItem("UUID").ToString();
                string resultado = facturasdao.insertanumfacturaimpresa();
                

            }
            else
            {
                MessageBox.Show("Error de generacion del CFDI " + respuesta[1] + " " + respuesta[2]);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿De verdad desea emitir esta factura?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (comboBox2.SelectedIndex != -1)
                {
                    if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == "")
                    {

                        var emisor = new Emisor();
                        var receptor = new Receptor();
                        receptor.domicilio = new Domicilio();
                        var concepto = new Concepto(); var impuestos = new Impuestos();
                        var fecha = DateTime.Now;
                        var comp = new Comprobante();
                        emisor.rfc = "CDD111007FP9";
                        emisor.domicilioFiscal = new DomicilioFiscal();
                        
                        emisor.domicilioFiscal.calle = "7";
                        emisor.domicilioFiscal.municipio = "Mérida";
                        emisor.domicilioFiscal.estado = "Yucatán";
                        emisor.domicilioFiscal.pais = "México";
                        emisor.domicilioFiscal.codigoPostal = "97136";
                        emisor.regimenFiscal = new RegimenFiscal();
                        emisor.regimenFiscal.regimen = "Comercio al por mayor de productos farmacéuticos";


                        
                        DAO.CatalogosDAO catalogos = new EquimarFac.DAO.CatalogosDAO();
                        catalogos.nombrecomercial = dataGridView1.CurrentRow.Cells["Cliente"].Value.ToString();
                        dataGridView2.DataSource = catalogos.devuelveclientepornombre();
                        
                            
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            receptor.rfc = row.Cells[5].Value.ToString(); 
                            
                            
                            
                            receptor.domicilio.calle = row.Cells[7].Value.ToString();
                            receptor.domicilio.noExterior = row.Cells[8].Value.ToString();
                            receptor.domicilio.noInterior = row.Cells[9].Value.ToString();
                            receptor.domicilio.colonia = row.Cells[10].Value.ToString();
                            receptor.domicilio.localidad = row.Cells[11].Value.ToString();
                            receptor.domicilio.municipio = row.Cells[13].Value.ToString();
                            receptor.domicilio.estado = row.Cells[14].Value.ToString();
                            receptor.domicilio.pais = row.Cells[15].Value.ToString();
                            receptor.domicilio.codigoPostal = row.Cells[16].Value.ToString();
                        }
                        List<string> datosConceptos = new List<string>();
                        cargaconceptos();
                        comp.conceptos = new List<Concepto>();
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            
                            concepto.cantidad = row.Cells["Cantidad"].Value.ToString();
                            concepto.unidad = row.Cells["Presentacion"].Value.ToString();
                            concepto.descripcion = row.Cells["Descripcion"].Value.ToString();
                            concepto.importe = row.Cells["Importe"].Value.ToString();
                            concepto.valorUnitario = row.Cells["Precio"].Value.ToString();
                            //El esquema, para incluir los conceptos sera el siguiente: | Cantidad | Unidad | noIdentificacion | Descripcion | valorUnitario | Importe |					
                            //Haciendo uso del caracter "|" pipe, para separar cada uno de los valores correspondientes. Ejemplo: |1|mtro.||alambre 1/2 pulgada|1.0|1.0|					
                            //|cantidad|unidad|noIdentificacion|descripcion|valorUnitario|importe|
                            //datosConceptos.Add(concepto.ToString());
                            
                            comp.conceptos.Add(concepto);
                            
                        }

                        

                        var iva = new Traslado();
                        iva.impuesto = "IVA";
                        iva.importe = dataGridView1.CurrentRow.Cells["totalimpuestostrasladados"].Value.ToString();
                        iva.tasa = "16";

                        
                        impuestos.traslados = new List<Traslado>();
                        impuestos.traslados.Add(iva);

                        
                        comp.fecha = string.Format("{0}T{1}", fecha.ToString("yyyy-MM-dd"), fecha.ToString("HH:mm:ss"));
                        comp.formaDePago = "PAGO EN UNA SOLA EXHIBICION";
                        comp.metodoDePago = "NO IDENTIFICADO";
                        comp.lugarExpedicion = "Yucatán";
                        comp.tipoDeComprobante = "ingreso";
                        comp.subTotal = (dataGridView1.CurrentRow.Cells["Subtotal"].Value).ToString();
                        comp.total = (dataGridView1.CurrentRow.Cells["Total"].Value).ToString();
                        comp.emisor = emisor;
                        comp.receptor = receptor;
                        
                        comp.impuestos = impuestos;
                        comp.terceros = true;
                        comp.serie = "U";
                        comp.folio = "0001";
                        //minimos (pero no mandatorios) para una impresion descente
                        //if (true)
                        //{
                        //    emisor.nombre = "PANCHO VILLA";
                        //    emisor.domicilioFiscal.noExterior = "1005";
                        //    emisor.domicilioFiscal.noInterior = "124";
                        //    emisor.domicilioFiscal.colonia = "Jose del Cantaro";
                        //    emisor.domicilioFiscal.localidad = "San Luis Potosí";
                        //    receptor.domicilio.calle = "AV. V. CARRANZA";
                        //    receptor.domicilio.codigoPostal = "78000";
                        //    receptor.domicilio.colonia = "Centro";
                        //    receptor.domicilio.noExterior = "715";
                        //    receptor.domicilio.noInterior = "PH";
                        //    receptor.domicilio.localidad = "San Luis Potosí";
                        //    receptor.domicilio.municipio = "San Luis Potosí";
                        //    receptor.domicilio.estado = "San Luis Potosí";
                        //    impuestos.totalImpuestosTrasladados = "0.16";
                            
                        //}

                        var cer = new X509Certificate2("C:\\Firma\\Archivo.pfx", "123456", X509KeyStorageFlags.MachineKeySet);
                        var xml = CFDIv32.Serializar(comp, false); //el xml sin sello
                        var cadena = CFDIv32.CadenaOriginalSellado(xml); //cadena original para sello
                        //SELLAR comprobante y salvarlo
                        var ar = cer.GetSerialNumber();
                        Array.Reverse(ar);
                        comp.noCertificado = Encoding.UTF8.GetString(ar);
                        comp.certificado = Convert.ToBase64String(cer.RawData);
                        comp.sello = CFDIv32.Sello(cadena, cer);
                        //validar y salvar el xml ya sellado
                        xml = CFDIv32.Serializar(comp, false);
                        CFDIv32.Validar(xml, false);
                        File.WriteAllText("mandatorio.xml", xml);
                        ////TIMBRAR con tralix y salvar respuesta soap
                        //var key = "TUCLAVEDECLIENTETRALIX";
                        //var soap = Timbrador.Timbrar("https://timbrador.tralix.com:7070/", key, xml);
                        //File.WriteAllText("mandatorio_timbrado_soap.xml", soap);
                        ////extraer el timbre de la respuesta soap
                        //comp.timbrado = Timbrador.Timbre(soap);
                        string[] respuesta = new string[4];
                        EquimarFac.DAO.TimbradoFelWebService timbrado = new EquimarFac.DAO.TimbradoFelWebService();
                        timbrado.cadenaXML = xml;
                        timbrado.referencia = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                        respuesta = timbrado.TimbrarCFD();
                        if (respuesta[0] == "")
                        {
                            XmlDocument xmldoc = new XmlDocument();
                            string resultado1 = respuesta[3].ToString();
                            //XmlWriterSettings settings;

                            ////settings = new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8, CheckCharacters = false };

                            //XmlReader reader = XmlReader.Create(resultado1, settings.Encoding.EncodingName = UTF8Encoding);
                            XmlReaderSettings rs = new XmlReaderSettings();
                            rs.CheckCharacters = false;

                            //// XmlXapResolver is the default resolver.
                            //using (XmlReader reader = XmlReader.Create(resultado1, rs))
                            //{
                            //    xmldoc.in
                            //    xmldoc.Load(reader);
                            //}

                            xmldoc.LoadXml(resultado1);

                            //xmldoc.Save("C:\\Facturas CFDI\\FacturasXML\\FacturasMiXML_Timbrado.xml");
                            DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
                            facturasdao.IDFactura = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                            //// Move to an element.
                            //XmlElement root = doc.DocumentElement;

                            //// Get an attribute.
                            //XmlAttribute attr = root.GetAttributeNode("ISBN");

                            //// Display the value of the attribute.
                            //String attrValue = attr.InnerXml;
                            //Console.WriteLine(attrValue);
                            XmlElement elementoxml = xmldoc.DocumentElement;
                            string lstVideos = elementoxml.ChildNodes.Count.ToString();
                            //XmlAttribute atributeelement = elementoxml.get
                            string atributouuid = lstVideos;
                            XmlNodeList nodelist = elementoxml.ChildNodes;
                            XmlNodeList nodelist2 = nodelist.Item(4).ChildNodes;
                            XmlNodeList nodelist3 = nodelist2.Item(0).ChildNodes;
                            XmlAttributeCollection elemento2 = nodelist2.Item(0).Attributes;
                            //XmlAttribute atrib = elemento2.GetNamedItem("UUID");
                            string nodotexto = elemento2.GetNamedItem("UUID").InnerText;

                            XmlAttributeCollection elemento3 = elementoxml.Attributes;
                            string nodotexto2 = elemento3.GetNamedItem("folio").InnerText;
                            facturasdao.facturaimpresa = nodotexto2;
                            //xmldoc.Save("C:\\Facturas CFDI\\FacturasXML\\" + nodotexto2 + ".xml");
                            File.WriteAllText("C:\\Facturas CFDI\\FacturasXML\\"+ nodotexto2 + ".xml", comp.timbrado);
                            //verificar y salvar el xml ya timbrado
                            xml = CFDIv32.Serializar(comp, false);
                            CFDIv32.Validar(xml, true);
                            File.WriteAllText("mandatorio_timbrado.xml", xml);
                            facturasdao.ClaveCFDI = nodotexto;

                            string resultado = facturasdao.insertanumfacturaimpresa();
                            MessageBox.Show("Correcto");
                            actualizagrid();
                        }
                        else
                        {
                            MessageBox.Show("Error de generacion del CFDI " + respuesta[1] + " " + respuesta[2]);
                        }

                        //File.WriteAllText("mandatorio_timbrado_soap.xml", comp.timbrado);
                        ////verificar y salvar el xml ya timbrado
                        //xml = CFDIv32.Serializar(comp, false);
                        //CFDIv32.Validar(xml, true);
                        //File.WriteAllText("mandatorio_timbrado.xml", xml);
                        ////mostrar la cadena original para impresion
                        //Console.WriteLine(CFDIv32.CadenaOriginalImpresa(xml));
                        ////CANCELAR un folio
                        //var xml2 = Cancelador.Xml("AA97B177-9383-4934-8543-0F91A7A02836", "AAA010101AAA", DateTime.Now, cer);
                        //File.WriteAllText("mandatario_cancel.xml", xml2);
                        //var soap2 = Cancelador.Cancelar("https://timbrador.tralix.com:8081/", key, xml2);
                        //File.WriteAllText("mandatario_cancel_soap.xml", soap2);
                        //var status = Cancelador.Status(soap2);
                        //Console.WriteLine("Cancel Status : " + status);


























                        //DAO.FelWebServiceDAO felweb = new EquimarFac.DAO.FelWebServiceDAO();
                        //DAO.CatalogosDAO catalogos = new EquimarFac.DAO.CatalogosDAO();
                        //catalogos.nombrecomercial = dataGridView1.CurrentRow.Cells["Cliente"].Value.ToString();
                        //dataGridView2.DataSource = catalogos.devuelveclientepornombre();
                        //foreach (DataGridViewRow row in dataGridView2.Rows)
                        //{
                        //    felweb.NombreCliente = row.Cells[1].Value.ToString();
                        //    felweb.Contacto = row.Cells[2].Value.ToString();
                        //    felweb.Telefono = row.Cells[3].Value.ToString();
                        //    felweb.Email = row.Cells[4].Value.ToString();
                        //    felweb.rfcReceptor = row.Cells[5].Value.ToString();
                        //    felweb.nombreReceptor = row.Cells[6].Value.ToString();
                        //    felweb.calleReceptor = row.Cells[7].Value.ToString();
                        //    felweb.noExteriorReceptor = row.Cells[8].Value.ToString();
                        //    felweb.noInteriorReceptor = row.Cells[9].Value.ToString();
                        //    felweb.coloniaReceptor = row.Cells[10].Value.ToString();
                        //    felweb.localidadReceptor = row.Cells[11].Value.ToString();
                        //    felweb.referenciaReceptor = row.Cells[12].Value.ToString();
                        //    felweb.municipioReceptor = row.Cells[13].Value.ToString();
                        //    felweb.estadoReceptor = row.Cells[14].Value.ToString();
                        //    felweb.paisReceptor = row.Cells[15].Value.ToString();
                        //    felweb.codigoPostalReceptor = row.Cells[16].Value.ToString();
                        //}
                        //DAO.FacturasDAO facturasdao1 = new EquimarFac.DAO.FacturasDAO();
                        //facturasdao1.Nombre = comboBox2.Text;
                        //dataGridView2.DataSource = facturasdao1.devuelvedatospacpornombre();
                        //foreach (DataGridViewRow row in dataGridView2.Rows)
                        //{
                        //    felweb.CuentaFEL = row.Cells[1].Value.ToString();
                        //    felweb.emisorRFC = row.Cells[0].Value.ToString();
                        //    felweb.PasswordFEL = row.Cells[2].Value.ToString();
                        //}
                        
                        
                        //felweb.ClaveCFDI = "FAC";
                        

                        //felweb.formaDePago = "Pago en una sola exhibición";
                        //felweb.parcialidades = "";
                        //felweb.condicionesDePago = "";
                        //felweb.metodoDePago = dataGridView1.CurrentRow.Cells["metodoDePago"].Value.ToString();
                        //string descuentostring;
                        //string porcentajedescuentostring;
                        //if (dataGridView1.CurrentRow.Cells["descuento"].Value.ToString() == "")
                        //{
                        //    decimal descuento = 0, porcentajedescuento = 0;
                        //    descuentostring = descuento.ToString("N6");
                        //    porcentajedescuentostring = porcentajedescuento.ToString("N6");
                        //}
                        //else
                        //{
                        //    decimal descuento = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["descuento"].Value),
                        //    porcentajedescuento = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["porcentajeDescuento"].Value);
                        //    descuentostring = descuento.ToString("N4");
                        //    porcentajedescuentostring = porcentajedescuento.ToString("N4");
                        //}

                        //decimal ivad = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["totalimpuestostrasladados"].Value),
                        // total = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Total"].Value),
                        // subtotal = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Subtotal"].Value);
                        //decimal tipodecambio;
                        //string tipodecambiostring;
                        //if (dataGridView1.CurrentRow.Cells["tipodecambio"].Value.ToString() == "")
                        //{

                        //    tipodecambiostring = "";
                        //}
                        //else
                        //{
                        //    tipodecambio = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["tipodecambio"].Value);
                        //    tipodecambiostring = tipodecambio.ToString("N4");
                        //}


                        //string ivastring = ivad.ToString("N4");
                        //string totalstring = total.ToString("N4");
                        //string subtotalstring = subtotal.ToString("N4");


                        //felweb.descuento = descuentostring;
                        //felweb.porcentajeDescuento = porcentajedescuentostring;
                        //felweb.motivoDescuento = dataGridView1.CurrentRow.Cells["motivodescuento"].Value.ToString();
                        //felweb.moneda = dataGridView1.CurrentRow.Cells["Moneda"].Value.ToString();
                        //felweb.tipoCambio = tipodecambiostring;
                        //felweb.fechaTipoCambio = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["fechatipodecambio"].Value).Date.ToShortDateString();
                        //felweb.totalImpuestosRetenidos = "0.000000";
                        //felweb.totalImpuestosTrasladados = ivastring;
                        //felweb.subTotal = subtotalstring;
                        //felweb.total = totalstring;
                        ////felweb.importeConLetra = dataGridView1.CurrentRow.Cells["TotalLetras"].Value.ToString();
                        //felweb.LugarExpedicion = dataGridView1.CurrentRow.Cells["LugarExpedicion"].Value.ToString();
                        //felweb.NumCuentaPago = dataGridView1.CurrentRow.Cells["NumCuenta"].Value.ToString(); ;
                        //felweb.FolioFiscalOrig = "";
                        //felweb.SerieFolioFiscalOrig = "";
                        //felweb.FechaFolioFiscalOrig = "";
                        //felweb.MontoFolioFiscalOrig = "";
                        ////Datos Varios
                        ////felweb.datosEtiquetas1 = "|B/R|" + dataGridView1.CurrentRow.Cells["Remolcadores"].Value.ToString() + "|";
                        ////if (dataGridView1.CurrentRow.Cells["Agencia"].Value.ToString() == "")
                        ////{
                        ////    felweb.datosEtiquetas2 = "";
                        ////}
                        ////else
                        ////{
                        ////    felweb.datosEtiquetas2 = "|Agencia|" + dataGridView1.CurrentRow.Cells["Agencia"].Value.ToString() + "|";
                        ////}

                        //felweb.importeConLetra = dataGridView1.CurrentRow.Cells["TotalLetras"].Value.ToString();
                        //List<string> datosConceptos = new List<string>(), datosInfoAduanera = new List<string>();
                        //cargaconceptos();
                        //foreach (DataGridViewRow row in dataGridView2.Rows)
                        //{
                        //    //El esquema, para incluir los conceptos sera el siguiente: | Cantidad | Unidad | noIdentificacion | Descripcion | valorUnitario | Importe |					
                        //    //Haciendo uso del caracter "|" pipe, para separar cada uno de los valores correspondientes. Ejemplo: |1|mtro.||alambre 1/2 pulgada|1.0|1.0|					
                        //    //|cantidad|unidad|noIdentificacion|descripcion|valorUnitario|importe|
                        //    datosConceptos.Add("|" + row.Cells["Cantidad"].Value.ToString() + "|" + row.Cells["Presentacion"].Value.ToString() + "||" + row.Cells["Descripcion"].Value.ToString() + "|" + row.Cells["Precio"].Value.ToString() + "|" + row.Cells["Importe"].Value.ToString() + "|");
                        //    datosInfoAduanera.Add("");
                        //}
                        //felweb.conceptos = datosConceptos;
                        //felweb.infoaduanera = datosInfoAduanera;
                        ////felweb.datosConceptos = dataGridView1.CurrentRow.Cells["Cliente"].Value.ToString();
                        ////felweb.datosInfoAduanera = dataGridView1.CurrentRow.Cells["Cliente"].Value.ToString();
                        //felweb.datosRetenidosIVA = "";
                        //felweb.datosRetenidosISR = "";
                        //felweb.datosTraslados1 = "|IVA (IVA 16.00%)|IVA|16.00|" + dataGridView1.CurrentRow.Cells["totalimpuestostrasladados"].Value.ToString() + "|";
                        //felweb.datosRetenidosLocales1 = "";
                        //felweb.datosRetenidosLocales2 = "";
                        //felweb.datosTrasladosLocales1 = "";
                        //string[] respuesta = new string[4];


                        //respuesta = felweb.GenerarCDFI();
                        //if (respuesta[0] == "True")
                        //{
                        //    XmlDocument xmldoc = new XmlDocument();
                        //    string resultado1 = respuesta[3].ToString();
                        //    //XmlWriterSettings settings;

                        //    ////settings = new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8, CheckCharacters = false };

                        //    //XmlReader reader = XmlReader.Create(resultado1, settings.Encoding.EncodingName = UTF8Encoding);
                        //    XmlReaderSettings rs = new XmlReaderSettings();
                        //    rs.CheckCharacters = false;

                        //    //// XmlXapResolver is the default resolver.
                        //    //using (XmlReader reader = XmlReader.Create(resultado1, rs))
                        //    //{
                        //    //    xmldoc.in
                        //    //    xmldoc.Load(reader);
                        //    //}

                        //    xmldoc.LoadXml(resultado1);

                        //    //xmldoc.Save("C:\\Facturas CFDI\\FacturasXML\\FacturasMiXML_Timbrado.xml");
                        //    DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
                        //    facturasdao.IDFactura = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                        //    //// Move to an element.
                        //    //XmlElement root = doc.DocumentElement;

                        //    //// Get an attribute.
                        //    //XmlAttribute attr = root.GetAttributeNode("ISBN");

                        //    //// Display the value of the attribute.
                        //    //String attrValue = attr.InnerXml;
                        //    //Console.WriteLine(attrValue);
                        //    XmlElement elementoxml = xmldoc.DocumentElement;
                        //    string lstVideos = elementoxml.ChildNodes.Count.ToString();
                        //    //XmlAttribute atributeelement = elementoxml.get
                        //    string atributouuid = lstVideos;
                        //    XmlNodeList nodelist = elementoxml.ChildNodes;
                        //    XmlNodeList nodelist2 = nodelist.Item(4).ChildNodes;
                        //    XmlNodeList nodelist3 = nodelist2.Item(0).ChildNodes;
                        //    XmlAttributeCollection elemento2 = nodelist2.Item(0).Attributes;
                        //    //XmlAttribute atrib = elemento2.GetNamedItem("UUID");
                        //    string nodotexto = elemento2.GetNamedItem("UUID").InnerText;

                        //    XmlAttributeCollection elemento3 = elementoxml.Attributes;
                        //    string nodotexto2 = elemento3.GetNamedItem("folio").InnerText;
                        //    facturasdao.facturaimpresa = nodotexto2;
                        //    xmldoc.Save("C:\\Facturas CFDI\\FacturasXML\\" + nodotexto2 + ".xml");

                        //    facturasdao.ClaveCFDI = nodotexto;

                        //    string resultado = facturasdao.insertanumfacturaimpresa();
                        //    MessageBox.Show("Correcto");
                        //    actualizagrid();

                        //}
                        //else
                        //{
                        //    MessageBox.Show("Error de generacion del CFDI " + respuesta[1] + " " + respuesta[2]);
                        //}
                    }
                    else
                    {
                        MessageBox.Show("Para volver a emitir una factura es necesario volver a crearla");
                    }
                }
                else
                {
                    MessageBox.Show("Es necesario elegir una cuenta");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["ClaveCFDI"].Value.ToString() != "")
            {
                DAO.FelWebServiceDAO webservice = new EquimarFac.DAO.FelWebServiceDAO();
                webservice.UUID = dataGridView1.CurrentRow.Cells["ClaveCFDI"].Value.ToString();
                string[] respuesta = new string[3];
                DAO.FacturasDAO facturasdao1 = new EquimarFac.DAO.FacturasDAO();
                facturasdao1.Nombre = comboBox2.Text;
                dataGridView2.DataSource = facturasdao1.devuelvedatospacpornombre();
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    webservice.CuentaFEL = row.Cells[1].Value.ToString();
                    webservice.emisorRFC = row.Cells[0].Value.ToString();
                    webservice.PasswordFEL = row.Cells[2].Value.ToString();
                }
                respuesta = webservice.GenerarFacturaBidimensional();

                if (respuesta[0] == "True")
                {

                    Image imagen = Base64ToImage(respuesta[2]);
                    imagen.Save("C:\\Facturas CFDI\\FacturasCBD\\" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + ".png");
                    MessageBox.Show("Guardado correctamente");
                }
                else
                {
                    MessageBox.Show(respuesta[1].ToString());
                }
            }
            else
            {
                MessageBox.Show("Genere el CFDI primero");
            }



        }
        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);
           

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[2].Value.ToString() != "")
            {
                try
                {
                    DialogResult result = MessageBox.Show("¿De verdad desea cancelar esta factura?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        DAO.FelWebServiceDAO webservice = new EquimarFac.DAO.FelWebServiceDAO();
                        webservice.UUID = dataGridView1.CurrentRow.Cells["ClaveCFDI"].Value.ToString();
                        string[] respuesta = new string[3];
                        DAO.FacturasDAO facturasdao1 = new EquimarFac.DAO.FacturasDAO();
                        facturasdao1.Nombre = comboBox2.Text;
                        dataGridView2.DataSource = facturasdao1.devuelvedatospacpornombre();
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            webservice.CuentaFEL = row.Cells[1].Value.ToString();
                            webservice.emisorRFC = row.Cells[0].Value.ToString();
                            webservice.PasswordFEL = row.Cells[2].Value.ToString();
                        }
                        respuesta = webservice.cancelacdfi();
                        if (respuesta[0] == "True")
                        {
                            DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
                            facturas.IDFactura = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                            facturas.ConceptoT = respuesta[2];
                            string resultado = facturas.cancelafactura();
                            if (resultado != "Correcto")
                            {
                                MessageBox.Show("Error de guardado en la base de datos" + respuesta[1].ToString());
                            }
                            else
                            {
                                MessageBox.Show(respuesta[1].ToString());
                                actualizagrid();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error" + respuesta[1].ToString());
                        }
                            
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error :" + ex);
                }
            }
            else
            {
                MessageBox.Show("Una factura no emitida en CFDI se cancela con el boton de cancelar factura");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿De verdad desea enviar esta factura? Se enviara al Email que tiene registrado del cliente", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (dataGridView1.CurrentRow.Cells[2].Value.ToString() != "")
                {
                    DAO.FelWebServiceDAO felweb = new EquimarFac.DAO.FelWebServiceDAO();
                    DAO.CatalogosDAO catalogos = new EquimarFac.DAO.CatalogosDAO();
                    catalogos.nombrecomercial = dataGridView1.CurrentRow.Cells["Cliente"].Value.ToString();
                    dataGridView2.DataSource = catalogos.devuelveclientepornombre();
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        felweb.Email = row.Cells["EmailCliente"].Value.ToString();
                    }
                    felweb.UUID = dataGridView1.CurrentRow.Cells["ClaveCFDI"].Value.ToString();
                    string[] resultado = new string[2];
                    DAO.FacturasDAO facturasdao1 = new EquimarFac.DAO.FacturasDAO();
                    facturasdao1.Nombre = comboBox2.Text;
                    dataGridView2.DataSource = facturasdao1.devuelvedatospacpornombre();
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        felweb.CuentaFEL = row.Cells[1].Value.ToString();
                        felweb.emisorRFC = row.Cells[0].Value.ToString();
                        felweb.PasswordFEL = row.Cells[2].Value.ToString();
                    }
                    resultado = felweb.enviacfdicorreo();
                    if (resultado[0] == "True")
                    {
                        MessageBox.Show("Enviado");
                    }
                    else
                    {
                        MessageBox.Show(resultado[1]);
                    }
                }
                else
                {
                    MessageBox.Show("Genere el CFDI primero");
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[2].Value.ToString() != "")
            {
                DAO.FelWebServiceDAO webservice = new EquimarFac.DAO.FelWebServiceDAO();
                webservice.UUID = dataGridView1.CurrentRow.Cells["ClaveCFDI"].Value.ToString();
                string[] respuesta = new string[4];
                DAO.FacturasDAO facturasdao1 = new EquimarFac.DAO.FacturasDAO();
                facturasdao1.Nombre = comboBox2.Text;
                dataGridView2.DataSource = facturasdao1.devuelvedatospacpornombre();
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    webservice.CuentaFEL = row.Cells[1].Value.ToString();
                    webservice.emisorRFC = row.Cells[0].Value.ToString();
                    webservice.PasswordFEL = row.Cells[2].Value.ToString();
                }
                respuesta = webservice.obtenerpdf();
                if (respuesta[0] == "True")
                {
                    byte[] bytes = Convert.FromBase64String(respuesta[3]);
                    //Step 2 is saving the byte array to disk:
                    try
                    {
                        System.IO.FileStream stream =
                            new FileStream(@"C:\\Facturas CFDI\\FacturasPDF\\" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + ".pdf", FileMode.CreateNew);
                        System.IO.BinaryWriter writer =
                            new BinaryWriter(stream);
                        writer.Write(bytes, 0, bytes.Length);
                        writer.Close();
                        MessageBox.Show("Correcto guardado");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de guardado del pdf, es posible que ya exista o que la carpeta se haya movido o cambiado, verifique la existencia de C:/Facturas CFDI/FacturasPDF - Error " + ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show(respuesta[1]);
                }
            }
            else
            {
                MessageBox.Show("Genere el CFDI primero");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if ((comboBox2.SelectedIndex !=-1))
            {
                DAO.FelWebServiceDAO webservice = new EquimarFac.DAO.FelWebServiceDAO();
                string[] respuesta = new string[7];
                DAO.FacturasDAO facturasdao1 = new EquimarFac.DAO.FacturasDAO();
                facturasdao1.Nombre = comboBox2.Text;
                dataGridView2.DataSource = facturasdao1.devuelvedatospacpornombre();
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    webservice.CuentaFEL = row.Cells[1].Value.ToString();
                    webservice.emisorRFC = row.Cells[0].Value.ToString();
                    webservice.PasswordFEL = row.Cells[2].Value.ToString();
                }
                respuesta = webservice.consultarcreditos();
                if (respuesta[0] == "True")
                {
                    MessageBox.Show("Creditos totales " + respuesta[3] + " Creditos usados " + respuesta[4] + " Creditos restantes " + respuesta[5] + " Fecha de vigencia del paquete actual " + respuesta[6]);
                }
                else
                {
                    MessageBox.Show(respuesta[1]);
                }
            }
            else
            {
                MessageBox.Show("Es necesario escoger una cuenta primero");
            }
        }
    }
}
