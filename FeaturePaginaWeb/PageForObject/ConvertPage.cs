using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PracticasBancolombia.FunctionalsTest.PageForObject
{
    public class ConvertPage
    {
        IWebDriver driver = null;
        public ConvertPage(IWebDriver navegador)
        {
            driver = navegador;
        }

        public string Numero
        {
            get
            {
                IWebElement numeroConvertir = driver.FindElement(By.Name("comboTipoSimulacion"));
                return numeroConvertir.Text;
            }
            set
            {
                IWebElement numeroConvertir =  driver.FindElement(By.Name("comboTipoSimulacion"));
                numeroConvertir.Clear();
                numeroConvertir.SendKeys(value);

            }
        }

        public string ResultadoConversion
        {
            get
            {
                IWebElement resultadoConversionElemento = driver.FindElement(By.Id("Result01"));
                return resultadoConversionElemento.Text;
            }

        }

        public void ConvertirNumero()
        {
            IWebElement botonConvertirElemento = driver.FindElement(By.Id("btnConvertir"));
            botonConvertirElemento.Click();
        }
    }
}
