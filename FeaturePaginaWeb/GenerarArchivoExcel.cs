using System;
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
        public void CrearArchivoExcel( string nombreArchivo, double valorCredConsumo, double valorCredSIM)
        {
            try
            {
                //======================================================
                //Definición de variables
                //======================================================
                int respuesta;
                string hojaCredConsumo;
                string hojaCredSIM;
                Application _excelApp;
                double vlrConsumo;
                double vlrSIM;
                object valorComFin;
                object valorSIMFin;

                
                vlrConsumo = Convert.ToDouble(valorCredConsumo);
                vlrSIM = Convert.ToDouble(valorCredSIM);

                //======================================================
                //Eliminar el archivo anterior
                //======================================================
                respuesta = 0;
                if (File.Exists("D:\\Resultado\\" + nombreArchivo))
                {
                    try
                    {
                        File.Delete("D:\\Resultado\\" + nombreArchivo);
                        respuesta = 0;
                    }
                    catch (System.IO.IOException ex)
                    {
                        Console.WriteLine(ex.Message);
                        respuesta = -1;
                    }
                }

                //======================================================
                //Validación del exito de la eliminación del archivo
                //======================================================
                if (respuesta == 0)
                {
                    //======================================================
                    //Asignación de valores
                    //======================================================
                    _excelApp = new Application();
                    _excelApp.Visible = false;
                    hojaCredConsumo = "CreditoConsumo";
                    hojaCredSIM = "CreditoSIM";

                    //======================================================
                    //Creación del libro
                    //======================================================
                    Workbook libroProyecto = _excelApp.Workbooks.Add();
                    libroProyecto.Activate();

                    //======================================================
                    //Hoja del credito de consumo
                    //======================================================
                    Worksheet hojaCreditoCom = libroProyecto.Worksheets[1];
                    hojaCreditoCom.Activate();
                    hojaCreditoCom.Name = hojaCredConsumo;
                    hojaCreditoCom.Cells[1, 1] = "CREDITO";
                    hojaCreditoCom.Cells[2, 1] = "VALOR CUOTA";
                    hojaCreditoCom.Cells[1, 2] = "CONSUMO";
                    hojaCreditoCom.Cells[2, 2] = vlrConsumo;

                    //======================================================
                    //Hoja del credito de SIM
                    //======================================================
                    Worksheet hojaCreditoSIM = libroProyecto.Worksheets.Add();
                    hojaCreditoSIM.Activate();
                    hojaCreditoSIM.Name = hojaCredSIM;
                    hojaCreditoSIM.Cells[1, 1] = "CREDITO";
                    hojaCreditoSIM.Cells[2, 1] = "CUOTA";
                    hojaCreditoSIM.Cells[2, 2] = "VALOR";
                    hojaCreditoSIM.Cells[1, 2] = "CONSUMO";
                    hojaCreditoSIM.Cells[1, 2] = "INMOBILIARIA";
                    hojaCreditoSIM.Cells[2, 2] = vlrSIM;

                    //======================================================
                    //Hoja del Comparativo
                    //======================================================
                    Worksheet hojaFinal = libroProyecto.Worksheets.Add();
                    hojaFinal.Activate();
                    hojaFinal.Name = "ResultadoFinal";
                    hojaFinal.Cells[1, 1] = "CREDITO";
                    hojaFinal.Cells[1, 2] = "CONSUMO";
                    hojaFinal.Cells[1, 3] = "INMOBILIARIA";
                    hojaFinal.Cells[1, 4] = "MEJOR CUOTA";
                    hojaFinal.Cells[2, 1] = "CUOTA";
                    hojaFinal.Cells[2, 2] = vlrConsumo;
                    hojaFinal.Cells[2, 3] = vlrSIM;

                    //======================================================
                    //Comparativo del mejor valor de los creditos
                    //======================================================
                    valorComFin = hojaCreditoCom.Cells[2, 2].Value;
                    valorSIMFin = hojaCreditoSIM.Cells[2, 2].Value;
                    if (Convert.ToDouble(valorSIMFin) < Convert.ToDouble(valorComFin))
                    {
                        hojaFinal.Cells[2, 4] = "Consumo";
                        hojaFinal.Cells[2, 2].Interior.Color = XlRgbColor.rgbGreen;
                        hojaFinal.Cells[2, 2].Font.Color = XlRgbColor.rgbWhite;
                    }
                    else
                    {
                        hojaFinal.Cells[2, 4] = "Inmobiliaria";
                        hojaFinal.Cells[2, 3].Interior.Color = XlRgbColor.rgbGreen;
                        hojaFinal.Cells[2, 3].Font.Color = XlRgbColor.rgbWhite;
                    }

                    //======================================================
                    //Guardar Archivo
                    //======================================================
                    libroProyecto.SaveAs("D:\\Resultado\\" + nombreArchivo);
                    libroProyecto.Close(0);
                }
            }
            catch (IOException e)
            {

            }
        }
    }
}


