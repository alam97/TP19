using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class Shop
    {
        private DataRepository data;

        public Shop(DataRepository data)
        {
            this.data = data;
        }

        #region add
        public void AddUser(User u) => this.data.AddUser(u);
        public void AddCatalog(Catalog c) => this.data.AddCatalog(c);
        public void AddEvent(Event e) => this.data.AddEvent(e);
        public void AddInventory(Inventory i) => this.data.AddInventory(i);
        #endregion

        #region create
        public void CreateUser(string firstName, string lastName, int userId) => this.data.AddUser(new User(firstName, lastName, userId));
        public void CreateCatalog(string productName, double productPrice, int productId) => this.data.AddCatalog(new Catalog(productName, productPrice, productId));
        public void CreateEvent(User user, Catalog catalog, DateTimeOffset date) => this.data.AddEvent(new Event(user, catalog, date));
        public void CreateInventory(Catalog catalog, int amount, DateTimeOffset date, int inventoryId) => this.data.AddInventory(new Inventory(catalog, amount, date, inventoryId));
        #endregion

        #region shop actions
        // buy an item -> 
        // public void BuyItem(User u, int item, int amount)
        //{
        //    Catalog c = data.GetCatalog(item);
        //    Random random = new Random();
        //    int eventId = random.Next(1, 1000);
        //    CreateEvent(u, c, DateTimeOffset.Now, eventId);

        //}

        // 
        #endregion
    }
}
