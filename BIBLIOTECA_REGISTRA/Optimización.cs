using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIBLIOTECA_REGISTRA
{
    public class Optimización
    {
        public static string[,] AgregarFila(string[,] original, string[] nuevaFila)
        {
            int numFilas = original.GetLength(0);
            int numCols = original.GetLength(1);
            string[,] nuevoArray = new string[numFilas + 1, numCols];

            for (int i = 0; i < numFilas; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    nuevoArray[i, j] = original[i, j];
                }
            }

            for (int j = 0; j < numCols; j++)
            {
                nuevoArray[numFilas, j] = nuevaFila[j];
            }

            return nuevoArray;
        }

        public static void LimpiarAreaRegistro(int filaInicial)
        {
            int anchoArea = 88;
            for (int i = filaInicial; i <= 25; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write(new string(' ', anchoArea));
            }
            Console.SetCursorPosition(2, filaInicial);
        }

        public static void MostrarErrorYContinuar(string mensaje, int filaError)
        {
            Console.SetCursorPosition(2, filaError);
            Console.Write($" Error: {mensaje} ");
            Console.ResetColor();

            Console.SetCursorPosition(2, filaError + 1);
            Console.WriteLine("Presione cualquier tecla para reintentar...");
            Console.ReadKey(true);

            Console.SetCursorPosition(2, filaError);
            Console.Write(new string(' ', 86));
            Console.SetCursorPosition(2, filaError + 1);
            Console.Write(new string(' ', 86));
        }

        public static string ObtenerEntradaValidada(string mensaje, int fila, Func<string, string> validadorAdicional = null)
        {
            while (true)
            {
                Console.SetCursorPosition(2, fila);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, fila);
                Console.Write(mensaje);
                string input = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    MostrarErrorYContinuar("Este campo no puede estar vacío.", fila + 1);
                    continue;
                }

                if (validadorAdicional != null)
                {
                    string error = validadorAdicional(input);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MostrarErrorYContinuar(error, fila + 1);
                        continue;
                    }
                }

                return input;
            }
        }


    }
}
