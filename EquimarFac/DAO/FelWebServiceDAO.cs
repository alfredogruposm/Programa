using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rnd = EquimarFac.FelWebService;

namespace EquimarFac.DAO
{
    class FelWebServiceDAO
    {
        public List<string> conceptos, infoaduanera;
        public string emisorRFC;

        public string CuentaFEL;
            
        //"EPR911024AH7";

        //public string CuentaFELNotasCredito = "NOTACREDITO";

        //public string CuentaFELFacturas = "FACTURAS";

        public string PasswordFEL;

        // Datos Receptor
        public string NombreCliente { get; set; }

        public string Contacto {get; set;}

        public string Telefono {get; set;}

        public string Email {get; set;}

        public string rfcReceptor {get; set;}

        public string nombreReceptor {get; set;}

        public string calleReceptor {get; set;}

        public string noExteriorReceptor {get; set;}

        public string noInteriorReceptor {get; set;}

        public string coloniaReceptor {get; set;}

        public string localidadReceptor {get; set;}

        public string referenciaReceptor {get; set;}

        public string municipioReceptor {get; set;}

        public string estadoReceptor {get; set;}

        public string paisReceptor {get; set;}


        public string codigoPostalReceptor {get; set;}

        //Datos CFDI
        public string ClaveCFDI {get; set;}

        public string formaDePago {get; set;}

        public string parcialidades {get; set;}

        public string condicionesDePago {get; set;}

        public string metodoDePago {get; set;}

        public string descuento {get; set;}

        public string porcentajeDescuento {get; set;}

        public string motivoDescuento {get; set;}

        public string moneda {get; set;}

        public string tipoCambio {get; set;}

        public string fechaTipoCambio {get; set;}

        public string totalImpuestosRetenidos {get; set;}

        public string totalImpuestosTrasladados {get; set;}

        public string subTotal {get; set;}

        public string total {get; set;}

        public string importeConLetra { get; set; }

        public string LugarExpedicion { get; set; }

        public string NumCuentaPago { get; set; }

        public string FolioFiscalOrig { get; set; }

        public string SerieFolioFiscalOrig { get; set; }

        public string FechaFolioFiscalOrig { get; set; }

        public string MontoFolioFiscalOrig { get; set; }
        //Datos Varios
        public string datosEtiquetas1 { get; set; }
        public string datosEtiquetas2 { get; set; }
        public string datosConceptos { get; set; }
        public string datosInfoAduanera { get; set; }
        public string datosRetenidosIVA { get; set; }
        public string datosRetenidosISR { get; set; }
        public string datosTraslados1 { get; set; }
        public string datosRetenidosLocales1 { get; set; }
        public string datosRetenidosLocales2 { get; set; }
        public string datosTrasladosLocales1 { get; set; }
        public string UUID { get; set; }
        public string[] AUUID { get; set; }
      

