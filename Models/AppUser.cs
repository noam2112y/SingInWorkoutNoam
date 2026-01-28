using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignInWorkoutYavin.Models
{
    public class User
    {
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public bool IsAdmin { get; set; }
        public  int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime UBDate { get; set; }
        public DateTime RegDate { get; set; }
    }
}
