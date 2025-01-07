using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chuongtrinhquanlygarage.Database.Repository;
using chuongtrinhquanlygarage.Database;

namespace chuongtrinhquanlygarage.Models
{
    public static class UserSession
    {
        private static UserRepository userRepo = new UserRepository(new DatabaseContext());
        public static User CurrentUser { get; private set; }

        public static void SetUser(User user)
        {
            CurrentUser = user;
        }

        public static void Clear()
        {
            CurrentUser = null;
        }

        public static bool HasRole(string role)
        {
            // Fetch the role of the current user using their EmpID
            string empRole = userRepo.GetRoleEmployee(CurrentUser.EmpID);

            if (empRole == null)
            {
                return false;
            }

            // Fetch the user's role from the database or check the in-memory property
            return string.Equals(empRole, role, StringComparison.OrdinalIgnoreCase);
        }
    }
}
