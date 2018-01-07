using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Microsoft.Office.Interop.Excel;

namespace PracticasBancolombia.FunctionalsTest.PageForObject
{
    public class InformacionClientePage
    {
        private IWebDriver driver;

        public InformacionClientePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void SimularCredito()
        {
            IWebElement botonSimular = driver.FindElement(By.ClassName("btn-primary"));
            botonSimular.Click();
        }

        public void SetData(String tipoDeSimulacion,string fechaNacimiento,  string tasa, string tipoproducto, string PlazoInversion, string ValorPrestamo)
        {

            SelectElement select = new SelectElement(driver.FindElement(By.Name("comboTipoSimulacion")));
            select.SelectByText(tipoDeSimulacion);

            IWebElement fechaNacimientoElement = driver.FindElement(By.Name("dateFechaNacimiento"));
            fechaNacimientoElement.SendKeys(fechaNacimiento);

            SelectElement selectTasa = new SelectElement(driver.FindElement(By.Name("comboTipoTasa")));
            selectTasa.SelectByText(tasa);

            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollBy(0,250)", "");

            System.Threading.Thread.Sleep(5000);
            
            jse.ExecuteScript("window.scrollBy(0,250)", "");

            SelectElement selectProduct = new SelectElement(driver.FindElement(By.Name("comboTipoProducto")));
            selectProduct.SelectByValue("1");

            IWebElement plazoinversion = driver.FindElement(By.Name("textPlazoInversion"));
            plazoinversion.SendKeys(PlazoInversion);

            IWebElement Valorprestamo = driver.FindElement(By.Name("textValorPrestamo"));
            Valorprestamo.SendKeys(ValorPrestamo);

         }

        public String ObtenerResultados()
        {
            IWebElement Capturarcuota = driver.FindElement(By.XPath("//tr[@ng-show='ctrl.visualizarSimulaCuota']")).FindElement(By.ClassName("monto"));
            return Capturarcuota.Text;
            
        }

        public void  DataExcel()
        {
          

        }


    }
}