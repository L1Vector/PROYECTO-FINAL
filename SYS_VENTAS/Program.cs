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

                switch (opcion)
                {
                    case 0:
                        string[] arregloRegistra = { "PRODUCTOS", "CLIENTES", "VENDEDORES", "PROVEEDORES" };
                        ClaseSubMenu.SubMenuDinamico(opcion, arregloRegistra);
                        break;
                    case 1:
                        string[] arregloVentas = { "BOLETA", "FACTURA", "GUIA REM", "PROFORMA" };
                        ClaseSubMenu.SubMenuDinamico(opcion, arregloVentas);
                        break;
                    case 2:
                        string[] arregloReporte = { "PRODUCTOS", "CLIENTES", "VENDEDORES", "PROVEEDORES", "BOLETAS", "FACTURAS", "GUIAS", "PROFORMAS" };
                        ClaseSubMenu.SubMenuDinamico(opcion, arregloReporte);
                        break;
                    case 3:
                        string[] arregloModifica = { "PRODUCTOS", "CLIENTES", "VENDEDORES", "PROVEEDORES" };
                        ClaseSubMenu.SubMenuDinamico(opcion, arregloModifica);
                        break;
                }

                Console.Clear();

            } while (opcion != 5);

        }
    }
}
