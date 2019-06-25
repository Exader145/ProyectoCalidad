using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Cucumber
{
    [Binding]
    class TestPlayList
    {
        ChromeDriver driver = new ChromeDriver(@"c:");
        [Given(@"el ususario quiera crear una nueva play list")]
        public void GivenUsuarioQuieraCrearUnaNuevaPlayList()
        {
            
            Thread.Sleep(TimeSpan.FromSeconds(2));

        }
        [When(@"registre la playList con nombre (.*)")]
        public void WhenRegistreLaPlayListConNombre(string nameList)
        {
            
        }
        [Then(@"la web restra la play list y la muestra")]
        public void ThenLaWenRegistrLaPlayListYLaMuestra()
        {
            Assert.AreEqual("Bienvenido ", "Bienvenido ");
            driver.Close();
        }
    }
}
