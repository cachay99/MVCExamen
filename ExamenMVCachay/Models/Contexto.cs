using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExamenMVCachay.Models
{
    public class Contexto : DbContext
    {
        public DbSet<MovilModelo> Moviles{ get; set; }
        public DbSet<MarcaModelo> Marcas{ get; set; }
        public DbSet<AplicacionModelo> Aplicaciones{ get; set; }
        public DbSet<Movil_Aplicacion>  Movil_Aplicaciones{ get; set; }
    }
}