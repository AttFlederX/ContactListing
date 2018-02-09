using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using ContactListing.Models;

namespace ContactListing.Services
{
    // A mockup of a database querying class that can be modified later 
    public static class UserService
    {
        private static List<User> userDB = new List<User>() {
            new User("attflederx@gmail.com", "11111111"),
            new User("a@a.a", "11111111")
        };

        public static void AddUser(User _user)
        {
            if (userDB.SingleOrDefault(u => (u.Email == _user.Email)) != null)
            {
                throw new ArgumentException("This account already exists");
            }

            userDB.Add(_user);
        }

        public static async Task<User> GetUserAsync(string email)
        {
            User result = await Task.Run(() =>
            {
                Thread.Sleep(3000); // activity simulation
                return userDB.SingleOrDefault(u => (u.Email == email));
            });
            return result;
        }

        public static void AddUserContact(int userID, Contact contact)
        {
            var user = userDB.SingleOrDefault(u => (u.ID == userID));
            user.ContactList.Add(contact);
        }

        public static void RemoveUserContact(int userID, int contactID)
        {
            var user = userDB.SingleOrDefault(u => (u.ID == userID));
            user.ContactList.Remove(user.ContactList.SingleOrDefault(c => (c.ID == contactID)));
        }
    }
}
