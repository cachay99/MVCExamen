using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenMVCachay.Models
{
    public class Movil_Aplicacion
    {
        public int ID { get; set; }
        public int movilID { get; set; }
        public int aplicacionID { get; set; }
        public MovilModelo Movil { get; set; }
        public AplicacionModelo Aplicacion { get; set; }
    }
}