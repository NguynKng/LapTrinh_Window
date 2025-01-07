using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace chuongtrinhquanlygarage.Models
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int BaseSalary { get; set; }
        public string EmpType { get; set; }

        public Employee(string id, string name, string phoneNumber, string gender, string email, int baseSalary, string empType)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Email = email;
            BaseSalary = baseSalary;
            EmpType = empType;
        }

        public Employee() { }
    }
}
