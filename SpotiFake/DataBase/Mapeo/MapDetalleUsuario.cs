using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SpotiFake.DataBase.Mapeo
{
    public class MapDetalleUsuario : EntityTypeConfiguration<DetalleUsuario>
    {
        public MapDetalleUsuario()
        {
            ToTable("DetalleUsuario");
            HasKey(o => o.idDetalleUsuario);

            HasRequired(o => o.usuario).WithMany(o => o.detalleUsuario).HasForeignKey(o => o.idUsuario);

            HasRequired(o => o.usuario).WithMany(o => o.detalleUsuario).HasForeignKey(o => o.idContacto);
        }
    }
}