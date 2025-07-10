using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OPERACION_WRLF_EXAMEN_2025.BusinessLogic
{
    public static class Validation
    {
        public static bool IsNumeric(string input)
        {
            // Verifica si el string contiene solo dígitos
            return Regex.IsMatch(input, @"^\d+$");
        }

        public static bool IsValidAccountLength(string nroCuenta, string tipoCuenta)
        {
            if (string.IsNullOrWhiteSpace(nroCuenta) || string.IsNullOrWhiteSpace(tipoCuenta))
            {
                return false;
            }

            if (tipoCuenta == "CTE" && nroCuenta.Length != 13)
            {
                return false;
            }
            else if (tipoCuenta == "AHO" && nroCuenta.Length != 14)
            {
                return false;
            }
            return true;
        }

        public static bool IsDecimal(string input)
        {
            return decimal.TryParse(input, out _);
        }
    }
}
