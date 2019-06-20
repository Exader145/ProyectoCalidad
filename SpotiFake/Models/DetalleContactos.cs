using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SpotiFake.Models
{
    public class DetalleContactos
    {
        public int idDetalleContactos { get; set; }
        public int idUsuario { get; set; }
        public int idUsuarioAmigo { get; set; }
        
    }
}