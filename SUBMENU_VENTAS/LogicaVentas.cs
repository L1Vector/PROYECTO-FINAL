using BIBLIOTECA_REGISTRA;

namespace SUBMENU_VENTAS
{
    public static class LogicaVentas
    {
        // ============================================================
        // ARREGLO UNICO — CADA DOCUMENTO ES UNA FILA (10 columnas)
        // ============================================================
        // [0] Tipo (BOLETA, FACTURA, etc)
        // [1] Número documento
        // [2] DNI/RUC
        // [3] Nombre cliente / Empresa
        // [4] DNI vendedor
        // [5] Código producto
        // [6] Producto
        // [7] Cantidad
        // [8] Precio unitario
        // [9] Total

        public static string[,] Documentos = new string[0, 10];

        // ============================================================
        // 1. FUNCIÓN PARA AGREGAR UNA FILA AL ARREGLO UNICO
        // ============================================================
        public static string[,] AgregarFila(string[,] original, string[] nuevaFila)
        {
            int filas = original.GetLength(0);
            int cols = original.GetLength(1);

            string[,] nuevo = new string[filas + 1, cols];

            for (int i = 0; i < filas; i++)
                for (int j = 0; j < cols; j++)
                    nuevo[i, j] = original[i, j];

            for (int j = 0; j < cols; j++)
                nuevo[filas, j] = nuevaFila[j];

            return nuevo;
        }

        // ============================================================
        // 2. GUARDAR BOLETA
        // ============================================================
        public static void GuardarBoleta(
            string nroBoleta, string dniCli, string nombreCli, string dniVend,
            string codigoProd, string producto, string cantidad, string precio, double monto)
        {
            string[] fila = {
                "BOLETA",
                nroBoleta,
                dniCli,
                nombreCli,
                dniVend,
                codigoProd,
                producto,
                cantidad,
                precio,
                monto.ToString()
            };

            Documentos = AgregarFila(Documentos, fila);
        }

        // ============================================================
        // 3. GUARDAR FACTURA
        // ============================================================
        public static void GuardarFactura(
            string ruc, string empresa, string nroFactura, string codigoProd,
            string producto, string cantidad, string precio, double monto, string dniVend)
        {
            string[] fila = {
                "FACTURA",
                nroFactura,
                ruc,
                empresa,
                dniVend,
                codigoProd,
                producto,
                cantidad,
                precio,
                monto.ToString()
            };

            Documentos = AgregarFila(Documentos, fila);
        }

        // ============================================================
        // 4. GUARDAR GUIA REMISION
        // ============================================================
        public static void GuardarGuiaRemision(
            string nroGuia, string dniCli, string nombreCli, string transportista,
            string codigoProd, string producto, string cantidad, string precio,
            string pesoKg, double monto, string dniVend)
        {
            string productoFinal = $"{producto} (PESO:{pesoKg}kg / TRANS:{transportista})";

            string[] fila = {
                "GUIA REM",
                nroGuia,
                dniCli,
                nombreCli,
                dniVend,
                codigoProd,
                productoFinal,
                cantidad,
                precio,
                monto.ToString()
            };

            Documentos = AgregarFila(Documentos, fila);
        }

        // ============================================================
        // 5. GUARDAR PROFORMA
        // ============================================================
        public static void GuardarProforma(
            string cliente, string nroProforma, string codigoProd,
            string producto, string cantidad, string precio, double monto, string dniVend)
        {
            string[] fila = {
                "PROFORMA",
                nroProforma,
                "",          // DNI vacío
                cliente,
                dniVend,
                codigoProd,
                producto,
                cantidad,
                precio,
                monto.ToString()
            };

            Documentos = AgregarFila(Documentos, fila);
        }
    }
}
