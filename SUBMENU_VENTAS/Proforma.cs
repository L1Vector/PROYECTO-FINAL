using System;
using BIBLIOTECA_REGISTRA;

namespace SUBMENU_VENTAS
{
    public class Proforma
    {
        public static void Mostrar()
        {
            Utilities.LimpiarZonaTrabajo();
            Console.SetCursorPosition(38, 6);
            Console.Write("PROFORMA");

            Console.SetCursorPosition(10, 8);
            Console.Write("CLIENTE:");
            string cliente = Utilities.LeerCaja(20, 8, 30);

            string nroProforma = Numerador.VerProformaActual();
            Console.SetCursorPosition(60, 8);
            Console.Write("NRO PROFORMA:");
            Utilities.DibujarCajaLectura(75, 8, nroProforma, 10);

            // PRODUCTO AUTOCOMPLETADO
            Console.SetCursorPosition(10, 13); Console.Write("CODIGO");
            Console.SetCursorPosition(23, 13); Console.Write("PRODUCTO");
            Console.SetCursorPosition(38, 13); Console.Write("CANTIDAD");
            Console.SetCursorPosition(55, 13); Console.Write("PRECIO");
            Console.SetCursorPosition(74, 13); Console.Write("MONTO");

            string codigoProd;
            string producto;
            double precioUni;
            int stock;

            while (true)
            {
                Console.SetCursorPosition(10, 15);
                Console.Write(new string(' ', 10));
                codigoProd = Utilities.LeerCaja(10, 15, 10).ToUpper();

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

            Utilities.DibujarCajaLectura(23, 15, producto, 20);
            Utilities.DibujarCajaLectura(55, 15, precioUni.ToString("F2"), 10);

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
                Console.Write($"MAX {stock}");
                Console.ResetColor();
                System.Threading.Thread.Sleep(700);
                Console.SetCursorPosition(38, 16);
                Console.Write(new string(' ', 40));
            }

            double monto = Math.Round(cantidad * precioUni, 2);
            Utilities.DibujarCajaLectura(74, 15, monto.ToString("F2"), 10);

            // vendedor
            Console.SetCursorPosition(10, 19);
            Console.Write("DNI VENDEDOR:");
            string dniVend = Utilities.LeerDNI(25, 19);

            Console.SetCursorPosition(62, 19);
            Console.Write("TOTAL:");
            Utilities.DibujarCajaLectura(69, 19, monto.ToString("F2"), 10);

            bool guardar = Utilities.MenuGuardarCancelar();

            if (guardar)
            {
                Numerador.ConsumirProforma();

                LogicaVentas.GuardarProforma(
                    cliente,
                    nroProforma,
                    codigoProd,
                    producto,
                    cantidad.ToString(),
                    precioUni.ToString(),
                    monto,
                    dniVend
                );

                Console.SetCursorPosition(30, 25);
                Console.Write("PROFORMA GUARDADA.");
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
