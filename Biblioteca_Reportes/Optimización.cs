using System;

namespace Biblioteca_Reportes
{
    internal class Optimización
    {
        public static void PausaYLimpieza()
        {
            Console.SetCursorPosition(Variables.InicioX, 24);
            Console.Write("Presione una tecla para regresar al menú principal...");
            Console.ReadKey(true);
            LimpiarAreaReporte();
        }

        public static void LimpiarAreaReporte()
        {
            for (int i = 5; i < 26; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write(new string(' ', 87));
            }
        }

        public static void EscribirMensajeSinDatos(int fila)
        {
            Console.SetCursorPosition(Variables.InicioX, fila);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No hay datos registrados.");
            Console.ResetColor();
            Console.ReadKey();
        }

        public static void EscribirFila(int fila, int xInicial, params object[] columnas)
        {
            int posX = xInicial;

            for (int i = 0; i < columnas.Length; i += 2)
            {
                string valor = columnas[i].ToString();
                int ancho = (int)columnas[i + 1];

                string texto = valor.PadRight(ancho).Substring(0, ancho);

                Console.SetCursorPosition(posX, fila);
                Console.Write(texto);

                posX += ancho;
            }
        }

        public static void EscribirLineaSeparadora(int fila)
        {
            Console.SetCursorPosition(Variables.InicioX, fila);
            Console.WriteLine(new string('-', 80));
        }

    }
}