        public string[] GenerarCDFI()
        {
            string[] datosUsuario = new string[3], datosReceptor = new string[16], datosCFDI = new string[22], datosEtiquetas = new string[0], datosConceptos = new string[conceptos.Count], datosInfoAduanera = new string[infoaduanera.Count], datosRetenidos = new string[1], datosTraslados = new string[1], datosRetenidosLocales = new string[1], datosTrasladosLocales = new string[1];
            string[] respuesta = new string[4];
            //try
            //{
                                // Vector para envío de datos de usuario.
                        //Dim datosUsuario As New WSRemota32.ArrayOfString
                        // RFC del emisor (REQUERIDO);. Posición 0.
                        datosUsuario[0] = emisorRFC;
                        // Cuenta del usuario (REQUERIDO);. Posición 1.
                        datosUsuario[1] = CuentaFEL;
                        // Password del usuario (REQUERIDO);. Posición 2.
                        datosUsuario[2] = PasswordFEL;

                        //*************************************************************************************
                        // Sección de variables para identificar y actualizar los datos del Cliente o Receptor.
                        //*************************************************************************************
                        // Vector para envío de datos de cliente receptor.
                        
                        // Nombre del cliente (REQUERIDO;. Posición 0.
                        datosReceptor[0] = NombreCliente;
                        // Contacto de referencia del cliente (opcional;. Posición 1.
                        datosReceptor[1] = Contacto;
                        // Teléfono del cliente (opcional;. Posición 2.
                        datosReceptor[2] = Telefono;
                        // Email del cliente (opcional;. Posición 3.
                        datosReceptor[3] = Email;
                        // RFC del receptor (REQUERIDO;. Posición 4.
                        datosReceptor[4] = rfcReceptor; //WAPR7802271P5
                        // Nombre del receptor (REQUERIDO;. Posición 5.
                        datosReceptor[5] = nombreReceptor;
                        // Calle del receptor (REQUERIDO;. Posición 6.
                        datosReceptor[6] = calleReceptor;
                        // No. exterior del receptor (REQUERIDO;. Posición 7.
                        datosReceptor[7] = noExteriorReceptor;
                        // No. interior del receptor (opcional;. Posición 8.
                        datosReceptor[8] = noInteriorReceptor;
                        // Colonia del receptor (REQUERIDO;. Posición 9.
                        datosReceptor[9] = coloniaReceptor;
                        // Localidad del receptor (opcional;. Posición 10.
                        datosReceptor[10] = localidadReceptor;
                        // Referencia del receptor (opcional;. Posición 11.
                        datosReceptor[11] = referenciaReceptor;
                        // Municio del receptor (REQUERIDO;. Posición 12.
                        datosReceptor[12] = municipioReceptor;
                        // Estado del receptor (REQUERIDO;. Posición 13.
                        datosReceptor[13] = estadoReceptor;
                        // País del receptor (REQUERIDO;. Posición 14.
                        datosReceptor[14] = paisReceptor;
                        // Código postal del receptor (REQUERIDO;. Posición 15.
                        datosReceptor[15] = codigoPostalReceptor;

                        //******************************************************
                        // Sección de variables de información general del CFDI.
                        //******************************************************
                        // Clave del CFDI (REQUERIDO);. Posición 0.
                        datosCFDI[0] = ClaveCFDI;
                        // Forma de pago (REQUERIDO;. Posición 1.
                        datosCFDI[1] = formaDePago;
                        // Pago en parcialidades (opcional;. Posición 2.
                        datosCFDI[2] = parcialidades;
                        // Condiciones de pago (opcional;. Posición 3.
                        datosCFDI[3] = condicionesDePago;
                        // Método de pago (opcional;. Posición 4.
                        datosCFDI[4] = metodoDePago;
                        // El descuento usado (opcional;. Posición 5.
                        datosCFDI[5] = descuento;
                        // El porcentaje de descuento (opcional;. Posición 6.
                        datosCFDI[6] = porcentajeDescuento;
                        // El motivo de descuento (opcional;. Posición 7.
                        datosCFDI[7] = motivoDescuento;
                        // La moneda utilizada (REQUERIDO;. Posición 8.
                        datosCFDI[8] = moneda;
                        // Tipo de cambio (opcional;. Posición 9.
                        datosCFDI[9] = tipoCambio;
                        // Fecha del tipo de cambio (opcional;. Posición 10.
                        datosCFDI[10] = fechaTipoCambio;
                        // El total de impuestos retenidos (REQUERIDO;. Posición 11.
                        datosCFDI[11] = totalImpuestosRetenidos;
                        // El total de impuestos trasladados (REQUERIDO;. Posición 12.
                        datosCFDI[12] = totalImpuestosTrasladados;
                        // El subtotal del comprobante (REQUERIDO;. Posición 13.
                        datosCFDI[13] = subTotal;
                        // El total del comprobante (REQUERIDO;. Posición 14.
                        datosCFDI[14] = total;
                        // El importe con letra formado (REQUERIDO;. Posición 15.
                        datosCFDI[15] = importeConLetra;
                        // NUEVOS CAMPOS SAT 3.2
                        // (16; LugarExpedicion (REQUERIDO;
                        datosCFDI[16] = LugarExpedicion;
                        // (17; NumCuentaPago (OPCIONAL;
                        datosCFDI[17] = NumCuentaPago;
                        // (18; FolioFiscalOrig (OPCIONAL;
                        datosCFDI[18] = FolioFiscalOrig;
                        // (19; SerieFolioFiscalOrig (OPCIONAL;
                        datosCFDI[19] = SerieFolioFiscalOrig;
                        // (20; FechaFolioFiscalOrig (OPCIONAL;
                        datosCFDI[20] = FechaFolioFiscalOrig;
                        // (21; MontoFolioFiscalOrig (OPCIONAL;
                        datosCFDI[21] = MontoFolioFiscalOrig;

                        //********************************************************************************************
                        // Sección de variables para el uso de información comercial y personal de la empresa emisora.
                        //********************************************************************************************
                        // Secuencia: |nombre|valor|
                        // Etiqueta1(opcional;.

                        //datosEtiquetas[0] = datosEtiquetas1;
                        //// Etiqueta2 (opcional;.
                        //datosEtiquetas[1] = datosEtiquetas2;
                        //datosEtiquetas[0] = datosEtiquetas1;
                        //// Etiqueta2 (opcional;.
                        //datosEtiquetas[1] = datosEtiquetas2;

                        //*************************************************************************
                        // Sección de variables para la información y descripción de los conceptos.
                        //*************************************************************************
                        // Vector para referenciar los conceptos del comprobante.
                        

                        // Secuencia: |cantidad|unidad|noIdentificacion|descripcion|valorUnitario|importe|
                int contador = 0;
                        foreach(string i in conceptos)
                        {
                            datosConceptos[contador] = i;
                            contador=contador+1;
                        }
                // Concepto1
                        //datosConceptos[] = |1|mtro.||Prueba de CFDI concepto1|1|1|);
                        //// Concepto2
                        //datosConceptos[] = |1|mtro.||Prueba de CFDI concepto2|1|1|);
                        //// Concepto3
                        //datosConceptos[] = |1|mtro.|104445|Prueba de CFDI concepto3|1|1|);
                        //// Concepto4
                        //datosConceptos[] = |1|ltro.|104445|Prueba de CFDI concepto4|1|1|);

                        //****************************************************************************************************
                        // Sección de variables para la información aduanera correspondiente a cada concepto usado en el CFDI.
                        //****************************************************************************************************
                        // Vector para referenciar la información aduanera.
                        
                        // Secuencia: |numero|fecha|aduana|
                        // IMPORTANTE: El tamaño del vector de aduanera debe coincidir respectivamente con el de conceptos, ya que es 1 a 1.
                        // Información aduanera para el concepto 1
                contador=0;
                foreach(string i in infoaduanera)
                {
                    datosInfoAduanera[contador] = i;
                    contador=contador+1;
                }
                 //       datosInfoAduanera[] = |777888|2012-02-07|Aduana de Puebla|);
                 //       // Información aduanera para el concepto 2
                 //// Algunos lenguajes no aceptan “nothing”, por lo que puede simplemente establecer un string vacío “” como una excepción a la regla.
                 //       datosInfoAduanera.Add;
                 //       // Información aduanera para el concepto 3
                 //       datosInfoAduanera[] = |444555|2012-02-05||);
                 //       // Información aduanera para el concepto 4
                 //       datosInfoAduanera[] = Nothing);

                        //*************************************************************************************************
                        // Sección de variables para la información de todos los impuestos retenidos utilizados en el CFDI.
                        //*************************************************************************************************
                        // Vector para referenciar los impuestos retenidos.
                        

                        // Secuencia: |NombreImpuesto|impuesto|importe|
                        // Impuesto retenido 1
                datosRetenidos[0] = "|IVA (IVA 16.00%)|IVA|0.00|";
                        // Impuesto retenido 2
                        //datosRetenidos[] = datosRetenidosISR);

                        //***************************************************************************************************
                        // Sección de variables para la información de todos los impuestos trasladados utilizados en el CFDI.
                        //***************************************************************************************************
                        // Vector para referenciar los impuestos trasladados.
                        

                        // Secuencia: |NombreImpuesto|impuesto|tasa|importe|
                        // Impuesto trasladado no. 1.
                        datosTraslados[0] = datosTraslados1;

                        //*********************************************************************************************************
                        // Sección de variables para la información de todos los impuestos retenidos locales utilizados en el CFDI.
                        //*********************************************************************************************************
                        // Vector para referenciar los impuestos retenidos locales.
                        

                        // Secuencia: |NombreImpuesto|impuesto|tasa|importe|
                        // Impuesto retenido local 1
                        datosRetenidosLocales[0] = "|IVA (Local 16.00%)|IVA|16.00|0.00|";
                        // Impuesto retenido local 2
                        //datosRetenidosLocales[] = datosRetenidosLocales2);

                //***********************************************************************************************************
                        // Sección de variables para la información de todos los impuestos trasladados locales utilizados en el CFDI.
                        //***********************************************************************************************************
                        // Vector para referenciar los impuestos trasladados locales.
                        

                        // Secuencia: |NombreImpuesto|impuesto|tasa|importe|
                        // Impuesto trasladado local no. 1.
                        datosTrasladosLocales[0] = "|IVA (Local 16.00%)|IVA|16.00|0.00|";
                rnd.ConexionRemota32 coneccion=new EquimarFac.FelWebService.ConexionRemota32();
                coneccion.PreAuthenticate = true;
                // |cantidad|unidad|noIdentificacion|descripcion|valorUnitario|importe|
                respuesta = coneccion.GenerarCFDIv32(datosUsuario, datosReceptor, datosCFDI, datosEtiquetas, datosConceptos, datosInfoAduanera, datosRetenidos, datosTraslados, datosRetenidosLocales, datosTrasladosLocales);
                return respuesta;


            //}
            //catch
            //{
            //    return respuesta;
            //}
        }

