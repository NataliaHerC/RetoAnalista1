using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Microsoft.Office.Interop.Excel;

namespace PracticasBancolombia.FunctionalsTest
{
    class GenerarArchivoExcel    {
        public void CrearArchivoExcel(String nombreArchivo, int valorCredSIM)
        {
            try
            {
                //======================================================
                //Definición de variables
                //======================================================
                int respuesta;
                string hojaCredSIM;
                Application _excelApp;
                double vlrSIM;
                object valorComFin;
                object valorSIMFin;

                vlrSIM = Convert.ToDouble(valorCredSIM);

                //======================================================
                //Eliminar el archivo anterior
                //======================================================
                respuesta = 0;
                if (File.Exists("C:\\Resultado\\" + nombreArchivo))
                {
                    try
                    {
                        File.Delete("C:\\Resultado\\" + nombreArchivo);
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
                    hojaCredSIM = "CreditoSIM";

                    //======================================================
                    //Creación del libro
                    //======================================================
                    Workbook libroProyecto = _excelApp.Workbooks.Add();
                    libroProyecto.Activate();

                   
                    //======================================================
                    //Hoja del credito de SIM
                    //======================================================
                    Worksheet hojaCreditoSIM = libroProyecto.Worksheets.Add();
                    hojaCreditoSIM.Activate();
                    hojaCreditoSIM.Name = hojaCredSIM;
                    hojaCreditoSIM.Cells[1, 1] = "CREDITO";
                    hojaCreditoSIM.Cells[2, 1] = "VALOR CUOTA";
                    hojaCreditoSIM.Cells[1, 2] = hojaCredSIM;
                    hojaCreditoSIM.Cells[2, 2] = vlrSIM;
                                     
                    //======================================================
                    //Guardar Archivo
                    //======================================================
                    libroProyecto.SaveAs("C:\\Resultado\\" + nombreArchivo);
                    libroProyecto.Close(0);
                }
            }
            catch (IOException e)
            {

            }
        }
    }
}
