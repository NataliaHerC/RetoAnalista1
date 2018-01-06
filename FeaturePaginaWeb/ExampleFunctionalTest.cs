using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PracticasBancolombia.FunctionalsTest
{
    [TestClass]
    public class ExampleFunctionalTest
    {
       [TestMethod]
        public void GettingStartedTest()
        {
            IWebDriver driver = new ChromeDriver();

            //driver.Navigate().GoToUrl("http://ceibapruebasbanco.azurewebsites.net/FunctionalTesting");
            driver.Navigate().GoToUrl("http://ceibapruebasbanco.azurewebsites.net/");

            IWebElement myLink = driver.FindElement(By.LinkText("Functional Test Sample"));
            myLink.Click();

            IWebElement numeroAConvertirElemento = driver.FindElement(By.Id("Number"));
            numeroAConvertirElemento.Clear();
            numeroAConvertirElemento.SendKeys("123");

            IWebElement botonConvertirElemento = driver.FindElement(By.Id("btnConvertir"));
            botonConvertirElemento.Click();

            IWebElement resultadoConversionElemento = driver.FindElement(By.Id("Result01"));

            Assert.AreEqual("Uno-Dos-Tres-", resultadoConversionElemento.Text, "El resultado no es el esperado");
            
            driver.Quit();


        }

       // [TestMethod]
        public void ProbarBusquedaEnGoogle()
        {

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.google.com.co/");

            IWebElement barraBusqueda = driver.FindElement(By.Name("q"));

            barraBusqueda.SendKeys("ceiba software");

            barraBusqueda.SendKeys(Keys.Enter);

            driver.Quit();





        }
    }

    

}