        public string[] GenerarFacturaBidimensional()
        {
            string[] datosUsuario = new string[3];
            string[] respuesta = new string[3];
            try
            {
                datosUsuario[0] = emisorRFC;
                // Cuenta del usuario (REQUERIDO);. Posición 1.
                datosUsuario[1] = CuentaFEL;
                // Password del usuario (REQUERIDO);. Posición 2.
                datosUsuario[2] = PasswordFEL;

                rnd.ConexionRemota32 coneccion=new EquimarFac.FelWebService.ConexionRemota32();
                
                return respuesta = coneccion.GenerarCodigoBidimensional(datosUsuario, UUID);    
            }
            catch
            {
                return respuesta;
            }
        }

        public string[] cancelacdfi()
        {
            string[] datosUsuario = new string[3];
            string[] respuesta = new string[3];
            string[] listaUUID = new string[1];
            try
            {
                datosUsuario[0] = emisorRFC; ;
                // Cuenta del usuario (REQUERIDO);. Posición 1.
                datosUsuario[1] = CuentaFEL;
                // Password del usuario (REQUERIDO);. Posición 2.
                datosUsuario[2] = PasswordFEL;
                listaUUID[0] = UUID;
                rnd.ConexionRemota32 coneccion = new EquimarFac.FelWebService.ConexionRemota32();

                return respuesta = coneccion.CancelarCFDI(datosUsuario, listaUUID);
            }
            catch
            {
                return respuesta;
            }
        }

