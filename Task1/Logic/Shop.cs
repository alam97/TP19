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

        public Shop(DataFill fill)
        {
            data = new DataRepository();
        }

        #region add
        public void AddUser(User u) => this.data.AddUser(u);
        public void AddProduct(Product p) => this.data.AddProduct(p);
        public void AddEvent(Event e) => this.data.AddEvent(e);
        public void AddProductToInventoryy(Product p, int amount) => this.data.AddProductToInventoryy(p, amount);
        #endregion

        #region exists
        public Boolean ProductExists(Product p) => this.data.ProductExists(p);
        public Boolean ProductExistsinInventory(Product p) => this.data.ProductExistsinInventory(p);
        #endregion

        #region create
        public void CreateUser(string firstName, string lastName, int userId) => this.data.AddUser(new User(firstName, lastName, userId));
        public void CreateProduct(string productName, double productPrice, int productId) => this.data.AddProduct(new Product(productName, productPrice, productId));
        public void CreateEvent(User user, Product catalog, DateTimeOffset date) => this.data.AddEvent(new Event(user, catalog, date));
        #endregion

        #region delete
        public void DeleteUser(User u) => this.data.DeleteUser(u);
        public void DeleteProduct(Product p) => this.data.DeleteProduct(p);
        public void DeleteEvent(Event e) => this.data.DeleteEvent(e);
        #endregion

        #region get
        public void GetUser(int id) => this.data.GetUser(id);
        public void GetProduct(int id) => this.data.GetProduct(id);
        public void GetEvent(int id) => this.data.GetEvent(id);
        #endregion

        #region getall
        public IReadOnlyList<User> GetAllUsers() => this.data.GetAllUsers();
        public IReadOnlyList<Product> GetAllProducts() => this.data.GetAllProducts();
        public IReadOnlyDictionary<Product, int> GetInventory() => this.data.GetInventory();
        public IReadOnlyList<Event> GetEvents() => this.data.GetAllEvents();
        #endregion

        #region update
        public void UpdateInventory(Product p, int amount) => this.data.UpdateInventory(p, amount);
        #endregion

        #region shop actions
        // buy an item -> creates an invoice, updates inventory
        public void BuyItem(User user, Product product, int amount)
        {
            if (ProductExists(product) && ProductExistsinInventory(product))
            {
                CreateEvent(user, product, DateTimeOffset.Now);
                UpdateInventory(product, amount);
            }
        }
        #endregion
    }
}
