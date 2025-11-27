using System;

namespace SUBMENU_VENTAS
{
    public class GuiaRemision
    {
        public static void Mostrar()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ResetColor();

            DibujarMarco("GUIA DE REMISION");

            // ===============================
            // DATOS PRINCIPALES
            // ===============================
            Console.SetCursorPosition(8, 6);
            Console.Write("DNI CLIENTE:");
            string dniCliente = Utilities.LeerDNI(22, 6);

            Console.SetCursorPosition(40, 6);
            Console.Write("CLIENTE:");
            string cliente = Utilities.LeerCaja(48, 6, 32);

            Console.SetCursorPosition(8, 8);
            Console.Write("TRANSPORTISTA:");
            string transportista = Utilities.LeerCaja(24, 8, 30);

            // Número NO consumido aún
            string nroGuia = Numerador.VerGuiaActual();
            Console.SetCursorPosition(86, 6);
            Console.Write("NRO GUIA:");
            Console.SetCursorPosition(96, 6);
            Console.Write(nroGuia);

            // ===============================
            // TABLA PRODUCTO
            // ===============================
            Console.SetCursorPosition(8, 11); Console.Write("CODIGO");
            Console.SetCursorPosition(24, 11); Console.Write("PRODUCTO");
            Console.SetCursorPosition(50, 11); Console.Write("CANTIDAD");
            Console.SetCursorPosition(62, 11); Console.Write("PRECIO UNI");
            Console.SetCursorPosition(74, 11); Console.Write("PESO KG");
            Console.SetCursorPosition(86, 11); Console.Write("MONTO");

            string codigo = Utilities.GenerarCodigoProducto();
            Console.SetCursorPosition(8, 13); Console.Write(codigo);

            Console.SetCursorPosition(24, 13);
            string producto = Utilities.LeerCaja(24, 13, 24);

            double cantidad = Utilities.LeerNumero(50, 13, 8);
            double precioUni = Utilities.LeerNumero(62, 13, 10);
            double pesoKg = Utilities.LeerNumero(74, 13, 8);

            double monto = Math.Round(cantidad * precioUni, 2);
            Console.SetCursorPosition(86, 13);
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
                Numerador.ConsumirGuia();

                LogicaVentas.GuardarGuiaRemision(
                    nroGuia,
                    dniCliente,
                    cliente,
                    transportista,
                    codigo,
                    producto,
                    cantidad.ToString(),
                    precioUni.ToString(),
                    pesoKg.ToString(),
                    monto,
                    dniVendedor
                );

                Console.SetCursorPosition(30, 25);
                Console.Write("GUIA GUARDADA.");
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