        public string[] enviacfdicorreo()
        {
            string[] datosUsuario = new string[3];
            string[] respuesta = new string[2];
            try
            {
                datosUsuario[0] = emisorRFC; ;
                // Cuenta del usuario (REQUERIDO);. Posición 1.
                datosUsuario[1] = CuentaFEL;
                // Password del usuario (REQUERIDO);. Posición 2.
                datosUsuario[2] = PasswordFEL;

                rnd.ConexionRemota32 coneccion = new EquimarFac.FelWebService.ConexionRemota32();

                return respuesta = coneccion.EnviarCFDI(datosUsuario, UUID, Email);
            }
            catch
            {
                return respuesta;
            }
        }


        public string[] obtenerpdf()
        {
            string[] datosUsuario = new string[3];
            string[] respuesta = new string[4];
            try
            {
                datosUsuario[0] = emisorRFC; ;
                // Cuenta del usuario (REQUERIDO);. Posición 1.
                datosUsuario[1] = CuentaFEL;
                // Password del usuario (REQUERIDO);. Posición 2.
                datosUsuario[2] = PasswordFEL;

                rnd.ConexionRemota32 coneccion = new EquimarFac.FelWebService.ConexionRemota32();

                return respuesta = coneccion.ObtenerPDF(datosUsuario, UUID);
            }
            catch
            {
                return respuesta;
            }
        }


        public string[] consultarcreditos()
        {
            string[] datosUsuario = new string[3];
            string[] respuesta = new string[7];
            try
            {
                datosUsuario[0] = emisorRFC; ;
                // Cuenta del usuario (REQUERIDO);. Posición 1.
                datosUsuario[1] = CuentaFEL;
                // Password del usuario (REQUERIDO);. Posición 2.
                datosUsuario[2] = PasswordFEL;

                rnd.ConexionRemota32 coneccion = new EquimarFac.FelWebService.ConexionRemota32();

                return respuesta = coneccion.ObtenerNumeroCreditos(datosUsuario);
            }
            catch
            {
                return respuesta;
            }
        }
















            
    }
}
