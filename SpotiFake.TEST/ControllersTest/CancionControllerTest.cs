using Moq;
using NUnit.Framework;
using SpotiFake.Controllers;
using SpotiFake.Interface;
using SpotiFake.Interface.Validations;
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
    public class CancionControllerTest
    {
        [Test]
        public void probarIndexObtenerListaCanciones()
        {
            var mock = new Mock<ICancionService>();
            mock.Setup(o => o.obtenerListaCanciones());

            var controller = new CancionController(mock.Object, null);
            var result = controller.Index() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void probarIndexSysObtenerListaCanciones()
        {
            var mock = new Mock<ICancionService>();
            mock.Setup(o => o.obtenerListaCanciones());

            var controller = new CancionController(mock.Object, null);
            var result = controller.IndexSys() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void probarRegistrarCancion()
        {
            var controller = new CancionController();

            var result = controller.registrarCancion();

            Assert.IsNotNull(result);
        }

        [Test]
        public void probarRegistrarCancionSys()
        {
            var controller = new CancionController();

            var result = controller.registrarCancionSys();

            Assert.IsNotNull(result);
        }

        [Test]
        public void probarAgregarGuardarCancion()
        {
            var cancion = new Cancion()
            {
                idCancion = 2,
                nombre = "El quinto teletubie",
                artista = "Chabelos",
                album = "Teletubies",
                genero = "Rock",
                duracionCancion = 3.24,
                fechaLanzamiento = DateTime.Now,
                fechaRegistro = DateTime.Now,
                imagen = "El quinto teletubie"
            };

            var mockValidation = new Mock<ICancionValidation>();
            mockValidation.Setup(o => o.Validate(cancion, null));
            mockValidation.Setup(o => o.IsValid()).Returns(true);

            var mockService = new Mock<ICancionService>();
            mockService.Setup(o => o.guardarCancion(cancion));

            var controller = new CancionController(mockService.Object, mockValidation.Object);
            var result = controller.agregar(cancion) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }

        [Test]
        public void probarAgregarGuardarCancionSys()
        {
            var cancion = new Cancion()
            {
                idCancion = 2,
                nombre = "El quinto teletubie",
                artista = "Chabelos",
                album = "Teletubies",
                genero = "Rock",
                duracionCancion = 3.24,
                fechaLanzamiento = DateTime.Now,
                fechaRegistro = DateTime.Now,
                imagen = "El quinto teletubie"
            };

            var mockValidation = new Mock<ICancionValidation>();
            mockValidation.Setup(o => o.Validate(cancion, null));
            mockValidation.Setup(o => o.IsValid()).Returns(true);

            var mockService = new Mock<ICancionService>();
            mockService.Setup(o => o.guardarCancion(cancion));

            var controller = new CancionController(mockService.Object, mockValidation.Object);
            var result = controller.agregarSys(cancion) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }
    }
}
