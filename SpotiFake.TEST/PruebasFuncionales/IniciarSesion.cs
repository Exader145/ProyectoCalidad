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
    public class IniciarSesion
    {
        [Test]
        public void iniciarSesionUsuario()
        {
            var chromeDriver = new ChromeDriver();
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
        public void iniciarSesionAdministrador()
        {
            var chromeDriver = new ChromeDriver();
            chromeDriver.Url = "http://localhost:57748/";

            chromeDriver.FindElementById("user").SendKeys("juan@hotmail.com");
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
        public void iniciarSesionSys()
        {
            var chromeDriver = new ChromeDriver();
            chromeDriver.Url = "http://localhost:57748/";

            chromeDriver.FindElementById("user").SendKeys("pedro@hotmail.com");
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
    }
}
