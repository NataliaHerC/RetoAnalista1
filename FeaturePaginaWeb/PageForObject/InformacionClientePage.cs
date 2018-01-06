using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PracticasBancolombia.FunctionalsTest.PageForObject
{
    public class InformacionClientePage
    {
        private IWebDriver driver;

        public InformacionClientePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string Identificacion
        {
            get
            {
                IWebElement campoIdentificacion = driver.FindElement(By.Name("comboTipoSimulacion"));
                campoIdentificacion.Click();
                //var selectElement = new SelectElement(campoIdentificacion);
                //selectElement.SelectByValue("Simula tu Cuota");
                return campoIdentificacion.GetAttribute("value");
            }
            set
            {
                IWebElement campoIdentificacion = driver.FindElement(By.Name("comboTipoSimulacion"));
                campoIdentificacion.Click();
                //campoIdentificacion.Clear();
                campoIdentificacion.SendKeys(value);
            }
        }
        public string MensajeErrorIdentificacion
        {
            get
            {
                IWebElement Mensajeerrorelemento = driver.FindElement(By.Id("IdentificationError"));
                return Mensajeerrorelemento.Text;
            }
         }
        public string RazonSocial
        {
            get
            {
                IWebElement campoRazonSocial = driver.FindElement(By.Id("txtRazonSocial"));
                return campoRazonSocial.GetAttribute("value");
            }
            set
            {
                IWebElement campoRazonSocial = driver.FindElement(By.Id("txtRazonSocial"));
                campoRazonSocial.Clear();
                campoRazonSocial.SendKeys(value);
            }
        }
        public string Ciudad
        {
            get
            {
                IWebElement campoCiudad = driver.FindElement(By.Id("txtCiudad"));
                return campoCiudad.GetAttribute("value");
            }
            set
            {
                IWebElement campoCiudad = driver.FindElement(By.Id("txtCiudad"));
                campoCiudad.Clear();
                campoCiudad.SendKeys(value);
            }
        }
        public string TipoCliente
        {
            get
            {
                IWebElement campoTipoCliente = driver.FindElement(By.Id("txtTipoCliente"));
                return campoTipoCliente.GetAttribute("value");
            }
            set
            {
                IWebElement campoTipoCliente = driver.FindElement(By.Id("txtTipoCliente"));
                campoTipoCliente.Clear();
                campoTipoCliente.SendKeys(value);
            }
        }
        public string NivelRiesgo
        {
            get
            {
                IWebElement campoNivelRiesgo = driver.FindElement(By.Id("txtNivelRiesgo"));
                return campoNivelRiesgo.GetAttribute("value");
            }
            set
            {
                IWebElement campoNivelRiesgo = driver.FindElement(By.Id("txtNivelRiesgo"));
                campoNivelRiesgo.Clear();
                campoNivelRiesgo.SendKeys(value);
            }
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

        public void DatosExcel()
        {
            IWebElement Capturarcuota = driver.FindElement(By.ClassName("monto valor ng-binding"));

            
        }


    }
}