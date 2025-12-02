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

            // DATOS PRINCIPALES

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

            Console.SetCursorPosition(10, 10);
            Console.Write("CLIENTE:");
            Utilities.DibujarCajaLectura(25, 10, nombreCliente, 30);

            string numeroBoleta = Numerador.VerBoletaActual();
            Console.SetCursorPosition(60, 8);
            Console.Write("NRO BOLETA:");
            Utilities.DibujarCajaLectura(73, 8, numeroBoleta, 10);

            // TABLA

            Console.SetCursorPosition(10, 13); Console.Write("CODIGO");
            Console.SetCursorPosition(23, 13); Console.Write("PRODUCTO");
            Console.SetCursorPosition(38, 13); Console.Write("CANTIDAD");
            Console.SetCursorPosition(55, 13); Console.Write("PRECIO UNI");
            Console.SetCursorPosition(74, 13); Console.Write("MONTO");

            double totalBoleta = 0;

            // ========= AGREGAR VARIOS PRODUCTOS =============

            while (true)
            {
                string codigoProd;
                string producto;
                double precioUni;
                int stock;

                // ===== CÓDIGO =====
                while (true)
                {
                    Console.SetCursorPosition(10, 15);
                    Console.Write(new string(' ', 10));
                    codigoProd = Utilities.LeerCaja(10, 15, 8).ToUpper();

                    producto = Utilities.BuscarProductoPorCodigo(codigoProd);
                    precioUni = Utilities.BuscarPrecioPorCodigo(codigoProd);
                    stock = Utilities.BuscarStockPorCodigo(codigoProd);

                    if (producto != "" && stock >= 0) break;

                    Console.SetCursorPosition(10, 16);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Código NO existe");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.SetCursorPosition(10, 16);
                    Console.Write(new string(' ', 40));
                }

                Utilities.DibujarCajaLectura(23, 15, producto, 12);
                Utilities.DibujarCajaLectura(55, 15, precioUni.ToString("F2"), 10);

                // ===== CANTIDAD =====
                double cantidad;

                // Si NO hay stock - mostrar mensaje y saltar a la pregunta S/N
                if (stock == 0)
                {
                    Console.SetCursorPosition(25, 18);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("PRODUCTO SIN STOCK.");
                    Console.ResetColor();
                    Console.ReadKey();

                    cantidad = 0; // No genera monto
                }
                else
                {
                    while (true)
                    {
                        Console.SetCursorPosition(38, 15);
                        Console.Write(new string(' ', 8));
                        cantidad = Utilities.LeerNumero(38, 15, 8);

                        if (cantidad <= 0)
                        {
                            Console.SetCursorPosition(38, 16);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Cantidad debe ser mayor a 0");
                            Console.ResetColor();
                            Console.ReadKey();
                            Console.SetCursorPosition(38, 16);
                            Console.Write(new string(' ', 40));
                            continue;
                        }

                        if (cantidad > stock)
                        {
                            Console.SetCursorPosition(38, 16);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"Stock insuficiente (MAX {stock})");
                            Console.ResetColor();
                            Console.ReadKey();
                            Console.SetCursorPosition(38, 16);
                            Console.Write(new string(' ', 50));
                            continue;
                        }

                        // RESTAR STOCK
                        int nuevoStock = stock - (int)cantidad;

                        for (int i = 0; i < BIBLIOTECA_REGISTRA.Arreglos.Productos.GetLength(0); i++)
                        {
                            if (BIBLIOTECA_REGISTRA.Arreglos.Productos[i, 0] == codigoProd)
                            {
                                BIBLIOTECA_REGISTRA.Arreglos.Productos[i, 3] = nuevoStock.ToString();
                                break;
                            }
                        }

                        break;
                    }
                }

                double monto = Math.Round(cantidad * precioUni, 2);
                if (cantidad > 0)
                {
                    Utilities.DibujarCajaLectura(74, 15, monto.ToString("F2"), 10);
                    totalBoleta += monto;

                    // GUARDAR PRODUCTO INDIVIDUAL
                    LogicaVentas.GuardarBoleta(
                        numeroBoleta,
                        dniCliente,
                        nombreCliente,
                        "",
                        codigoProd,
                        producto,
                        cantidad.ToString(),
                        precioUni.ToString("F2"),
                        monto
                    );
                }

                // ======= PREGUNTA S/N =======
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
                    Console.ReadKey();
                    Console.SetCursorPosition(25, 19);
                    Console.Write(new string(' ', 40));
                }

                Console.SetCursorPosition(25, 18);
                Console.Write(new string(' ', 40));

                if (resp == "N")
                    break;

                // LIMPIAR LINEA
                Console.SetCursorPosition(10, 15); Console.Write(new string(' ', 80));
                Console.SetCursorPosition(10, 16); Console.Write(new string(' ', 80));
                Console.SetCursorPosition(10, 15);
            }

            // =====================================================
            // VENDEDOR + TOTAL FINAL
            // =====================================================

            Console.SetCursorPosition(10, 19);
            Console.Write("DNI VENDEDOR:");
            string dniVend = Utilities.LeerDNI(25, 19);

            Console.SetCursorPosition(62, 19);
            Console.Write("TOTAL:");
            Utilities.DibujarCajaLectura(69, 19, totalBoleta.ToString("F2"), 10);

            // GUARDAR O CANCELAR

            bool guardar = Utilities.MenuGuardarCancelar();

            if (guardar)
            {
                Numerador.ConsumirBoleta();

                for (int i = 0; i < LogicaVentas.Documentos.GetLength(0); i++)
                {
                    if (LogicaVentas.Documentos[i, 1] == numeroBoleta)
                    {
                        LogicaVentas.Documentos[i, 4] = dniVend;
                    }
                }

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
