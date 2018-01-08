﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Microsoft.Office.Interop.Excel;

namespace PracticasBancolombia.FunctionalsTest
{
    class GenerarArchivoExcel
    {
        public void CrearArchivoExcelCredito(string nombreArchivo, double dblValorCredito, string strNomHoja)
        {
            try
            {
                //======================================================
                //Definición de variables
                //======================================================
                Application _excelApp;
                Workbook libroProyecto;
                Worksheet hojaCredito;

                //======================================================
                //Asignación de valores
                //======================================================
                _excelApp = new Application();
                _excelApp.Visible = false;
                _excelApp.DisplayAlerts = false;

                //======================================================
                //Validación si el archivo existe
                //======================================================
                if (!File.Exists("D:\\Resultado\\" + nombreArchivo))
                {
                    //======================================================
                    //Creación del libro
                    //======================================================
                    libroProyecto = _excelApp.Workbooks.Add();
                    libroProyecto.Activate();

                    //======================================================
                    //Hoja del credito
                    //======================================================
                    hojaCredito = libroProyecto.Worksheets[1];
                    hojaCredito.Activate();
                    hojaCredito.Name = strNomHoja;
                    hojaCredito.Cells[1, 1] = "CREDITO";
                    hojaCredito.Cells[2, 1] = "VALOR CUOTA";
                    hojaCredito.Cells[1, 2] = strNomHoja;
                    hojaCredito.Cells[2, 2] = dblValorCredito;
                }
                else
                {
                    //======================================================
                    //Abrir el libro
                    //======================================================
                    libroProyecto = _excelApp.Workbooks.Open("D:\\Resultado\\" + nombreArchivo);
                    libroProyecto.Activate();

                    Boolean existeHoja;
                    existeHoja = false;
                    foreach (Worksheet hojas in libroProyecto.Sheets)
                    {
                        if (hojas.Name == strNomHoja)
                        {
                            existeHoja = true;
                        }
                    }

                    if (existeHoja == true)
                    {
                        hojaCredito = libroProyecto.Worksheets[strNomHoja];
                        hojaCredito.Delete();
                    }

                    hojaCredito = libroProyecto.Worksheets.Add();
                    hojaCredito.Activate();
                    hojaCredito.Name = strNomHoja;
                    hojaCredito.Cells[1, 1] = "CREDITO";
                    hojaCredito.Cells[2, 1] = "VALOR CUOTA";
                    hojaCredito.Cells[1, 2] = strNomHoja;
                    hojaCredito.Cells[2, 2] = dblValorCredito;
                }

                //======================================================
                //Guardar Archivo
                //======================================================
                libroProyecto.SaveAs("D:\\Resultado\\" + nombreArchivo);
                libroProyecto.Close(0);
                _excelApp.Quit();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }

        public void CompararResultado(string nombreArchivo)
        {
            try
            {
                //======================================================
                //Definición de variables
                //======================================================
                Application _excelApp;
                Workbook libroProyecto;
                Worksheet hojaConsumo;
                Worksheet hojaInmobiliario;
                Worksheet hojaComparativo;
                string strHojaCOM;
                string strHojaSIM;
                string strHojaFIN;
                Boolean extHojaCOM;
                Boolean extHojaSIM;
                Boolean extHojaFIN;
                double vlrCreConsumo;
                double vlrCreInmobiliario;

                //======================================================
                //Asignación de valores
                //======================================================
                _excelApp = new Application();
                _excelApp.Visible = false;
                _excelApp.DisplayAlerts = false;
                strHojaCOM = "Consumo";
                strHojaSIM = "Inmobiliaria";
                strHojaFIN = "Comparativo";

                if (File.Exists("D:\\Resultado\\" + nombreArchivo))
                {
                    //======================================================
                    //Abrir el libro
                    //======================================================
                    libroProyecto = _excelApp.Workbooks.Open("D:\\Resultado\\" + nombreArchivo);
                    libroProyecto.Activate();

                    //======================================================
                    //Validar existencia hojas
                    //======================================================
                    extHojaCOM = ValirdarExisteHoja(strHojaCOM, libroProyecto);
                    extHojaSIM = ValirdarExisteHoja(strHojaSIM, libroProyecto);
                    extHojaFIN = ValirdarExisteHoja(strHojaFIN, libroProyecto);

                    //======================================================
                    //Validar Existencia Hoja
                    //======================================================
                    if (extHojaCOM == true & extHojaSIM == true)
                    {
                        hojaConsumo = libroProyecto.Worksheets[strHojaCOM];
                        hojaInmobiliario = libroProyecto.Worksheets[strHojaSIM];
                        if (extHojaFIN == true)
                        {
                            hojaComparativo = libroProyecto.Worksheets[strHojaCOM];
                            hojaComparativo.Activate();
                            hojaComparativo.Delete();
                        }

                        hojaComparativo = libroProyecto.Worksheets.Add();
                        hojaComparativo.Activate();
                        hojaComparativo.Name = strHojaFIN;
                        hojaComparativo.Cells[1, 1] = "Crédito";
                        hojaComparativo.Cells[1, 2] = "Consumo";
                        hojaComparativo.Cells[1, 3] = "Inmobiliaria";
                        hojaComparativo.Cells[1, 4] = "Mejor Cuota";
                        hojaComparativo.Cells[2, 1] = "Cuota";
                        hojaComparativo.Cells[2, 2] = hojaConsumo.Cells[2, 2].Value;
                        hojaComparativo.Cells[2, 3] = hojaInmobiliario.Cells[2, 2].Value;

                        vlrCreConsumo = Convert.ToDouble(hojaConsumo.Cells[2, 2].Value);
                        vlrCreInmobiliario = Convert.ToDouble(hojaInmobiliario.Cells[2, 2].Value);

                        if (vlrCreConsumo < vlrCreInmobiliario)
                        {
                            hojaComparativo.Cells[2, 4] = "Consumo";
                            hojaComparativo.Cells[2, 2].Interior.Color = XlRgbColor.rgbGreen;
                            hojaComparativo.Cells[2, 2].Font.Color = XlRgbColor.rgbWhite;
                        }
                        else
                        {
                            hojaComparativo.Cells[2, 4] = "Inmobiliaria";
                            hojaComparativo.Cells[2, 3].Interior.Color = XlRgbColor.rgbGreen;
                            hojaComparativo.Cells[2, 3].Font.Color = XlRgbColor.rgbWhite;
                        }

                        //======================================================
                        //Guardar Archivo
                        //======================================================
                        libroProyecto.SaveAs("D:\\Resultado\\" + nombreArchivo);
                        libroProyecto.Close(0);
                        _excelApp.Quit();
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }

        public Boolean ValirdarExisteHoja(string nomHoja, Workbook libroProyecto)
        {
            Boolean existHoja;
            existHoja = false;

            foreach (Worksheet hojas in libroProyecto.Sheets)
            {
                if (hojas.Name == nomHoja)
                {
                    existHoja = true;
                }
            }

            return existHoja;
        }
    }
}
