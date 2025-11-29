using System;
using System.ComponentModel.Design;
using BIBLIOTECA_REGISTRA;

namespace SUBMENU_VENTAS
{
    public static class Utilities
    {
        // =====================================================
        // CAJA DE TEXTO
        // =====================================================
        public static string LeerCaja(int x, int y, int width = 15)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(x, y);
            Console.Write(new string(' ', width));
            Console.SetCursorPosition(x, y);

            string texto = "";
            ConsoleKeyInfo key;

            while (true)
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                    break;

                if (key.Key == ConsoleKey.Backspace && texto.Length > 0)
                {
                    texto = texto.Substring(0, texto.Length - 1);
                }
                else if (!char.IsControl(key.KeyChar) && texto.Length < width)
                {
                    texto += key.KeyChar;
                }

                Console.SetCursorPosition(x, y);
                Console.Write(texto + new string(' ', width - texto.Length));
            }

            Console.ResetColor();
            return texto.Trim();
        }

        // =====================================================
        // CAJA SOLO LECTURA
        // =====================================================
        public static void DibujarCajaLectura(int x, int y, string texto, int width = 12)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            if (texto.Length > width)
                texto = texto.Substring(0, width);

            Console.SetCursorPosition(x, y);
            Console.Write(new string(' ', width));

            Console.SetCursorPosition(x, y);
            Console.Write(texto);

            Console.ResetColor();
        }

        // =====================================================
        // LEER DNI
        // =====================================================
        public static string LeerDNI(int x, int y)
        {
            while (true)
            {
                string dni = LeerCaja(x, y, 30);

                if (dni.Length == 8 && long.TryParse(dni, out _))
                    return dni;

                Console.SetCursorPosition(x, y + 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("DNI inválido.");
                Console.ResetColor();
                System.Threading.Thread.Sleep(700);

                Console.SetCursorPosition(x, y + 1);
                Console.Write(new string(' ', 25));
                Console.SetCursorPosition(x, y);
            }
        }

        // =====================================================
        // LEER RUC
        // =====================================================
        public static string LeerRUC(int x, int y)
        {
            while (true)
            {
                string ruc = LeerCaja(x, y, 30);

                if (ruc.Length == 11 && long.TryParse(ruc, out _))
                    return ruc;

                Console.SetCursorPosition(x, y + 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("RUC inválido.");
                Console.ResetColor();
                System.Threading.Thread.Sleep(700);

                Console.SetCursorPosition(x, y + 1);
                Console.Write(new string(' ', 25));
                Console.SetCursorPosition(x, y);
            }
        }

        // =====================================================
        // LEER NUMERO
        // =====================================================
        public static double LeerNumero(int x, int y, int width = 10)
        {
            while (true)
            {
                string txt = LeerCaja(x, y, width);

                if (double.TryParse(txt, out double num) && num >= 0)
                    return num;

                Console.SetCursorPosition(x, y + 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Número inválido.");
                Console.ResetColor();
                System.Threading.Thread.Sleep(600);

                Console.SetCursorPosition(x, y + 1);
                Console.Write(new string(' ', 25));
                Console.SetCursorPosition(x, y);
            }
        }

        // =====================================================
        // BUSCAR CLIENTE
        // =====================================================
        public static string BuscarClientePorDNI(string dni)
        {
            for (int i = 0; i < BibliotecaRegistra.Clientes.GetLength(0); i++)
            {
                if (BibliotecaRegistra.Clientes[i, 0] == dni)
                    return BibliotecaRegistra.Clientes[i, 1] + " " +
                           BibliotecaRegistra.Clientes[i, 2];
            }
            return "";
        }

        // =====================================================
        // BUSCAR PRODUCTO
        // =====================================================
        public static string BuscarProductoPorCodigo(string codigo)
        {
            for (int i = 0; i < BibliotecaRegistra.Productos.GetLength(0); i++)
            {
                if (BibliotecaRegistra.Productos[i, 0].ToUpper() == codigo.ToUpper())
                    return BibliotecaRegistra.Productos[i, 1];
            }
            return "";
        }

        public static double BuscarPrecioPorCodigo(string codigo)
        {
            for (int i = 0; i < BibliotecaRegistra.Productos.GetLength(0); i++)
            {
                if (BibliotecaRegistra.Productos[i, 0].ToUpper() == codigo.ToUpper())
                {
                    double.TryParse(BibliotecaRegistra.Productos[i, 4], out double p);
                    return p;
                }
            }
            return 0;
        }

        public static int BuscarStockPorCodigo(string codigo)
        {
            for (int i = 0; i < BibliotecaRegistra.Productos.GetLength(0); i++)
            {
                if (BibliotecaRegistra.Productos[i, 0].ToUpper() == codigo.ToUpper())
                {
                    int.TryParse(BibliotecaRegistra.Productos[i, 3], out int s);
                    return s;
                }
            }
            return -1;
        }

        // MENÚ GUARDAR / CANCELAR (SIN CAMBIOS)
        // ===================================
        public static bool MenuGuardarCancelar(int y = 22, int xGuardar = 30, int xCancelar = 50)
        {
            string[] opciones = { "GUARDAR", "CANCELAR" };
            int seleccionado = 0; // 0 = GUARDAR, 1 = CANCELAR

            while (true)
            {
                // ---- GUARDAR ----
                Console.SetCursorPosition(xGuardar, y);
                if (seleccionado == 1)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write(" GUARDAR ");
                Console.ResetColor();

                // ---- CANCELAR ----
                Console.SetCursorPosition(xCancelar, y);
                if (seleccionado == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write(" CANCELAR ");
                Console.ResetColor();

                ConsoleKey tecla = Console.ReadKey(true).Key;

                if (tecla == ConsoleKey.LeftArrow)
                {
                    if (seleccionado == 1)
                        seleccionado--;
                }
                else if (tecla == ConsoleKey.RightArrow)
                {
                    seleccionado++;
                    if (seleccionado > 1)
                        seleccionado = 1;
                }
                else if (tecla == ConsoleKey.Enter)
                {
                    return seleccionado == 0; // true = guardar, false = cancelar
                }
            }
        }


        // =====================================================
        // LIMPIAR ZONA DE TRABAJO
        // =====================================================
        public static void LimpiarZonaTrabajo()
        {
            for (int y = 5; y <= 25; y++)
            {
                Console.SetCursorPosition(1, y);
                Console.Write(new string(' ', 88));
            }
        }
        public static string BuscarEmpresaPorRUC(string ruc)
        {
            for (int i = 0; i < BibliotecaRegistra.Proveedores.GetLength(0); i++)
            {
                if (BibliotecaRegistra.Proveedores[i, 2] == ruc) // columna 2 = RUC
                {
                    return BibliotecaRegistra.Proveedores[i, 1]; // columna 1 = Empresa
                }
            }
            return "";
        }

    }
}
