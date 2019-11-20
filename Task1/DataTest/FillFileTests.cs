using System;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
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
            data_copy.AddUser(new User("Michal", "Smutny", 2));
            data_copy.AddUser(new User("Piotr", "Wesoly", 3));
            data_copy.AddUser(new User("Lukasz", "Ciekawy", 4));
            data_copy.AddUser(new User("Joanna", "Wysoka", 5));
            data_copy.AddUser(new User("Barbara", "Kowalska", 6));
            data_copy.AddUser(new User("Katarzyna", "Szybka", 7));

            for (int i = 1; i < 8; i++)
            {
                Assert.AreEqual(data.GetUser(i), data_copy.GetUser(i));
                Assert.AreEqual(data.GetUser(i).LastName, data_copy.GetUser(i).LastName);
                Assert.AreEqual(data.GetUser(i).FirstName, data_copy.GetUser(i).FirstName);
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
                Assert.AreEqual(data.GetProduct(i).ProductName, data_copy.GetProduct(i).ProductName);
                Assert.AreEqual(data.GetProduct(i).ProductPrice, data_copy.GetProduct(i).ProductPrice);
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
    }
}
