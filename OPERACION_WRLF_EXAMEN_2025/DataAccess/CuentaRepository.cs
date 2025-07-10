using Microsoft.Data.SqlClient;
using OPERACION_WRLF_EXAMEN_2025.Models;

namespace OPERACION_WRLF_EXAMEN_2025.DataAccess
{
    public class CuentaRepository
    {
        public void InsertarCuenta(Cuenta cuenta)
        {
            string query = "INSERT INTO CUENTA (NRO_CUENTA, TIPO, MONEDA, NOMBRE, SALDO) VALUES (@NroCuenta, @Tipo, @Moneda, @Nombre, @Saldo)";

            using (SqlConnection connection = DbHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NroCuenta", cuenta.NroCuenta);
                    command.Parameters.AddWithValue("@Tipo", cuenta.Tipo);
                    command.Parameters.AddWithValue("@Moneda", cuenta.Moneda);
                    command.Parameters.AddWithValue("@Nombre", cuenta.Nombre);
                    command.Parameters.AddWithValue("@Saldo", cuenta.Saldo);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public Cuenta GetCuentaByNroCuenta(string nroCuenta)
        {
            string query = "SELECT NRO_CUENTA, TIPO, MONEDA, NOMBRE, SALDO FROM CUENTA WHERE NRO_CUENTA = @NroCuenta";
            Cuenta cuenta = null;

            using (SqlConnection connection = DbHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NroCuenta", nroCuenta);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cuenta = new Cuenta
                            {
                                NroCuenta = reader["NRO_CUENTA"].ToString(),
                                Tipo = reader["TIPO"].ToString(),
                                Moneda = reader["MONEDA"].ToString(),
                                Nombre = reader["NOMBRE"].ToString(),
                                Saldo = Convert.ToDecimal(reader["SALDO"])
                            };
                        }
                    }
                }
            }
            return cuenta;
        }

        public void ActualizarSaldo(string nroCuenta, decimal nuevoSaldo)
        {
            string query = "UPDATE CUENTA SET SALDO = @NuevoSaldo WHERE NRO_CUENTA = @NroCuenta";

            using (SqlConnection connection = DbHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NuevoSaldo", nuevoSaldo);
                    command.Parameters.AddWithValue("@NroCuenta", nroCuenta);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Cuenta> GetAllCuentas()
        {
            string query = "SELECT NRO_CUENTA, TIPO, MONEDA, NOMBRE, SALDO FROM CUENTA";
            List<Cuenta> cuentas = new List<Cuenta>();

            using (SqlConnection connection = DbHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cuentas.Add(new Cuenta
                            {
                                NroCuenta = reader["NRO_CUENTA"].ToString(),
                                Tipo = reader["TIPO"].ToString(),
                                Moneda = reader["MONEDA"].ToString(),
                                Nombre = reader["NOMBRE"].ToString(),
                                Saldo = Convert.ToDecimal(reader["SALDO"])
                            });
                        }
                    }
                }
            }
            return cuentas;
        }
    }
}
