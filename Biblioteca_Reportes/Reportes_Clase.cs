using System;
using BIBLIOTECA_REGISTRA;
using SUBMENU_VENTAS;

namespace Biblioteca_Reportes
{
    public class Reportes_Clase
    {
        // --- Método de entrada (Llamado desde el Programa Principal) ---
        public static void MostrarReporte(string tipoReporte)
        {
            Optimización.LimpiarAreaReporte();

            // Título
            Console.SetCursorPosition(Variables.InicioX, Variables.InicioY);
            Console.WriteLine($"-------------------------------- REPORTE DE {tipoReporte.ToUpper()} --------------------------------");
            Console.SetCursorPosition(Variables.InicioX, Variables.InicioY + 1);
            Console.WriteLine(new string('-', 85));

            switch (tipoReporte.ToUpper())
            {
                // =============================
                // REPORTES DE REGISTRO
                // =============================
                case "PRODUCTOS":
                    GenerarReporteProductos();
                    break;

                case "CLIENTES":
                    GenerarReporteClientes();
                    break;

                case "VENDEDORES":
                    GenerarReporteVendedores();
                    break;

                case "PROVEEDORES":
                    GenerarReporteProveedores();
                    break;

                // =============================
                // REPORTES DE VENTAS (FIX)
                // =============================
                case "BOLETAS":
                    GenerarReporteDocumentos("BOLETA");
                    break;

                case "FACTURAS":
                    GenerarReporteDocumentos("FACTURA");
                    break;

                case "GUIAS":
                    GenerarReporteDocumentos("GUIA REM");
                    break;

                case "PROFORMAS":
                    GenerarReporteDocumentos("PROFORMA");
                    break;

                default:
                    Console.SetCursorPosition(Variables.InicioX, Variables.InicioY + 3);
                    Console.WriteLine($"Error: Tipo de reporte '{tipoReporte}' no encontrado.");
                    break;
            }

            Optimización.PausaYLimpieza();
        }

        // =================================================================
        // REPORTES DE REGISTRO
        // =================================================================

        private static void GenerarReporteProductos()
        {
            string[,] datos = Arreglos.Productos;
            int filaActual = Variables.InicioY + 3;

            Optimización.EscribirFila(filaActual++, Variables.InicioX,
                "CÓDIGO", 10,
                "NOMBRE", 25,
                "CATEGORÍA", 15,
                "STOCK", 10,
                "PRECIO", 15);

            Optimización.EscribirLineaSeparadora(filaActual++);

            if (datos.GetLength(0) == 0)
            {
                Optimización.EscribirMensajeSinDatos(filaActual++);
                return;
            }

            for (int i = 0; i < datos.GetLength(0); i++)
            {
                Optimización.EscribirFila(filaActual++, Variables.InicioX,
                    datos[i, 0], 10,
                    datos[i, 1], 25,
                    datos[i, 2], 15,
                    datos[i, 3], 10,
                    datos[i, 4], 15);
            }
        }

        private static void GenerarReporteClientes()
        {
            string[,] datos = Arreglos.Clientes;
            int filaActual = Variables.InicioY + 3;

            Optimización.EscribirFila(filaActual++, Variables.InicioX,
                "DNI", 10,
                "NOMBRES", 20,
                "APELLIDOS", 20,
                "TELÉFONO", 15,
                "EMAIL", 20);

            Optimización.EscribirLineaSeparadora(filaActual++);

            if (datos.GetLength(0) == 0)
            {
                Optimización.EscribirMensajeSinDatos(filaActual++);
                return;
            }

            for (int i = 0; i < datos.GetLength(0); i++)
            {
                Optimización.EscribirFila(filaActual++, Variables.InicioX,
                    datos[i, 0], 10,
                    datos[i, 1], 20,
                    datos[i, 2], 20,
                    datos[i, 3], 15,
                    datos[i, 4], 20);
            }
        }

