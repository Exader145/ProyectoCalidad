using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Cucumber
{
    [Binding]
    public class EscenariosSteps
    {
        ChromeDriver driver = new ChromeDriver(@"c:");
        [Given(@"el correo del usario (.*)")]
        public void GivenElCorreoDelUsario(string correoUser)
        {
            driver.Url = "http://localhost:57748/";
            Thread.Sleep(TimeSpan.FromSeconds(1));
            var inputCorreo = driver.FindElementById("user");
            inputCorreo.Clear();
            inputCorreo.SendKeys(correoUser);
        }
        
        [Given(@"la contraseña (.*)")]
        public void GivenLaContrasena(string passUser)
        {
            var inputPass = driver.FindElementById("pass");
            inputPass.Clear();
            inputPass.SendKeys(passUser);
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
        
        [When(@"el usaurio quiera iniciar session")]
        public void WhenElUsaurioQuieraIniciarSession()
        {
            var btnIniciarSession = driver.FindElementById("btnIniciarSession");
            btnIniciarSession.Click();
        }
        
        [Then(@"la pagina web redirecionara a vista del usuario con nombre: (.*)")]
        public void ThenLaInterfazDeLaWebCambiaraALaPaginaInicioDelUsuario(string userName)
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            var saludoUser = driver.FindElementById("saludoAlUsuario");
            Assert.AreEqual(saludoUser.Text, "Bienvenido "+userName);
            driver.Close();
        }
    }
}
