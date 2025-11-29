using System;
using BIBLIOTECA_REGISTRA;

namespace SUBMENU_VENTAS
{
    public class Boleta
    {
        public static void Mostrar()
        {
            Utilities.LimpiarZonaTrabajo();
            Console.SetCursorPosition(38, 6);
            Console.Write("BOLETA DE VENTA");

            // =====================================================
            // DATOS PRINCIPALES
            // =====================================================
            Console.SetCursorPosition(10, 8);
            Console.Write("DNI CLIENTE:");
            string dniCliente = Utilities.LeerDNI(25, 8);

            string nombreCliente = Utilities.BuscarClientePorDNI(dniCliente);

            if (string.IsNullOrEmpty(nombreCliente))
            {
                Console.SetCursorPosition(25, 10);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("DNI NO REGISTRADO. Registre al cliente primero.");
                Console.ResetColor();
                Console.ReadKey();

                Utilities.LimpiarZonaTrabajo();
                return;
            }

            // *** CORREGIDO: FALTABA ETIQUETA CLIENTE ***
            Console.SetCursorPosition(10, 10);
            Console.Write("CLIENTE:");
            Utilities.DibujarCajaLectura(25, 10, nombreCliente, 30);

            string numeroBoleta = Numerador.VerBoletaActual();
            Console.SetCursorPosition(60, 8);
            Console.Write("NRO BOLETA:");
            Utilities.DibujarCajaLectura(73, 8, numeroBoleta, 10);

            // =====================================================
            // PRODUCTO AUTOCOMPLETADO
            // =====================================================
            Console.SetCursorPosition(10, 13); Console.Write("CODIGO");
            Console.SetCursorPosition(23, 13); Console.Write("PRODUCTO");
            Console.SetCursorPosition(38, 13); Console.Write("CANTIDAD");
            Console.SetCursorPosition(55, 13); Console.Write("PRECIO UNI");
            Console.SetCursorPosition(74, 13); Console.Write("MONTO");

            string codigoProd;
            string producto;
            double precioUni;
            int stock;

            // ====== INGRESAR CÓDIGO Y VALIDAR ======
            while (true)
            {
                Console.SetCursorPosition(10, 15);
                Console.Write(new string(' ', 10));
                codigoProd = Utilities.LeerCaja(10, 15, 8).ToUpper();

                producto = Utilities.BuscarProductoPorCodigo(codigoProd);
                precioUni = Utilities.BuscarPrecioPorCodigo(codigoProd);
                stock = Utilities.BuscarStockPorCodigo(codigoProd);

                if (producto != "" && stock >= 0)
                    break;

                Console.SetCursorPosition(10, 16);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Código NO existe");
                Console.ResetColor();
                System.Threading.Thread.Sleep(700);

                Console.SetCursorPosition(10, 16);
                Console.Write(new string(' ', 40));
            }

            // *** CORREGIDO: PRODUCTO AHORA SE VE COMPLETO ***
            Utilities.DibujarCajaLectura(23, 15, producto, 12);

            // *** PRECIO UNI YA SE DIBUJA AUTOMÁTICO ***
            Utilities.DibujarCajaLectura(55, 15, precioUni.ToString("F2"), 10);

            // ====== INGRESAR CANTIDAD VALIDADA ======
            double cantidad;

            while (true)
            {
                Console.SetCursorPosition(38, 15);
                Console.Write(new string(' ', 8));
                cantidad = Utilities.LeerNumero(38, 15, 8);

                if (cantidad <= stock)
                    break;

                Console.SetCursorPosition(38, 16);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Stock insuficiente (MAX {stock})");
                Console.ResetColor();
                System.Threading.Thread.Sleep(700);

                Console.SetCursorPosition(38, 16);
                Console.Write(new string(' ', 40));
            }

            // MONTO AUTOMÁTICO
            double monto = Math.Round(cantidad * precioUni, 2);
            Utilities.DibujarCajaLectura(74, 15, monto.ToString("F2"), 10);

            // =====================================================
            // VENDEDOR + TOTAL
            // =====================================================
            Console.SetCursorPosition(10, 19);
            Console.Write("DNI VENDEDOR:");
            string dniVend = Utilities.LeerDNI(25, 19);

            Console.SetCursorPosition(62, 19);
            Console.Write("TOTAL:");
            Utilities.DibujarCajaLectura(69, 19, monto.ToString("F2"), 10);

            // =====================================================
            // GUARDAR O CANCELAR
            // =====================================================
            bool guardar = Utilities.MenuGuardarCancelar();

            if (guardar)
            {
                Numerador.ConsumirBoleta();

                LogicaVentas.GuardarBoleta(
                    numeroBoleta,
                    dniCliente,
                    nombreCliente,
                    dniVend,
                    codigoProd,
                    producto,
                    cantidad.ToString(),
                    precioUni.ToString(),
                    monto
                );

                Console.SetCursorPosition(30, 25);
                Console.Write("BOLETA GUARDADA.");
                Console.ReadKey();
            }
            else
            {
                Console.SetCursorPosition(30, 25);
                Console.Write("OPERACION CANCELADA.");
                Console.ReadKey();
            }
        }
    }
}
