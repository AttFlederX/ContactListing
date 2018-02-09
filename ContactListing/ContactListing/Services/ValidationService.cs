using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ContactListing.Services
{
    // A mockup validation service for user data
    public static class ValidationService
    {
        private static Regex emailValidator = new Regex(@"^[0-9a-z\.]+@\w+.\w+$");

        public static bool IsEmailValid(string email)
        {
            return (!string.IsNullOrWhiteSpace(email) && emailValidator.IsMatch(email));
        }

        public static bool IsPasswordValid(string password)
        {
            return (!string.IsNullOrWhiteSpace(password) && password.Length > 7);
        }
    }
}
