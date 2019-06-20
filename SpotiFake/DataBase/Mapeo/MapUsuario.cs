using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SpotiFake.DataBase.Mapeo
{
    public class MapUsuario : EntityTypeConfiguration<Usuario>
    {
        public MapUsuario()
        {
            ToTable("Usuario");
            HasKey(o => o.idUsuario);

            HasMany(o => o.cancionesEscuchadas).WithRequired(o => o.usuario).HasForeignKey(o => o.idUsuario);

            HasMany(o => o.listaReproduccion).WithRequired(o => o.usuario).HasForeignKey(o => o.idUsuario);
        }
    }
}