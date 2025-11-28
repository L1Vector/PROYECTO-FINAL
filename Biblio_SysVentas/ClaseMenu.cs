using System;
using System.Reflection;


namespace Biblio_SysVentas
{
    public class ClaseMenu
    {
        public static int MenuPrincipaDinamico()
        {
            string[] menuPrincipal = { "REGISTRAR", "VENTA", "REPORTE", "MODIFICAR", "AYUDA", "SALIR" };
            int indice = 0;
            ConsoleKey tecla;

            do
            {
                Console.Clear();
                ClaseInterfaz.Interfaz();

                int j = 1;

                for (int i = 0; i < menuPrincipal.Length; i++)
                {
                    if (indice == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;  // bloque negro
                        Console.ForegroundColor = ConsoleColor.White;  // texto blanco
                        Console.SetCursorPosition(j, 3);
                        Console.Write("             ");
                        Console.SetCursorPosition(j + 3, 3);
                        Console.Write(menuPrincipal[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;  // bloque blanco
                        Console.ForegroundColor = ConsoleColor.Black;  // texto negro
                        Console.SetCursorPosition(j, 3);
                        Console.Write("             ");
                        Console.SetCursorPosition(j + 3, 3);
                        Console.Write(menuPrincipal[i]);
                        Console.ResetColor();
                    }

                    j += 15;

                }

                ConsoleKeyInfo Info = Console.ReadKey(true);
                tecla = Info.Key;

                Console.SetCursorPosition(0, 28);

                if (tecla == ConsoleKey.RightArrow)
                {
                    indice++;
                    if (indice > menuPrincipal.Length - 1)
                    {
                        indice = 0;
                    }
                }
                else if (tecla == ConsoleKey.LeftArrow)
                {
                    indice--;
                    if (indice < 0)
                    {
                        indice = menuPrincipal.Length - 1;
                    }
                }
            } while (tecla != ConsoleKey.Enter);
            return indice;
        }

        //Metodo para presentar el menu principal de manera estatica
        public static void MenuPrincipalEstatico()
        {
            string[] menuPrincipal = { "REGISTRAR", "VENTA", "REPORTE", "MODIFICAR", "AYUDA", "SALIR" };
            int j = 1;
            int indice = 0;

            ClaseInterfaz.Interfaz();

            for (int i = 0; i < menuPrincipal.Length; i++)
            {
                if (indice == i)
                {
                    Console.BackgroundColor = ConsoleColor.White;  // bloque negro
                    Console.ForegroundColor = ConsoleColor.Black;  // texto blanco
                    Console.SetCursorPosition(j, 3);
                    Console.Write("             ");
                    Console.SetCursorPosition(j + 3, 3);
                    Console.Write(menuPrincipal[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;  // bloque blanco
                    Console.ForegroundColor = ConsoleColor.Black;  // texto negro
                    Console.SetCursorPosition(j, 3);
                    Console.Write("             ");
                    Console.SetCursorPosition(j + 3, 3);
                    Console.Write(menuPrincipal[i]);
                    Console.ResetColor();
                }

                j += 15;
            }

            Console.SetCursorPosition(0, 28);
        }
    }
}
