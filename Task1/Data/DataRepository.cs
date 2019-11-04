using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataRepository
    {
        private DataContext context;

        public DataRepository(DataContext c)
        {
            this.context = c;
        }

        #region User
        public void AddUser(User u)
        {
            if (context.users.Exists(x => x.UserID == u.UserID))
            {
                throw new Exception("Such an user already exists");
            }
            context.users.Add(u);
        }

        public User GetUser(int id)
        {
            if (context.users.Exists(x=>x.UserID == id))
            {
                return context.users[id];
            }
            throw new Exception("No such an user");
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.users;
        }

        public void DeleteUser(int id)
        {
            User tmp = GetUser(id);
            context.users.Remove(tmp);
        }
        #endregion
    }
}
