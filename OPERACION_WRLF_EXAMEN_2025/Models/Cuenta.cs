namespace OPERACION_WRLF_EXAMEN_2025.Models
{
    public class Cuenta
    {
        public string NroCuenta { get; set; }
        public string Tipo { get; set; } // AHO/CTE
        public string Moneda { get; set; }
        public string Nombre { get; set; }
        public decimal Saldo { get; set; }
    }
}
