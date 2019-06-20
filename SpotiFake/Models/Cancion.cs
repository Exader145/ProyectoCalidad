using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace SpotiFake.Models
{
    public class Cancion
    {
        public int idCancion { get; set; }
        public string nombre { get; set; }
        public string artista { get; set; }
        public string album { get; set; }
        public string genero { get; set; }
        public double duracionCancion { get; set; }
        public DateTime fechaLanzamiento { get; set; }
        public DateTime fechaRegistro { get; set; }
        public String imagen { get; set; }

        public List<CancionesEscuchadas> cancionesEscuchadas { get; set; }
        public List<ListaReproduccion_Cancion> listaReproduccion_Cancion { get; set; }
    }
}