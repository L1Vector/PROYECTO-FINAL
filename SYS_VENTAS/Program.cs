/*
 * El sistema de venta como proyecto final debe incluir:
 * -> BIBLIOTECAS
 * -> CLASES
 * -> METODOS
 * -> ESTRUCTURAS REPETITIVAS
 * -> ESTRUCTURAS CONDICIONALES
 * -> ARREGLOS UNIDIMENSIONALES
 * -> ARREGLOS BIDIMENSIONALES
 * -> VARIABLES
 */
using System;
using Biblio_SysVentas;//Llamamos a nuestra biblioteca

namespace SYS_VENTAS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            do
            {
                opcion = ClaseMenu.MenuPrincipaDinamico();

                Console.ReadKey();
                Console.Clear();

            } while (opcion != 5);
        }
    }
}
