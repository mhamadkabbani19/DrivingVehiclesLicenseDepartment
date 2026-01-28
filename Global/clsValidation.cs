using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DrivingVehiclesLicense
{
    public class clsValidation
    {
        public static bool ValidateEmail(string EmailAddress)
        {
            var pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

            var regex = new Regex(pattern);

            return regex.IsMatch(EmailAddress);
        }

        public static bool IsInteger(string Number)
        {
            var pattern = @"^[0-9]*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool IsFloat(string Number)
        {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool IsNumber(string Number)
        {
            return IsInteger(Number) || IsFloat(Number);
        }
    }
}
