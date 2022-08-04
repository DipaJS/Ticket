using System;
using System.Collections.Generic;
using System.Linq;
using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repositories
{
    public class UserRepository
    {
        private readonly List<User> users = new()
        {
            new() { FirstName = "John", LastName = "Smith", Username = "jsmith" },
            new() { FirstName = "Sarah", LastName = "Berg", Username = "sberg" }
        };

        public User GetUser(string username)
        {
            return users.FirstOrDefault(a => a.Username == username);
        }

        public User GetAccountManager()
        {
            // Assume this method does not need to change.
            return GetUser("sberg");
        }
    }
}
