using System.Data;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using Task4;

namespace Services
{
    public class Store
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
            AddToInventory(p, 0);
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

        #region exists
        public Boolean ProductExists(int Id)
        {
            var query =
                from product in db.Products
                where product.Id == Id
                select product;

            if (query.Count() > 0)
                return true;
            else
                return false;
        }
        public Boolean UserExists(int Id)
        {
            var query =
                from person in db.Persons
                where person.Id == Id
                select person;

            if (query.Count() > 0)
                return true;
            else
                return false;
        }
        public Boolean ProductExistsinInventory(int Id)
        {
            var query =
               from inventory in db.Inventories
               where inventory.ProductId == Id
               select inventory;

            if (query.Count() > 0)
                return true;
            else
                return false;
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

        public void CreateEvent(int user, int catalog, DateTimeOffset date)
        {
            Event ewent = new Event()
            {
                PersonId = user,
                ProductId = catalog,
                EventDate = date
            };
            AddEvent(ewent);
        }
        #endregion

        #region read

        public int GetAmountOfProduct(int p)
        {
            var query =
                from inventory in db.Inventories
                where inventory.ProductId == p
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

        public ObservableCollection<Event> GetEvents(int search)
        {
            var result = (from e in db.Events
                          where e.Id == search
                          select e);
            ObservableCollection<Event> events = new ObservableCollection<Event>(result);
            return events;
        }

        public ObservableCollection<Event> GetAllEvents()
        {
            var result = (from e in db.Events
                          select e);
            ObservableCollection<Event> events = new ObservableCollection<Event>(result);
            return events;
        }

        #endregion

        #region update
        public void UpdateInventory(int p, int amount)
        {
            var query =
                from inventory in db.Inventories
                where inventory.ProductId == p
                select inventory;
            if (query.Count() > 0)
            {
                foreach (Inventory inv in query)
                {
                    inv.amount = inv.amount + amount;
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
        public void DeleteUser(Person p)
        {
            var deletePerson =
                from person in db.Persons
                where person.Id == p.Id
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

        public void RemoveFromInventory(Product p)
        {
            var query =
                from inventory in db.Inventories
                where inventory.ProductId == p.Id
                select inventory;
            if (query.Count() > 0)
            {
                db.Inventories.DeleteOnSubmit(query.First());

            }
            else
            {
                throw new Exception("This product does not exist in inventory");
            }
        }

        #endregion

        #region shop actions
        // buy an item -> creates an invoice, updates inventory
        public void BuyItem(int user, int product, int amount)
        {
            if (GetAmountOfProduct(product) < amount)
                throw new Exception("There is not enough of this product in inventory");
            else
            {
                CreateEvent(user, product, DateTime.Today);
                UpdateInventory(product, -amount);
            }
         
        }

        #endregion
    }
}
