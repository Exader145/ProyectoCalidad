using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpotiFake.Interface
{
    public interface IAdministradorService
    {
        List<Usuario> retornarListaAdministradores();

        void agregarAdministrador(Usuario usuario);

        Usuario obtenerIdUsuarioParaModificar(int idUsuario);

        void actualizarYGuardarDatosUsuario(Usuario usuario);

        void eliminarUsuario(int idUsuario);
    }
}