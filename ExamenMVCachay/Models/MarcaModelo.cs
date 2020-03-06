using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenMVCachay.Models
{
    public class MarcaModelo
    {
        public int ID { get; set; }
        public string Nombre_marca { get; set; }
        public List<int> MovilesSeleccionados { get; set; }
        public List<MovilModelo> Moviles { get; set; }
    }
}