using NUnit.Framework;
using SpotiFake.Controllers;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SpotiFake.TEST.ControllersTest
{
    [TestFixture]
    public class UsuarioControllerTest
    {
        [Test]
        public void probarSysIndexRetornaSaludo()
        {
            var controller = new UsuarioController();

            var result = controller.SysIndex() as ViewResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public void probarAdminIndexRetornaSaludo()
        {
            var usuario = new Usuario()
            {
                idUsuario = 2,
                nombre = "Daniel Perez",
                correoElectronico = "daniel@hotmail.com",
                rol = "Usuario",
                contraseña = "1234",
                fechaCreación = DateTime.Now
            };

            var controller = new UsuarioController();

            var result = controller.AdminIndex(usuario) as ViewResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public void probarUsuarioIndexRetornaListaCancionesPorUsuario()
        {
            
        }
    }
}
