using System;

namespace SUBMENU_VENTAS
{
    public class Boleta
    {
        public static void Mostrar()
        {
            Utilities.LimpiarZonaTrabajo();
            Console.SetCursorPosition(38, 6);
            Console.Write("BOLETA DE VENTA");



            // CAMPOS PRINCIPALES

            Console.SetCursorPosition(10, 8);
            Console.Write("DNI CLIENTE:");
            string dniCliente = Utilities.LeerDNI(25, 8);

            Console.SetCursorPosition(10, 10);
            Console.Write("CLIENTE:");
            string nombreCliente = Utilities.LeerCaja(25, 10, 30);

            // Número mostrado pero NO consumido
            string numeroBoleta = Numerador.VerBoletaActual();
            Console.SetCursorPosition(60, 8);
            Console.Write("NRO BOLETA:");
            Utilities.DibujarCajaLectura(73, 8, numeroBoleta, 10);


            // TABLA DE PRODUCTO

            Console.SetCursorPosition(10, 13); Console.Write("CODIGO");
            Console.SetCursorPosition(23, 13); Console.Write("PRODUCTO");
            Console.SetCursorPosition(38, 13); Console.Write("CANTIDAD");
            Console.SetCursorPosition(55, 13); Console.Write("PRECIO UNI");
            Console.SetCursorPosition(74, 13); Console.Write("MONTO");

            string codigoProducto = Utilities.GenerarCodigoProducto();
            Console.SetCursorPosition(10, 15);
            Console.Write(codigoProducto);

            Console.SetCursorPosition(20, 15);
            string producto = Utilities.LeerCaja(23, 15, 8);

            double cantidad = Utilities.LeerNumero(38, 15, 8);
            double precioUni = Utilities.LeerNumero(55, 15, 10);

            double monto = Math.Round(cantidad * precioUni, 2);
            Console.SetCursorPosition(74, 15);
            Utilities.DibujarCajaLectura(74, 15, monto.ToString("F2"), 10);


            // DATOS DEL VENDEDOR Y TOTAL

            Console.SetCursorPosition(10, 19);
            Console.Write("DNI VENDEDOR:");
            string dniVendedor = Utilities.LeerDNI(25, 19);

            Console.SetCursorPosition(62, 19);
            Console.Write("TOTAL:");
            Utilities.DibujarCajaLectura(69, 19, monto.ToString("F2"), 10);


            // BOTONES FINALES

            bool guardar = Utilities.MenuGuardarCancelar();

            if (guardar)
            {
                // Ahora SÍ se consume el número
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
        public static void DibujarMarco()
        {
            Console.BackgroundColor = ConsoleColor.Black;

            for (int i = 4; i <= 26; i++)
            {
                Console.SetCursorPosition(6, i); Console.Write(" ");
                Console.SetCursorPosition(86, i); Console.Write(" ");
            }

            for (int i = 6; i <= 86; i++)
            {
                Console.SetCursorPosition(i, 4); Console.Write(" ");
                Console.SetCursorPosition(i, 26); Console.Write(" ");
            }

            Console.SetCursorPosition(34, 5);
            Console.Write("BOLETA DE VENTA");

            Console.ResetColor();
        }

    }
}
