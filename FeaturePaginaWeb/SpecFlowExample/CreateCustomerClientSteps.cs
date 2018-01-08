using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PracticasBancolombia.FunctionalsTest.PageForObject;
using System;
using TechTalk.SpecFlow;

namespace PracticasBancolombia.FunctionalsTest.SpecFlowExample
{
    [Binding]
    public class CreateCustomerClientSteps
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
            //informacionClientePage.Identificacion = "Simula tu Cuota";
                   
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
            informacionClientePage.sumavalorcuota();
        }

    }
}
