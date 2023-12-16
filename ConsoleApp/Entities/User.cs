using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Entities
{
    public enum UserRole
    {
        ADMIN, AGENT, CLIENT
    }

    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

        public User() { }

        public User(int userId, string username, string password, UserRole role)
        {
            UserId = userId;
            Username = username;
            Password = password;
            Role = role;
        }

        public override string ToString()
        {
            return $"User ID: {UserId}, Username: {Username}, Role: {Role}";
        }
    }
}
