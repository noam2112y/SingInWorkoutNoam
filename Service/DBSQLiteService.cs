using SignInWorkoutYavin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignInWorkoutYavin.Service
{
    public class DBSQLiteService : IDBService
    {
        public void AddUser(AppUser user)
        {
            throw new NotImplementedException();
        }

        public AppUser GetUserByEmail(string uEmail)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(string uEmail, string uPass)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(AppUser user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
