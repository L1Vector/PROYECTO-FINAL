using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIBLIOTECA_REGISTRA
{
    public static class BibliotecaRegistra
    {

        // 1. DEFINICIÓN DE ARREGLOS GLOBALES (Public para que Program pueda leerlos)
        public static string[,] Productos = new string[0, 5];
        public static string[,] Clientes = new string[0, 6];
        public static string[,] Vendedores = new string[0, 5];
        public static string[,] Proveedores = new string[0, 7];

        // 2. FUNCIÓN AUXILIAR PARA AÑADIR FILA
        // Esta función incrementa el tamaño del arreglo bidimensional en una fila 
        // y añade los nuevos datos al final.
        public static string[,] AgregarFila(string[,] original, string[] nuevaFila)
        {
            int numFilas = original.GetLength(0);
            int numCols = original.GetLength(1);
            int nuevaNumFilas = numFilas + 1;

            // Crear el nuevo arreglo con una fila más
            string[,] nuevoArray = new string[nuevaNumFilas, numCols];

            // Copiar los datos del arreglo original
            for (int i = 0; i < numFilas; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    nuevoArray[i, j] = original[i, j];
                }
            }

            // Insertar la nueva fila en el último índice
            for (int j = 0; j < numCols; j++)
            {
                nuevoArray[numFilas, j] = nuevaFila[j];
            }

            return nuevoArray;
        }

        // Función auxiliar de interfaz para limpiar el área del formulario antes de registrar
        private static void LimpiarAreaRegistro(int filaInicial)
        {
            int ancho = Console.WindowWidth;
            // Limpia desde la fila inicial hasta el final de la ventana
            for (int i = filaInicial; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', ancho));
            }
            // Devuelve el cursor a la posición inicial
            Console.SetCursorPosition(0, filaInicial);
        }

        // 3. REGISTRAR PRODUCTO
        public static void RegistrarProducto()
        {
            const int FILA_INICIO_FORMULARIO = 8;
            string[] nuevoProducto = new string[5];
            string titulo = "REGISTRAR PRODUCTOS";

            int anchoConsola = Console.WindowWidth;

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            Console.SetCursorPosition(0, FILA_INICIO_FORMULARIO);

            Console.WriteLine(new string(' ', (anchoConsola - titulo.Length) / 2) + titulo);
            Console.WriteLine(new string('-', anchoConsola));

            // 1. CÓDIGO (Unicidad y No Vacío)
            while (true)
            {
                Console.Write("Ingrese Código del Producto (Único): ");
                string codigo = Console.ReadLine().Trim().ToUpper();

                if (string.IsNullOrWhiteSpace(codigo)) { Console.WriteLine("Error: El código no puede estar vacío."); }
                else
                {
                    bool repetido = false;
                    for (int i = 0; i < Productos.GetLength(0); i++)
                    {
                        if (Productos[i, 0].Equals(codigo)) { repetido = true; break; }
                    }
                    if (repetido) { Console.WriteLine("Error: El código de producto ya existe y debe ser único."); }
                    else { nuevoProducto[0] = codigo; break; }
                }
            }

            // 2. NOMBRE (Unicidad y No Vacío)
            while (true)
            {
                Console.Write("Ingrese Nombre del Producto (Único): ");
                string nombre = Console.ReadLine().Trim().ToUpper();

                if (string.IsNullOrWhiteSpace(nombre)) { Console.WriteLine("Error: El nombre no puede estar vacío."); }
                else
                {
                    bool repetido = false;
                    for (int i = 0; i < Productos.GetLength(0); i++)
                    {
                        if (Productos[i, 1].Equals(nombre)) { repetido = true; break; }
                    }
                    if (repetido) { Console.WriteLine("Error: El nombre de producto ya existe y debe ser único."); }
                    else { nuevoProducto[1] = nombre; break; }
                }
            }

            // 3. CATEGORÍA (No Vacío)
            while (true)
            {
                Console.Write("Ingrese Categoría: ");
                string categoria = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(categoria)) { Console.WriteLine("Error: La categoría no puede estar vacía."); }
                else { nuevoProducto[2] = categoria; break; }
            }

            // 4. STOCK (Solo números enteros y >= 0)
            while (true)
            {
                Console.Write("Ingrese Stock (Solo números): ");
                string inputStock = Console.ReadLine().Trim();
                // Intenta convertir a entero, verifica que sea válido y no negativo
                if (int.TryParse(inputStock, out int stock) && stock >= 0) { nuevoProducto[3] = stock.ToString(); break; }
                else { Console.WriteLine("Error: El stock debe ser un número entero positivo o cero."); }
            }

            // 5. PRECIO UNITARIO (Solo números decimales y > 0)
            while (true)
            {
                Console.Write("Ingrese Precio Unitario (Solo números): ");
                string inputPrecio = Console.ReadLine().Trim();
                // Intenta convertir a decimal, verifica que sea válido y positivo
                if (decimal.TryParse(inputPrecio, out decimal precio) && precio > 0) { nuevoProducto[4] = precio.ToString(); break; }
                else { Console.WriteLine("Error: El precio debe ser un número decimal positivo."); }
            }

            // Añadir el nuevo producto al arreglo global
            Productos = AgregarFila(Productos, nuevoProducto);

            Console.WriteLine("\nProducto registrado con éxito. Presione una tecla para volver al menú.");
            Console.ReadKey();
            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
        }

        // 4. REGISTRAR CLIENTE
        public static void RegistrarCliente()
        {
            const int FILA_INICIO_FORMULARIO = 8;
            string[] nuevoCliente = new string[6];
            string titulo = "REGISTRAR CLIENTES";

            int anchoConsola = Console.WindowWidth;

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            Console.SetCursorPosition(0, FILA_INICIO_FORMULARIO);

            Console.WriteLine(new string(' ', (anchoConsola - titulo.Length) / 2) + titulo);
            Console.WriteLine(new string('-', anchoConsola));

            // 1. DNI (8 DÍGITOS y Unicidad)
            while (true)
            {
                Console.Write("Ingrese DNI Cliente (Único, 8 dígitos): ");
                string dni = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(dni)) { Console.WriteLine("Error: El DNI no puede estar vacío."); }
                else if (!dni.All(char.IsDigit)) { Console.WriteLine("Error: El DNI debe contener solo números."); }
                else if (dni.Length != 8) { Console.WriteLine("Error: El DNI debe tener exactamente 8 dígitos."); }
                else
                {
                    bool repetido = false;
                    for (int i = 0; i < Clientes.GetLength(0); i++)
                    {
                        if (Clientes[i, 0].Equals(dni)) { repetido = true; break; }
                    }
                    if (repetido) { Console.WriteLine("Error: El DNI de cliente ya existe y debe ser único."); }
                    else { nuevoCliente[0] = dni; break; }
                }
            }

            // 2. NOMBRES (No Vacío)
            while (true)
            {
                Console.Write("Ingrese Nombres: ");
                string nombres = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(nombres)) { Console.WriteLine("Error: Los nombres no pueden estar vacíos."); }
                else { nuevoCliente[1] = nombres; break; }
            }

            // 3. APELLIDOS (No Vacío)
            while (true)
            {
                Console.Write("Ingrese Apellidos: ");
                string apellidos = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(apellidos)) { Console.WriteLine("Error: Los apellidos no pueden estar vacíos."); }
                else { nuevoCliente[2] = apellidos; break; }
            }

            // 4. TELÉFONO (9 DÍGITOS)
            while (true)
            {
                Console.Write("Ingrese Teléfono (9 dígitos): ");
                string telefono = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(telefono)) { Console.WriteLine("Error: El teléfono no puede estar vacío."); }
                else if (!telefono.All(char.IsDigit)) { Console.WriteLine("Error: El teléfono debe contener solo números."); }
                else if (telefono.Length != 9) { Console.WriteLine("Error: El teléfono debe tener exactamente 9 dígitos."); }
                else { nuevoCliente[3] = telefono; break; }
            }

            // 5. EMAIL (Obligatorio)
            while (true)
            {
                Console.Write("Ingrese Email: ");
                string email = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(email)) { Console.WriteLine("Error: El Email no puede estar vacío."); }
                else { nuevoCliente[4] = email; break; }
            }

            // 6. DIRECCIÓN (No Vacío)
            while (true)
            {
                Console.Write("Ingrese Dirección: ");
                string direccion = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(direccion)) { Console.WriteLine("Error: La dirección no puede estar vacía."); }
                else { nuevoCliente[5] = direccion; break; }
            }

            Clientes = AgregarFila(Clientes, nuevoCliente);

            Console.WriteLine("\nCliente registrado con éxito. Presione una tecla para volver al menú.");
            Console.ReadKey();
            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
        }

        // 5. REGISTRAR VENDEDORES
        public static void RegistrarVendedor()
        {
            const int FILA_INICIO_FORMULARIO = 8;
            string[] nuevoVendedor = new string[5];
            string titulo = "REGISTRAR VENDEDORES";

            int anchoConsola = Console.WindowWidth;

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            Console.SetCursorPosition(0, FILA_INICIO_FORMULARIO);

            Console.WriteLine(new string(' ', (anchoConsola - titulo.Length) / 2) + titulo);
            Console.WriteLine(new string('-', anchoConsola));

            // 1. CÓDIGO VENDEDOR (Unicidad y No Vacío)
            while (true)
            {
                Console.Write("Ingrese Código de Vendedor (Único): ");
                string codigo = Console.ReadLine().Trim().ToUpper();

                if (string.IsNullOrWhiteSpace(codigo)) { Console.WriteLine("Error: El código no puede estar vacío."); }
                else
                {
                    bool repetido = false;
                    for (int i = 0; i < Vendedores.GetLength(0); i++)
                    {
                        if (Vendedores[i, 0].Equals(codigo)) { repetido = true; break; }
                    }
                    if (repetido) { Console.WriteLine("Error: El código de vendedor ya existe y debe ser único."); }
                    else { nuevoVendedor[0] = codigo; break; }
                }
            }

            // 2. NOMBRES (No Vacío)
            while (true)
            {
                Console.Write("Ingrese Nombres: ");
                string nombres = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(nombres)) { Console.WriteLine("Error: Los nombres no pueden estar vacíos."); }
                else { nuevoVendedor[1] = nombres; break; }
            }

            // 3. APELLIDOS (No Vacío)
            while (true)
            {
                Console.Write("Ingrese Apellidos: ");
                string apellidos = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(apellidos)) { Console.WriteLine("Error: Los apellidos no pueden estar vacíos."); }
                else { nuevoVendedor[2] = apellidos; break; }
            }

            // 4. SUELDO (Solo números decimales y > 0)
            while (true)
            {
                Console.Write("Ingrese Sueldo (Solo números): ");
                string inputSueldo = Console.ReadLine().Trim();
                // Intenta convertir a decimal, verifica que sea válido y positivo
                if (decimal.TryParse(inputSueldo, out decimal sueldo) && sueldo > 0) { nuevoVendedor[3] = sueldo.ToString(); break; }
                else { Console.WriteLine("Error: El sueldo debe ser un número positivo."); }
            }

            // 5. TELÉFONO (Solo números y No Vacío)
            while (true)
            {
                Console.Write("Ingrese Teléfono (Solo números): ");
                string telefono = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(telefono)) { Console.WriteLine("Error: El teléfono no puede estar vacío."); }
                else if (!telefono.All(char.IsDigit)) { Console.WriteLine("Error: El teléfono debe contener solo números."); }
                else { nuevoVendedor[4] = telefono; break; }
            }

            Vendedores = AgregarFila(Vendedores, nuevoVendedor);

            Console.WriteLine("\nVendedor registrado con éxito. Presione una tecla para volver al menú.");
            Console.ReadKey();
            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
        }

        // 6. REGISTRAR PROVEEDOR
        public static void RegistrarProveedor()
        {
            const int FILA_INICIO_FORMULARIO = 8;
            string[] nuevoProveedor = new string[7];
            string titulo = "REGISTRAR PROVEEDORES";

            int anchoConsola = Console.WindowWidth;

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            Console.SetCursorPosition(0, FILA_INICIO_FORMULARIO);

            Console.WriteLine(new string(' ', (anchoConsola - titulo.Length) / 2) + titulo);
            Console.WriteLine(new string('-', anchoConsola));

            // 1. CÓDIGO PROVEEDOR (Unicidad y No Vacío)
            while (true)
            {
                Console.Write("Ingrese Código de Proveedor (Único): ");
                string codigo = Console.ReadLine().Trim().ToUpper();

                if (string.IsNullOrWhiteSpace(codigo)) { Console.WriteLine("Error: El código no puede estar vacío."); }
                else
                {
                    bool repetido = false;
                    for (int i = 0; i < Proveedores.GetLength(0); i++)
                    {
                        if (Proveedores[i, 0].Equals(codigo)) { repetido = true; break; }
                    }
                    if (repetido) { Console.WriteLine("Error: El código de proveedor ya existe y debe ser único."); }
                    else { nuevoProveedor[0] = codigo; break; }
                }
            }

            // 2. EMPRESA PROVEEDORA (No Vacío)
            while (true)
            {
                Console.Write("Ingrese Empresa Proveedora: ");
                string empresa = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(empresa)) { Console.WriteLine("Error: El nombre de la empresa no puede estar vacío."); }
                else { nuevoProveedor[1] = empresa; break; }
            }

            // 3. NÚMERO DE RUC (Solo números y No Vacío)
            while (true)
            {
                Console.Write("Ingrese Número de RUC (Solo números): ");
                string ruc = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(ruc)) { Console.WriteLine("Error: El RUC no puede estar vacío."); }
                else if (!ruc.All(char.IsDigit)) { Console.WriteLine("Error: El RUC debe contener solo números."); }
                else { nuevoProveedor[2] = ruc; break; }
            }

            // 4. REPRESENTANTE (No Vacío)
            while (true)
            {
                Console.Write("Ingrese Nombre del Representante: ");
                string representante = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(representante)) { Console.WriteLine("Error: El nombre del representante no puede estar vacío."); }
                else { nuevoProveedor[3] = representante; break; }
            }

            // 5. TELÉFONO (Solo números, No Vacío, 9 DÍGITOS)
            while (true)
            {
                Console.Write("Ingrese Teléfono (9 dígitos): ");
                string telefono = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(telefono)) { Console.WriteLine("Error: El teléfono no puede estar vacío."); }
                else if (!telefono.All(char.IsDigit)) { Console.WriteLine("Error: El teléfono debe contener solo números."); }
                else if (telefono.Length != 9) { Console.WriteLine("Error: El teléfono debe tener exactamente 9 dígitos."); }
                else { nuevoProveedor[4] = telefono; break; }
            }

            // 6. DIRECCIÓN (No Vacío)
            while (true)
            {
                Console.Write("Ingrese Dirección: ");
                string direccion = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(direccion)) { Console.WriteLine("Error: La dirección no puede estar vacía."); }
                else { nuevoProveedor[5] = direccion; break; }
            }

            // 7. CIUDAD (No Vacío)
            while (true)
            {
                Console.Write("Ingrese Ciudad: ");
                string ciudad = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(ciudad)) { Console.WriteLine("Error: La ciudad no puede estar vacía."); }
                else { nuevoProveedor[6] = ciudad; break; }
            }

            Proveedores = AgregarFila(Proveedores, nuevoProveedor);

            Console.WriteLine("\nProveedor registrado con éxito. Presione una tecla para volver al menú.");
            Console.ReadKey();
            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
        }
    }
}

