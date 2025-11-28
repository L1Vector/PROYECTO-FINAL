using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIBLIOTECA_REGISTRA
{
    public static class BibliotecaRegistra
    {

        public static string[,] Productos = new string[0, 5];    // [Código, Nombre, Categoría, Stock, PrecioUnitario]
        public static string[,] Clientes = new string[0, 6];     // [DNI, Nombres, Apellidos, Teléfono, Email, Dirección]
        public static string[,] Vendedores = new string[0, 5];   // [CódigoVendedor, Nombres, Apellidos, Sueldo, Teléfono]
        public static string[,] Proveedores = new string[0, 7]; // [CódigoProveedor, Empresa, RUC, Representante, Teléfono, Dirección, Ciudad]

        // Esta función incrementa el tamaño del arreglo bidimensional en una fila y añade los nuevos datos al final.
        public static string[,] AgregarFila(string[,] original, string[] nuevaFila)
        {
            int numFilas = original.GetLength(0);
            int numCols = original.GetLength(1);
            int nuevaNumFilas = numFilas + 1;

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
        private static void LimpiarAreaRegistro(int filaInicial)
        {
            int anchoArea = 88; 

            for (int i = filaInicial; i <= 25; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write(new string(' ', anchoArea));
            }
            Console.SetCursorPosition(2, filaInicial); 
        }
        // 3. REGISTRAR PRODUCTO
        public static void RegistrarProducto()
        {
            // La posición vertical donde empieza el formulario
            const int FILA_INICIO_FORMULARIO = 5;

            string[] nuevoProducto = new string[5];
            string titulo = "R E G I S T R A R   P R O D U C T O S";

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            int filaActual = FILA_INICIO_FORMULARIO;

            // Centramos el título
            Console.SetCursorPosition(2 + (86 - titulo.Length) / 2, filaActual++);
            Console.WriteLine(titulo);
            filaActual++; // Dejamos una línea de espacio

            // 1. CÓDIGO
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86)); // Limpiar línea antes de escribir
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Código del Producto (Único): ");
                string codigo = Console.ReadLine().Trim().ToUpper();

                if (string.IsNullOrWhiteSpace(codigo))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El código no puede estar vacío.");
                }
                else
                {
                    bool repetido = false;
                    for (int i = 0; i < Productos.GetLength(0); i++)
                    {
                        if (Productos[i, 0].Equals(codigo)) { repetido = true; break; }
                    }
                    if (repetido)
                    {
                        Console.SetCursorPosition(2, filaActual + 1);
                        Console.WriteLine("Error: El código de producto ya existe y debe ser único.");
                    }
                    else { nuevoProducto[0] = codigo; break; }
                }
                filaActual += 2; // Movemos la fila actual para volver a intentar
            }
            filaActual++;

            // 2. NOMBRE
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Nombre del Producto (Único): ");
                string nombre = Console.ReadLine().Trim().ToUpper();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El nombre no puede estar vacío.");
                }
                else
                {
                    bool repetido = false;
                    for (int i = 0; i < Productos.GetLength(0); i++)
                    {
                        if (Productos[i, 1].Equals(nombre)) { repetido = true; break; }
                    }
                    if (repetido)
                    {
                        Console.SetCursorPosition(2, filaActual + 1);
                        Console.WriteLine("Error: El nombre de producto ya existe y debe ser único.");
                    }
                    else { nuevoProducto[1] = nombre; break; }
                }
                filaActual += 2;
            }
            filaActual++;

            // 3. CATEGORÍA
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Categoría: ");
                string categoria = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(categoria))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: La categoría no puede estar vacía.");
                }
                else { nuevoProducto[2] = categoria; break; }
                filaActual += 2;
            }
            filaActual++;

            // 4. STOCK
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Stock (Solo números): ");
                string inputStock = Console.ReadLine().Trim();

                if (int.TryParse(inputStock, out int stock) && stock >= 0) { nuevoProducto[3] = stock.ToString(); break; }
                else
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El stock debe ser un número entero positivo o cero.");
                }
                filaActual += 2;
            }
            filaActual++;

            // 5. PRECIO UNITARIO
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Precio Unitario (Solo números): ");
                string inputPrecio = Console.ReadLine().Trim();

                if (decimal.TryParse(inputPrecio, out decimal precio) && precio > 0) { nuevoProducto[4] = precio.ToString(); break; }
                else
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El precio debe ser un número decimal positivo.");
                }
                filaActual += 2;
            }
            filaActual++;

            // Añadir el nuevo producto al arreglo global
            Productos = AgregarFila(Productos, nuevoProducto);

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            Console.SetCursorPosition(3, FILA_INICIO_FORMULARIO);
            Console.WriteLine("Producto registrado con éxito.");
            Console.SetCursorPosition(2, FILA_INICIO_FORMULARIO + 2);
            Console.WriteLine("Presione una tecla para volver al menú.");
            Console.ReadKey();
            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
        }
        // 4. REGISTRAR CLIENTE
        public static void RegistrarCliente()
        {
            const int FILA_INICIO_FORMULARIO = 5;
            string[] nuevoCliente = new string[6];
            string titulo = "R E G I S T R A R   C L I E N T E S";

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            int filaActual = FILA_INICIO_FORMULARIO;

            // Centramos el título
            Console.SetCursorPosition(2 + (86 - titulo.Length) / 2, filaActual++);
            Console.WriteLine(titulo);
            filaActual++;

            // 1. DNI
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese DNI Cliente (Único, 8 dígitos): ");
                string dni = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(dni))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El DNI no puede estar vacío.");
                }
                else if (!dni.All(char.IsDigit))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El DNI debe contener solo números.");
                }
                else if (dni.Length != 8)
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El DNI debe tener exactamente 8 dígitos.");
                }
                else
                {
                    bool repetido = false;
                    for (int i = 0; i < Clientes.GetLength(0); i++)
                    {
                        if (Clientes[i, 0].Equals(dni)) { repetido = true; break; }
                    }
                    if (repetido)
                    {
                        Console.SetCursorPosition(2, filaActual + 1);
                        Console.WriteLine("Error: El DNI de cliente ya existe y debe ser único.");
                    }
                    else { nuevoCliente[0] = dni; break; }
                }
                filaActual += 2;
            }
            filaActual++;

            // 2. NOMBRES
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Nombres: ");
                string nombres = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(nombres))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: Los nombres no pueden estar vacíos.");
                }
                else { nuevoCliente[1] = nombres; break; }
                filaActual += 2;
            }
            filaActual++;

            // 3. APELLIDOS
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Apellidos: ");
                string apellidos = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(apellidos))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: Los apellidos no pueden estar vacíos.");
                }
                else { nuevoCliente[2] = apellidos; break; }
                filaActual += 2;
            }
            filaActual++;

            // 4. TELÉFONO
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Teléfono (9 dígitos): ");
                string telefono = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(telefono))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El teléfono no puede estar vacío.");
                }
                else if (!telefono.All(char.IsDigit))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El teléfono debe contener solo números.");
                }
                else if (telefono.Length != 9)
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El teléfono debe tener exactamente 9 dígitos.");
                }
                else { nuevoCliente[3] = telefono; break; }
                filaActual += 2;
            }
            filaActual++;

            // 5. EMAIL
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Email: ");
                string email = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(email))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El Email no puede estar vacío.");
                }
                else { nuevoCliente[4] = email; break; }
                filaActual += 2;
            }
            filaActual++;

            // 6. DIRECCIÓN
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Dirección: ");
                string direccion = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(direccion))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: La dirección no puede estar vacía.");
                }
                else { nuevoCliente[5] = direccion; break; }
                filaActual += 2;
            }
            filaActual++;

            Clientes = AgregarFila(Clientes, nuevoCliente);

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            Console.SetCursorPosition(3, FILA_INICIO_FORMULARIO);
            Console.WriteLine("Cliente registrado con éxito.");
            Console.SetCursorPosition(2, FILA_INICIO_FORMULARIO + 2);
            Console.WriteLine("Presione una tecla para volver al menú.");
            Console.ReadKey();
            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
        }
        // 5. REGISTRAR VENDEDORES
        public static void RegistrarVendedor()
        {
            const int FILA_INICIO_FORMULARIO = 5;
            string[] nuevoVendedor = new string[5];
            string titulo = "R E G I S T R A R   V E N D E D O R E S";

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            int filaActual = FILA_INICIO_FORMULARIO;

            // Centramos el título
            Console.SetCursorPosition(2 + (86 - titulo.Length) / 2, filaActual++);
            Console.WriteLine(titulo);
            filaActual++;

            // 1. CÓDIGO VENDEDOR
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Código de Vendedor (Único): ");
                string codigo = Console.ReadLine().Trim().ToUpper();

                if (string.IsNullOrWhiteSpace(codigo))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El código no puede estar vacío.");
                }
                else
                {
                    bool repetido = false;
                    for (int i = 0; i < Vendedores.GetLength(0); i++)
                    {
                        if (Vendedores[i, 0].Equals(codigo)) { repetido = true; break; }
                    }
                    if (repetido)
                    {
                        Console.SetCursorPosition(2, filaActual + 1);
                        Console.WriteLine("Error: El código de vendedor ya existe y debe ser único.");
                    }
                    else { nuevoVendedor[0] = codigo; break; }
                }
                filaActual += 2;
            }
            filaActual++;

            // 2. NOMBRES
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Nombres: ");
                string nombres = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(nombres))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: Los nombres no pueden estar vacíos.");
                }
                else { nuevoVendedor[1] = nombres; break; }
                filaActual += 2;
            }
            filaActual++;

            // 3. APELLIDOS
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Apellidos: ");
                string apellidos = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(apellidos))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: Los apellidos no pueden estar vacíos.");
                }
                else { nuevoVendedor[2] = apellidos; break; }
                filaActual += 2;
            }
            filaActual++;

            // 4. SUELDO
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Sueldo (Solo números): ");
                string inputSueldo = Console.ReadLine().Trim();

                if (decimal.TryParse(inputSueldo, out decimal sueldo) && sueldo > 0) { nuevoVendedor[3] = sueldo.ToString(); break; }
                else
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El sueldo debe ser un número positivo.");
                }
                filaActual += 2;
            }
            filaActual++;

            // 5. TELÉFONO
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Teléfono (Solo números): ");
                string telefono = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(telefono))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El teléfono no puede estar vacío.");
                }
                else if (!telefono.All(char.IsDigit))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El teléfono debe contener solo números.");
                }
                else { nuevoVendedor[4] = telefono; break; }
                filaActual += 2;
            }
            filaActual++;

            Vendedores = AgregarFila(Vendedores, nuevoVendedor);

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            Console.SetCursorPosition(3, FILA_INICIO_FORMULARIO);
            Console.WriteLine("Vendedor registrado con éxito.");
            Console.SetCursorPosition(2, FILA_INICIO_FORMULARIO + 2);
            Console.WriteLine("Presione una tecla para volver al menú.");
            Console.ReadKey();
            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
        }
        // 6. REGISTRAR PROVEEDOR
        public static void RegistrarProveedor()
        {
            const int FILA_INICIO_FORMULARIO = 5;
            string[] nuevoProveedor = new string[7];
            string titulo = "R E G I S T R A R   P R O V E E D O R E S";

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            int filaActual = FILA_INICIO_FORMULARIO;

            // Centramos el título
            Console.SetCursorPosition(2 + (86 - titulo.Length) / 2, filaActual++);
            Console.WriteLine(titulo);
            filaActual++;

            // 1. CÓDIGO PROVEEDOR
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Código de Proveedor (Único): ");
                string codigo = Console.ReadLine().Trim().ToUpper();

                if (string.IsNullOrWhiteSpace(codigo))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El código no puede estar vacío.");
                }
                else
                {
                    bool repetido = false;
                    for (int i = 0; i < Proveedores.GetLength(0); i++)
                    {
                        if (Proveedores[i, 0].Equals(codigo)) { repetido = true; break; }
                    }
                    if (repetido)
                    {
                        Console.SetCursorPosition(2, filaActual + 1);
                        Console.WriteLine("Error: El código de proveedor ya existe y debe ser único.");
                    }
                    else { nuevoProveedor[0] = codigo; break; }
                }
                filaActual += 2;
            }
            filaActual++;

            // 2. EMPRESA PROVEEDORA
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Empresa Proveedora: ");
                string empresa = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(empresa))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El nombre de la empresa no puede estar vacío.");
                }
                else { nuevoProveedor[1] = empresa; break; }
                filaActual += 2;
            }
            filaActual++;

            // 3. NÚMERO DE RUC
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Número de RUC (Solo números): ");
                string ruc = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(ruc))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El RUC no puede estar vacío.");
                }
                else if (!ruc.All(char.IsDigit))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El RUC debe contener solo números.");
                }
                else { nuevoProveedor[2] = ruc; break; }
                filaActual += 2;
            }
            filaActual++;

            // 4. REPRESENTANTE
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Nombre del Representante: ");
                string representante = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(representante))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El nombre del representante no puede estar vacío.");
                }
                else { nuevoProveedor[3] = representante; break; }
                filaActual += 2;
            }
            filaActual++;

            // 5. TELÉFONO
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Teléfono (9 dígitos): ");
                string telefono = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(telefono))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El teléfono no puede estar vacío.");
                }
                else if (!telefono.All(char.IsDigit))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El teléfono debe contener solo números.");
                }
                else if (telefono.Length != 9)
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: El teléfono debe tener exactamente 9 dígitos.");
                }
                else { nuevoProveedor[4] = telefono; break; }
                filaActual += 2;
            }
            filaActual++;
            // 6. DIRECCIÓN
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Dirección: ");
                string direccion = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(direccion))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: La dirección no puede estar vacía.");
                }
                else { nuevoProveedor[5] = direccion; break; }
                filaActual += 2;
            }
            filaActual++;
            // 7. CIUDAD 
            while (true)
            {
                Console.SetCursorPosition(2, filaActual);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaActual);
                Console.Write("Ingrese Ciudad: ");
                string ciudad = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(ciudad))
                {
                    Console.SetCursorPosition(2, filaActual + 1);
                    Console.WriteLine("Error: La ciudad no puede estar vacía.");
                }
                else { nuevoProveedor[6] = ciudad; break; }
                filaActual += 2;
            }
            filaActual++;

            Proveedores = AgregarFila(Proveedores, nuevoProveedor);

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            Console.SetCursorPosition(3, FILA_INICIO_FORMULARIO);
            Console.WriteLine("Proveedor registrado con éxito.");
            Console.SetCursorPosition(2, FILA_INICIO_FORMULARIO + 2);
            Console.WriteLine("Presione una tecla para volver al menú.");
            Console.ReadKey();
            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
        }
    }
}

