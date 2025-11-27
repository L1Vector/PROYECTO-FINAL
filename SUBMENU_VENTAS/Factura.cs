using System;

namespace SUBMENU_VENTAS
{
    public class Factura
    {
        public static void Mostrar()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ResetColor();

            DibujarMarco("FACTURA");

            // ===============================
            // DATOS PRINCIPALES
            // ===============================
            Console.SetCursorPosition(8, 6);
            Console.Write("RUC:");
            string ruc = Utilities.LeerRUC(15, 6);

            Console.SetCursorPosition(8, 8);
            Console.Write("EMPRESA:");
            string empresa = Utilities.LeerCaja(18, 8, 40);

            // Número mostrado sin consumir
            string nroFactura = Numerador.VerFacturaActual();
            Console.SetCursorPosition(62, 6);
            Console.Write("NRO FACTURA:");
            Console.SetCursorPosition(76, 6);
            Console.Write(nroFactura);

            // ===============================
            // TABLA PRODUCTO
            // ===============================
            Console.SetCursorPosition(8, 11); Console.Write("CODIGO");
            Console.SetCursorPosition(24, 11); Console.Write("PRODUCTO");
            Console.SetCursorPosition(50, 11); Console.Write("CANTIDAD");
            Console.SetCursorPosition(62, 11); Console.Write("PRECIO UNI");
            Console.SetCursorPosition(76, 11); Console.Write("MONTO");

            string codigo = Utilities.GenerarCodigoProducto();
            Console.SetCursorPosition(8, 13); Console.Write(codigo);

            Console.SetCursorPosition(24, 13);
            string producto = Utilities.LeerCaja(24, 13, 24);

            double cantidad = Utilities.LeerNumero(50, 13, 8);
            double precioUni = Utilities.LeerNumero(62, 13, 10);

            double monto = Math.Round(cantidad * precioUni, 2);
            Console.SetCursorPosition(76, 13);
            Console.Write(monto.ToString("F2"));

            // ===============================
            // VENDEDOR Y TOTAL
            // ===============================
            Console.SetCursorPosition(8, 17);
            Console.Write("DNI VENDEDOR:");
            string dniVendedor = Utilities.LeerDNI(22, 17);

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
                Numerador.ConsumirFactura();

                LogicaVentas.GuardarFactura(
                    ruc,
                    empresa,
                    nroFactura,
                    codigo,
                    producto,
                    cantidad.ToString(),
                    precioUni.ToString(),
                    monto,
                    dniVendedor
                );

                Console.SetCursorPosition(30, 25);
                Console.Write("FACTURA GUARDADA.");
                Console.ReadKey();
            }
            else
            {
                Console.SetCursorPosition(30, 25);
                Console.Write("OPERACION CANCELADA.");
                Console.ReadKey();
            }
        }

        // ===== MARCO =====
        static void DibujarMarco(string titulo)
        {
            for (int i = 4; i <= 26; i++)
            {
                Console.SetCursorPosition(6, i); Console.Write(" ");
                Console.SetCursorPosition(118, i); Console.Write(" ");
            }

            for (int i = 6; i <= 118; i++)
            {
                Console.SetCursorPosition(i, 4); Console.Write(" ");
                Console.SetCursorPosition(i, 26); Console.Write(" ");
            }

            Console.SetCursorPosition(44, 5);
            Console.Write(titulo);
        }
    }
}