        private static void GenerarReporteVendedores()
        {
            string[,] datos = Arreglos.Vendedores;
            int filaActual = Variables.InicioY + 3;

            Optimización.EscribirFila(filaActual++, Variables.InicioX,
                "CÓDIGO", 10,
                "NOMBRES", 20,
                "APELLIDOS", 20,
                "SUELDO", 15,
                "TELÉFONO", 15);

            Optimización.EscribirLineaSeparadora(filaActual++);

            if (datos.GetLength(0) == 0)
            {
                Optimización.EscribirMensajeSinDatos(filaActual++);
                return;
            }

            for (int i = 0; i < datos.GetLength(0); i++)
            {
                Optimización.EscribirFila(filaActual++, Variables.InicioX,
                    datos[i, 0], 10,
                    datos[i, 1], 20,
                    datos[i, 2], 20,
                    datos[i, 3], 15,
                    datos[i, 4], 15);
            }
        }

        private static void GenerarReporteProveedores()
        {
            // [CódigoProveedor, Empresa, RUC, Representante, Teléfono, Dirección, Ciudad]
            string[,] datos = Arreglos.Proveedores;
            int filaActual = Variables.InicioY + 3;

            // Cabecera corregida
            Optimización.EscribirFila(filaActual++, Variables.InicioX,
                "CÓDIGO", 10,
                "EMPRESA", 20,
                "RUC", 12,
                "REPRESENTANTE", 20,
                "TELÉFONO", 12,
                "CIUDAD", 12);

            Optimización.EscribirLineaSeparadora(filaActual++);

            if (datos.GetLength(0) == 0)
            {
                Optimización.EscribirMensajeSinDatos(filaActual++);
                return;
            }

            for (int i = 0; i < datos.GetLength(0); i++)
            {
                Optimización.EscribirFila(filaActual++, Variables.InicioX,
                    datos[i, 0], 10,   // Código proveedor
                    datos[i, 1], 20,   // Empresa
                    datos[i, 2], 12,   // RUC
                    datos[i, 3], 20,   // Representante
                    datos[i, 4], 12,   // Teléfono
                    datos[i, 6], 12);  // Ciudad
            }
        }


        // =================================================================
        // REPORTES DE DOCUMENTOS (VENTAS)
        // =================================================================

        private static void GenerarReporteDocumentos(string tipoDocumento)
        {
            string[,] datosVentas = LogicaVentas.Documentos;
            int filaActual = Variables.InicioY + 3;

            // ======= TITULO DEPENDIENDO DEL TIPO =======
            string tituloCliente = "CLIENTE";

            if (tipoDocumento == "FACTURA")
                tituloCliente = "EMPRESA";
            else if (tipoDocumento == "GUIA REM")
                tituloCliente = "DESTINATARIO";
            else if (tipoDocumento == "PROFORMA")
                tituloCliente = "CLIENTE";

            // ======= CABECERA =======
            Optimización.EscribirFila(filaActual++, Variables.InicioX,
                "NRO. DOC", 12,
                tituloCliente, 25,
                "PRODUCTO", 25,
                "CANT", 6,
                "TOTAL", 15);

            Optimización.EscribirLineaSeparadora(filaActual++);

            if (datosVentas.GetLength(0) == 0)
            {
                Optimización.EscribirMensajeSinDatos(filaActual++);
                return;
            }

            bool datosEncontrados = false;

            for (int i = 0; i < datosVentas.GetLength(0); i++)
            {
                if (datosVentas[i, 0] == tipoDocumento)
                {
                    datosEncontrados = true;

                    Optimización.EscribirFila(filaActual++, Variables.InicioX,
                        datosVentas[i, 1], 12,   // Nro Doc
                        datosVentas[i, 3], 25,   // Empresa / Cliente
                        datosVentas[i, 6], 25,   // Producto
                        datosVentas[i, 7], 6,    // Cantidad
                        datosVentas[i, 9], 15);  // Total
                }
            }

            if (!datosEncontrados)

            {
                Optimización.EscribirMensajeSinDatos(filaActual++);
            }
        }


        // =================================================================
        // AUXILIARES
        // =================================================================

    }
}
