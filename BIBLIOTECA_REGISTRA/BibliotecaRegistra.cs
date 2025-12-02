using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIBLIOTECA_REGISTRA
{
    public static class BibliotecaRegistra
    {
        public static void RegistrarProducto()
        {
            int FILA_INICIO_FORMULARIO = 5;
            string[] nuevoProducto = new string[5];
            string titulo = "R E G I S T R A R  P R O D U C T O S";

            Optimización.LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            int filaActual = FILA_INICIO_FORMULARIO;

            Console.SetCursorPosition(2 + (86 - titulo.Length) / 2, filaActual++);
            Console.WriteLine(titulo);
            filaActual++;

            int filaInputCodigo = filaActual;
            nuevoProducto[0] = Optimización.ObtenerEntradaValidada("Ingrese Código del Producto (Único): ", filaInputCodigo, (codigo) =>
            {
                string codigoUpper = codigo.ToUpper();
                for (int i = 0; i < Arreglos.Productos.GetLength(0); i++)
                {
                    if (Arreglos.Productos[i, 0].Equals(codigoUpper)) { return "El código de producto ya existe y debe ser único."; }
                }
                return null;
            }).ToUpper();
            filaActual = filaInputCodigo + 2;

            int filaInputNombre = filaActual;
            nuevoProducto[1] = Optimización.ObtenerEntradaValidada("Ingrese Nombre del Producto (Único): ", filaInputNombre, (nombre) =>
            {
                string nombreUpper = nombre.ToUpper();
                for (int i = 0; i < Arreglos.Productos.GetLength(0); i++)
                {
                    if (Arreglos.Productos[i, 1].Equals(nombreUpper)) { return "El nombre de producto ya existe y debe ser único."; }
                }
                return null;
            }).ToUpper();
            filaActual = filaInputNombre + 2;

            int filaInputCategoria = filaActual;
            nuevoProducto[2] = Optimización.ObtenerEntradaValidada("Ingrese Categoría: ", filaInputCategoria);
            filaActual = filaInputCategoria + 2;

            int filaInputStock = filaActual;
            nuevoProducto[3] = Optimización.ObtenerEntradaValidada("Ingrese Stock: ", filaInputStock, (input) =>
            {
                if (int.TryParse(input, out int stock) && stock >= 0) { return null; }
                return "El stock debe ser un número entero positivo o cero.";
            });
            filaActual = filaInputStock + 2;

            int filaInputPrecio = filaActual;
            nuevoProducto[4] = Optimización.ObtenerEntradaValidada("Ingrese Precio Unitario: ", filaInputPrecio, (input) =>
            {
                if (decimal.TryParse(input, out decimal precio) && precio > 0) { return null; }
                return "El precio debe ser un número decimal positivo.";
            });
            filaActual = filaInputPrecio + 2;

            Arreglos.Productos = Optimización.AgregarFila(Arreglos.Productos, nuevoProducto);
            Optimización.LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            Console.SetCursorPosition(3, FILA_INICIO_FORMULARIO);
            Console.WriteLine("Producto registrado con éxito.");
            Console.SetCursorPosition(2, FILA_INICIO_FORMULARIO + 2);
            Console.WriteLine("Presione una tecla para volver al menú.");
            Console.ReadKey();
            Optimización.LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
        }

        public static void RegistrarCliente()
        {
            int FILA_INICIO_FORMULARIO = 5;
            string[] nuevoCliente = new string[6];
            string titulo = "R E G I S T R A R  C L I E N T E S";

            Optimización.LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            int filaActual = FILA_INICIO_FORMULARIO;

            Console.SetCursorPosition(2 + (86 - titulo.Length) / 2, filaActual++);
            Console.WriteLine(titulo);
            filaActual++;

            int filaInputDni = filaActual;
            nuevoCliente[0] = Optimización.ObtenerEntradaValidada("Ingrese DNI Cliente (Único, 8 dígitos): ", filaInputDni, (dni) =>
            {
                if (!dni.All(char.IsDigit) || dni.Length != 8) { return "El DNI debe contener 8 dígitos numéricos exactos."; }
                for (int i = 0; i < Arreglos.Clientes.GetLength(0); i++)
                {
                    if (Arreglos.Clientes[i, 0].Equals(dni)) { return "El DNI de cliente ya existe y debe ser único."; }
                }
                return null;
            });
            filaActual = filaInputDni + 2;

            int filaInputNombres = filaActual;
            nuevoCliente[1] = Optimización.ObtenerEntradaValidada("Ingrese Nombres: ", filaInputNombres);
            filaActual = filaInputNombres + 2;

            int filaInputApellidos = filaActual;
            nuevoCliente[2] = Optimización.ObtenerEntradaValidada("Ingrese Apellidos: ", filaInputApellidos);
            filaActual = filaInputApellidos + 2;

            int filaInputTelefono = filaActual;
            nuevoCliente[3] = Optimización.ObtenerEntradaValidada("Ingrese Teléfono (9 dígitos): ", filaInputTelefono, (tel) =>
            {
                if (!tel.All(char.IsDigit) || tel.Length != 9) { return "El teléfono debe contener 9 dígitos numéricos exactos."; }
                return null;
            });
            filaActual = filaInputTelefono + 2;

            int filaInputEmail = filaActual;
            nuevoCliente[4] = Optimización.ObtenerEntradaValidada("Ingrese Email: ", filaInputEmail, (email) =>
            {
                if (!email.Contains("@")) { return "La dirección de correo electrónico debe contener un '@'."; }
                return null;
            });
            filaActual = filaInputEmail + 2;

            int filaInputDireccion = filaActual;
            nuevoCliente[5] = Optimización.ObtenerEntradaValidada("Ingrese Dirección: ", filaInputDireccion);
            filaActual = filaInputDireccion + 2;

            Arreglos.Clientes = Optimización.AgregarFila(Arreglos.Clientes, nuevoCliente);

            Optimización.LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            Console.SetCursorPosition(3, FILA_INICIO_FORMULARIO);
            Console.WriteLine("Cliente registrado con éxito.");
            Console.SetCursorPosition(2, FILA_INICIO_FORMULARIO + 2);
            Console.WriteLine("Presione una tecla para volver al menú.");
            Console.ReadKey();
            Optimización.LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
        }

        public static void RegistrarVendedor()
        {
            int FILA_INICIO_FORMULARIO = 5;
            string[] nuevoVendedor = new string[5];
            string titulo = "R E G I S T R A R  V E N D E D O R E S";

            Optimización.LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            int filaActual = FILA_INICIO_FORMULARIO;

            Console.SetCursorPosition(2 + (86 - titulo.Length) / 2, filaActual++);
            Console.WriteLine(titulo);
            filaActual++;

            int filaInputCodigo = filaActual;
            nuevoVendedor[0] = Optimización.ObtenerEntradaValidada("Ingrese Código de Vendedor (Único): ", filaInputCodigo, (codigo) =>
            {
                string codigoUpper = codigo.ToUpper();
                for (int i = 0; i < Arreglos.Vendedores.GetLength(0); i++)
                {
                    if (Arreglos.Vendedores[i, 0].Equals(codigoUpper)) { return "El código de vendedor ya existe y debe ser único."; }
                }
                return null;
            }).ToUpper();
            filaActual = filaInputCodigo + 2;

            int filaInputNombres = filaActual;
            nuevoVendedor[1] = Optimización.ObtenerEntradaValidada("Ingrese Nombres: ", filaInputNombres);
            filaActual = filaInputNombres + 2;

            int filaInputApellidos = filaActual;
            nuevoVendedor[2] = Optimización.ObtenerEntradaValidada("Ingrese Apellidos: ", filaInputApellidos);
            filaActual = filaInputApellidos + 2;

            int filaInputSueldo = filaActual;
            nuevoVendedor[3] = Optimización.ObtenerEntradaValidada("Ingrese Sueldo: ", filaInputSueldo, (input) =>
            {
                if (decimal.TryParse(input, out decimal sueldo) && sueldo > 0) { return null; }
                return "El sueldo debe ser un número positivo.";
            });
            filaActual = filaInputSueldo + 2;

            int filaInputTelefono = filaActual;
            nuevoVendedor[4] = Optimización.ObtenerEntradaValidada("Ingrese Teléfono (9 dígitos): ", filaInputTelefono, (tel) =>
            {
                if (!tel.All(char.IsDigit) || tel.Length != 9) { return "El teléfono debe contener 9 dígitos numéricos exactos."; }
                return null;
            });
            filaActual = filaInputTelefono + 2;

            Arreglos.Vendedores = Optimización.AgregarFila(Arreglos.Vendedores, nuevoVendedor);

            Optimización.LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            Console.SetCursorPosition(3, FILA_INICIO_FORMULARIO);
            Console.WriteLine("Vendedor registrado con éxito.");
            Console.SetCursorPosition(2, FILA_INICIO_FORMULARIO + 2);
            Console.WriteLine("Presione una tecla para volver al menú.");
            Console.ReadKey();
            Optimización.LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
        }

        public static void RegistrarProveedor()
        {
            int FILA_INICIO_FORMULARIO = 5;
            string[] nuevoProveedor = new string[7];
            string titulo = "R E G I S T R A R  P R O V E E D O R E S";

            Optimización.LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            int filaActual = FILA_INICIO_FORMULARIO;

            Console.SetCursorPosition(2 + (86 - titulo.Length) / 2, filaActual++);
            Console.WriteLine(titulo);
            filaActual++;

            int filaInputCodigo = filaActual;
            nuevoProveedor[0] = Optimización.ObtenerEntradaValidada("Ingrese Código de Proveedor (Único): ", filaInputCodigo, (codigo) =>
            {
                string codigoUpper = codigo.ToUpper();
                for (int i = 0; i < Arreglos.Proveedores.GetLength(0); i++)
                {
                    if (Arreglos.Proveedores[i, 0].Equals(codigoUpper)) { return "El código de proveedor ya existe y debe ser único."; }
                }
                return null;
            }).ToUpper();
            filaActual = filaInputCodigo + 2;

            int filaInputEmpresa = filaActual;
            nuevoProveedor[1] = Optimización.ObtenerEntradaValidada("Ingrese Empresa Proveedora: ", filaInputEmpresa);
            filaActual = filaInputEmpresa + 2;

            int filaInputRuc = filaActual;
            nuevoProveedor[2] = Optimización.ObtenerEntradaValidada("Ingrese Número de RUC (11 dígitos): ", filaInputRuc, (ruc) =>
            {
                if (!ruc.All(char.IsDigit) || ruc.Length != 11) { return "El RUC debe contener exactamente 11 dígitos numéricos."; }
                return null;
            });
            filaActual = filaInputRuc + 2;

            int filaInputRepresentante = filaActual;
            nuevoProveedor[3] = Optimización.ObtenerEntradaValidada("Ingrese Nombre del Representante: ", filaInputRepresentante);
            filaActual = filaInputRepresentante + 2;

            int filaInputTelefono = filaActual;
            nuevoProveedor[4] = Optimización.ObtenerEntradaValidada("Ingrese Teléfono (9 dígitos): ", filaInputTelefono, (tel) =>
            {
                if (!tel.All(char.IsDigit) || tel.Length != 9) { return "El teléfono debe contener 9 dígitos numéricos exactos."; }
                return null;
            });
            filaActual = filaInputTelefono + 2;

            int filaInputDireccion = filaActual;
            nuevoProveedor[5] = Optimización.ObtenerEntradaValidada("Ingrese Dirección: ", filaInputDireccion);
            filaActual = filaInputDireccion + 2;

            int filaInputCiudad = filaActual;
            nuevoProveedor[6] = Optimización.ObtenerEntradaValidada("Ingrese Ciudad: ", filaInputCiudad);
            filaActual = filaInputCiudad + 2;

            Arreglos.Proveedores = Optimización.AgregarFila(Arreglos.Proveedores, nuevoProveedor);

            Optimización.LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
            Console.SetCursorPosition(3, FILA_INICIO_FORMULARIO);
            Console.WriteLine("Proveedor registrado con éxito.");
            Console.SetCursorPosition(2, FILA_INICIO_FORMULARIO + 2);
            Console.WriteLine("Presione una tecla para volver al menú.");
            Console.ReadKey();
            Optimización.LimpiarAreaRegistro(FILA_INICIO_FORMULARIO);
        }
    }
}

