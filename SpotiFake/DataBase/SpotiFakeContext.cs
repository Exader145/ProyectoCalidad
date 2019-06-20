using SpotiFake.DataBase.Mapeo;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SpotiFake.DataBase
{
    public class SpotiFakeContext:DbContext
    {
        public IDbSet<Cancion> Cancions { get; set; }
        public IDbSet<CancionesEscuchadas> CancionesEscuchadass { get; set; }
        public IDbSet<ListaReproduccion_Cancion> listaReproduccion_Cancion { get; set; }
        public IDbSet<ListaReproduccion> ListaReproduccions { get; set; }
        public IDbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new MapCancion());
            modelBuilder.Configurations.Add(new MapCancionesEscuchadas());
            modelBuilder.Configurations.Add(new MapListaReproducion_Cancion());
            modelBuilder.Configurations.Add(new MapListaReproduccion());
            modelBuilder.Configurations.Add(new MapUsuario());
        }
    }
}