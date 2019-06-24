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

        public void agregarCancionACancionesEscuchadas(int idCancion, int idUsuario)
        {
            var cancionExisteEnBD = context.CancionesEscuchadass.Where(o => o.idUsuario == idUsuario && o.idCancion == idCancion).FirstOrDefault();
            var cancionEscuchada = new CancionesEscuchadas();
            cancionEscuchada.fecha = DateTime.Now;
            cancionEscuchada.idUsuario = idUsuario;
            cancionEscuchada.idCancion = idCancion;
            if (cancionExisteEnBD==null)
            {
                context.CancionesEscuchadass.Add(cancionEscuchada);
                context.SaveChanges();
            }
            else
            {
                context.CancionesEscuchadass.Remove(cancionExisteEnBD);
                context.CancionesEscuchadass.Add(cancionEscuchada);
                context.SaveChanges();
            }
        }

        public List<CancionesEscuchadas> obtenerListaCancionesEscuchadas(int idUsuario)
        {
            var cancionesEscuchadas = context.CancionesEscuchadass.Where(o => o.idUsuario == idUsuario).OrderByDescending(o=>o.fecha).Include(o => o.cancion).ToList();

            return cancionesEscuchadas;
        }

    }
}