namespace OPERACION_WRLF_EXAMEN_2025.Models
{
    public class Movimiento
    {
        public int IdMovimiento { get; set; } // Puede ser nulo para inserciones
        public string NroCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } // D-Debito, A-Abono
        public decimal Importe { get; set; }
    }
}
