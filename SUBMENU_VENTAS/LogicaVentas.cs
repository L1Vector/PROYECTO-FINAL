namespace SUBMENU_VENTAS
{
    using System;

    public static class LogicaVentas
    {
        // ARREGLOS 1D
        public static string[] tipo = new string[100];
        public static string[] numeroDocumento = new string[100];
        public static string[] dniCliente = new string[100];
        public static string[] nombreCliente = new string[100];
        public static string[] dniVendedor = new string[100];
        public static string[] codigoProducto = new string[100];
        public static double[] total = new double[100];

        // ARREGLO 2D (detalle)
        // detalle[i,0] = producto
        // detalle[i,1] = cantidad
        // detalle[i,2] = precio
        public static string[,] detalle = new string[100, 3];

        public static int contador = 0;

        // -------------------------
        // Guardar BOLETA
        // -------------------------
        public static void GuardarBoleta(
            string nroBoleta,
            string dniCli,
            string nombreCli,
            string dniVend,
            string codigoProd,
            string producto,
            string cantidad,
            string precio,
            double monto)
        {
            int i = contador;

            tipo[i] = "BOLETA";
            numeroDocumento[i] = nroBoleta;
            dniCliente[i] = dniCli;
            nombreCliente[i] = nombreCli;
            dniVendedor[i] = dniVend;
            codigoProducto[i] = codigoProd;

            detalle[i, 0] = producto;
            detalle[i, 1] = cantidad;
            detalle[i, 2] = precio;

            total[i] = monto;

            contador++;
        }

        // -------------------------
        // Guardar FACTURA
        // -------------------------
        public static void GuardarFactura(
            string ruc,
            string empresa,
            string nroFactura,
            string codigoProd,
            string producto,
            string cantidad,
            string precio,
            double monto,
            string dniVend)
        {
            int i = contador;

            tipo[i] = "FACTURA";
            numeroDocumento[i] = nroFactura;
            dniCliente[i] = ruc;       // aquí reutilizamos dniCliente como RUC
            nombreCliente[i] = empresa;
            dniVendedor[i] = dniVend;
            codigoProducto[i] = codigoProd;

            detalle[i, 0] = producto;
            detalle[i, 1] = cantidad;
            detalle[i, 2] = precio;

            total[i] = monto;

            contador++;
        }

        // -------------------------
        // Guardar GUIA DE REMISION
        // -------------------------
        public static void GuardarGuiaRemision(
            string nroGuia,
            string dniCli,
            string nombreCli,
            string transportista,
            string codigoProd,
            string producto,
            string cantidad,
            string precio,
            string pesoKg,
            double monto,
            string dniVend)
        {
            int i = contador;

            tipo[i] = "GUIA REM";
            numeroDocumento[i] = nroGuia;
            dniCliente[i] = dniCli;
            nombreCliente[i] = nombreCli;
            dniVendedor[i] = dniVend;
            codigoProducto[i] = codigoProd;

            // Guardamos más info en el campo producto para no crear más arreglos
            detalle[i, 0] = producto + $" (peso:{pesoKg}kg, trans:{transportista})";
            detalle[i, 1] = cantidad;
            detalle[i, 2] = precio;

            total[i] = monto;

            contador++;
        }

        // -------------------------
        // Guardar PROFORMA
        // -------------------------
        public static void GuardarProforma(
            string cliente,
            string nroProforma,
            string codigoProd,
            string producto,
            string cantidad,
            string precio,
            double monto,
            string dniVend)
        {
            int i = contador;

            tipo[i] = "PROFORMA";
            numeroDocumento[i] = nroProforma;
            dniCliente[i] = "";
            nombreCliente[i] = cliente;
            dniVendedor[i] = dniVend;
            codigoProducto[i] = codigoProd;

            detalle[i, 0] = producto;
            detalle[i, 1] = cantidad;
            detalle[i, 2] = precio;

            total[i] = monto;

            contador++;
        }
    }
}
