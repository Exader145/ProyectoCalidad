using Moq;
using NUnit.Framework;
using SpotiFake.Controllers;
using SpotiFake.Interface;
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
            var controller = new UsuarioController();

            var result = controller.AdminIndex() as ViewResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public void probarUsuarioIndexRetornaListaCancionesRegistradas()
        {
            var idUsuario = 2;

            var mock = new Mock<IUsuarioService>();
            mock.Setup(o => o.obtenerListaCancionesRegistradas());

            var controller = new UsuarioController(mock.Object);
            var result = controller.UsuarioIndex(idUsuario) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            mock.Verify(o => o.obtenerListaCancionesRegistradas(), Times.AtLeastOnce);
        }

            }
}
