namespace SUBMENU_VENTAS
{
    using System;

    public static class LogicaVentas
    {
        // --- NUEVOS ARREGLOS BIDIMENSIONALES

        public static string[,] tipo = new string[0, 1];            // [tipo]
        public static string[,] numeroDocumento = new string[0, 1]; // [nroDoc]
        public static string[,] dniCliente = new string[0, 1];      // [dni/ruc]
        public static string[,] nombreCliente = new string[0, 1];   // [nombre/empresa]
        public static string[,] dniVendedor = new string[0, 1];     // [dniVendedor]
        public static string[,] codigoProducto = new string[0, 1];  // [codigoProducto]
        public static string[,] total = new string[0, 1];           // [total] (Convertido a string para la función)

        public static string[,] detalle = new string[0, 3];


        // --- 1. FUNCIÓN DE REDIMENSIONAMIENTO

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

      
        // --- 2. FUNCIONES DE GUARDADO ADAPTADAS ---
    
        // Guardar BOLETA
        public static void GuardarBoleta(
            string nroBoleta, string dniCli, string nombreCli, string dniVend,
            string codigoProd, string producto, string cantidad, string precio, double monto)
        {
            // 1. Prepara las filas 1D con los datos
            string[] filaTipo = { "BOLETA" };
            string[] filaDocumento = { nroBoleta };
            string[] filaCliente = { dniCli };
            string[] filaNombre = { nombreCli };
            string[] filaVendedor = { dniVend };
            string[] filaCodigo = { codigoProd };
            string[] filaTotal = { monto.ToString() }; // Convertimos double a string
            string[] filaDetalle = { producto, cantidad, precio };

            // 2. Aplica la función AgregarFila a TODOS los arreglos
            tipo = AgregarFila(tipo, filaTipo);
            numeroDocumento = AgregarFila(numeroDocumento, filaDocumento);
            dniCliente = AgregarFila(dniCliente, filaCliente);
            nombreCliente = AgregarFila(nombreCliente, filaNombre);
            dniVendedor = AgregarFila(dniVendedor, filaVendedor);
            codigoProducto = AgregarFila(codigoProducto, filaCodigo);
            total = AgregarFila(total, filaTotal);
            detalle = AgregarFila(detalle, filaDetalle);
        }


        // Guardar FACTURA
        public static void GuardarFactura(
            string ruc, string empresa, string nroFactura, string codigoProd,
            string producto, string cantidad, string precio, double monto, string dniVend)
        {
            // 1. Prepara las filas 1D con los datos
            string[] filaTipo = { "FACTURA" };
            string[] filaDocumento = { nroFactura };
            string[] filaCliente = { ruc };         // ruc reutiliza dniCliente
            string[] filaNombre = { empresa };
            string[] filaVendedor = { dniVend };
            string[] filaCodigo = { codigoProd };
            string[] filaTotal = { monto.ToString() };
            string[] filaDetalle = { producto, cantidad, precio };

            // 2. Aplica la función AgregarFila a TODOS los arreglos
            tipo = AgregarFila(tipo, filaTipo);
            numeroDocumento = AgregarFila(numeroDocumento, filaDocumento);
            dniCliente = AgregarFila(dniCliente, filaCliente);
            nombreCliente = AgregarFila(nombreCliente, filaNombre);
            dniVendedor = AgregarFila(dniVendedor, filaVendedor);
            codigoProducto = AgregarFila(codigoProducto, filaCodigo);
            total = AgregarFila(total, filaTotal);
            detalle = AgregarFila(detalle, filaDetalle);
        }


        // Guardar GUIA DE REMISION
        public static void GuardarGuiaRemision(
            string nroGuia, string dniCli, string nombreCli, string transportista,
            string codigoProd, string producto, string cantidad, string precio,
            string pesoKg, double monto, string dniVend)
        {
            // 1. Prepara las filas 1D con los datos
            string[] filaTipo = { "GUIA REM" };
            string[] filaDocumento = { nroGuia };
            string[] filaCliente = { dniCli };
            string[] filaNombre = { nombreCli };
            string[] filaVendedor = { dniVend };
            string[] filaCodigo = { codigoProd };
            string[] filaTotal = { monto.ToString() };

            // Combina datos para el detalle 2D
            string productoDetalle = producto + $" (peso:{pesoKg}kg, trans:{transportista})";
            string[] filaDetalle = { productoDetalle, cantidad, precio };

            // 2. Aplica la función AgregarFila a TODOS los arreglos
            tipo = AgregarFila(tipo, filaTipo);
            numeroDocumento = AgregarFila(numeroDocumento, filaDocumento);
            dniCliente = AgregarFila(dniCliente, filaCliente);
            nombreCliente = AgregarFila(nombreCliente, filaNombre);
            dniVendedor = AgregarFila(dniVendedor, filaVendedor);
            codigoProducto = AgregarFila(codigoProducto, filaCodigo);
            total = AgregarFila(total, filaTotal);
            detalle = AgregarFila(detalle, filaDetalle);
        }


        // Guardar PROFORMA
        public static void GuardarProforma(
            string cliente, string nroProforma, string codigoProd,
            string producto, string cantidad, string precio, double monto, string dniVend)
        {
            // 1. Prepara las filas 1D con los datos
            string[] filaTipo = { "PROFORMA" };
            string[] filaDocumento = { nroProforma };
            string[] filaCliente = { "" }; // Vacio
            string[] filaNombre = { cliente };
            string[] filaVendedor = { dniVend };
            string[] filaCodigo = { codigoProd };
            string[] filaTotal = { monto.ToString() };
            string[] filaDetalle = { producto, cantidad, precio };

            // 2. Aplica la función AgregarFila a TODOS los arreglos
            tipo = AgregarFila(tipo, filaTipo);
            numeroDocumento = AgregarFila(numeroDocumento, filaDocumento);
            dniCliente = AgregarFila(dniCliente, filaCliente);
            nombreCliente = AgregarFila(nombreCliente, filaNombre);
            dniVendedor = AgregarFila(dniVendedor, filaVendedor);
            codigoProducto = AgregarFila(codigoProducto, filaCodigo);
            total = AgregarFila(total, filaTotal);
            detalle = AgregarFila(detalle, filaDetalle);
        }
    }
}