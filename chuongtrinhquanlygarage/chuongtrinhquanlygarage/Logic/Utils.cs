using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace chuongtrinhquanlygarage.Logic
{
    public class Utils
    {
        public static bool IsValidLicensePlate(string licensePlate)
        {
            if (string.IsNullOrWhiteSpace(licensePlate))
                return false;

            string pattern = @"^\d{2}[A-Z]{1}\d{1}-\d{4,5}$";

            return Regex.IsMatch(licensePlate, pattern);
        }
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Số điện thoại Việt Nam: bắt đầu bằng 0 và dài 10-11 ký tự
            string pattern = @"^0\d{9,10}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        public static bool IsValidEmail(string email)
        {
            // Định dạng email chung
            string pattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
