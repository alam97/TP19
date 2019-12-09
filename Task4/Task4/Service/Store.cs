using System.Data;
using System;
using System.Linq;
using Data;
using System.Collections.ObjectModel;

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
        public void AddToInventory(Product p, int a)
        {
            Inventory inventory = new Inventory()
            {
                ProductId = p.Id,
                amount = a
            };
            db.Inventories.InsertOnSubmit(inventory);
            db.SubmitChanges();
        }
        #endregion

        // C.R.U.D.

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

        #region read

        public int GetAmountOfProduct(Product p)
        {
            var query =
                from inventory in db.Inventories
                where inventory.ProductId == p.Id
                select inventory;
            if (query.Count() > 0)
                return (int)query.First().amount;
            else
                throw new Exception("This product does not exist in inventory");
        }

        public ObservableCollection<Person> GetPersons(String search)
        {
            var result = (from p in db.Persons
                          where p.FirstName.Contains(search)
                          || p.LastName.Contains(search)
                          select p);

            ObservableCollection<Person> people = new ObservableCollection<Person>(result);
            return people;
        }

        public ObservableCollection<Person> GetAllPersons()
        {
            var result = (from p in db.Persons
                          select p);
            ObservableCollection<Person> people = new ObservableCollection<Person>(result);
            return people;
        }

        public ObservableCollection<Product> GetProducts(String search)
        {
            var result = (from p in db.Products
                          where p.Name.Contains(search)
                          select p);

            ObservableCollection<Product> products = new ObservableCollection<Product>(result);
            return products;
        }

        public ObservableCollection<Product> GetAllProducts()
        {
            var result = (from p in db.Products
                          select p);
            ObservableCollection<Product> products = new ObservableCollection<Product>(result);
            return products;
        }


        #endregion

        #region update
        public void UpdateInventory(Product p, int amount)
        {
            var query =
                from inventory in db.Inventories
                where inventory.ProductId == p.Id
                select inventory;
            if (query.Count() > 0)
            {
                foreach (Inventory inv in query)
                {
                    inv.amount = inv.amount - amount;
                }
                db.SubmitChanges();
            }
            else
            {
                throw new Exception("This product does not exist in inventory");
            }
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
            else
            {
                throw new Exception("There is no such user");
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
            else
            {
                throw new Exception("There is no such product");
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
            else
            {
                throw new Exception("There is no such event");
            }
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
            if (GetAmountOfProduct(product) < amount)
                throw new Exception("There is not enough of this product in inventory");
            else
            {
                CreateEvent(user, product, DateTime.Today);
                UpdateInventory(product, amount);
            }
         
        }

        #endregion
    }
}
