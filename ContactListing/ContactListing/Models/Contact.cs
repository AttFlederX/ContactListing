using System;
using System.Collections.Generic;
using System.Text;

namespace ContactListing.Models
{
    public class Contact
    {
        private static int counter = 0;

        public int ID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string ImageURL { get => "http://placehold.it/100x100"; } // best i can do so far
        public bool Important { get; set; }

        public Contact(string firstName, string lastName, string countryCode, string number, string email, bool important)
        {
            ID = counter++;
            Name = $"{firstName} {lastName}";

            string regionCode = number.Substring(0, number.Length - 7);
            int phoneNumber = int.Parse(number.Substring(number.Length - 7, 7));

            Number = string.Format("+{0} ({1}) {2:###-####}", countryCode, regionCode, phoneNumber);
            Email = email;
            Important = important;
        }
    }
}
