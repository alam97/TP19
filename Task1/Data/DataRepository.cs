using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataRepository
    {
        private DataContext context;

        public DataRepository()
        {
            this.context = new DataContext();
        }

        //public DataRepository(DataFill dataFill)
        //{
        //   this.context = new DataContext(dataFill);
        //}

        #region User
        public void AddUser(User user)
        {
            if (context.users.Contains(user))
            {
                throw new Exception("Such an user already exists");
            }
            context.users.Add(user);
        }

        public User GetUser(int id)
        {
            foreach (var u in context.users)
            {
                if (u.UserID == id)
                {
                    return u;
                }
            }
            throw new Exception("No such an user");
        }

        public IReadOnlyList<User> GetAllUsers()
        {
            return context.users;
        }

        public void DeleteUser(User user)
        {
            if (context.users.Contains(user))
            {
                context.users.Remove(user);
            }
            throw new Exception("Such an user does not exist!");
        }
        #endregion

        #region Event
        public void AddEvent(Event e)
        {
            context.events.Add(e);
        }

        public Event GetEvent(int id)
        {
            return context.events[id];
        }

        public IReadOnlyList<Event> GetAllEvents()
        {
            return context.events;
        }

        public void DeleteEvent(Event e)
        {
            context.events.Remove(e);
        }
        #endregion

        #region Product
    
        public void AddProduct(Product p)
        {
            context.catalog.Add(p);
        }

        public Boolean ProductExists(Product p)
        {
            return context.catalog.Contains(p);
        }

        public Product GetProduct(int id)
        {
           foreach ( var p in context.catalog)
            {
                if (p.ProductID == id)
                {
                    return p;
                }
            }
            throw new Exception("No product with such an id");
        }
        public IReadOnlyList<Product> GetAllProducts()
        {
            return context.catalog;
        }
        public void DeleteProduct(Product p)
        {
          if (context.catalog.Contains(p))
            {
                context.catalog.Remove(p);
            }
            throw new Exception("No such a product exists");
        }

        #endregion

        #region Inventory

        public Boolean ProductExistsinInventory(Product p)
        {
            return context.inventory.ContainsKey(p);
        }
        
        public IReadOnlyDictionary<Product,int> GetInventory()
        {
            return context.inventory;
        }

        public void DeleteFromInventory(Product p)
        {
            if (ProductExistsinInventory(p))
            {
                context.inventory.Remove(p);
            }
            throw new Exception("No such product in inventory!");
        }
        public void UpdateInventory(Product p, int amount)
        {
            if (ProductExistsinInventory(p))
            {
                context.inventory[p] -= amount;
            }
        }
        #endregion
    }
}
