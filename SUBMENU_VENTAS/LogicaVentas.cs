using BIBLIOTECA_REGISTRA;

namespace SUBMENU_VENTAS
{
    public static class LogicaVentas
    {
        // ============================================================
        // ARREGLO — CADA PRODUCTO ES UNA FILA
        // ============================================================
        // [0] Tipo documento (BOLETA, FACTURA)
        // [1] Número documento
        // [2] DNI/RUC del cliente
        // [3] Nombre cliente / Empresa
        // [4] DNI vendedor
        // [5] Código producto
        // [6] Producto
        // [7] Cantidad
        // [8] Precio unitario
        // [9] Subtotal
        // ============================================================

        public static string[,] Documentos = new string[0, 10];

        // ============================================================
        // FUNCIÓN PARA AGREGAR UNA FILA
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
        // GUARDAR BOLETA — UNA FILA POR CADA PRODUCTO
        // ============================================================
        public static void GuardarBoleta(
            string nroBoleta,
            string dniCli,
            string nombreCli,
            string dniVend,
            string codigoProd,
            string producto,
            string cantidad,
            string precio,
            double subtotal)
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
                subtotal.ToString()
            };

            Documentos = AgregarFila(Documentos, fila);
        }

        // ============================================================
        // GUARDAR FACTURA — UNA FILA POR PRODUCTO
        // ============================================================
        public static void GuardarFactura(
            string ruc,
            string empresa,
            string nroFactura,
            string codigoProd,
            string producto,
            string cantidad,
            string precio,
            double subtotal,
            string dniVend)
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
                subtotal.ToString()
            };

            Documentos = AgregarFila(Documentos, fila);
        }
    }
}
