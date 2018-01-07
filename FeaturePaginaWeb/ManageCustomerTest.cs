using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PracticasBancolombia.FunctionalsTest.PageForObject;

namespace PracticasBancolombia.FunctionalsTest
{
    [TestClass]
    public class ManageCustomerTest
    {
        [TestMethod]
        public void CuandoCreoUnNuevoCliente_VerificoQueSiEstaListado()
        {
            //Arrage
            IWebDriver driver = DriverFactory.GetDriver(TipoDriver.Chrome);
            PrincipalPage principalPage = new PrincipalPage(driver);
            ManageCustomerPage manageCustomerPage = principalPage.IngresarManageCustomersPage();
            //InformacionClientePage informacionClientePage = manageCustomerPage.NavegarAOpcionCrearCliente();
            //informacionClientePage.Identificacion = "111";
            //informacionClientePage.RazonSocial = "a";
            //informacionClientePage.Ciudad = "b";
            //informacionClientePage.TipoCliente = "c";
            //informacionClientePage.NivelRiesgo = "d";

            //Act
            //informacionClientePage.CrearNuevoCliente();
            bool resultadoVerificacion = manageCustomerPage.VerificarExistenciaRegistroCliente("111");

            principalPage.Terminar();

            //Assert
            Assert.IsTrue(resultadoVerificacion, "El cliente no quedo creado enla lista de clientes");


        }
        [TestMethod]
        public void CuandoCreoUnNuevoClienteYIdentificacionVacia_EsperoMensajeError()
        {
            //Arrage
            IWebDriver driver = DriverFactory.GetDriver(TipoDriver.Chrome);
            PrincipalPage principalPage = new PrincipalPage(driver);
            ManageCustomerPage manageCustomerPage = principalPage.IngresarManageCustomersPage();
            InformacionClientePage informacionClientePage = manageCustomerPage.NavegarAOpcionCrearCliente();
            //informacionClientePage.Identificacion = "";
            //informacionClientePage.RazonSocial = "a";
            //informacionClientePage.Ciudad = "b";
            //informacionClientePage.TipoCliente = "c";
            //informacionClientePage.NivelRiesgo = "d";

            //Act
            //informacionClientePage.CrearNuevoCliente();
            //string mensajeerrorObtenido = informacionClientePage.MensajeErrorIdentificacion;
           

            principalPage.Terminar();

            //Assert
            //Assert.AreEqual("The Identificacion field is required.", mensajeerrorObtenido,"Falló la validación" );


        }
    }
}
