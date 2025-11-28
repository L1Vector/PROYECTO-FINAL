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
using Biblio_SysVentas; //Referencia a la biblioteca de Interfaz
using BIBLIOTECA_REGISTRA; //Referencia a la biblioteca de Registro
using SUBMENU_VENTAS; //Referencia a la biblioteca de Ventas

namespace SYS_VENTAS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            int valor;
            do
            {
                opcion = ClaseMenu.MenuPrincipaDinamico();

                switch (opcion)
                {
                    case 0://REGISTRA
                        valor = ClaseSubMenu.SubMenuDinamico(opcion, ClaseArreglos.arregloRegistra);
                        switch(valor)
                        {
                            case 0:
                                BibliotecaRegistra.RegistrarProducto();
                                break;
                            case 1:
                                BibliotecaRegistra.RegistrarCliente();
                                break;
                            case 2:
                                BibliotecaRegistra.RegistrarVendedor();
                                break;
                            case 3:
                                BibliotecaRegistra.RegistrarProveedor();
                                break;
                        }
                        break;
                    case 1://VENTAS
                        valor = ClaseSubMenu.SubMenuDinamico(opcion, ClaseArreglos.arregloVentas);
                        switch(valor)
                        {
                            case 0:
                                Boleta.Mostrar();
                                break;
                            case 1:
                                Factura.Mostrar();
                                break;
                            case 2:
                                GuiaRemision.Mostrar();
                                break;
                            case 3:
                                Proforma.Mostrar();
                                break;

                        }
                        break;
                    case 2://REPORTES
                        valor = ClaseSubMenu.SubMenuDinamico(opcion, ClaseArreglos.arregloReporte);
                        switch (valor)
                        {
                            case 0:
                                break;
                            case 1:
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                             
                        }
                        break;
                    case 3://MODIFICA
                        valor = ClaseSubMenu.SubMenuDinamico(opcion, ClaseArreglos.arregloModifica);
                        break;
                }

                Console.Clear();

            } while (opcion != 5);

        }
    }
}
