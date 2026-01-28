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
        void AddUser(User user);
        User GetUserByEmail(string uEmail);
        void RemoveUser(User user);
        void UpdateUser(User user);

        
    }


    public class DBMokup : IDBService
    {
        private List<User> _users;
        public List<User> Users { get { return _users; } }

        public DBMokup()
        {
            _users = new List<User>();
            _users.Add(new User { FirstName = "Noam", LastName = "1234567890", UserEmail = "Noam", UserPassword = "1234567890", IsAdmin = true });
            _users.Add(new User { FirstName = "AA", LastName = "BB", UserEmail = "User1@gmail.com", UserPassword = "pass1" });
            _users.Add(new User { FirstName = "CC", LastName = "DD", UserEmail = "user2@gmail.com", UserPassword = "pass2" });
        }

        public List<User> GetUsers() { return _users; }
        public bool IsExist(string uEmail, string uPass)
        {
            return _users.Any(u => u.UserEmail == uEmail && u.UserPassword == uPass);
        }
        public User GetUserByEmail(string uEmail)
        {
            return _users.FirstOrDefault(u => u.UserEmail == uEmail)!;
        }
        public void AddUser(User user)
        {
            if (user != null)
            {
                _users.Add(user);
            }
        }
        public void RemoveUser(User user)
        {
            if (user != null && _users.Contains(user))
            {
                _users.Remove(user);
            }
        }
        public void UpdateUser(User user)
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