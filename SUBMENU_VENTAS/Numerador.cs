namespace SUBMENU_VENTAS
{
    public static class Numerador
    {
        public static int contadorBoleta = 1;
        public static int contadorFactura = 1;
        public static int contadorGuia = 1;
        public static int contadorProforma = 1;

        // SOLO MUESTRA el número actual (NO incrementa)
        public static string VerBoletaActual() => "B" + contadorBoleta.ToString("000");
        public static string VerFacturaActual() => "F" + contadorFactura.ToString("000");

        // SOLO cuando se GUARDA se consume el número
        public static void ConsumirBoleta() => contadorBoleta++;
        public static void ConsumirFactura() => contadorFactura++;
    }
}
