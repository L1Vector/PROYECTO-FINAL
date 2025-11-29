using System;
using BIBLIOTECA_REGISTRA;

namespace SUBMENU_VENTAS
{
    public class GuiaRemision
    {
        public static void Mostrar()
        {
            Utilities.LimpiarZonaTrabajo();
            Console.SetCursorPosition(35, 6);
            Console.Write("GUIA DE REMISIÓN");

            // Cliente
            Console.SetCursorPosition(10, 8);
            Console.Write("DNI CLIENTE:");
            string dniCliente = Utilities.LeerDNI(25, 8);

            string nombreCliente = Utilities.BuscarClientePorDNI(dniCliente);
            Utilities.DibujarCajaLectura(25, 10, nombreCliente, 30);

            // Transportista
            Console.SetCursorPosition(10, 12);
            Console.Write("TRANSPORTISTA:");
            string transportista = Utilities.LeerCaja(25, 12, 30);

            // Número guía
            string nroGuia = Numerador.VerGuiaActual();
            Console.SetCursorPosition(60, 8);
            Console.Write("NRO GUIA:");
            Utilities.DibujarCajaLectura(73, 8, nroGuia, 10);

            // Tabla producto
            Console.SetCursorPosition(10, 15); Console.Write("CODIGO");
            Console.SetCursorPosition(25, 15); Console.Write("PRODUCTO");
            Console.SetCursorPosition(45, 15); Console.Write("CANT.");
            Console.SetCursorPosition(55, 15); Console.Write("PRECIO");
            Console.SetCursorPosition(67, 15); Console.Write("PESO");
            Console.SetCursorPosition(77, 15); Console.Write("MONTO");

            string codigoProd;
            string producto;
            double precioUni;
            int stock;

            while (true)
            {
                Console.SetCursorPosition(10, 17);
                Console.Write(new string(' ', 10));
                codigoProd = Utilities.LeerCaja(10, 17, 10).ToUpper();

                producto = Utilities.BuscarProductoPorCodigo(codigoProd);
                precioUni = Utilities.BuscarPrecioPorCodigo(codigoProd);
                stock = Utilities.BuscarStockPorCodigo(codigoProd);

                if (producto != "" && stock >= 0)
                    break;

                Console.SetCursorPosition(10, 18);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Código NO existe");
                Console.ResetColor();
                System.Threading.Thread.Sleep(700);

                Console.SetCursorPosition(10, 18);
                Console.Write(new string(' ', 40));
            }

            Utilities.DibujarCajaLectura(25, 17, producto, 20);
            Utilities.DibujarCajaLectura(55, 17, precioUni.ToString("F2"), 10);

            double cantidad;
            while (true)
            {
                Console.SetCursorPosition(45, 17);
                Console.Write(new string(' ', 8));
                cantidad = Utilities.LeerNumero(45, 17, 8);

                if (cantidad <= stock)
                    break;

                Console.SetCursorPosition(45, 18);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"MAX {stock}");
                Console.ResetColor();
                System.Threading.Thread.Sleep(700);
                Console.SetCursorPosition(45, 18);
                Console.Write(new string(' ', 20));
            }

            Console.SetCursorPosition(67, 17);
            double pesoKg = Utilities.LeerNumero(67, 17, 8);

            double monto = Math.Round(cantidad * precioUni, 2);
            Utilities.DibujarCajaLectura(77, 17, monto.ToString("F2"), 10);

            // Vendedor
            Console.SetCursorPosition(10, 21);
            Console.Write("DNI VENDEDOR:");
            string dniVend = Utilities.LeerDNI(25, 21);

            Console.SetCursorPosition(60, 21);
            Console.Write("TOTAL:");
            Utilities.DibujarCajaLectura(67, 21, monto.ToString("F2"), 10);

            bool guardar = Utilities.MenuGuardarCancelar();

            if (guardar)
            {
                Numerador.ConsumirGuia();

                LogicaVentas.GuardarGuiaRemision(
                    nroGuia, dniCliente, nombreCliente, transportista,
                    codigoProd, producto,
                    cantidad.ToString(),
                    precioUni.ToString(),
                    pesoKg.ToString(),
                    monto, dniVend
                );

                Console.SetCursorPosition(25, 25);
                Console.Write("GUIA GUARDADA.");
                Console.ReadKey();
            }
            else
            {
                Console.SetCursorPosition(25, 25);
                Console.Write("OPERACION CANCELADA.");
                Console.ReadKey();
            }
        }
    }
}
