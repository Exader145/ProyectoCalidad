using SpotiFake.Interface.Validations;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpotiFake.Validations
{
    public class CancionValidation : ICancionValidation
    {
        private ModelStateDictionary modelState;

        public void Validate(Cancion cancion, ModelStateDictionary modelState)
        {
            this.modelState = modelState;

            if (cancion.nombre == null)
                modelState.AddModelError("Nombre", "El campo es obligatorio");

            if (cancion.artista == null)
                modelState.AddModelError("Artista", "El campo es obligatorio");

            if (cancion.album == null)
                modelState.AddModelError("Album", "El campo es obligatorio");

            if (cancion.genero == null)
                modelState.AddModelError("Genero", "El campo es obligatorio");

            if (cancion.duracionCancion == 0)
                modelState.AddModelError("Duracion", "El campo es obligatorio");

            if (cancion.fechaLanzamiento == null)
                modelState.AddModelError("FechaLanzamiento", "El campo es obligatorio");
        }

        public bool IsValid()
        {
            return modelState.IsValid;
        }
    }
}