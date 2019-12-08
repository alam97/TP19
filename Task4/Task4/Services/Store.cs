using Data;
using System;
using System.Collections.Generic;
using System.Text;


namespace Services
{
    class Store


    {
        private LinqToSqlDataContext db;


        public Store()
        {
            this.db = new LinqToSqlDataContext();
        }
        #region add
        public void AddUser(Person p)
        {

        }
        public void AddProduct(Product p)
        {

        }
        public void AddEvent(Event e)
        {

        }
        public void AddToInventory(Product p, int amount)
        {

        }
        #endregion

        #region create
        public void CreateUser(string firstName, string lastName, int userId)
        {

        }
        public void CreateProduct(string productName, double productPrice, int productId)
        { }

        public void CreateEvent(Person user, Product catalog, DateTimeOffset date) { }
        #endregion

        #region delete
        public void DeleteUser(Person u) { }
        public void DeleteProduct(Product p) { }
        public void DeleteEvent(Event e) { }
        #endregion

        #region update
        public void UpdateInventory(Product p, int amount) { }
        #endregion

        #region exists
        public Boolean ProductExists(Product p) { return true; }
        public Boolean UserExists(Person u) { return true; }
        public Boolean ProductExistsinInventory(Product p) { return true; }
        #endregion

        #region shop actions
        // buy an item -> creates an invoice, updates inventory
        public void BuyItem(Person user, Product product, int amount)
        {

        }

        #endregion
    }
}
