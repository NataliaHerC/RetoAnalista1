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
        ConvertPage convertpage = null;

       
        InformacionClientePage informacionClientePage = null;

        [Given(@"Ingreso a la pagina principal de Bancolombia")]
        public void GivenIngresoALaPaginaPrincipalDeBancolombia()
        {
            driver = DriverFactory.GetDriver(TipoDriver.Chrome);
            principalPage = new PrincipalPage(driver);
            convertpage = principalPage.IngresoSimuladorCreditoConsumo();

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
            

            //ScenarioContext.Current.Pending();
        }



    }
}
