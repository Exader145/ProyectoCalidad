using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SpotiFake.DataBase.Mapeo
{
    public class MapListaReproduccion : EntityTypeConfiguration<ListaReproduccion>
    {
        public MapListaReproduccion()
        {
            ToTable("ListaReproduccion");
            HasKey(o => o.idListaReproduccion);

            HasMany(o => o.listaReproduccion_Cancion).WithRequired(o => o.listaReproduccion).HasForeignKey(o => o.idListaReproduccion);

            HasRequired(o => o.usuario).WithMany(o => o.listaReproduccion).HasForeignKey(o => o.idUsuario);
        }
    }
}