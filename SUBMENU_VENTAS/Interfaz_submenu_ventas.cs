namespace SUBMENU_VENTAS
{
    using System;

    public class BibliotecaVentas
    {
        // Submenú de ventas
        static string[] submenuVentas = { "BOLETA", "FACTURA", "GUIA REM", "PROFORMA" };

        // Posición en pantalla donde se dibujará
        public static int PosX { get; set; }
        public static int PosY { get; set; }

        // -----------------------------------------------------------
        //       MÉTODO PRINCIPAL DEL SUBMENÚ VENTAS
        // -----------------------------------------------------------
        public static void Mostrar()
        {
            int opcion = 0;

            while (true)
            {
                DibujarMenuVertical(submenuVentas, opcion, PosX, PosY);

                ConsoleKey tecla = Console.ReadKey(true).Key;

                if (tecla == ConsoleKey.UpArrow)
                    opcion = (opcion - 1 + submenuVentas.Length) % submenuVentas.Length;

                else if (tecla == ConsoleKey.DownArrow)
                    opcion = (opcion + 1) % submenuVentas.Length;

                else if (tecla == ConsoleKey.Enter)
                {
                    Console.Clear();

                    // 🔥 AQUI LLAMAMOS A CADA INTERFAZ 🔥
                    switch (submenuVentas[opcion])
                    {
                        case "BOLETA":
                            Boleta.Mostrar();
                            break;

                        case "FACTURA":
                            Factura.Mostrar();
                            break;

                    }

                    Console.Clear();
                    return; // volvemos al menú principal
                }

                else if (tecla == ConsoleKey.Escape)
                {
                    Console.Clear();
                    return;
                }
            }
        }

        // -----------------------------------------------------------
        //              DIBUJAR MENÚ VERTICAL
        // -----------------------------------------------------------
        private static void DibujarMenuVertical(string[] opciones, int seleccionado, int x, int y)
        {
            for (int i = 0; i < opciones.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);

                if (i == seleccionado)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.Write($" {opciones[i]} ");
                Console.ResetColor();
            }
        }
    }
}
