using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpotiFake.Models
{
    public class DetalleUsuario
    {
        public int idDetalleUsuario { get; set; }

        public int idUsuario { get; set; }
        public Usuario usuario { get; set; }

        public int idContacto { get; set; }
        public Usuario contacto { get; set; }
    }
}