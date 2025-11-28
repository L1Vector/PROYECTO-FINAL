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
            string[,] nuevoArray = new string[numFilas + 1, numCols];

            for (int i = 0; i < numFilas; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    nuevoArray[i, j] = original[i, j];
                }
            }

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

        private static void MostrarErrorYContinuar(string mensaje, int filaError)
        {
            Console.SetCursorPosition(2, filaError);
            Console.Write($" Error: {mensaje} ");
            Console.ResetColor();

            Console.SetCursorPosition(2, filaError + 1);
            Console.WriteLine("Presione cualquier tecla para reintentar...");
            Console.ReadKey(true);

            Console.SetCursorPosition(2, filaError);
            Console.Write(new string(' ', 86));
            Console.SetCursorPosition(2, filaError + 1);
            Console.Write(new string(' ', 86));
        }

        private static string ObtenerEntradaValidada(string mensaje, int fila, Func<string, string> validadorAdicional = null)
        {
            while (true)
            {
                Console.SetCursorPosition(2, fila);
                Console.Write(new string(' ', 86));
                Console.SetCursorPosition(2, fila);
                Console.Write(mensaje);
                string input = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    MostrarErrorYContinuar("Este campo no puede estar vacío.", fila + 1);
                    continue;
                }

                if (validadorAdicional != null)
                {
                    string error = validadorAdicional(input);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MostrarErrorYContinuar(error, fila + 1);
                        continue;
                    }
                }

                return input;
            }
        }

        public static void RegistrarProducto()
        {
            const int FILA_INICIO_FORMULARIO = 5;
            string[] nuevoProducto = new string[5];
            string titulo = "R E G I S T R A R   P R O D U C T O S";

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            int filaActual = FILA_INICIO_FORMULARIO;

            Console.SetCursorPosition(2 + (86 - titulo.Length) / 2, filaActual++);
            Console.WriteLine(titulo);
            filaActual++;

            int filaInputCodigo = filaActual;
            nuevoProducto[0] = ObtenerEntradaValidada("Ingrese Código del Producto (Único): ", filaInputCodigo, (codigo) =>
            {
                string codigoUpper = codigo.ToUpper();
                for (int i = 0; i < Productos.GetLength(0); i++)
                {
                    if (Productos[i, 0].Equals(codigoUpper)) { return "El código de producto ya existe y debe ser único."; }
                }
                return null;
            }).ToUpper();
            filaActual = filaInputCodigo + 2;

            int filaInputNombre = filaActual;
            nuevoProducto[1] = ObtenerEntradaValidada("Ingrese Nombre del Producto (Único): ", filaInputNombre, (nombre) =>
            {
                string nombreUpper = nombre.ToUpper();
                for (int i = 0; i < Productos.GetLength(0); i++)
                {
                    if (Productos[i, 1].Equals(nombreUpper)) { return "El nombre de producto ya existe y debe ser único."; }
                }
                return null;
            }).ToUpper();
            filaActual = filaInputNombre + 2;

            int filaInputCategoria = filaActual;
            nuevoProducto[2] = ObtenerEntradaValidada("Ingrese Categoría: ", filaInputCategoria);
            filaActual = filaInputCategoria + 2;

            int filaInputStock = filaActual;
            nuevoProducto[3] = ObtenerEntradaValidada("Ingrese Stock: ", filaInputStock, (input) =>
            {
                if (int.TryParse(input, out int stock) && stock >= 0) { return null; }
                return "El stock debe ser un número entero positivo o cero.";
            });
            filaActual = filaInputStock + 2;

            int filaInputPrecio = filaActual;
            nuevoProducto[4] = ObtenerEntradaValidada("Ingrese Precio Unitario: ", filaInputPrecio, (input) =>
            {
                if (decimal.TryParse(input, out decimal precio) && precio > 0) { return null; }
                return "El precio debe ser un número decimal positivo.";
            });
            filaActual = filaInputPrecio + 2;

            Productos = AgregarFila(Productos, nuevoProducto);

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            Console.SetCursorPosition(3, FILA_INICIO_FORMULARIO);
            Console.WriteLine("Producto registrado con éxito.");
            Console.SetCursorPosition(2, FILA_INICIO_FORMULARIO + 2);
            Console.WriteLine("Presione una tecla para volver al menú.");
            Console.ReadKey();
            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
        }

        public static void RegistrarCliente()
        {
            const int FILA_INICIO_FORMULARIO = 5;
            string[] nuevoCliente = new string[6];
            string titulo = "R E G I S T R A R   C L I E N T E S";

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            int filaActual = FILA_INICIO_FORMULARIO;

            Console.SetCursorPosition(2 + (86 - titulo.Length) / 2, filaActual++);
            Console.WriteLine(titulo);
            filaActual++;

            int filaInputDni = filaActual;
            nuevoCliente[0] = ObtenerEntradaValidada("Ingrese DNI Cliente (Único, 8 dígitos): ", filaInputDni, (dni) =>
            {
                if (!dni.All(char.IsDigit) || dni.Length != 8) { return "El DNI debe contener 8 dígitos numéricos exactos."; }
                for (int i = 0; i < Clientes.GetLength(0); i++)
                {
                    if (Clientes[i, 0].Equals(dni)) { return "El DNI de cliente ya existe y debe ser único."; }
                }
                return null;
            });
            filaActual = filaInputDni + 2;

            int filaInputNombres = filaActual;
            nuevoCliente[1] = ObtenerEntradaValidada("Ingrese Nombres: ", filaInputNombres);
            filaActual = filaInputNombres + 2;

            int filaInputApellidos = filaActual;
            nuevoCliente[2] = ObtenerEntradaValidada("Ingrese Apellidos: ", filaInputApellidos);
            filaActual = filaInputApellidos + 2;

            int filaInputTelefono = filaActual;
            nuevoCliente[3] = ObtenerEntradaValidada("Ingrese Teléfono (9 dígitos): ", filaInputTelefono, (tel) =>
            {
                if (!tel.All(char.IsDigit) || tel.Length != 9) { return "El teléfono debe contener 9 dígitos numéricos exactos."; }
                return null;
            });
            filaActual = filaInputTelefono + 2;

            int filaInputEmail = filaActual;
            nuevoCliente[4] = ObtenerEntradaValidada("Ingrese Email: ", filaInputEmail);
            filaActual = filaInputEmail + 2;

            int filaInputDireccion = filaActual;
            nuevoCliente[5] = ObtenerEntradaValidada("Ingrese Dirección: ", filaInputDireccion);
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

        public static void RegistrarVendedor()
        {
            const int FILA_INICIO_FORMULARIO = 5;
            string[] nuevoVendedor = new string[5];
            string titulo = "R E G I S T R A R   V E N D E D O R E S";

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            int filaActual = FILA_INICIO_FORMULARIO;

            Console.SetCursorPosition(2 + (86 - titulo.Length) / 2, filaActual++);
            Console.WriteLine(titulo);
            filaActual++;

            int filaInputCodigo = filaActual;
            nuevoVendedor[0] = ObtenerEntradaValidada("Ingrese Código de Vendedor (Único): ", filaInputCodigo, (codigo) =>
            {
                string codigoUpper = codigo.ToUpper();
                for (int i = 0; i < Vendedores.GetLength(0); i++)
                {
                    if (Vendedores[i, 0].Equals(codigoUpper)) { return "El código de vendedor ya existe y debe ser único."; }
                }
                return null;
            }).ToUpper();
            filaActual = filaInputCodigo + 2;

            int filaInputNombres = filaActual;
            nuevoVendedor[1] = ObtenerEntradaValidada("Ingrese Nombres: ", filaInputNombres);
            filaActual = filaInputNombres + 2;

            int filaInputApellidos = filaActual;
            nuevoVendedor[2] = ObtenerEntradaValidada("Ingrese Apellidos: ", filaInputApellidos);
            filaActual = filaInputApellidos + 2;

            int filaInputSueldo = filaActual;
            nuevoVendedor[3] = ObtenerEntradaValidada("Ingrese Sueldo: ", filaInputSueldo, (input) =>
            {
                if (decimal.TryParse(input, out decimal sueldo) && sueldo > 0) { return null; }
                return "El sueldo debe ser un número positivo.";
            });
            filaActual = filaInputSueldo + 2;

            int filaInputTelefono = filaActual;
            nuevoVendedor[4] = ObtenerEntradaValidada("Ingrese Teléfono (Solo números): ", filaInputTelefono, (tel) =>
            {
                if (!tel.All(char.IsDigit)) { return "El teléfono debe contener solo números."; }
                return null;
            });
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

        public static void RegistrarProveedor()
        {
            const int FILA_INICIO_FORMULARIO = 5;
            string[] nuevoProveedor = new string[7];
            string titulo = "R E G I S T R A R   P R O V E E D O R E S";

            LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            int filaActual = FILA_INICIO_FORMULARIO;

            Console.SetCursorPosition(2 + (86 - titulo.Length) / 2, filaActual++);
            Console.WriteLine(titulo);
            filaActual++;

            int filaInputCodigo = filaActual;
            nuevoProveedor[0] = ObtenerEntradaValidada("Ingrese Código de Proveedor (Único): ", filaInputCodigo, (codigo) =>
            {
                string codigoUpper = codigo.ToUpper();
                for (int i = 0; i < Proveedores.GetLength(0); i++)
                {
                    if (Proveedores[i, 0].Equals(codigoUpper)) { return "El código de proveedor ya existe y debe ser único."; }
                }
                return null;
            }).ToUpper();
            filaActual = filaInputCodigo + 2;

            int filaInputEmpresa = filaActual;
            nuevoProveedor[1] = ObtenerEntradaValidada("Ingrese Empresa Proveedora: ", filaInputEmpresa);
            filaActual = filaInputEmpresa + 2;

            int filaInputRuc = filaActual;
            nuevoProveedor[2] = ObtenerEntradaValidada("Ingrese Número de RUC (Solo números): ", filaInputRuc, (ruc) =>
            {
                if (!ruc.All(char.IsDigit)) { return "El RUC debe contener solo números."; }
                return null;
            });
            filaActual = filaInputRuc + 2;

            int filaInputRepresentante = filaActual;
            nuevoProveedor[3] = ObtenerEntradaValidada("Ingrese Nombre del Representante: ", filaInputRepresentante);
            filaActual = filaInputRepresentante + 2;

            int filaInputTelefono = filaActual;
            nuevoProveedor[4] = ObtenerEntradaValidada("Ingrese Teléfono (9 dígitos): ", filaInputTelefono, (tel) =>
            {
                if (!tel.All(char.IsDigit) || tel.Length != 9) { return "El teléfono debe contener 9 dígitos numéricos exactos."; }
                return null;
            });
            filaActual = filaInputTelefono + 2;

            int filaInputDireccion = filaActual;
            nuevoProveedor[5] = ObtenerEntradaValidada("Ingrese Dirección: ", filaInputDireccion);
            filaActual = filaInputDireccion + 2;

            int filaInputCiudad = filaActual;
            nuevoProveedor[6] = ObtenerEntradaValidada("Ingrese Ciudad: ", filaInputCiudad);
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

