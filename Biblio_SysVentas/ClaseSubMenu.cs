using Biblio_SysVentas;
using System;

public class ClaseSubMenu
{
    // Función mejorada para obtener la posición inicial X del submenú
    private static int ObtenerPosicionIzquierda(int valorMenuPrincipal)
    {
        return 1 + (valorMenuPrincipal * 15);
    }

    // El método principal del submenú que permite la selección dinámica vertical
    public static int SubMenuDinamico(int valorMenuPrincipal, string[] arregloOpciones)
    {
        int indice = 0; // Índice de la opción seleccionada dentro del submenú (vertical)
        ConsoleKey tecla;
        int izquierda = ObtenerPosicionIzquierda(valorMenuPrincipal);

        // La posición vertical inicial (Y) para el submenú
        const int PosicionYInicial = 5;

        // Define el ancho fijo de cada opción para el resaltado uniforme
        const int AnchoOpcion = 14;

        do
        {
            Console.Clear();
            ClaseMenu.MenuPrincipalEstatico();
            // 1. Dibuja las opciones del Submenú (con resaltado)
            for (int i = 0; i < arregloOpciones.Length; i++)
            {
                // Determina los colores según si es la opción seleccionada
                if (indice == i)
                {
                    // Opción seleccionada: Texto Negro sobre fondo Blanco
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    // Opción normal: Texto Blanco sobre fondo Negro (o el color del fondo)
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                // Posiciona y escribe la opción
                Console.SetCursorPosition(izquierda, PosicionYInicial + i);

                // Aseguramos un ancho consistente para el resaltado
                string texto = $" {arregloOpciones[i]}".PadRight(AnchoOpcion);
                Console.Write(texto);

                Console.ResetColor();
            }

            ConsoleKeyInfo Info = Console.ReadKey(true);
            tecla = Info.Key;

            if (tecla == ConsoleKey.DownArrow)
            {
                indice++;
                if (indice >= arregloOpciones.Length)
                {
                    indice = 0; 
                }
            }
            else if (tecla == ConsoleKey.UpArrow)
            {
                indice--;
                if (indice < 0)
                {
                    indice = arregloOpciones.Length - 1; 
                }
            }

            // 4. Permite salir del submenú con ESC (puedes usar esta opción)
            if (tecla == ConsoleKey.Escape)
            {
                return -1;
            }

        } while (tecla != ConsoleKey.Enter);

        return indice;
    }
}