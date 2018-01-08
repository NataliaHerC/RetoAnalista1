using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PracticasBancolombia.FunctionalsTest.PageForObject;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace PracticasBancolombia.FunctionalsTest.SpecFlowExample
{
    [Binding]
    public class CrearSimulacionClienteSteps
    {
        IWebDriver driver = null;
        PrincipalPage principalPage = null;
        InformacionClientePage informacionClientePage = null;

        [Given(@"Ingreso a la pagina principal de Bancolombia")]
        public void GivenIngresoALaPaginaPrincipalDeBancolombia()
        {
            driver = DriverFactory.GetDriver(TipoDriver.Chrome);
            principalPage = new PrincipalPage(driver);
            principalPage.IngresoSimuladorCreditoConsumo();

            //ScenarioContext.Current.Pending();
        }

        [When(@"Lleno los datos")]
        public void WhenLlenoLosDatos()
        {
            
                   
            if (informacionClientePage == null) {
                informacionClientePage = new InformacionClientePage(driver);
            }

            informacionClientePage.SetData("Simula tu Cuota", "1999-01-01", "Tasa Fija", "Crédito con Pignoración de Pensiones Voluntarias", "36", "20000000" );
            informacionClientePage.SimularCredito();
           
            //ScenarioContext.Current.Pending();
                   
        }

        [Then(@"verifico Resultadosimulacion")]
        public void ThenVerificoResultadosimulacion()
        {
            String resultado = informacionClientePage.ObtenerResultados();
            Assert.AreEqual("$671,223.35", resultado);
            Thread.Sleep(4000);
            principalPage.Terminar();
        }
        // Simulador de Solucion Inmobiliaria

        [Given(@"Ingreso a la pagina principal de Bancolombia y a la opción de simulador")]
        public void GivenIngresoALaPaginaPrincipalDeBancolombiaYALaOpcionDeSimulador()
        {

            driver = DriverFactory.GetDriver(TipoDriver.Chrome);
            principalPage = new PrincipalPage(driver);
            principalPage.IngresoSimuladorCreditoSolucionInmobiliaria();
            //ScenarioContext.Current.Pending();
        }

        [When(@"Diligenciar información de solución inmobiliaria")]
        public void WhenDiligenciarInformacionDeSolucionInmobiliaria()
        {
            if (informacionClientePage == null)
            {
                informacionClientePage = new InformacionClientePage(driver);
            }
            
            informacionClientePage.SetDataSIM("Crédito Hipotecario", "Casa", "Dependiendo del valor del inmueble que quiero", "Cuota fija-Tasa fija en pesos", "20", "1987-02-11", "Antioquia", "180000000");
            informacionClientePage.SimularCredito();
            //ScenarioContext.Current.Pending();
        }

        [Then(@"verifico Resultado Simulacion")]
        public void ThenVerificoResultadoSimulacion()
        {
            String cuota = informacionClientePage.ObtenerResultadosSIM();
            String segurodevida = informacionClientePage.ObtenerResultadosSIMSeguro();
            String seguroincendio = informacionClientePage.ObtenerResultadosSIMSeguroIincendio();
            Assert.AreEqual("$1,195,303.97", cuota);
            Assert.AreEqual("$15,645.00", segurodevida);
            Assert.AreEqual("$30,130.80", seguroincendio);
            Thread.Sleep(5000);
            principalPage.Terminar();
        }

        // Escenario de guardar informacion en excel de un credito de solucion inmobiliaria
        [Then(@"Se guarda la informacion de la cuota en excel")]
        public void ThenSeGuardaLaInformacionDeLaCuotaEnExcel()
        {

            double totalCuota = informacionClientePage.Sumavalorcuota();
            Assert.AreEqual(1241079.77, totalCuota);
            Thread.Sleep(5000);
            principalPage.Terminar();


            //ScenarioContext.Current.Pending();
        }
        // Escenario de guardar informacion en excel de un credito de consumo

        [Then(@"se guarda la informacion de la cuota del credito de consumo en excel")]
        public void ThenSeGuardaLaInformacionDeLaCuotaDelCreditoDeConsumoEnExcel()
        {
            informacionClientePage.ObtenerResultadosConsumo();
            Thread.Sleep(5000);
            principalPage.Terminar();


            //ScenarioContext.Current.Pending();
        }
             

    }
}
