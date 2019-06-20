using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SpotiFake.DataBase.Mapeo
{
    public class MapCancionesEscuchadas : EntityTypeConfiguration<CancionesEscuchadas>
    {
        public MapCancionesEscuchadas()
        {
            ToTable("CancionesEscuchadas");
            HasKey(o => o.idCancionesEscuchadas);

            HasRequired(o => o.usuario).WithMany(o => o.cancionesEscuchadas).HasForeignKey(o => o.idUsuario);

            //HasRequired(o => o.cancion).WithMany(o => o.cancionesEscuchadas).HasForeignKey(o => o.idCancion);
        }
    }
}