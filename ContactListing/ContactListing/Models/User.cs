using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ContactListing.Models
{
    public class User
    {
        private static int counter = 0;

        public int ID { get; }
        public string Email { get; }
        public string Password { get; set; }
        public ObservableCollection<Contact> ContactList { get; set; }

        public User(string email, string password)
        {
            ID = counter++;
            Email = email;
            Password = password;
            ContactList = new ObservableCollection<Contact>();
        }
    }
}
