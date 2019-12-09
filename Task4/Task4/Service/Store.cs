using System.Data;
using System;
using System.Linq;
using Data;

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
        public void AddPerson(Person p)
        {
            db.Persons.InsertOnSubmit(p);
            db.SubmitChanges();

        }
        public void AddProduct(Product p)
        {
            db.Products.InsertOnSubmit(p);
            db.SubmitChanges();

        }
        public void AddEvent(Event e)
        {
            db.Events.InsertOnSubmit(e);
            db.SubmitChanges();

        }
        public void AddToInventory(Inventory inventory)
        {
            db.Inventories.InsertOnSubmit(inventory);
            db.SubmitChanges();
        }
        #endregion

        #region create
        public void CreateUser(string firstName, string lastName, int userId)
        {
            Person person = new Person()
            {
                Id = userId,
                FirstName = firstName,
                LastName = lastName
            };
            AddPerson(person);
        }
        public void CreateProduct(string productName, double productPrice, int productId)
        {
            Product product = new Product()
            {
                Id = productId,
                Name = productName,
                Price = (decimal)productPrice
            };
            AddProduct(product);
        }

        public void CreateEvent(Person user, Product catalog, DateTimeOffset date)
        {
            Event ewent = new Event()
            {
                PersonId = user.Id,
                ProductId = catalog.Id,
                EventDate = date
            };
            AddEvent(ewent);
        }
        #endregion

        #region delete
        public void DeleteUser(Person u)
        {
            var deletePerson =
                from person in db.Persons
                where person.Id == u.Id
                select person;

            if (deletePerson.Count() > 0)
            {
                db.Persons.DeleteOnSubmit(deletePerson.First());
                db.SubmitChanges();

            }
        }
        public void DeleteProduct(Product p)
        {
            var deleteProduct =
                from product in db.Products
                where product.Id == p.Id
                select product;

            if (deleteProduct.Count() > 0)
            {
                db.Products.DeleteOnSubmit(deleteProduct.First());
                db.SubmitChanges();

            }
        }
        public void DeleteEvent(Event e)
        {

            var deleteEvent =
               from ewent in db.Events
               where ewent.Id == e.Id
               select ewent;

            if (deleteEvent.Count() > 0)
            {
                db.Events.DeleteOnSubmit(deleteEvent.First());
                db.SubmitChanges();
            }
        }

        #endregion

        #region update
        public void UpdateInventory(Product p, int amount)
        {
            var query =
                from inventory in db.Inventories
                where inventory.ProductId == p.Id
                select inventory;

            foreach (Inventory inv in query)
            {
                inv.amount = inv.amount - amount;
            }
            db.SubmitChanges();
        }
        #endregion

        #region exists
        public Boolean ProductExists(Product p)
        {
            var query =
                from product in db.Products
                where product.Id == p.Id
                select product;

            if (query.Count() > 0)
                return true;
            else
                return false;
        }
        public Boolean UserExists(Person p)
        {
            var query =
                from person in db.Persons
                where person.Id == p.Id
                select person;

            if (query.Count() > 0)
                return true;
            else
                return false;
        }
        public Boolean ProductExistsinInventory(Product p)
        {
            var query =
               from inventory in db.Inventories
               where inventory.ProductId == p.Id
               select inventory;

            if (query.Count() > 0)
                return true;
            else
                return false;
        }
        #endregion

        #region shop actions
        // buy an item -> creates an invoice, updates inventory
        public void BuyItem(Person user, Product product, int amount)
        {
            CreateEvent(user, product, DateTime.Today);
            UpdateInventory(product, amount);
        }

        #endregion
    }
}
