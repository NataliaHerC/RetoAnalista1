using OpenQA.Selenium;
using System;

namespace PracticasBancolombia.FunctionalsTest.PageForObject
{
    public class ManageCustomerPage
    {
        private IWebDriver driver;

        public ManageCustomerPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public InformacionClientePage NavegarAOpcionCrearCliente()
        {
            IWebElement opcionNavegarACrearCliente = driver.FindElement(By.LinkText("Create New"));
            opcionNavegarACrearCliente.Click();
            return new InformacionClientePage(driver);
        }
        public InformacionClientePage NavegarAOpcionEditarCliente(string identificacionCliente)
        {
            IWebElement opcionNavegarAEditarCliente = driver.FindElement(By.LinkText("Edit_"+ identificacionCliente));
            opcionNavegarAEditarCliente.Click();
            return new InformacionClientePage(driver);
        }
        public InformacionClientePage NavegarAOpcionEliminarCliente(string identificacionCliente)
        {
            IWebElement opcionNavegarAEliminarCliente = driver.FindElement(By.LinkText("Eliminar_" + identificacionCliente));
            opcionNavegarAEliminarCliente.Click();
            return new InformacionClientePage(driver);
        }
        public bool  VerificarExistenciaRegistroCliente(string identificacionCliente)
        {
            bool resultadoVerificarCliente = false;
            try
            {
                IWebElement elementoCliente = driver.FindElement(By.Id(identificacionCliente));
                resultadoVerificarCliente = true;
            }
            catch (Exception e)
            {
                resultadoVerificarCliente = false;
            }
            
            return resultadoVerificarCliente;
        }

    }
}