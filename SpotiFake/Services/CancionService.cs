using SpotiFake.DataBase;
using SpotiFake.Interface;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SpotiFake.Services
{
    public class CancionService : ICancionService
    {

        private SpotiFakeContext context;

        public CancionService()
        {
            context = new SpotiFakeContext();
        }

        public List<Cancion> obtenerListaCanciones()
        {
            var cancion = context.Cancions.ToList();
            return cancion;
        }

        public void guardarCancion(Cancion cancion)
        {
            context.Cancions.Add(cancion);
            cancion.fechaRegistro = DateTime.Now;
            context.SaveChanges();
        }

        public Cancion obtenerDatosCancionAModificar(int id)
        {
            var cancion = context.Cancions.Where(o => o.idCancion == id).FirstOrDefault();

            return cancion;
        }

        public void actualizarCancion(Cancion cancion)
        {
            var cancionBD = context.Cancions.Where(y => y.idCancion == cancion.idCancion).FirstOrDefault();
            cancionBD.nombre = cancion.nombre;
            cancionBD.artista = cancion.artista;
            cancionBD.album = cancion.album;
            cancionBD.genero = cancion.genero;
            cancionBD.duracionCancion = cancion.duracionCancion;
            cancionBD.fechaLanzamiento = cancion.fechaLanzamiento;
            cancionBD.imagen = cancion.imagen;
            context.SaveChanges();
        }

        public void eliminarCancion(int idCancion)
        {
            var cancion = context.Cancions.Where(d => d.idCancion == idCancion).FirstOrDefault();
            context.Cancions.Remove(cancion);
            context.SaveChanges();
        }

        public void logOff()
        {
            FormsAuthentication.SignOut();
        }
    }
}