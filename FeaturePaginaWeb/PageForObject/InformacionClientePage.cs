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
        public void SetDataSIM(String tipoDeFinanciacion, string DestinoCredito, string Opcionsimulacion, string PlandeAmortizacion,string Plazo, string fechadeNacimiento, string Departamento, string valor)
        {

            SelectElement select = new SelectElement(driver.FindElement(By.Name("combotipoFinanciacion")));
            select.SelectByText(tipoDeFinanciacion);

            SelectElement selectDestino = new SelectElement(driver.FindElement(By.Name("comboDestinoCredito")));
            selectDestino.SelectByText(DestinoCredito);

            SelectElement selectOpcionSimulacion = new SelectElement(driver.FindElement(By.Name("comboOpcionSimular")));
            selectOpcionSimulacion.SelectByText(Opcionsimulacion);
            SelectElement selectPlandeAmortizacion = new SelectElement(driver.FindElement(By.Name("comboPlanAmortizacion")));
            selectPlandeAmortizacion.SelectByText(PlandeAmortizacion);
            IWebElement plazoinversion = driver.FindElement(By.Name("textPlazoAnios"));
            plazoinversion.SendKeys(Plazo);

            IWebElement fechaNacimientoElement1 = driver.FindElement(By.Name("dateFechaNacimiento"));
            fechaNacimientoElement1.SendKeys(fechadeNacimiento);

            SelectElement selectDepto = new SelectElement(driver.FindElement(By.Name("comboDeptoColomnbia")));
            selectDepto.SelectByText(Departamento);

            IWebElement valorElement= driver.FindElement(By.Name("textValorBien"));
            valorElement.SendKeys(valor);
        }


        public String ObtenerResultados()
        {
            IWebElement Capturarcuota = driver.FindElement(By.XPath("//tr[@ng-show='ctrl.visualizarSimulaCuota']")).FindElement(By.ClassName("monto"));
            return Capturarcuota.Text;
            
            
        }

        public void sumavalorcuota()
        {
            IWebElement Capturarcuota1 = driver.FindElement(By.XPath("//*[@id='sim-results']/div[1]/table/tbody/tr[17]/td[4]"));
            IWebElement Capturarseguro = driver.FindElement(By.XPath("//*[@id='sim-results']/div[1]/table/tbody/tr[21]/td[2]"));
            IWebElement Capturarinc = driver.FindElement(By.XPath("//*[@id='sim-results']/div[1]/table/tbody/tr[22]/td[2]"));
            int valorcuota = Int32.Parse(Capturarcuota1.Text);
            int segurovida = Int32.Parse(Capturarseguro.Text);
            int seguroincyterremoto = Int32.Parse(Capturarseguro.Text);
            int total = valorcuota + segurovida + seguroincyterremoto;
            
            GenerarArchivoExcel arcExcel = new GenerarArchivoExcel();
            arcExcel.CrearArchivoExcel("Resultado", total);

        }
        public String ObtenerResultadosSIM()
        {
            IWebElement Capturarcuota1 = driver.FindElement(By.XPath("//*[@id='sim-results']/div[1]/table/tbody/tr[17]/td[4]"));

                      return Capturarcuota1.Text;

        }

        public String ObtenerResultadosSIMSeguro()
        {
            IWebElement Capturarseguro = driver.FindElement(By.XPath("//*[@id='sim-results']/div[1]/table/tbody/tr[21]/td[2]"));

            return Capturarseguro.Text;

        }

        public String ObtenerResultadosSIMSeguroIincendio()
        {
            IWebElement Capturarinc = driver.FindElement(By.XPath("//*[@id='sim-results']/div[1]/table/tbody/tr[22]/td[2]"));

            return Capturarinc.Text;
        }


    }
}