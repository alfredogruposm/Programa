using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rnd = EquimarFac.TimbradoFelWebService;

namespace EquimarFac.DAO
{
    class TimbradoFelWebService
    {
        public string usuario { get; set; }

        public string password { get; set; }

        public string cadenaXML { get; set; }

        public string referencia { get; set; }

        //public string password { get; set; }

        //public string cadenaXML { get; set; }


        public string[] TimbrarCFD()
        {
            try
            {
                usuario = "DEMO111007FP9";
                password = "S%8teo33MY@";
                TimbradoFelWebService felweb = new TimbradoFelWebService();
                string[] respuesta = new string[4];
                rnd.WS_TFD coneccion = new EquimarFac.TimbradoFelWebService.WS_TFD();
                
                cadenaXML="<?xml version=" + "1.0 " + " encoding=" + "UTF-8" + "? >" + cadenaXML;
                respuesta = coneccion.TimbrarCFDPrueba(usuario, password, cadenaXML);

                return respuesta;
            }
            catch(Exception Ex)
            {
                string[] respuesta = new string[4];
                respuesta[0]=Ex.ToString();
                return respuesta;
            }
        }

    }
}
