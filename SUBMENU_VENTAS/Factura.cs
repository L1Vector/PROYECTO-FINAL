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

            Console.SetCursorPosition(10, 10);
            Console.Write("EMPRESA:");
            Utilities.DibujarCajaLectura(20, 10, empresa, 30);

            string nroFactura = Numerador.VerFacturaActual();
            Console.SetCursorPosition(60, 8);
            Console.Write("NRO FACTURA:");
            Utilities.DibujarCajaLectura(73, 8, nroFactura, 10);

            // =====================================================
            // TABLA
            // =====================================================
            Console.SetCursorPosition(10, 13); Console.Write("CODIGO");
            Console.SetCursorPosition(23, 13); Console.Write("PRODUCTO");
            Console.SetCursorPosition(38, 13); Console.Write("CANTIDAD");
            Console.SetCursorPosition(55, 13); Console.Write("PRECIO UNI");
            Console.SetCursorPosition(74, 13); Console.Write("MONTO");

            double totalFactura = 0;

            // =====================================================
            // BUCLE MULTIPRODUCTO
            // =====================================================
            while (true)
            {
                string codigoProd;
                string producto;
                double precioUni;
                int stock;

                // ====== INGRESAR CÓDIGO ======
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

                Utilities.DibujarCajaLectura(23, 15, producto, 10);
                Utilities.DibujarCajaLectura(55, 15, precioUni.ToString("F2"), 10);

                // ====== CANTIDAD ======
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

                double monto = Math.Round(cantidad * precioUni, 2);
                Utilities.DibujarCajaLectura(74, 15, monto.ToString("F2"), 10);

                totalFactura += monto;

                // =====================================================
                // GUARDAR FILA DEL PRODUCTO
                // =====================================================
                LogicaVentas.GuardarFactura(
                    ruc,
                    empresa,
                    nroFactura,
                    codigoProd,
                    producto,
                    cantidad.ToString(),
                    precioUni.ToString("F2"),
                    monto,
                    "" // vendedor se coloca después
                );

                // =====================================================
                // PREGUNTA: ¿AGREGAR OTRO PRODUCTO?
                // =====================================================
                string resp = "";

                while (true)
                {
                    Console.SetCursorPosition(25, 18);
                    Console.Write(new string(' ', 40));
                    Console.SetCursorPosition(25, 18);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("¿Desea agregar otro producto? (S/N): ");
                    Console.ResetColor();

                    resp = Console.ReadLine().Trim().ToUpper();

                    if (resp == "S" || resp == "N")
                        break;

                    Console.SetCursorPosition(25, 19);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ERROR: Solo ingrese S o N");
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(900);

                    Console.SetCursorPosition(25, 19);
                    Console.Write(new string(' ', 40));
                }

                Console.SetCursorPosition(25, 18);
                Console.Write(new string(' ', 40));

                if (resp == "N") break;

                // LIMPIAR PARA SIGUIENTE PRODUCTO
                Console.SetCursorPosition(10, 15); Console.Write(new string(' ', 80));
                Console.SetCursorPosition(10, 16); Console.Write(new string(' ', 80));
                Console.SetCursorPosition(10, 15);
            }

            // =====================================================
            // VENDEDOR + TOTAL
            // =====================================================
            Console.SetCursorPosition(10, 19);
            Console.Write("DNI VENDEDOR:");
            string dniVend = Utilities.LeerDNI(25, 19);

            Console.SetCursorPosition(62, 19);
            Console.Write("TOTAL:");
            Utilities.DibujarCajaLectura(69, 19, totalFactura.ToString("F2"), 10);

            // =====================================================
            // GUARDAR O CANCELAR
            // =====================================================
            bool guardar = Utilities.MenuGuardarCancelar();

            if (guardar)
            {
                Numerador.ConsumirFactura();

                // ASIGNAR VENDEDOR A TODAS LAS FILAS DE ESTA FACTURA
                for (int i = 0; i < LogicaVentas.Documentos.GetLength(0); i++)
                {
                    if (LogicaVentas.Documentos[i, 1] == nroFactura)
                    {
                        LogicaVentas.Documentos[i, 4] = dniVend;
                    }
                }

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
