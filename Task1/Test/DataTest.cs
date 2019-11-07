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
            DataFill fillConst = new FillConst();
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
            DataFill fillConst = new FillConst();
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
            DataFill fillConst = new FillConst();
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
            DataFill fillConst = new FillConst();
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
            DataFill fillConst = new FillConst();
            DataRepository data = new DataRepository(fillConst);


            Product P = new Product("Knife", 123.13, 66);
            data.AddProductToInventory(P, 10);
            data.UpdateInventory(P, 5);
            Assert.AreEqual(5, data.GetAmountOfProduct(P));
        }
    
        [TestMethod()]
        public void DeleteFromInventory()
        {
            DataFill fillConst = new FillConst();
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
            DataFill fillConst = new FillConst();
            DataRepository data = new DataRepository(fillConst);


            Event E = new Event(data.GetUser(7), data.GetProduct(5), DateTime.Today);
            data.AddEvent(E);
            Assert.AreEqual(E, data.GetEvent(9)); //9 is a number of events in FillConst
        }

        [TestMethod()]
        public void DeleteEvent()
        {
            DataFill fillConst = new FillConst();
            DataRepository data = new DataRepository(fillConst);

            
            Event E = new Event(data.GetUser(7), data.GetProduct(5), DateTime.Today);
            data.AddEvent(E);
            Assert.AreEqual(E, data.GetEvent(9)); //9 is a number of events in FillConst

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



    }

    #region FillFile
    [TestClass()]
    public class FillFileTests
    {
        [TestMethod()]
        public void UserFile()
        {

            DataFill fillFile = new FillFile();
            DataRepository data = new DataRepository(fillFile);
            DataRepository data_copy = new DataRepository();
            data_copy.AddUser(new User("Jan", "Kowalski", 1));
            data_copy.AddUser(new User("Michał", "Smutny", 2));
            data_copy.AddUser(new User("Piotr", "Wesoły", 3));
            data_copy.AddUser(new User("Łukasz", "Ciekawy", 4));
            data_copy.AddUser(new User("Joanna", "Wysoka", 5));
            data_copy.AddUser(new User("Barbara", "Kowalska", 6));
            data_copy.AddUser(new User("Katarzyna", "Szybka", 7));

            for (int i = 1; i < 8; i++)
            {
                Assert.AreEqual(data.GetUser(i), data_copy.GetUser(i));
            }
        }

        [TestMethod()]
        public void CatalogFile()
        {

            DataFill fillFile = new FillFile();
            DataRepository data = new DataRepository(fillFile);
            DataRepository data_copy = new DataRepository();

            data_copy.AddProduct(new Product("Sword", 21.21, 1));
            data_copy.AddProduct(new Product("Spear", 23.99, 2));
            data_copy.AddProduct(new Product("Armour", 87.31, 3));
            data_copy.AddProduct(new Product("Axe", 45.11, 4));
            data_copy.AddProduct(new Product("Bow", 19.99, 5));
            data_copy.AddProduct(new Product("Arrow", 1.16, 6));
            for (int i = 1; i < 7; i++)
            {
                Assert.AreEqual(data.GetProduct(i), data_copy.GetProduct(i));
            }
        }

        [TestMethod()]
        public void EventsFile()
        {

            DataFill fillFile = new FillFile();
            DataRepository data = new DataRepository(fillFile);
            DataRepository data_copy = new DataRepository();

            data_copy.AddUser(new User("Jan", "Kowalski", 1));
            data_copy.AddUser(new User("Michał", "Smutny", 2));
            data_copy.AddUser(new User("Piotr", "Wesoły", 3));
            data_copy.AddUser(new User("Łukasz", "Ciekawy", 4));
            data_copy.AddUser(new User("Joanna", "Wysoka", 5));
            data_copy.AddUser(new User("Barbara", "Kowalska", 6));
            data_copy.AddUser(new User("Katarzyna", "Szybka", 7));
            data_copy.AddProduct(new Product("Sword", 21.21, 1));
            data_copy.AddProduct(new Product("Spear", 23.99, 2));
            data_copy.AddProduct(new Product("Armour", 87.31, 3));
            data_copy.AddProduct(new Product("Axe", 45.11, 4));
            data_copy.AddProduct(new Product("Bow", 19.99, 5));
            data_copy.AddProduct(new Product("Arrow", 1.16, 6));

            for (int i = 1; i < 6; i++)
            {
                data_copy.AddEvent(new Event(data.GetUser(i), data.GetProduct(i), DateTime.Today));
            }

            //RELATIONS ONE TO MANY (USER BUYS SEVERAL PRODUCTS ON ONE INVOICE)
            data_copy.AddEvent(new Event(data_copy.GetUser(6), data.GetProduct(1), DateTime.Today));
            data_copy.AddEvent(new Event(data_copy.GetUser(6), data.GetProduct(2), DateTime.Today));
            data_copy.AddEvent(new Event(data_copy.GetUser(6), data.GetProduct(3), DateTime.Today));
            data_copy.AddEvent(new Event(data_copy.GetUser(6), data.GetProduct(4), DateTime.Today));

            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(data.GetEvent(i).EventCatalog, data_copy.GetEvent(i).EventCatalog);
                Assert.AreEqual(data.GetEvent(i).EventUser, data_copy.GetEvent(i).EventUser);
            }
        }

        [TestMethod()]
        public void InventoryFile()
        {

            DataFill fillFile = new FillFile();
            DataRepository data = new DataRepository(fillFile);
            DataRepository data_copy = new DataRepository();
            for (int i = 1; i < 7; i++)
            {
                Random amount = new Random();
                data_copy.AddProductToInventory(data.GetProduct(i), i + 9);
            }

            int k = 1;
            foreach (Product c in data_copy.GetAllProducts())
            {
                Assert.AreEqual(c, data.GetProduct(k));
                Assert.AreEqual(data_copy.GetAmountOfProduct(c), data.GetAmountOfProduct(c));
                k++;
            }


        }


        #endregion
    }
}


