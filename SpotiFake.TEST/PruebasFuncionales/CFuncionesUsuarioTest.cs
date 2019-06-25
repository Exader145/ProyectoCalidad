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
    public class CFuncionesUsuarioTest
    {
        [Test]
        public void ARegistrarUsuario()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            chromeDriver.FindElementById("Registrar").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtNombre").SendKeys("Usuario 2");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtCorreo").SendKeys("usuario2@hotmail.com");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtPassword").SendKeys("1234");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnRegistrarUsuario").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaIndex = chromeDriver.FindElementById("saludoAlUsuario");
            Assert.IsNotNull(paginaIndex);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            chromeDriver.Close();
        }

        [Test]
        public void BIniciarSesionUsuario()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            chromeDriver.FindElementById("user").SendKeys("usuario2@hotmail.com");
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
        public void CReproducirYMostrarHistorialCancioneReproducidas()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            iniciarSesionComoUsuario(chromeDriver);

            chromeDriver.FindElementById("btnReproducir").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnCancionesRecientes").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaCancionesRecientes = chromeDriver.FindElementById("idPaginaCancionesEscuchadas");
            Assert.IsNotNull(paginaCancionesRecientes);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            chromeDriver.Close();
        }

        [Test]
        public void CCrearNuevoPlaylistYAgregarCancion()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            iniciarSesionComoUsuario(chromeDriver);

            chromeDriver.FindElementById("btnTuBiblioteca").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnNuevaListaReproduccion").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtNombrePlaylist").SendKeys("Playlist 1");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnGuardarNuevoPlaylist").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnInicioUsuario").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnAgregarAPlaylist").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnAgregarCancionAPlaylist").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaIndex = chromeDriver.FindElementById("saludoAlUsuario");
            Assert.IsNotNull(paginaIndex);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            chromeDriver.Close();
        }

        [Test]
        public void DMostrarPlaylistYReproducirCancionDePalylist()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            iniciarSesionComoUsuario(chromeDriver);

            chromeDriver.FindElementById("btnTuBiblioteca").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnAbrirPlaylist").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnReproducirCancion").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaIndex = chromeDriver.FindElementById("saludoAlUsuario");
            Assert.IsNotNull(paginaIndex);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            chromeDriver.Close();
        }

        [Test]
        public void EMostrarPlaylistYElminarCancionDePlaylist()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            iniciarSesionComoUsuario(chromeDriver);

            chromeDriver.FindElementById("btnTuBiblioteca").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnAbrirPlaylist").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnEliminarCancionDePlaylist").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaIndex = chromeDriver.FindElementById("paginaPlaylist");
            Assert.IsNotNull(paginaIndex);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            chromeDriver.Close();
        }

        [Test]
        public void FMostrarYEliminarPlaylist()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            iniciarSesionComoUsuario(chromeDriver);

            chromeDriver.FindElementById("btnTuBiblioteca").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnEliminarPlaylist").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaBiblioteca = chromeDriver.FindElementById("paginaBiblioteca");
            Assert.IsNotNull(paginaBiblioteca);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            chromeDriver.Close();
        }


        //PRUEBAS QUE NO DEBERIAN PASAR

        [Test]
        public void ARegistrarUsuarioDatosUsuarioIncorrecto()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            chromeDriver.FindElementById("Registrar").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtNombre").SendKeys("");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtCorreo").SendKeys("");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtPassword").SendKeys("");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaIndex = chromeDriver.FindElementById("saludoAlUsuario");
            Assert.IsNotNull(paginaIndex);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            chromeDriver.Close();
        }

        [Test]
        public void BIniciarSesionUsuarioIncorrecto()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            chromeDriver.FindElementById("user").SendKeys("roger_65@hotmail.com");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("pass").SendKeys("12346");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnIniciarSession").Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            chromeDriver.FindElementById("btnRegistrarUsuario").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaIndex = chromeDriver.FindElementById("saludoAlUsuario");
            Assert.IsNotNull(paginaIndex);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            chromeDriver.Close();
        }

        public void iniciarSesionComoUsuario(ChromeDriver chromeDriver)
        {
            chromeDriver.FindElementById("user").SendKeys("usuario2@hotmail.com");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("pass").SendKeys("1234");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnIniciarSession").Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
    }
}
