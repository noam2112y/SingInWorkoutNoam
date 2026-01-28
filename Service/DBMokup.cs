using SignInWorkoutYavin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignInWorkoutYavin.Service
{
    public interface IDBService
    {
        bool IsExist(string uEmail, string uPass);
        void AddUser(AppUser user);
        AppUser GetUserByEmail(string uEmail);
        void RemoveUser(AppUser user);
        void UpdateUser(AppUser user);

        
    }


    public class DBMokup : IDBService
    {
        private List<AppUser> _users;
        public List<AppUser> Users { get { return _users; } }

        public DBMokup()
        {
            _users = new List<AppUser>();
            _users.Add(new AppUser { FirstName = "Noam", LastName = "1234567890", UserEmail = "Noam", UserPassword = "1234567890", IsAdmin = true });
            _users.Add(new AppUser { FirstName = "AA", LastName = "BB", UserEmail = "User1@gmail.com", UserPassword = "pass1" });
            _users.Add(new AppUser { FirstName = "CC", LastName = "DD", UserEmail = "user2@gmail.com", UserPassword = "pass2" });
        }

        public bool IsExist(string uEmail, string uPass)
        {
            return _users.Any(u => u.UserEmail == uEmail && u.UserPassword == uPass);
        }
        public AppUser GetUserByEmail(string uEmail)
        {
            return _users.FirstOrDefault(u => u.UserEmail == uEmail)!;
        }
        public void AddUser(AppUser user)
        {
            if (user != null)
            {
                _users.Add(user);
            }
        }
        public void RemoveUser(AppUser user)
        {
            if (user != null && _users.Contains(user))
            {
                _users.Remove(user);
            }
        }
        public void UpdateUser(AppUser user)
        {
            if (user != null && _users.Contains(user))
            {
                var index = _users.IndexOf(user);
                if (index >= 0)
                {
                    _users[index] = user;
                }
            }
        }
    }
}