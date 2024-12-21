using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chuongtrinhquanlygarage.Models
{
    public class User
    {
        public string UserID { get; set; }       // Unique identifier for the user
        public string EmpID { get; set; }
        public string Username { get; set; }     // User's username
        public string PasswordHash { get; set; } // Secure hashed password
        public string Role { get; set; }         // User role (e.g., "employee", "admin")
        public DateTime CreatedAt { get; set; }  // Account creation timestamp
        public DateTime? UpdatedAt { get; set; } // Account update timestamp (nullable)

        // Constructor for initialization
        public User(string userID, string empID, string username, string passwordHash, string role, DateTime createdAt, DateTime? updatedAt = null)
        {
            UserID = userID;
            EmpID = empID;
            Username = username;
            PasswordHash = passwordHash;
            Role = role;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        // Default constructor
        public User() { }

        // Method to check if a user has a specific role
        public bool HasRole(string roleToCheck)
        {
            return string.Equals(Role, roleToCheck, StringComparison.OrdinalIgnoreCase);
        }
    }
}
