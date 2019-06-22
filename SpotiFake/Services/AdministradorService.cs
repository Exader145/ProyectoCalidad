using SpotiFake.DataBase;
using SpotiFake.Interface;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpotiFake.Services
{
    public class AdministradorService : IAdministradorService
    {
        private SpotiFakeContext context;

        public AdministradorService()
        {
            context = new SpotiFakeContext();
        }

        public List<Usuario> retornarListaAdministradores()
        {
            var administrador = context.Usuarios.Where(o => o.rol == "Admin").ToList();
            return administrador;
        }

        public void agregarAdministrador(Usuario usuario)
        {
                context.Usuarios.Add(usuario);
                usuario.rol = "Admin";
                usuario.fechaCreación = DateTime.Now;
                context.SaveChanges();
        }

        public Usuario obtenerIdUsuarioParaModificar(int idUsuario)
        {
            var administrador = context.Usuarios.Where(o => o.idUsuario == idUsuario).First();
            return administrador;
        }

        public void actualizarYGuardarDatosUsuario(Usuario usuario)
        {
            var adminBD = context.Usuarios.Where(o => o.idUsuario == usuario.idUsuario).First();
            adminBD.nombre = usuario.nombre;
            adminBD.correoElectronico = usuario.correoElectronico;
            adminBD.contraseña = usuario.contraseña;

            context.SaveChanges();
        }

        public void eliminarUsuario(int id)
        {
            var usuario = context.Usuarios.Where(o => o.idUsuario == id).FirstOrDefault();
            context.Usuarios.Remove(usuario);
            context.SaveChanges();
        }
    }
}