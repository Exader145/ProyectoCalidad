using SpotiFake.Interface.Validations;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpotiFake.Validations
{
    public class AdministradorValidation : IAdministradorValidation
    {
        private ModelStateDictionary modelState;

        public void Validate(Usuario usuario, ModelStateDictionary modelState)
        {
            this.modelState = modelState;

            if (string.IsNullOrEmpty(usuario.nombre))
                modelState.AddModelError("Nombres", "El campo es obligatorio");

            if (string.IsNullOrEmpty(usuario.correoElectronico))
                modelState.AddModelError("correoElectronico", "El campo es obligatorio");

            if (string.IsNullOrEmpty(usuario.contraseña))
                modelState.AddModelError("Contraseña", "El campo es obligatorio");
        }

        public bool IsValid()
        {
            return modelState.IsValid;
        }
    }
}