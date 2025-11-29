using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIBLIOTECA_REGISTRA
{
    public class Arreglos
    {
        public static string[,] Productos = new string[0, 5];    // [Código, Nombre, Categoría, Stock, PrecioUnitario]
        public static string[,] Clientes = new string[0, 6];     // [DNI, Nombres, Apellidos, Teléfono, Email, Dirección]
        public static string[,] Vendedores = new string[0, 5];   // [CódigoVendedor, Nombres, Apellidos, Sueldo, Teléfono]
        public static string[,] Proveedores = new string[0, 7]; // [CódigoProveedor, Empresa, RUC, Representante, Teléfono, Dirección, Ciudad]
    }
}
