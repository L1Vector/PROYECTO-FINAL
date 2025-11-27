using System;

namespace Biblio_SysVentas
{
    public class ClaseInterfaz
    {
        public static void Interfaz()
        {
            //Creamos el encabezado el programa
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("                                   SITEMA DE VENTAS                                       ");
            Console.WriteLine("                                                                                          ");
            Console.ResetColor();

            //Creamos el espacio para el menu
            Console.SetCursorPosition(0, 4);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                                          ");
            Console.ResetColor();

            //Creamos el contorno izquierdo de la interfaz
            for (int i = 5; i < 26; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(" ");
                Console.ResetColor();
            }
            //Creamos el contorno derecho de la interfaz

            for (int i = 5; i < 26; i++)
            {
                Console.SetCursorPosition(89, i);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(" ");
                Console.ResetColor();
            }

            //metodo para cerrar la interfaz
            Console.SetCursorPosition(0, 26);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                                          ");
            Console.ResetColor();
        }
    }
}
