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
        public void AddUserAndGet()
        {
            FillConst fillConst = new FillConst();
            DataRepository data = new DataRepository(fillConst);

            User U = new User("Aleksander", "Brylski", 66);
            data.AddUser(U);
            Assert.AreEqual(U, data.GetUser(66));

            //The same values
            User U1 = new User("Jan", "Kowalski", 1);
            Assert.AreEqual(U1, data.GetUser(U1.UserID));
        }

        [TestMethod()]
        public void DeleteUser()
        {
            FillConst fillConst = new FillConst();
            DataRepository data = new DataRepository(fillConst);

            User U = new User("Aleksander", "Brylski", 66);
            data.AddUser(U);
            Assert.AreEqual(U, data.GetUser(66));

            data.DeleteUser(data.GetUser(66));
            try
            {
                data.GetUser(66);
            }
            catch (Exception e)
            {
                Assert.AreEqual("No such an user", e.Message);
            }
        }

        #endregion

        #region Products
        [TestMethod()]
        public void AddProductAndGetProduct()
        {
            FillConst fillConst = new FillConst();
            DataRepository data = new DataRepository(fillConst);

            Product P = new Product("Knife", 123.13, 66);
            data.AddProduct(P);
            Assert.AreEqual(P, data.GetProduct(66));

            //The same values
            Product P1 = new Product("Sword", 21.21, 1);
            Assert.AreEqual(P1, data.GetProduct((P1.ProductID)));
        }

        [TestMethod()]
        public void DeleteProduct()
        {
            FillConst fillConst = new FillConst();
            DataRepository data = new DataRepository(fillConst);

            Product P = new Product("Knife", 123.13, 66);
            data.AddProduct(P);
            Assert.AreEqual(P, data.GetProduct(66));

            data.DeleteProduct(data.GetProduct(66));
            try
            {
                data.GetProduct(66);
            }
            catch (Exception e)
            {
                Assert.AreEqual("No product with such an id", e.Message);
            }
        }
        #endregion

        #region Inventory
        [TestMethod()]
        public void AddToInventoryAndUpdate()
        {
            FillConst fillConst = new FillConst();
            DataRepository data = new DataRepository(fillConst);

            Product P = new Product("Knife", 123.13, 66);
            data.AddProductToInventory(P, 10);
            data.UpdateInventory(P, 5);
        }
    
        [TestMethod()]
        public void DeleteFromInventory()
        {
            FillConst fillConst = new FillConst();
            DataRepository data = new DataRepository(fillConst);

            Product P = new Product("Knife", 123.13, 66);

            data.DeleteFromInventory(data.GetProduct(1));

            try
            {
                data.DeleteFromInventory(P);
            }
            catch (Exception e)
            {
                Assert.AreEqual("No such product in inventory!", e.Message);
            }
        }
        #endregion

        #region Events
        [TestMethod()]
        public void AddEventAndGetEvent()
        {
            FillConst fillConst = new FillConst();
            DataRepository data = new DataRepository(fillConst);

            Event E = new Event(data.GetUser(7), data.GetProduct(5), DateTime.Today);
            data.AddEvent(E);
            Assert.AreEqual(E, data.GetEvent(9));
        }

        [TestMethod()]
        public void DeleteEvent()
        {
            FillConst fillConst = new FillConst();
            DataRepository data = new DataRepository(fillConst);

            Event E = new Event(data.GetUser(7), data.GetProduct(5), DateTime.Today);
            data.AddEvent(E);
            Assert.AreEqual(E, data.GetEvent(9));

            data.DeleteEvent(data.GetEvent(9));
            try
            {
                data.GetEvent(9);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Such an event does not exist!", e.Message);
            }
        }
        #endregion


        #region Shop


        [TestMethod()]
        public void ShopCreateAndDelete()
        {
            FillConst fillConst = new FillConst();
            Shop shop = new Shop(fillConst);

            User U = new User("Aleksander", "Brylski", 66);
            shop.CreateUser("Aleksander", "Brylski", 66);
            Assert.AreEqual(U, shop.Data.GetUser(66));

            shop.DeleteUser(shop.Data.GetUser(66));
            try
            {
                shop.Data.GetUser(66);
            }
            catch (Exception e)
            {
                Assert.AreEqual("No such an user", e.Message);
            }
        }
        public void BuyItem()
        {
            FillConst fillConst = new FillConst();
            Shop shop = new Shop(fillConst);

            User U = new User("Aleksander", "Brylski", 66);
            shop.CreateUser("Aleksander", "Brylski", 66);
            Assert.AreEqual(U, shop.Data.GetUser(66));

            Product P = new Product("Knife", 14.21, 11);
            shop.CreateProduct("Knife", 14.21, 11);
            Assert.AreEqual(P, shop.Data.GetProduct(11));

            shop.AddToInventory(P, 25);
            Assert.Equals(true, shop.Data.ProductExistsinInventory(P));

            shop.BuyItem(shop.Data.GetUser(66), shop.Data.GetProduct(11), 5);

            //shop.Data.GetInventory.
  
          //  Assert.AreEqual(U, shop.Data.GetUser(66));

       
        }


        #endregion
    }
}


