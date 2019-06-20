using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpotiFake.Models
{
    public class ListaReproduccion_Cancion
    {
        public int idListaReproduccion_Cancion { get; set; }

        public int idListaReproduccion { get; set; }
        public ListaReproduccion listaReproduccion { get; set; }

        public int idCancion { get; set; }
        public Cancion cancion { get; set; }
    }
}