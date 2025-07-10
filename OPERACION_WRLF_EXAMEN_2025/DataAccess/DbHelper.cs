using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace OPERACION_WRLF_EXAMEN_2025.DataAccess
{
    public class DbHelper
    {
        private static string? connectionString;
        private static IConfiguration _configuration;

        // Constructor estático para inicializar la configuración y la cadena de conexión
        static DbHelper()
        {
            // Configurar el cargador de configuración para leer appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Busca appsettings.json en el directorio de ejecución
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // Carga el archivo

            _configuration = builder.Build();

            // Obtener la cadena de conexión
            connectionString = _configuration.GetConnectionString("BancoDB");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("La cadena de conexión 'BancoDB' no se encontró o está vacía en 'appsettings.json'.");
            }
        }

        // Método para obtener una nueva conexión a la base de datos
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Método para probar la conexión (útil para depuración)
        public static bool TestConnection()
        {
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error de SQL al conectar: {ex.Message}");
                    // Aquí podrías loggear el error para un entorno real
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error general al conectar: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
