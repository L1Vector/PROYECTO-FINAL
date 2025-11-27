using System;

namespace SUBMENU_VENTAS
{
    public class Boleta
    {
        public static void Mostrar()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ResetColor();

            Console.SetCursorPosition(50, 2);
            Console.Write("BOLETA DE VENTA");

            // ===============================
            // CAMPOS PRINCIPALES
            // ===============================
            Console.SetCursorPosition(10, 6);
            Console.Write("DNI CLIENTE:");
            string dniCliente = Utilities.LeerDNI(25, 6);

            Console.SetCursorPosition(10, 8);
            Console.Write("CLIENTE:");
            string nombreCliente = Utilities.LeerCaja(25, 8, 30);

            // Número mostrado pero NO consumido aún
            string numeroBoleta = Numerador.VerBoletaActual();
            Console.SetCursorPosition(60, 6);
            Console.Write("NRO BOLETA:");
            Console.SetCursorPosition(75, 6);
            Console.Write(numeroBoleta);

            // ===============================
            // TABLA DE PRODUCTO
            // ===============================
            Console.SetCursorPosition(10, 11); Console.Write("CODIGO");
            Console.SetCursorPosition(23, 11); Console.Write("PRODUCTO");
            Console.SetCursorPosition(38, 11); Console.Write("CANTIDAD");
            Console.SetCursorPosition(55, 11); Console.Write("PRECIO UNI");
            Console.SetCursorPosition(74, 11); Console.Write("MONTO");

            string codigoProducto = Utilities.GenerarCodigoProducto();
            Console.SetCursorPosition(10, 13);
            Console.Write(codigoProducto);

            Console.SetCursorPosition(20, 13);
            string producto = Utilities.LeerCaja(23, 13, 8);

            double cantidad = Utilities.LeerNumero(38, 13, 8);
            double precioUni = Utilities.LeerNumero(55, 13, 10);

            double monto = Math.Round(cantidad * precioUni, 2);
            Console.SetCursorPosition(74, 13);
            Console.Write(monto.ToString("F2"));

            // ===============================
            // DATOS DEL VENDEDOR Y TOTAL
            // ===============================
            Console.SetCursorPosition(10, 17);
            Console.Write("DNI VENDEDOR:");
            string dniVendedor = Utilities.LeerDNI(25, 17);

            Console.SetCursorPosition(62, 17);
            Console.Write("TOTAL:");
            Console.SetCursorPosition(69, 17);
            Console.Write(monto.ToString("F2"));

            // ===============================
            // BOTONES FINALES
            // ===============================
            bool guardar = Utilities.MenuGuardarCancelar();

            if (guardar)
            {
                // AHORA SÍ CONSUMIMOS EL NÚMERO
                Numerador.ConsumirBoleta();

                LogicaVentas.GuardarBoleta(
                    numeroBoleta,
                    dniCliente,
                    nombreCliente,
                    dniVendedor,
                    codigoProducto,
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
