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

        // Función auxiliar para limpiar un área específica de la consola.
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

        // Nueva función auxiliar para mostrar error, esperar tecla y limpiar el mensaje de error.
        private static void MostrarErrorYContinuar(string mensaje, int filaError)
        {
            // Posición para el mensaje de error (una fila debajo del input)
            Console.SetCursorPosition(2, filaError);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" Error: {mensaje} ");
            Console.ResetColor();

            // Mensaje para continuar
            Console.SetCursorPosition(2, filaError + 1);
            Console.WriteLine("Presione cualquier tecla para reintentar...");
            Console.ReadKey(true); // Espera la pulsación de una tecla

            // Limpiar la línea del mensaje de error y la línea de la indicación
            Console.SetCursorPosition(2, filaError);
            Console.Write(new string(' ', 86));
            Console.SetCursorPosition(2, filaError + 1);
            Console.Write(new string(' ', 86));
        }

        // --- 3. REGISTRAR PRODUCTO ---
        public static void RegistrarProducto()
        {
            int FILA_INICIO_FORMULARIO = 5;

            string[] nuevoProducto = new string[5];
            string titulo = "R E G I S T R A R   P R O D U C T O S";

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            int filaActual = FILA_INICIO_FORMULARIO;

            // Centramos el título
            Console.SetCursorPosition(2 + (86 - titulo.Length) / 2, filaActual++);
            Console.WriteLine(titulo);
            filaActual++; // Dejamos una línea de espacio

            // 1. CÓDIGO
            int filaInputCodigo = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputCodigo);
                Console.Write(new string(' ', 86)); // Limpiar línea antes de escribir
                Console.SetCursorPosition(2, filaInputCodigo);
                Console.Write("Ingrese Código del Producto (Único): ");
                string codigo = Console.ReadLine().Trim().ToUpper();

                bool errorEncontrado = false;
                if (string.IsNullOrWhiteSpace(codigo))
                {
                    MostrarErrorYContinuar("El código no puede estar vacío.", filaInputCodigo + 1);
                    errorEncontrado = true;
                }
                else
                {
                    for (int i = 0; i < Productos.GetLength(0); i++)
                    {
                        if (Productos[i, 0].Equals(codigo))
                        {
                            MostrarErrorYContinuar("El código de producto ya existe y debe ser único.", filaInputCodigo + 1);
                            errorEncontrado = true;
                            break;
                        }
                    }
                }

                if (!errorEncontrado) { nuevoProducto[0] = codigo; break; }
            }
            filaActual = filaInputCodigo + 2;

            // 2. NOMBRE
            int filaInputNombre = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputNombre);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputNombre);
                Console.Write("Ingrese Nombre del Producto (Único): ");
                string nombre = Console.ReadLine().Trim().ToUpper();

                bool errorEncontrado = false;
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MostrarErrorYContinuar("El nombre no puede estar vacío.", filaInputNombre + 1);
                    errorEncontrado = true;
                }
                else
                {
                    for (int i = 0; i < Productos.GetLength(0); i++)
                    {
                        if (Productos[i, 1].Equals(nombre))
                        {
                            MostrarErrorYContinuar("El nombre de producto ya existe y debe ser único.", filaInputNombre + 1);
                            errorEncontrado = true;
                            break;
                        }
                    }
                }

                if (!errorEncontrado) { nuevoProducto[1] = nombre; break; }
            }
            filaActual = filaInputNombre + 2;

            // 3. CATEGORÍA
            int filaInputCategoria = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputCategoria);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputCategoria);
                Console.Write("Ingrese Categoría: ");
                string categoria = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(categoria))
                {
                    MostrarErrorYContinuar("La categoría no puede estar vacía.", filaInputCategoria + 1);
                }
                else { nuevoProducto[2] = categoria; break; }
            }
            filaActual = filaInputCategoria + 2;

            // 4. STOCK
            int filaInputStock = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputStock);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputStock);
                Console.Write("Ingrese Stock: ");
                string inputStock = Console.ReadLine().Trim();

                if (int.TryParse(inputStock, out int stock) && stock >= 0)
                {
                    nuevoProducto[3] = stock.ToString();
                    break;
                }
                else
                {
                    MostrarErrorYContinuar("El stock debe ser un número entero positivo o cero.", filaInputStock + 1);
                }
            }
            filaActual = filaInputStock + 2;

            // 5. PRECIO UNITARIO
            int filaInputPrecio = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputPrecio);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputPrecio);
                Console.Write("Ingrese Precio Unitario: ");
                string inputPrecio = Console.ReadLine().Trim();

                if (decimal.TryParse(inputPrecio, out decimal precio) && precio > 0)
                {
                    nuevoProducto[4] = precio.ToString();
                    break;
                }
                else
                {
                    MostrarErrorYContinuar("El precio debe ser un número decimal positivo.", filaInputPrecio + 1);
                }
            }
            filaActual = filaInputPrecio + 2;

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

        // --- 4. REGISTRAR CLIENTE ---
        public static void RegistrarCliente()
        {
            int FILA_INICIO_FORMULARIO = 5;
            string[] nuevoCliente = new string[6];
            string titulo = "R E G I S T R A R   C L I E N T E S";

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            int filaActual = FILA_INICIO_FORMULARIO;

            // Centramos el título
            Console.SetCursorPosition(2 + (86 - titulo.Length) / 2, filaActual++);
            Console.WriteLine(titulo);
            filaActual++;

            // 1. DNI
            int filaInputDni = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputDni);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputDni);
                Console.Write("Ingrese DNI Cliente (Único, 8 dígitos): ");
                string dni = Console.ReadLine().Trim();

                bool errorEncontrado = false;
                if (string.IsNullOrWhiteSpace(dni))
                {
                    MostrarErrorYContinuar("El DNI no puede estar vacío.", filaInputDni + 1);
                    errorEncontrado = true;
                }
                else if (!dni.All(char.IsDigit))
                {
                    MostrarErrorYContinuar("El DNI debe contener solo números.", filaInputDni + 1);
                    errorEncontrado = true;
                }
                else if (dni.Length != 8)
                {
                    MostrarErrorYContinuar("El DNI debe tener exactamente 8 dígitos.", filaInputDni + 1);
                    errorEncontrado = true;
                }
                else
                {
                    for (int i = 0; i < Clientes.GetLength(0); i++)
                    {
                        if (Clientes[i, 0].Equals(dni))
                        {
                            MostrarErrorYContinuar("El DNI de cliente ya existe y debe ser único.", filaInputDni + 1);
                            errorEncontrado = true;
                            break;
                        }
                    }
                }

                if (!errorEncontrado) { nuevoCliente[0] = dni; break; }
            }
            filaActual = filaInputDni + 2;

            // 2. NOMBRES
            int filaInputNombres = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputNombres);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputNombres);
                Console.Write("Ingrese Nombres: ");
                string nombres = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(nombres))
                {
                    MostrarErrorYContinuar("Los nombres no pueden estar vacíos.", filaInputNombres + 1);
                }
                else { nuevoCliente[1] = nombres; break; }
            }
            filaActual = filaInputNombres + 2;

            // 3. APELLIDOS
            int filaInputApellidos = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputApellidos);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputApellidos);
                Console.Write("Ingrese Apellidos: ");
                string apellidos = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(apellidos))
                {
                    MostrarErrorYContinuar("Los apellidos no pueden estar vacíos.", filaInputApellidos + 1);
                }
                else { nuevoCliente[2] = apellidos; break; }
            }
            filaActual = filaInputApellidos + 2;

            // 4. TELÉFONO
            int filaInputTelefono = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputTelefono);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputTelefono);
                Console.Write("Ingrese Teléfono (9 dígitos): ");
                string telefono = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(telefono))
                {
                    MostrarErrorYContinuar("El teléfono no puede estar vacío.", filaInputTelefono + 1);
                }
                else if (!telefono.All(char.IsDigit))
                {
                    MostrarErrorYContinuar("El teléfono debe contener solo números.", filaInputTelefono + 1);
                }
                else if (telefono.Length != 9)
                {
                    MostrarErrorYContinuar("El teléfono debe tener exactamente 9 dígitos.", filaInputTelefono + 1);
                }
                else { nuevoCliente[3] = telefono; break; }
            }
            filaActual = filaInputTelefono + 2;

            // 5. EMAIL
            int filaInputEmail = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputEmail);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputEmail);
                Console.Write("Ingrese Email: ");
                string email = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(email))
                {
                    MostrarErrorYContinuar("El Email no puede estar vacío.", filaInputEmail + 1);
                }
                else { nuevoCliente[4] = email; break; }
            }
            filaActual = filaInputEmail + 2;

            // 6. DIRECCIÓN
            int filaInputDireccion = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputDireccion);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputDireccion);
                Console.Write("Ingrese Dirección: ");
                string direccion = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(direccion))
                {
                    MostrarErrorYContinuar("La dirección no puede estar vacía.", filaInputDireccion + 1);
                }
                else { nuevoCliente[5] = direccion; break; }
            }
            filaActual = filaInputDireccion + 2;

            Clientes = AgregarFila(Clientes, nuevoCliente);

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            Console.SetCursorPosition(3, FILA_INICIO_FORMULARIO);
            Console.WriteLine("Cliente registrado con éxito.");
            Console.SetCursorPosition(2, FILA_INICIO_FORMULARIO + 2);
            Console.WriteLine("Presione una tecla para volver al menú.");
            Console.ReadKey();
            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
        }

        // --- 5. REGISTRAR VENDEDORES ---
        public static void RegistrarVendedor()
        {
            int FILA_INICIO_FORMULARIO = 5;
            string[] nuevoVendedor = new string[5];
            string titulo = "R E G I S T R A R   V E N D E D O R E S";

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            int filaActual = FILA_INICIO_FORMULARIO;

            // Centramos el título
            Console.SetCursorPosition(2 + (86 - titulo.Length) / 2, filaActual++);
            Console.WriteLine(titulo);
            filaActual++;

            // 1. CÓDIGO VENDEDOR
            int filaInputCodigo = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputCodigo);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputCodigo);
                Console.Write("Ingrese Código de Vendedor (Único): ");
                string codigo = Console.ReadLine().Trim().ToUpper();

                bool errorEncontrado = false;
                if (string.IsNullOrWhiteSpace(codigo))
                {
                    MostrarErrorYContinuar("El código no puede estar vacío.", filaInputCodigo + 1);
                    errorEncontrado = true;
                }
                else
                {
                    for (int i = 0; i < Vendedores.GetLength(0); i++)
                    {
                        if (Vendedores[i, 0].Equals(codigo))
                        {
                            MostrarErrorYContinuar("El código de vendedor ya existe y debe ser único.", filaInputCodigo + 1);
                            errorEncontrado = true;
                            break;
                        }
                    }
                }

                if (!errorEncontrado) { nuevoVendedor[0] = codigo; break; }
            }
            filaActual = filaInputCodigo + 2;

            // 2. NOMBRES
            int filaInputNombres = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputNombres);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputNombres);
                Console.Write("Ingrese Nombres: ");
                string nombres = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(nombres))
                {
                    MostrarErrorYContinuar("Los nombres no pueden estar vacíos.", filaInputNombres + 1);
                }
                else { nuevoVendedor[1] = nombres; break; }
            }
            filaActual = filaInputNombres + 2;

            // 3. APELLIDOS
            int filaInputApellidos = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputApellidos);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputApellidos);
                Console.Write("Ingrese Apellidos: ");
                string apellidos = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(apellidos))
                {
                    MostrarErrorYContinuar("Los apellidos no pueden estar vacíos.", filaInputApellidos + 1);
                }
                else { nuevoVendedor[2] = apellidos; break; }
            }
            filaActual = filaInputApellidos + 2;

            // 4. SUELDO
            int filaInputSueldo = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputSueldo);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputSueldo);
                Console.Write("Ingrese Sueldo: ");
                string inputSueldo = Console.ReadLine().Trim();

                if (decimal.TryParse(inputSueldo, out decimal sueldo) && sueldo > 0)
                {
                    nuevoVendedor[3] = sueldo.ToString();
                    break;
                }
                else
                {
                    MostrarErrorYContinuar("El sueldo debe ser un número positivo.", filaInputSueldo + 1);
                }
            }
            filaActual = filaInputSueldo + 2;

            // 5. TELÉFONO
            int filaInputTelefono = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputTelefono);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputTelefono);
                Console.Write("Ingrese Teléfono (Solo números): ");
                string telefono = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(telefono))
                {
                    MostrarErrorYContinuar("El teléfono no puede estar vacío.", filaInputTelefono + 1);
                }
                else if (!telefono.All(char.IsDigit))
                {
                    MostrarErrorYContinuar("El teléfono debe contener solo números.", filaInputTelefono + 1);
                }
                else { nuevoVendedor[4] = telefono; break; }
            }
            filaActual = filaInputTelefono + 2;

            Vendedores = AgregarFila(Vendedores, nuevoVendedor);

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            Console.SetCursorPosition(3, FILA_INICIO_FORMULARIO);
            Console.WriteLine("Vendedor registrado con éxito.");
            Console.SetCursorPosition(2, FILA_INICIO_FORMULARIO + 2);
            Console.WriteLine("Presione una tecla para volver al menú.");
            Console.ReadKey();
            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
        }

        // --- 6. REGISTRAR PROVEEDOR ---
        public static void RegistrarProveedor()
        {
            int FILA_INICIO_FORMULARIO = 5;
            string[] nuevoProveedor = new string[7];
            string titulo = "R E G I S T R A R   P R O V E E D O R E S";

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            int filaActual = FILA_INICIO_FORMULARIO;

            // Centramos el título
            Console.SetCursorPosition(2 + (86 - titulo.Length) / 2, filaActual++);
            Console.WriteLine(titulo);
            filaActual++;

            // 1. CÓDIGO PROVEEDOR
            int filaInputCodigo = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputCodigo);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputCodigo);
                Console.Write("Ingrese Código de Proveedor (Único): ");
                string codigo = Console.ReadLine().Trim().ToUpper();

                bool errorEncontrado = false;
                if (string.IsNullOrWhiteSpace(codigo))
                {
                    MostrarErrorYContinuar("El código no puede estar vacío.", filaInputCodigo + 1);
                    errorEncontrado = true;
                }
                else
                {
                    for (int i = 0; i < Proveedores.GetLength(0); i++)
                    {
                        if (Proveedores[i, 0].Equals(codigo))
                        {
                            MostrarErrorYContinuar("El código de proveedor ya existe y debe ser único.", filaInputCodigo + 1);
                            errorEncontrado = true;
                            break;
                        }
                    }
                }

                if (!errorEncontrado) { nuevoProveedor[0] = codigo; break; }
            }
            filaActual = filaInputCodigo + 2;

            // 2. EMPRESA PROVEEDORA
            int filaInputEmpresa = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputEmpresa);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputEmpresa);
                Console.Write("Ingrese Empresa Proveedora: ");
                string empresa = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(empresa))
                {
                    MostrarErrorYContinuar("El nombre de la empresa no puede estar vacío.", filaInputEmpresa + 1);
                }
                else { nuevoProveedor[1] = empresa; break; }
            }
            filaActual = filaInputEmpresa + 2;

            // 3. NÚMERO DE RUC
            int filaInputRuc = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputRuc);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputRuc);
                Console.Write("Ingrese Número de RUC (Solo números): ");
                string ruc = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(ruc))
                {
                    MostrarErrorYContinuar("El RUC no puede estar vacío.", filaInputRuc + 1);
                }
                else if (!ruc.All(char.IsDigit))
                {
                    MostrarErrorYContinuar("El RUC debe contener solo números.", filaInputRuc + 1);
                }
                else { nuevoProveedor[2] = ruc; break; }
            }
            filaActual = filaInputRuc + 2;

            // 4. REPRESENTANTE
            int filaInputRepresentante = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputRepresentante);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputRepresentante);
                Console.Write("Ingrese Nombre del Representante: ");
                string representante = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(representante))
                {
                    MostrarErrorYContinuar("El nombre del representante no puede estar vacío.", filaInputRepresentante + 1);
                }
                else { nuevoProveedor[3] = representante; break; }
            }
            filaActual = filaInputRepresentante + 2;

            // 5. TELÉFONO
            int filaInputTelefono = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputTelefono);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputTelefono);
                Console.Write("Ingrese Teléfono (9 dígitos): ");
                string telefono = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(telefono))
                {
                    MostrarErrorYContinuar("El teléfono no puede estar vacío.", filaInputTelefono + 1);
                }
                else if (!telefono.All(char.IsDigit))
                {
                    MostrarErrorYContinuar("El teléfono debe contener solo números.", filaInputTelefono + 1);
                }
                else if (telefono.Length != 9)
                {
                    MostrarErrorYContinuar("El teléfono debe tener exactamente 9 dígitos.", filaInputTelefono + 1);
                }
                else { nuevoProveedor[4] = telefono; break; }
            }
            filaActual = filaInputTelefono + 2;

            // 6. DIRECCIÓN
            int filaInputDireccion = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputDireccion);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputDireccion);
                Console.Write("Ingrese Dirección: ");
                string direccion = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(direccion))
                {
                    MostrarErrorYContinuar("La dirección no puede estar vacía.", filaInputDireccion + 1);
                }
                else { nuevoProveedor[5] = direccion; break; }
            }
            filaActual = filaInputDireccion + 2;

            // 7. CIUDAD
            int filaInputCiudad = filaActual;
            while (true)
            {
                Console.SetCursorPosition(2, filaInputCiudad);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, filaInputCiudad);
                Console.Write("Ingrese Ciudad: ");
                string ciudad = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(ciudad))
                {
                    MostrarErrorYContinuar("La ciudad no puede estar vacía.", filaInputCiudad + 1);
                }
                else { nuevoProveedor[6] = ciudad; break; }
            }
            filaActual = filaInputCiudad + 2;

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

