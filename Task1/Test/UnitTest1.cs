using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Test
{
    [TestClass()]
    public class DataRepositoryTests
    {
        #region Users
        [TestMethod()]
        public void AddUser()
        {
            DataContext context = new DataContext();
            FillConst fillConst = new FillConst();
            DataRepository data = new DataRepository(context, fillConst);
            data.FillStatic();

            User U = new User("Aleksander", "Brylski", 66);
            data.AddUser(U);
             if (!U.Equals(context.users[context.users.Count() - 1])) Assert.Fail();
        }

        [TestMethod()]
        public void GetWykazTest()
        {
            DataContext context = new DataContext();
            FillConst fillConst = new FillConst();
            DataRepository data = new DataRepository(context, fillConst);
            data.FillStatic();

            //The same values
            User U = new User("Jan", "Kowalski", 1);
            Console.WriteLine(data.GetUser(U.UserID).UserID);
            Console.WriteLine(data.GetUser(U.UserID).FirstName);
            Console.WriteLine(data.GetUser(U.UserID).LastName);
            if (!U.Equals(data.GetUser(U.UserID))) Assert.Fail();
        }
    }
    #endregion
}
