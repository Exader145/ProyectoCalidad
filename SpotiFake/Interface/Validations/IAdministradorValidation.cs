using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SpotiFake.Interface.Validations
{
    public interface IAdministradorValidation
    {
        void Validate(Usuario usuario, ModelStateDictionary modelState);
        bool IsValid();
    }
}
