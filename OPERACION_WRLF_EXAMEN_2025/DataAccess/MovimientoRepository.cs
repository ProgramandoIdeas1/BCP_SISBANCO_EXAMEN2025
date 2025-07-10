using Microsoft.Data.SqlClient;
using OPERACION_WRLF_EXAMEN_2025.Models;

namespace OPERACION_WRLF_EXAMEN_2025.DataAccess
{
    public class MovimientoRepository
    {
        public void InsertarMovimiento(Movimiento movimiento)
        {
            string query = "INSERT INTO MOVIMIENTO (NRO_CUENTA, FECHA, TIPO, IMPORTE) VALUES (@NroCuenta, @Fecha, @Tipo, @DImporte)";

            using (SqlConnection connection = DbHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NroCuenta", movimiento.NroCuenta);
                    command.Parameters.AddWithValue("@Fecha", movimiento.Fecha);
                    command.Parameters.AddWithValue("@Tipo", movimiento.Tipo);
                    command.Parameters.AddWithValue("@DImporte", movimiento.Importe); // Usar DImporte para evitar conflicto con palabra reservada IMPORT

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Movimiento> GetMovimientosByNroCuenta(string nroCuenta)
        {
            string query = "SELECT ID_MOVIMIENTO, NRO_CUENTA, FECHA, TIPO, IMPORTE FROM MOVIMIENTO WHERE NRO_CUENTA = @NroCuenta ORDER BY FECHA DESC";
            List<Movimiento> movimientos = new List<Movimiento>();

            using (SqlConnection connection = DbHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NroCuenta", nroCuenta);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            movimientos.Add(new Movimiento
                            {
                                IdMovimiento = Convert.ToInt32(reader["ID_MOVIMIENTO"]),
                                NroCuenta = reader["NRO_CUENTA"].ToString(),
                                Fecha = Convert.ToDateTime(reader["FECHA"]),
                                Tipo = reader["TIPO"].ToString(),
                                Importe = Convert.ToDecimal(reader["IMPORTE"])
                            });
                        }
                    }
                }
            }
            return movimientos;
        }
    }
}
