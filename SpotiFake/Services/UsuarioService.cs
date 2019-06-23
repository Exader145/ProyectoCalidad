using SpotiFake.DataBase;
using SpotiFake.Interface;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SpotiFake.Services
{
    public class UsuarioService : IUsuarioService
    {

        private SpotiFakeContext context;

        public UsuarioService()
        {
            context = new SpotiFakeContext();
        }

        public List<Cancion> obtenerListaCancionesRegistradas()
        {
            var cancion = context.Cancions.ToList();
            return cancion;
        }

        public void logOff()
        {
            FormsAuthentication.SignOut();
        }

        public List<Cancion> agregarCancionACancionesEscuchadas(int idCancion, int idUsuario)
        {
            var cancionesEscuchadas = new CancionesEscuchadas();
            cancionesEscuchadas.fecha = DateTime.Now;
            cancionesEscuchadas.idUsuario = idUsuario;
            cancionesEscuchadas.idCancion = idCancion;
            context.CancionesEscuchadass.Add(cancionesEscuchadas);
            context.SaveChanges();
            var cancion = context.Cancions.ToList();

            return cancion;
        }

        public List<CancionesEscuchadas> obtenerListaCancionesEscuchadas(int idUsuario)
        {
            var cancionesEscuchadas = context.CancionesEscuchadass.Where(o => o.idUsuario == idUsuario).Include(o => o.cancion).ToList();

            return cancionesEscuchadas;
        }
    }
}