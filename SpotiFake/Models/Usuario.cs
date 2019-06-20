using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpotiFake.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string correoElectronico { get; set; }
        public string rol { get; set; }
        public string contraseña { get; set; }
        public DateTime fechaCreación { get; set; }

        public List<ListaReproduccion> listaReproduccion { get; set; }
        public List<CancionesEscuchadas> cancionesEscuchadas { get; set; }
    }
}