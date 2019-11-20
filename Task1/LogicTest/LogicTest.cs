using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using Test;

namespace Test
{
    [TestClass]
    public class LogicTest
    {
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

            Product P = new Product("Knife", 14.21, 7);
            shop.CreateProduct("Knife", 14.21, 7);
            Assert.AreEqual(P, shop.Data.GetProduct(7));

            shop.AddToInventory(P, 25);
            Assert.Equals(true, shop.Data.ProductExistsinInventory(P));
            shop.BuyItem(shop.Data.GetUser(66), shop.Data.GetProduct(7), 5);

            DataRepository data_copy = new DataRepository();

            data_copy.AddProduct(new Product("Sword", 21.21, 1));
            data_copy.AddProduct(new Product("Spear", 23.99, 2));
            data_copy.AddProduct(new Product("Armour", 87.31, 3));
            data_copy.AddProduct(new Product("Axe", 45.11, 4));
            data_copy.AddProduct(new Product("Bow", 19.99, 5));
            data_copy.AddProduct(new Product("Arrow", 1.16, 6));
            data_copy.AddProduct(new Product("Knife", 14.21, 7));
            data_copy.AddProductToInventory(data_copy.GetProduct(7), 20); //25-5

            int k = 1;
            foreach (Product c in shop.Data.GetAllProducts())
            {
                Assert.AreEqual(c, data_copy.GetProduct(k));
                Assert.AreEqual(data_copy.GetAmountOfProduct(c), shop.Data.GetAmountOfProduct(c));
                k++;
            }
        }
        #endregion
    }
}

