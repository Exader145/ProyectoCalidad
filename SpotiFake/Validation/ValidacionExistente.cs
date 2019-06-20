using SpotiFake.DataBase;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace SpotiFake.Validation
{
    public class ValidacionExistente
    {
        SpotiFakeContext spotiFakeContext = new SpotiFakeContext();

        public void existeCliente(Usuario usuario, ModelStateDictionary ModelState)
        {
            if (spotiFakeContext.Usuarios.Any(a => a.nombre == usuario.nombre))
            {
                ModelState.AddModelError("nombre", "Este nombre de usuario ya existe");
            }
            if (spotiFakeContext.Usuarios.Any(a => a.correoElectronico == usuario.correoElectronico))
            {
                ModelState.AddModelError("correoElectronico", "Este correo electrónico ya existe");
            }
        }
    }
}