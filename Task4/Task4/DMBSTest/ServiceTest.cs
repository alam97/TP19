using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System.Data.Linq.SqlClient;
using System.Linq;
using Task4;

namespace DMBSTest
{
    [TestClass]
    public class ServiceTest
    {

        Store store = new Store();
        [TestMethod]
        public void AddUserAndDeleteUser()
        {
            
            Person person1 = new Person()
            {
                FirstName = "Aleksander",
                LastName = "Brylski",
                Id = 167
            };
            store.AddPerson(person1);
            Assert.AreEqual(true, store.UserExists(167));
            store.DeleteUser(person1);
            Assert.AreEqual(false, store.UserExists(167));

            store.CreateUser("Aleksander", "Brylski", 167);
            Assert.AreEqual(true, store.UserExists(167));
            store.DeleteUser(person1);
            Assert.AreEqual(false, store.UserExists(167));
        }

        [TestMethod]
        public void AddProductAndDeleteProduct()
        {
            Product product1 = new Product()
            {
                Name = "Sword",
                Price = (decimal)17.12,
                Id = 137
            };
            store.AddProduct(product1);
            Assert.AreEqual(true, store.ProductExists(137));
            store.RemoveFromInventory(product1);
            store.DeleteProduct(product1);
            Assert.AreEqual(false, store.ProductExists(137));

            store.CreateProduct("Sword", 17.12, 137);
            Assert.AreEqual(true, store.ProductExists(137));
            store.RemoveFromInventory(product1);
            store.DeleteProduct(product1);
            Assert.AreEqual(false, store.ProductExists(137));
        }

        [TestMethod]
        public void AddEventAndDeleteEvent()
        {
            Product product1 = new Product()
            {
                Name = "Sword",
                Price = (decimal)17.12,
                Id = 137
            };
            store.AddProduct(product1);
            Person person1 = new Person()
            {
                FirstName = "Aleksander",
                LastName = "Brylski",
                Id = 137
            };
            store.AddPerson(person1);
            Event ewent = new Event()
            {
                Id = 137,
                ProductId = product1.Id,
                PersonId = person1.Id,
                EventDate = DateTime.Today
            };

            store.AddEvent(ewent);
            Assert.AreEqual(true, store.GetAllEvents().Contains(ewent));
            store.DeleteEvent(ewent);
            Assert.AreEqual(false, store.GetAllEvents().Contains(ewent));
            store.DeleteUser(person1);
            store.RemoveFromInventory(product1);
            store.DeleteProduct(product1); 
        }

        [TestMethod]
        public void AddToInventoryAndRemoveFromInventory()
        {
            Product product1 = new Product()
            {
                Name = "Sword",
                Price = (decimal)17.12,
                Id = 137
            };
            store.AddProduct(product1);
            store.UpdateInventory(product1, 200);
            Assert.AreEqual(200, store.GetAmountOfProduct(product1));
            store.RemoveFromInventory(product1);
            try
            {
                store.GetAmountOfProduct(product1);
            }
            catch (Exception e)
            {
                Assert.AreEqual("This product does not exist in inventory", e.Message);
            }
            store.DeleteProduct(product1);
        }

        [TestMethod]
        public void BuyItem()
        {
            Person person1 = new Person()
            {
                FirstName = "Aleksander",
                LastName = "Brylski",
                Id = 137
            };
            store.AddPerson(person1);
            Product product1 = new Product()
            {
                Name = "Sword",
                Price = (decimal)17.12,
                Id = 137
            };
            store.AddProduct(product1);
            store.UpdateInventory(product1, 200);
            store.BuyItem(person1, product1, 50);

            Event ewent = new Event()
            {
                ProductId = product1.Id,
                PersonId = person1.Id,
                EventDate = DateTime.Today,
                Id = 0
            };
            Assert.AreEqual(150, store.GetAmountOfProduct(product1));
             store.DeleteEvent(ewent);
            Assert.AreEqual(store.GetAllEvents().Contains(ewent), false);
              store.RemoveFromInventory(product1);
           store.DeleteUser(person1);
         store.DeleteProduct(product1);
        }
    }
}
