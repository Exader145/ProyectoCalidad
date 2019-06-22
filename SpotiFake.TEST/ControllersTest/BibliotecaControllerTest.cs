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
    public class BibliotecaControllerTest
    {

        //Pruebas que deberían pasar

        [Test]
        public void probarIndexObtenerListaReproduccionUsuario()
        {
            var idUsuario = 2;

            var mock = new Mock<IBibliotecaService>();
            mock.Setup(o => o.obtenerListaReproduccionUsuario(idUsuario));

            var controller = new BibliotecaController(mock.Object);
            var result = controller.Index(idUsuario) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            mock.Verify(o => o.obtenerListaReproduccionUsuario(idUsuario), Times.AtLeastOnce);
        }

        [Test]
        public void probarAgregarListaReproduccion()
        {
            var idUsuario = 2;

            var listaReproduccion = new ListaReproduccion()
            {
                nombre = "Rock",
                idUsuario = 2,
                usuario = new Usuario()
            };

            var mock = new Mock<IBibliotecaService>();
            mock.Setup(o => o.verificarListaReproduccionRepetida(listaReproduccion, idUsuario));
            mock.Setup(o => o.agregarIdUsuarioAListaReproduccion(listaReproduccion, idUsuario));
            mock.Setup(o => o.obtenerListaReproduccionPorUsuario(idUsuario));

            var controller = new BibliotecaController(mock.Object);
            var result = controller.AgregarListaDeReproduccion(listaReproduccion, idUsuario) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            mock.Verify(o => o.verificarListaReproduccionRepetida(listaReproduccion, idUsuario), Times.AtLeastOnce);
            mock.Verify(o => o.agregarIdUsuarioAListaReproduccion(listaReproduccion, idUsuario), Times.AtLeastOnce);
            mock.Verify(o => o.obtenerListaReproduccionPorUsuario(idUsuario), Times.AtLeastOnce);
        }

        [Test]
        public void pruebaSeleccionarPlaylistObtenerListaReproduccionPorUsuario()
        {
            var idUsuario = 2;
            var idCancion = 5;

            var mock = new Mock<IBibliotecaService>();
            mock.Setup(o => o.obtenerListaReproduccionPorUsuarioIQueriable(idUsuario));

            var controller = new BibliotecaController(mock.Object);
            var result = controller.SeleccionarPlaylist(idCancion, idUsuario) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            mock.Verify(o => o.obtenerListaReproduccionPorUsuarioIQueriable(idUsuario), Times.AtLeastOnce);
        }

        [Test]
        public void pruebaEliminarListaReproduccion() 
        {
            var idListaReproduccion = 2;
            var idUsuario = 1;

            var mock = new Mock<IBibliotecaService>();
            mock.Setup(o => o.eliminarListaReproduccionYMostrarNuevaLista(idListaReproduccion, idUsuario));

            var controller = new BibliotecaController(mock.Object);
            var result = controller.EliminarListRe(idListaReproduccion, idUsuario) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            mock.Verify(o => o.eliminarListaReproduccionYMostrarNuevaLista(idListaReproduccion, idUsuario), Times.AtLeastOnce);
        }

        [Test]
        public void probarGuardarCancionEnListaReproduccion()
        {
            var idUsuario = 1;
            var idListaReproduccion = 2;

            var mock = new Mock<IBibliotecaService>();
            mock.Setup(o => o.agregarCancionAListaReproduccion(idUsuario, idListaReproduccion));

            var controller = new BibliotecaController(mock.Object);
            var result = controller.AgregarCancion(idUsuario, idListaReproduccion) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mock.Verify(o => o.agregarCancionAListaReproduccion(idUsuario, idListaReproduccion), Times.AtLeastOnce);
        }

        [Test]
        public void probarDetalleObtenerCancionesDeListaReproduccion()
        {
            var idListaReproduccion = 2;

            var mock = new Mock<IBibliotecaService>();
            mock.Setup(o => o.obtenerCancionesDeUnaListaReproduccion(idListaReproduccion));

            var controller = new BibliotecaController(mock.Object);
            var result = controller.Detalle(idListaReproduccion) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            mock.Verify(o => o.obtenerCancionesDeUnaListaReproduccion(idListaReproduccion), Times.AtLeastOnce);
        }


        //Pruebas que no deberían pasar

        [Test]
        public void probarIndexObtenerListaReproduccionUsuarioNoPasa()
        {
            var idUsuario = 2;

            var mock = new Mock<IBibliotecaService>();
            mock.Setup(o => o.obtenerListaReproduccionUsuario(idUsuario));

            var controller = new BibliotecaController(mock.Object);
            var result = controller.Index(idUsuario) as ViewResult;

            Assert.IsNotInstanceOf<ViewResult>(result);
            mock.Verify(o => o.obtenerListaReproduccionUsuario(idUsuario), Times.Never);
        }

        [Test]
        public void probarAgregarListaReproduccionNoPasa()
        {
            var idUsuario = 2;

            var listaReproduccion = new ListaReproduccion()
            {
                nombre = "Rock",
                idUsuario = 2,
                usuario = new Usuario()
            };

            var mock = new Mock<IBibliotecaService>();
            mock.Setup(o => o.verificarListaReproduccionRepetida(listaReproduccion, idUsuario));
            mock.Setup(o => o.agregarIdUsuarioAListaReproduccion(listaReproduccion, idUsuario));
            mock.Setup(o => o.obtenerListaReproduccionPorUsuario(idUsuario));

            var controller = new BibliotecaController(mock.Object);
            var result = controller.AgregarListaDeReproduccion(listaReproduccion, idUsuario) as ViewResult;

            Assert.IsNotInstanceOf<ViewResult>(result);
            mock.Verify(o => o.verificarListaReproduccionRepetida(listaReproduccion, idUsuario), Times.Never);
            mock.Verify(o => o.agregarIdUsuarioAListaReproduccion(listaReproduccion, idUsuario), Times.Never);
            mock.Verify(o => o.obtenerListaReproduccionPorUsuario(idUsuario), Times.Never);
        }

        [Test]
        public void pruebaSeleccionarPlaylistObtenerListaReproduccionPorUsuarioNoPasa()
        {
            var idUsuario = 2;
            var idCancion = 5;

            var mock = new Mock<IBibliotecaService>();
            mock.Setup(o => o.obtenerListaReproduccionPorUsuario(idUsuario));

            var controller = new BibliotecaController(mock.Object);
            var result = controller.SeleccionarPlaylist(idCancion, idUsuario) as ViewResult;

            Assert.IsNotInstanceOf<ViewResult>(result);
            mock.Verify(o => o.obtenerListaReproduccionPorUsuario(idUsuario), Times.Never);
        }

        [Test]
        public void pruebaEliminarListaReproduccionNoPasa()
        {
            var idListaReproduccion = 2;
            var idUsuario = 1;

            var mock = new Mock<IBibliotecaService>();
            mock.Setup(o => o.eliminarListaReproduccionYMostrarNuevaLista(idListaReproduccion, idUsuario));

            var controller = new BibliotecaController(mock.Object);
            var result = controller.EliminarListRe(idListaReproduccion, idUsuario) as ViewResult;

            Assert.IsNotInstanceOf<ViewResult>(result);
            mock.Verify(o => o.eliminarListaReproduccionYMostrarNuevaLista(idListaReproduccion, idUsuario), Times.Never);
        }

        [Test]
        public void probarGuardarCancionEnListaReproduccionNoPasa()
        {
            var idUsuario = 1;
            var idListaReproduccion = 2;

            var mock = new Mock<IBibliotecaService>();
            mock.Setup(o => o.agregarCancionAListaReproduccion(idUsuario, idListaReproduccion));

            var controller = new BibliotecaController(mock.Object);
            var result = controller.AgregarCancion(idUsuario, idListaReproduccion) as RedirectToRouteResult;

            Assert.IsNotInstanceOf<RedirectToRouteResult>(result);
            mock.Verify(o => o.agregarCancionAListaReproduccion(idUsuario, idListaReproduccion), Times.Never);
        }

        [Test]
        public void probarDetalleObtenerCancionesDeListaReproduccionNoPasa()
        {
            var idListaReproduccion = 2;

            var mock = new Mock<IBibliotecaService>();
            mock.Setup(o => o.obtenerCancionesDeUnaListaReproduccion(idListaReproduccion));

            var controller = new BibliotecaController(mock.Object);
            var result = controller.Detalle(idListaReproduccion) as ViewResult;

            Assert.IsNotInstanceOf<ViewResult>(result);
            mock.Verify(o => o.obtenerCancionesDeUnaListaReproduccion(idListaReproduccion), Times.Never);
        }

    }
}
