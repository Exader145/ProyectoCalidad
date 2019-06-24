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
    public class FuncionesUsuarioTest
    {
        [Test]
        public void iniciarSesionUsuario()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Url = "http://localhost:57748/";

            chromeDriver.FindElementById("user").SendKeys("fernando@hotmail.com");
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
        public void reproducirYMostrarHistorialCancioneReproducidas()
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

        }







        public void iniciarSesionComoUsuario(ChromeDriver chromeDriver)
        {
            chromeDriver.FindElementById("user").SendKeys("fernando@hotmail.com");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("pass").SendKeys("1234");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            chromeDriver.FindElementById("btnIniciarSession").Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
    }
}
