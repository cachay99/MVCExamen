using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenMVCachay.Models
{
    public class MovilModelo
    {
        public int ID { get; set; }
        public string Nombre_movil { get; set; }
        public int MarcaID { get; set; }
        public MarcaModelo Marca { get; set; }
        public string Gama { get; set; }
        public List<int> AplicacionesSeleccionadas { get; set; }
        public List<Movil_Aplicacion> movil_Aplicaciones { get; set; }
    }
}