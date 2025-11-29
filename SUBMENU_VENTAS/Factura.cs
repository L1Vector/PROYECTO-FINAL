using System;
using BIBLIOTECA_REGISTRA;

namespace SUBMENU_VENTAS
{
    public class Factura
    {
        public static void Mostrar()
        {
            Utilities.LimpiarZonaTrabajo();
            Console.SetCursorPosition(38, 6);
            Console.Write("FACTURA");

            // =====================================================
            // DATOS PRINCIPALES
            // =====================================================
            Console.SetCursorPosition(10, 8);
            Console.Write("RUC:");
            string ruc = Utilities.LeerRUC(20, 8);

            // Buscar empresa por RUC
            string empresa = Utilities.BuscarEmpresaPorRUC(ruc);

            if (string.IsNullOrEmpty(empresa))
            {
                Console.SetCursorPosition(20, 10);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("RUC NO REGISTRADO. Registre la empresa primero.");
                Console.ResetColor();
                Console.ReadKey();

                Utilities.LimpiarZonaTrabajo();
                return;
            }

            // Mostrar empresa
            Console.SetCursorPosition(10, 10);
            Console.Write("EMPRESA:");
            Utilities.DibujarCajaLectura(20, 10, empresa, 30);

            // Nº de factura no consumido aún
            string nroFactura = Numerador.VerFacturaActual();
            Console.SetCursorPosition(60, 8);
            Console.Write("NRO FACTURA:");
            Utilities.DibujarCajaLectura(73, 8, nroFactura, 10);

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

            // MOSTRAR PRODUCTO Y PRECIO AUTOMÁTICO
            Utilities.DibujarCajaLectura(23, 15, producto, 10);
            Utilities.DibujarCajaLectura(55, 15, precioUni.ToString("F2"), 10);

            // ====== VALIDAR CANTIDAD ======
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
                Numerador.ConsumirFactura();

                LogicaVentas.GuardarFactura(
                    ruc,
                    empresa,
                    nroFactura,
                    codigoProd,
                    producto,
                    cantidad.ToString(),
                    precioUni.ToString(),
                    monto,
                    dniVend
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
    }
}
