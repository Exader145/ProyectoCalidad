using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpotiFake.Models
{
    public class CancionesEscuchadas
    {
        public int idCancionesEscuchadas { get; set; }
        public int idUsuario { get; set; }
        public int idCancion { get; set; }
        public DateTime fecha { get; set; }

        public Cancion cancion { get; set; }
        public Usuario usuario { get; set; }
    }
}