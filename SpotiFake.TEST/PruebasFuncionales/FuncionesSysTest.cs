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
    public class FuncionesSysTest
    {
        [Test]
        public void AIniciarSesionSys()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            chromeDriver.FindElementById("user").SendKeys("sys@hotmail.com");
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
        public void BRegistrarAdministrador()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            IniciarSesionSys(chromeDriver);

            chromeDriver.FindElementById("btnAdministradores").Click();

            chromeDriver.FindElementById("btnRegistrarAdministrador").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtNombre").SendKeys("Administrador 2");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtCorreo").SendKeys("administrador2@hotmail.com");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtContraseña").SendKeys("1234");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnAgregarUsuario").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaIndexSys = chromeDriver.FindElementById("btnRegistrarAdministrador");
            Assert.IsNotNull(paginaIndexSys);

            Thread.Sleep(TimeSpan.FromSeconds(1));
            chromeDriver.Close();
        }

        [Test]
        public void CEditarAdministrador()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            IniciarSesionSys(chromeDriver);

            chromeDriver.FindElementById("btnAdministradores").Click();

            chromeDriver.FindElementById("btnEditar").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var nombre = chromeDriver.FindElementById("txtNombre");
            nombre.Clear();
            nombre.SendKeys("José Pérez");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var correo = chromeDriver.FindElementById("txtCorreo");
            correo.Clear();
            correo.SendKeys("jose@hotmail.com");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var contraseña = chromeDriver.FindElementById("txtContraseña");
            contraseña.Clear();
            contraseña.SendKeys("123456");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnGuardarAdministrador").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaIndexSys = chromeDriver.FindElementById("btnRegistrarAdministrador");
            Assert.IsNotNull(paginaIndexSys);

            Thread.Sleep(TimeSpan.FromSeconds(1));
            chromeDriver.Close();
        }

        [Test]
        public void DMostrarListaUsuariosYELiminarUsuario()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            IniciarSesionSys(chromeDriver);

            chromeDriver.FindElementById("btnAdministradores").Click();

            chromeDriver.FindElementById("btnEliminar").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaIndexSys = chromeDriver.FindElementById("btnRegistrarAdministrador");
            Assert.IsNotNull(paginaIndexSys);

            Thread.Sleep(TimeSpan.FromSeconds(1));
            chromeDriver.Close();
        }

        [Test]
        public void ERegistrarNuevaCancion()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            IniciarSesionSys(chromeDriver);

            chromeDriver.FindElementById("btnCanciones").Click();

            chromeDriver.FindElementById("btnRegistrarCancion").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtNombre").SendKeys("Song 2");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtArtista").SendKeys("Blur");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtAlbum").SendKeys("Blur");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtGenero").SendKeys("Pop");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtDuracion").SendKeys("3,30");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtFechaLanzamiento").SendKeys("12-05-2010");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("txtImagen").SendKeys("Song 2");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnGuardar").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaIndexSys = chromeDriver.FindElementById("btnRegistrarCancion");
            Assert.IsNotNull(paginaIndexSys);

            Thread.Sleep(TimeSpan.FromSeconds(1));
            chromeDriver.Close();
        }

        [Test]
        public void FEditarCancion()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            IniciarSesionSys(chromeDriver);

            chromeDriver.FindElementById("btnCanciones").Click();

            chromeDriver.FindElementById("btnEditar").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var nombre = chromeDriver.FindElementById("txtNombre");
            nombre.Clear();
            nombre.SendKeys("Feel good inc");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var artista = chromeDriver.FindElementById("txtArtista");
            artista.Clear();
            artista.SendKeys("Gorillaz");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var album = chromeDriver.FindElementById("txtAlbum");
            album.Clear();
            album.SendKeys("Feel good inc");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var genero = chromeDriver.FindElementById("txtGenero");
            genero.Clear();
            genero.SendKeys("Alternativo");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var duracion = chromeDriver.FindElementById("txtDuracion");
            duracion.Clear();
            duracion.SendKeys("3,50");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var fechaLanzamiento = chromeDriver.FindElementById("txtFechaLanzamiento");
            fechaLanzamiento.Clear();
            fechaLanzamiento.SendKeys("12-05-2014");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var imagen = chromeDriver.FindElementById("txtImagen");
            imagen.Clear();
            imagen.SendKeys("Feel good inc.jpg");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnActualizar").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaIndexSys = chromeDriver.FindElementById("btnRegistrarCancion");
            Assert.IsNotNull(paginaIndexSys);

            Thread.Sleep(TimeSpan.FromSeconds(1));
            chromeDriver.Close();
        }

        [Test]
        public void GMostrarListaCancionesYEliminarCancion()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            IniciarSesionSys(chromeDriver);

            chromeDriver.FindElementById("btnCanciones").Click();

            chromeDriver.FindElementById("btnEliminar").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaIndexSys = chromeDriver.FindElementById("btnRegistrarCancion");
            Assert.IsNotNull(paginaIndexSys);

            Thread.Sleep(TimeSpan.FromSeconds(1));
            chromeDriver.Close();
        }


        //PRUEBAS QUE NO DEBERIAN PASAR

        [Test]
        public void AIniciarSesionSysDatosIncorrectos()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            chromeDriver.FindElementById("user").SendKeys("daniel@hotmail.com");
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
        public void BRegistrarAdministradorDatosNulos()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            IniciarSesionSys(chromeDriver);

            chromeDriver.FindElementById("btnAdministradores").Click();

            chromeDriver.FindElementById("btnRegistrarAdministrador").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnAgregarUsuario").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaIndexSys = chromeDriver.FindElementById("btnRegistrarAdministrador");
            Assert.IsNotNull(paginaIndexSys);

            Thread.Sleep(TimeSpan.FromSeconds(1));
            chromeDriver.Close();
        }

        [Test]
        public void CEditarAdministradorDatosNulos()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            IniciarSesionSys(chromeDriver);

            chromeDriver.FindElementById("btnAdministradores").Click();

            chromeDriver.FindElementById("btnEditar").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var nombre = chromeDriver.FindElementById("txtNombre");
            nombre.Clear();
            nombre.SendKeys("");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var correo = chromeDriver.FindElementById("txtCorreo");
            correo.Clear();
            correo.SendKeys("");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var contraseña = chromeDriver.FindElementById("txtContraseña");
            contraseña.Clear();
            contraseña.SendKeys("");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnGuardarAdministrador").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaIndexSys = chromeDriver.FindElementById("btnRegistrarAdministrador");
            Assert.IsNotNull(paginaIndexSys);

            Thread.Sleep(TimeSpan.FromSeconds(1));
            chromeDriver.Close();
        }

        [Test]
        public void ERegistrarNuevaCancionDatosNulos()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            IniciarSesionSys(chromeDriver);

            chromeDriver.FindElementById("btnCanciones").Click();

            chromeDriver.FindElementById("btnRegistrarCancion").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnGuardar").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaIndexSys = chromeDriver.FindElementById("btnRegistrarCancion");
            Assert.IsNotNull(paginaIndexSys);

            Thread.Sleep(TimeSpan.FromSeconds(1));
            chromeDriver.Close();
        }


        [Test]
        public void FEditarCancionDatosNulos()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            IniciarSesionSys(chromeDriver);

            chromeDriver.FindElementById("btnCanciones").Click();

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

            chromeDriver.FindElementById("btnActualizar").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var paginaIndexSys = chromeDriver.FindElementById("btnRegistrarCancion");
            Assert.IsNotNull(paginaIndexSys);

            Thread.Sleep(TimeSpan.FromSeconds(1));
            chromeDriver.Close();
        }



        public void IniciarSesionSys(ChromeDriver chromeDriver)
        {
            chromeDriver.FindElementById("user").SendKeys("sys@hotmail.com");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("pass").SendKeys("1234");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnIniciarSession").Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
    }
}
