using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpotiFake.TEST.PruebasFuncionales
{
    [TestFixture]
    public class BFuncionesAdministradorTest
    {
        [Test]
        public void AIniciarSesionAdministrador()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            chromeDriver.FindElementById("user").SendKeys("administrador2@hotmail.com");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("pass").SendKeys("1234");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnIniciarSession").Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            var paginaIndex = chromeDriver.FindElementById("saludoAlUsuario");
            Assert.IsNotNull(paginaIndex);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            chromeDriver.Close();
        }

        [Test]
        public void BRegistrarCancion()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            iniciarSesionComoAdministrador(chromeDriver);

            chromeDriver.FindElementById("btnInicioUsuario").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnRegistrarCancion").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtNombre").SendKeys("Hold the line");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtArtista").SendKeys("Toto");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtAlbum").SendKeys("Hold the line");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtGenero").SendKeys("Rock");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtDuracion").SendKeys("3.12");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtFechaLanzamiento").SendKeys("12/05/1990");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtImagen").SendKeys("Hold the line.jpg");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnAgregarCancion").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaIndexAdministrador = chromeDriver.FindElementById("btnRegistrarCancion");
            Assert.IsNotNull(paginaIndexAdministrador);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            chromeDriver.Close();
        }

        [Test]
        public void CEditarCancion()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            iniciarSesionComoAdministrador(chromeDriver);

            chromeDriver.FindElementById("btnInicioUsuario").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnEditar").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var nombre = chromeDriver.FindElementById("txtNombre");
            nombre.Clear();
            nombre.SendKeys("Roxanne");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var artista = chromeDriver.FindElementById("txtArtista");
            artista.Clear();
            artista.SendKeys("The Police");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var album = chromeDriver.FindElementById("txtAlbum");
            album.Clear();
            album.SendKeys("The Police");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var genero = chromeDriver.FindElementById("txtGenero");
            genero.Clear();
            genero.SendKeys("Rock");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var duracion = chromeDriver.FindElementById("txtDuracion");
            duracion.Clear();
            duracion.SendKeys("3.12");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var fechaLanzamiento = chromeDriver.FindElementById("txtFechaLanzamiento");
            fechaLanzamiento.Clear();
            fechaLanzamiento.SendKeys("12/05/1986");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var imagen = chromeDriver.FindElementById("txtImagen");
            imagen.Clear();
            imagen.SendKeys("Roxanne.jpg");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnModificar").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaIndexAdministrador = chromeDriver.FindElementById("btnRegistrarCancion");
            Assert.IsNotNull(paginaIndexAdministrador);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            chromeDriver.Close();
        }

        [Test]
        public void DEliminarCancion()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            iniciarSesionComoAdministrador(chromeDriver);

            chromeDriver.FindElementById("btnInicioUsuario").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnEliminar").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaIndexAdministrador = chromeDriver.FindElementById("btnRegistrarCancion");
            Assert.IsNotNull(paginaIndexAdministrador);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            chromeDriver.Close();
        }


        //PRUEBAS QUE DEBERIAN FALLAR


        [Test]
        public void AIniciarSesionAdministradorIncorrecto()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            chromeDriver.FindElementById("user").SendKeys("administradorjuan@hotmail.com");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("pass").SendKeys("123456");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnIniciarSession").Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            var paginaIndex = chromeDriver.FindElementById("saludoAlUsuario");
            Assert.IsNotNull(paginaIndex);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            chromeDriver.Close();
        }

        [Test]
        public void CEditarCancionSinDatos()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            iniciarSesionComoAdministrador(chromeDriver);

            chromeDriver.FindElementById("btnInicioUsuario").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnEditar").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var nombre = chromeDriver.FindElementById("txtNombre");
            nombre.Clear();
            nombre.SendKeys("");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var artista = chromeDriver.FindElementById("txtArtista");
            artista.Clear();
            artista.SendKeys("");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var album = chromeDriver.FindElementById("txtAlbum");
            album.Clear();
            album.SendKeys("");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var genero = chromeDriver.FindElementById("txtGenero");
            genero.Clear();
            genero.SendKeys("");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var duracion = chromeDriver.FindElementById("txtDuracion");
            duracion.Clear();
            duracion.SendKeys("");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var fechaLanzamiento = chromeDriver.FindElementById("txtFechaLanzamiento");
            fechaLanzamiento.Clear();
            fechaLanzamiento.SendKeys("");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var imagen = chromeDriver.FindElementById("txtImagen");
            imagen.Clear();
            imagen.SendKeys("");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnModificar").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaIndexAdministrador = chromeDriver.FindElementById("btnRegistrarCancion");
            Assert.IsNotNull(paginaIndexAdministrador);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            chromeDriver.Close();
        }

        public void iniciarSesionComoAdministrador(ChromeDriver chromeDriver)
        {
            chromeDriver.FindElementById("user").SendKeys("administrador2@hotmail.com");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("pass").SendKeys("1234");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnIniciarSession").Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
    }
}
