using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PracticasBancolombia.FunctionalsTest.PageForObject;

namespace PracticasBancolombia.FunctionalsTest
{
    [TestClass]
    public class ConvertPageTest
    {
        IWebDriver driver = null;
        IWebElement numeroAConvertirElemento = null;
        IWebElement botonConvertirElemento = null;
        IWebElement resultadoConversionElemento = null;

        #region "Metodos de navegacion de ConvertPage"
        private void IngresoPaginaPrincipal()
        {
            driver = new ChromeDriver();
            driver.Url = "http://ceibapruebasbanco.azurewebsites.net/";
            driver.Navigate();
        }
        private void IngresarOpcionMenu(string opcionMenu)
        {
            IWebElement myLink = driver.FindElement(By.LinkText(opcionMenu));
            myLink.Click();
        }
        private void IngresarPaginaConversion()
        {
            IngresarOpcionMenu("Functional Test Sample");
        }

        private void IngresarValorAConvertir(string valor)
        {
            numeroAConvertirElemento = driver.FindElement(By.Id("Number"));
            numeroAConvertirElemento.Clear();
            numeroAConvertirElemento.SendKeys(valor);
        }
        private void ConvertirNumero()
        {
            botonConvertirElemento = driver.FindElement(By.Id("btnConvertir"));
            botonConvertirElemento.Click();
        }

        private string ObtenerResultadoConversion()
        {
            resultadoConversionElemento = driver.FindElement(By.Id("Result01"));
            return resultadoConversionElemento.Text;
        }

        private void Terminar()
        {
            driver.Quit();
        }
        #endregion

        [TestMethod]
        [TestCategory("PruebasFuncionales")]
        public void CuandoQuieroConvertirUnNumeroPositivo123()
        {
            //Arrange
            string resultadoEsperado = "Uno-Dos-Tres-";
            string resultadoObtenido = String.Empty;

            //Act
            IngresoPaginaPrincipal();

            IngresarPaginaConversion();

            IngresarValorAConvertir("123");

            ConvertirNumero();

            resultadoObtenido = ObtenerResultadoConversion();

            Terminar();

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "La conversion no es la esperada: Se esperaba texto Uno-Dos-Tres-");
        }

        [TestMethod]
        [TestCategory("PruebasFuncionales")]
        public void CuandoQuieroConvertirUnNumeroYEnvioLetrasABC()
        {
            //Arrange
            string resultadoEsperado = "Error: No Es Numero Valido";
            string resultadoObtenido = String.Empty;

            //Act
            IngresoPaginaPrincipal();

            IngresarPaginaConversion();

            IngresarValorAConvertir("ABC");

            ConvertirNumero();

            resultadoObtenido = ObtenerResultadoConversion();

            Terminar();

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "La conversion no es la esperada: Se esperaba texto Error: No Es Numero Valido");
        }

        [TestMethod]
        [TestCategory("PruebasFuncionales")]
        public void CuandoQuieroConvertirUnNumeroYEnvioVacio()
        {
            //Arrange
            string resultadoEsperado = "Error: No Es Numero Valido";
            string resultadoObtenido = String.Empty;

            //Act
            IngresoPaginaPrincipal();

            IngresarPaginaConversion();

            IngresarValorAConvertir("");

            ConvertirNumero();

            resultadoObtenido = ObtenerResultadoConversion();

            Terminar();

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "La conversion no es la esperada: Se esperaba texto Error: No Es Numero Valido");
        }

        [TestMethod]
        [TestCategory("PruebasFuncionales")]
        public void CuandoQuieroConvertirUnNumeroYEnvioNegativos()
        {
            //Arrange
            string resultadoEsperado = "Error: No Es Numero Valido";
            string resultadoObtenido = String.Empty;

            //Act
            IngresoPaginaPrincipal();

            IngresarPaginaConversion();

            IngresarValorAConvertir("-1");

            ConvertirNumero();

            resultadoObtenido = ObtenerResultadoConversion();

            Terminar();

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "La conversion no es la esperada: Se esperaba texto Error: No Es Numero Valido");
        }

        [TestMethod]
        [TestCategory("PruebasFuncionales")]
        public void CuandoQuieroConvertirUnNumeroYEnvioNegativoYEnvioPositivo()
        {
            //Arrange
            string resultadoEsperado = "Uno-Dos-Tres-";
            string resultadoObtenido = String.Empty;

            //Act
            IngresoPaginaPrincipal();

            IngresarPaginaConversion();

            IngresarValorAConvertir("-123");

            ConvertirNumero();
            
            IngresarValorAConvertir("123");

            ConvertirNumero();

            resultadoObtenido = ObtenerResultadoConversion();

            Terminar();

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "La conversion no es la esperada: Se esperaba texto Uno-Dos-Tres-");
        }

        [TestMethod]
        [TestCategory("PruebasFuncionales")]
        public void CuandoUtilizoObjetosdePagina()
        {
            //Arrange
            IWebDriver driver = DriverFactory.GetDriver(TipoDriver.Chrome);

            PrincipalPage principalpage = new PrincipalPage(driver);

            ConvertPage convertPage = principalpage.IngresoSimuladorCreditoConsumo();

            convertPage.Numero = "123";

            //Act
            convertPage.ConvertirNumero();

            string resultado = convertPage.ResultadoConversion;

            principalpage.Terminar();

            //Assert
            Assert.AreEqual("Uno-Dos-Tres-", resultado);

        }
    }
}
