using System;

namespace SUBMENU_VENTAS
{
    public static class Utilities
    {
        // Contador de productos (código P001, P002...)
        private static int contadorProductos = 1;

        public static string GenerarCodigoProducto()
        {
            return "P" + contadorProductos++.ToString("000");
        }

        // ===================================
        // CAJA DE TEXTO - USUARIO ESCRIBE
        // ===================================
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
                    Console.SetCursorPosition(x, y);
                    Console.Write(texto + new string(' ', width - texto.Length));
                    Console.SetCursorPosition(x + texto.Length, y);
                }
                else if (!char.IsControl(key.KeyChar) && texto.Length < width)
                {
                    texto += key.KeyChar;
                    Console.SetCursorPosition(x, y);
                    Console.Write(texto);
                }
            }

            Console.ResetColor();
            return texto.Trim();
        }

        // ===================================
        // CAJA DE SOLO LECTURA (NUEVA)
        // ===================================
        public static void DibujarCajaLectura(int x, int y, string texto, int width = 12)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(x, y);
            Console.Write(new string(' ', width));

            if (texto.Length > width)
                texto = texto.Substring(0, width);

            Console.SetCursorPosition(x, y);
            Console.Write(texto);

            Console.ResetColor();
        }

        // ===================================
        // DNI – 8 dígitos
        // ===================================
        public static string LeerDNI(int x, int y)
        {
            while (true)
            {
                string dni = LeerCaja(x, y, 30);

                if (dni.Length == 8 && long.TryParse(dni, out _))
                    return dni;

                Console.SetCursorPosition(x, y + 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("DNI inválido. Solo 8 dígitos.");
                Console.ResetColor();

                System.Threading.Thread.Sleep(900);
                Console.SetCursorPosition(x, y + 1);
                Console.Write(new string(' ', 40));
                Console.SetCursorPosition(x, y);
                Console.Write(new string(' ', 8));
                Console.SetCursorPosition(x, y);
            }
        }

        // ===================================
        // RUC – 11 dígitos
        // ===================================
        public static string LeerRUC(int x, int y)
        {
            while (true)
            {
                string ruc = LeerCaja(x, y, 11);

                if (ruc.Length == 11 && long.TryParse(ruc, out _) && !ruc.StartsWith("-"))
                    return ruc;

                Console.SetCursorPosition(x, y + 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("RUC inválido. Debe tener 11 dígitos.");
                Console.ResetColor();

                System.Threading.Thread.Sleep(900);
                Console.SetCursorPosition(x, y + 1);
                Console.Write(new string(' ', 40));
                Console.SetCursorPosition(x, y);
                Console.Write(new string(' ', 11));
                Console.SetCursorPosition(x, y);
            }
        }

        // ===================================
        // LEER NÚMERO (cantidad, precio)
        // ===================================
        public static double LeerNumero(int x, int y, int width = 10)
        {
            while (true)
            {
                string txt = LeerCaja(x, y, width);
                if (double.TryParse(txt, out double num) && num >= 0)
                    return num;

                Console.SetCursorPosition(x, y + 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Valor inválido.");
                Console.ResetColor();

                System.Threading.Thread.Sleep(700);
                Console.SetCursorPosition(x, y + 1);
                Console.Write(new string(' ', 30));
                Console.SetCursorPosition(x, y);
                Console.Write(new string(' ', width));
                Console.SetCursorPosition(x, y);
            }
        }

        // ===================================
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


        public static void LimpiarZonaTrabajo()
        {
            for (int y = 5; y <= 25; y++)
            {
                Console.SetCursorPosition(1, y);
                Console.Write(new string(' ', 88));
            }
        }

    }
}
