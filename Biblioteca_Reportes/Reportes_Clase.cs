using System;
using BIBLIOTECA_REGISTRA;
using SUBMENU_VENTAS;

namespace Biblioteca_Reportes
{
    public class Reportes_Clase
    {
        private const int InicioX = 2;
        private const int InicioY = 6;

        // --- Método de entrada (Llamado desde el Programa Principal) ---
        public static void MostrarReporte(string tipoReporte)
        {
            LimpiarAreaReporte();

            // Título
            Console.SetCursorPosition(InicioX, InicioY);
            Console.WriteLine($"--- REPORTE DE {tipoReporte.ToUpper()} ---");
            Console.SetCursorPosition(InicioX, InicioY + 1);
            Console.WriteLine(new string('-', 50));

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
                    Console.SetCursorPosition(InicioX, InicioY + 3);
                    Console.WriteLine($"Error: Tipo de reporte '{tipoReporte}' no encontrado.");
                    break;
            }

            PausaYLimpieza();
        }

        // =================================================================
        // REPORTES DE REGISTRO
        // =================================================================

        private static void GenerarReporteProductos()
        {
            string[,] datos = BibliotecaRegistra.Productos;
            int filaActual = InicioY + 3;

            EscribirFila(filaActual++, InicioX,
                "CÓDIGO", 10,
                "NOMBRE", 25,
                "CATEGORÍA", 15,
                "STOCK", 10,
                "PRECIO", 15);

            EscribirLineaSeparadora(filaActual++);

            if (datos.GetLength(0) == 0)
            {
                EscribirMensajeSinDatos(filaActual++);
                return;
            }

            for (int i = 0; i < datos.GetLength(0); i++)
            {
                EscribirFila(filaActual++, InicioX,
                    datos[i, 0], 10,
                    datos[i, 1], 25,
                    datos[i, 2], 15,
                    datos[i, 3], 10,
                    datos[i, 4], 15);
            }
        }

        private static void GenerarReporteClientes()
        {
            string[,] datos = BibliotecaRegistra.Clientes;
            int filaActual = InicioY + 3;

            EscribirFila(filaActual++, InicioX,
                "DNI", 10,
                "NOMBRES", 20,
                "APELLIDOS", 20,
                "TELÉFONO", 15,
                "EMAIL", 20);

            EscribirLineaSeparadora(filaActual++);

            if (datos.GetLength(0) == 0)
            {
                EscribirMensajeSinDatos(filaActual++);
                return;
            }

            for (int i = 0; i < datos.GetLength(0); i++)
            {
                EscribirFila(filaActual++, InicioX,
                    datos[i, 0], 10,
                    datos[i, 1], 20,
                    datos[i, 2], 20,
                    datos[i, 3], 15,
                    datos[i, 4], 20);
            }
        }

        private static void GenerarReporteVendedores()
        {
            string[,] datos = BibliotecaRegistra.Vendedores;
            int filaActual = InicioY + 3;

            EscribirFila(filaActual++, InicioX,
                "CÓDIGO", 10,
                "NOMBRES", 20,
                "APELLIDOS", 20,
                "SUELDO", 15,
                "TELÉFONO", 15);

            EscribirLineaSeparadora(filaActual++);

            if (datos.GetLength(0) == 0)
            {
                EscribirMensajeSinDatos(filaActual++);
                return;
            }

            for (int i = 0; i < datos.GetLength(0); i++)
            {
                EscribirFila(filaActual++, InicioX,
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
            string[,] datos = BibliotecaRegistra.Proveedores;
            int filaActual = InicioY + 3;

            // Cabecera corregida
            EscribirFila(filaActual++, InicioX,
                "CÓDIGO", 10,
                "EMPRESA", 20,
                "RUC", 12,
                "REPRESENTANTE", 20,
                "TELÉFONO", 12,
                "CIUDAD", 12);

            EscribirLineaSeparadora(filaActual++);

            if (datos.GetLength(0) == 0)
            {
                EscribirMensajeSinDatos(filaActual++);
                return;
            }

            for (int i = 0; i < datos.GetLength(0); i++)
            {
                EscribirFila(filaActual++, InicioX,
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
            int filaActual = InicioY + 3;

            // ======= TITULO DEPENDIENDO DEL TIPO =======
            string tituloCliente = "CLIENTE";

            if (tipoDocumento == "FACTURA")
                tituloCliente = "EMPRESA";
            else if (tipoDocumento == "GUIA REM")
                tituloCliente = "DESTINATARIO";
            else if (tipoDocumento == "PROFORMA")
                tituloCliente = "CLIENTE";

            // ======= CABECERA =======
            EscribirFila(filaActual++, InicioX,
                "NRO. DOC", 12,
                tituloCliente, 25,
                "PRODUCTO", 25,
                "CANT", 6,
                "TOTAL", 15);

            EscribirLineaSeparadora(filaActual++);

            if (datosVentas.GetLength(0) == 0)
            {
                EscribirMensajeSinDatos(filaActual++);
                return;
            }

            bool datosEncontrados = false;

            for (int i = 0; i < datosVentas.GetLength(0); i++)
            {
                if (datosVentas[i, 0] == tipoDocumento)
                {
                    datosEncontrados = true;

                    EscribirFila(filaActual++, InicioX,
                        datosVentas[i, 1], 12,   // Nro Doc
                        datosVentas[i, 3], 25,   // Empresa / Cliente
                        datosVentas[i, 6], 25,   // Producto
                        datosVentas[i, 7], 6,    // Cantidad
                        datosVentas[i, 9], 15);  // Total
                }
            }

            if (!datosEncontrados)

            {
                EscribirMensajeSinDatos(filaActual++);
            }
        }


        // =================================================================
        // AUXILIARES
        // =================================================================

        private static void PausaYLimpieza()
        {
            Console.SetCursorPosition(InicioX, 24);
            Console.Write("Presione una tecla para regresar al menú principal...");
            Console.ReadKey(true);
            LimpiarAreaReporte();
        }

        private static void LimpiarAreaReporte()
        {
            for (int i = InicioY; i < 26; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write(new string(' ', 87));
            }
        }

        private static void EscribirMensajeSinDatos(int fila)
        {
            Console.SetCursorPosition(InicioX, fila);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No hay datos registrados.");
            Console.ResetColor();
        }

        private static void EscribirFila(int fila, int xInicial, params object[] columnas)
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

        private static void EscribirLineaSeparadora(int fila)
        {
            Console.SetCursorPosition(InicioX, fila);
            Console.WriteLine(new string('-', 80));
        }
    }
}
