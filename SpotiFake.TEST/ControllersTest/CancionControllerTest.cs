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
            mock.Verify(o => o.obtenerListaCanciones(), Times.AtLeastOnce);
        }

        [Test]
        public void probarIndexSysObtenerListaCanciones()
        {
            var mock = new Mock<ICancionService>();
            mock.Setup(o => o.obtenerListaCanciones());

            var controller = new CancionController(mock.Object, null);
            var result = controller.IndexSys() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            mock.Verify(o => o.obtenerListaCanciones(), Times.AtLeastOnce);
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

            var modelState = new ModelStateDictionary();

            var mockValidation = new Mock<ICancionValidation>();
            mockValidation.Setup(o => o.Validate(cancion, modelState));
            mockValidation.Setup(o => o.IsValid()).Returns(true);

            var mockService = new Mock<ICancionService>();
            mockService.Setup(o => o.guardarCancion(cancion));

            var controller = new CancionController(mockService.Object, mockValidation.Object);
            var result = controller.agregar(cancion) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mockValidation.Verify(o => o.Validate(cancion, modelState), Times.AtLeastOnce);
            mockValidation.Verify(o => o.IsValid(), Times.AtLeastOnce);
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

            var modelState = new ModelStateDictionary();

            var mockValidation = new Mock<ICancionValidation>();
            mockValidation.Setup(o => o.Validate(cancion, modelState));
            mockValidation.Setup(o => o.IsValid()).Returns(true);

            var mockService = new Mock<ICancionService>();
            mockService.Setup(o => o.guardarCancion(cancion));

            var controller = new CancionController(mockService.Object, mockValidation.Object);
            var result = controller.agregarSys(cancion) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mockValidation.Verify(o => o.Validate(cancion, modelState), Times.AtLeastOnce);
            mockValidation.Verify(o => o.IsValid(), Times.AtLeastOnce);
        }

        [Test]
        public void pruebaModificarCancion()
        {
            var idCancion = 2;

            var mockService = new Mock<ICancionService>();
            mockService.Setup(o => o.obtenerDatosCancionAModificar(idCancion));

            var controller = new CancionController(mockService.Object, null);
            var result = controller.modificar(idCancion) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            mockService.Verify(o => o.obtenerDatosCancionAModificar(idCancion), Times.AtLeastOnce);
        }

        [Test]
        public void pruebaModyficarCancionSys()
        {
            var idCancion = 2;

            var mockService = new Mock<ICancionService>();
            mockService.Setup(o => o.obtenerDatosCancionAModificar(idCancion));

            var controller = new CancionController(mockService.Object, null);
            var result = controller.modificarSys(idCancion) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            mockService.Verify(o => o.obtenerDatosCancionAModificar(idCancion), Times.AtLeastOnce);
        }

        [Test]
        public void probarActualizarCancion()
        {
            var cancion = new Cancion()
            {
                idCancion = 2,
                nombre = "Numb",
                artista = "Linkin Park",
                album = "Numb",
                genero = "Rock",
                duracionCancion = 3.24,
                fechaLanzamiento = DateTime.Now,
                fechaRegistro = DateTime.Now,
                imagen = "Numb"
            };

            var mock = new Mock<ICancionService>();
            mock.Setup(o => o.actualizarCancion(cancion));

            var controller = new CancionController(mock.Object, null);
            var result = controller.actualizar(cancion) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mock.Verify(o => o.actualizarCancion(cancion), Times.AtLeastOnce);
        }

        [Test]
        public void probarActualizarCancionSys()
        {
            var cancion = new Cancion()
            {
                idCancion = 2,
                nombre = "Numb",
                artista = "Linkin Park",
                album = "Numb",
                genero = "Rock",
                duracionCancion = 3.24,
                fechaLanzamiento = DateTime.Now,
                fechaRegistro = DateTime.Now,
                imagen = "Numb"
            };

            var mock = new Mock<ICancionService>();
            mock.Setup(o => o.actualizarCancion(cancion));

            var controller = new CancionController(mock.Object, null);
            var result = controller.actualizarSys(cancion) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mock.Verify(o => o.actualizarCancion(cancion), Times.AtLeastOnce);
        }

        [Test]
        public void eliminarCancion()
        {
            int idCancion = 2;

            var mock = new Mock<ICancionService>();
            mock.Setup(o => o.eliminarCancion(idCancion));

            var controller = new CancionController(mock.Object, null);
            var result = controller.eliminar(idCancion) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mock.Verify(o => o.eliminarCancion(idCancion), Times.AtLeastOnce);
        }

        [Test]
        public void eliminarCancionSys()
        {
            int idCancion = 2;

            var mock = new Mock<ICancionService>();
            mock.Setup(o => o.eliminarCancion(idCancion));

            var controller = new CancionController(mock.Object, null);
            var result = controller.eliminarSys(idCancion) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mock.Verify(o => o.eliminarCancion(idCancion), Times.AtLeastOnce);
        }

        [Test]
        public void probarLogOff()
        {
            var mock = new Mock<ICancionService>();
            mock.Setup(o => o.logOff());

            var controller = new CancionController(mock.Object, null);
            var result = controller.logOff() as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mock.Verify(o => o.logOff(), Times.AtLeastOnce);
        }

        //Pruebas que deberian fallar
        [Test]
        public void probarAgregarGuardarCancionNoPasa()
        {
            var cancion = new Cancion();
            var modelState = new ModelStateDictionary();

            var mockValidation = new Mock<ICancionValidation>();
            mockValidation.Setup(o => o.Validate(cancion, null));
            mockValidation.Setup(o => o.IsValid()).Returns(false);

            var mockService = new Mock<ICancionService>();
            mockService.Setup(o => o.guardarCancion(cancion));

            var controller = new CancionController(mockService.Object, mockValidation.Object);
            var result = controller.agregar(cancion) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mockValidation.Verify(o => o.Validate(cancion, modelState), Times.AtLeastOnce);
            mockValidation.Verify(o => o.IsValid(), Times.AtLeastOnce);
        }

        [Test]
        public void probarAgregarGuardarCancionSysNoPasa()
        {
            var cancion = new Cancion();
            var modelState = new ModelStateDictionary(); 

            var mockValidation = new Mock<ICancionValidation>();
            mockValidation.Setup(o => o.Validate(cancion, null));
            mockValidation.Setup(o => o.IsValid()).Returns(false);

            var mockService = new Mock<ICancionService>();
            mockService.Setup(o => o.guardarCancion(cancion));

            var controller = new CancionController(mockService.Object, mockValidation.Object);
            var result = controller.agregarSys(cancion) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mockValidation.Verify(o => o.Validate(cancion, modelState), Times.AtLeastOnce);
            mockValidation.Verify(o => o.IsValid(), Times.AtLeastOnce);
        }

    }
}
