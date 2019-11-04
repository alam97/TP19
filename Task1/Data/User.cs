using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class User
    {
        private string firstName;
        private string lastName;
        private int userId;
        public User(string fname, string lname, int id)
        {
            this.firstName = fname;
            this.lastName = lname;
            this.userId = id;
        }

        public override bool Equals(object obj)
        {
            User compare = (User)obj;
            return this.userId == compare.userId;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int UserID { get => userId; set => userId = value; }
    }
}
