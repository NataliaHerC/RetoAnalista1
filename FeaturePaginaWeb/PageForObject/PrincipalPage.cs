using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PracticasBancolombia.FunctionalsTest.PageForObject
{
    public class PrincipalPage
    {
        IWebDriver driver = null;
        public PrincipalPage(IWebDriver navegador)
        {
            driver = navegador;
            driver.Url = "http://www.google.com";
            driver.Navigate();
            IWebElement barradebusqueda= driver.FindElement(By.Name("q"));
            barradebusqueda.SendKeys("Bancolombia");
            barradebusqueda.SendKeys(Keys.Enter);
            IWebElement sucursalpersonas = driver.FindElement(By.LinkText("Sucursal Virtual Personas"));
            sucursalpersonas.Click();
            IWebElement parati = driver.FindElement(By.LinkText("Para Ti"));
            parati.Click();

        }

        private void IngresarOpcionMenu(string opcionmenu)
        {
            IWebElement myLink = driver.FindElement(By.Id("terminoBusqueda"));
            myLink.SendKeys(opcionmenu);
            myLink.SendKeys(Keys.Enter);
         
        }
        public void IngresoSimuladorCreditoConsumo()
        {
            IngresarOpcionMenu("Simulador");
            IWebElement simulador = driver.FindElement(By.LinkText("Simulador Crédito de Consumo"));
            simulador.Click();

        }

        public void IngresoSimuladorCreditoSolucionInmobiliaria()
        {
            IngresarOpcionMenu("Simulador");
            IWebElement simulador = driver.FindElement(By.LinkText("Simulador Solución Inmobiliaria"));
            simulador.Click();

        }

    
        public void Terminar()
        {
            driver.Quit();
        }
    }
}
